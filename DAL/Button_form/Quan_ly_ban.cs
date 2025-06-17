using DTO_DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Button_form
{
    public class Quan_ly_ban:Main_SQL
    {
        DTO dto = new DTO();
        public int Dem_ban()
        {
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM list_table";
                SqlCommand cmd = new SqlCommand(query, conn);
                return (int)cmd.ExecuteScalar();
            }
        }

        //LẤY DANH SÁCH BÀN 
        public List<(int idban, string tenban, string trangthai)> GetAllTables()
        {
            List<(int table_ID, string table_name, string table_status)> tables = new List<(int, string, string)>();
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                conn.Open();
                string query = "SELECT * FROM list_table";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tables.Add((reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
            }
            return tables;
        }
        // THÊM BÀN 
        public void AddTable(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                conn.Open();
                string query = "INSERT INTO list_table (table_name, table_status) VALUES (@tenban, N'Trống')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tenban", tableName);
                cmd.ExecuteNonQuery();
            }
        }
        //XÓA BÀN
        public void RemoveLastTable()
        {
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                conn.Open();

                // Tìm ID bàn lớn nhất
                string getMaxIdQuery = "SELECT MAX(table_ID) FROM list_table";
                SqlCommand getMaxIdCmd = new SqlCommand(getMaxIdQuery, conn);
                object result = getMaxIdCmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    int maxId = Convert.ToInt32(result);

                    // Xóa bàn có ID lớn nhất
                    string deleteQuery = "DELETE FROM list_table WHERE table_ID = @maxId";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                    deleteCmd.Parameters.AddWithValue("@maxId", maxId);
                    deleteCmd.ExecuteNonQuery();

                    // Reset lại IDENTITY về ID lớn nhất vừa xóa
                    string reseedQuery = $"DBCC CHECKIDENT ('list_table', RESEED, {maxId - 1})";
                    SqlCommand reseedCmd = new SqlCommand(reseedQuery, conn);
                    reseedCmd.ExecuteNonQuery();
                }
            }

        }

        //ĐẶT BÀN 

        public int DatBan(int idban, int tongtien)
        {
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                try
                {
                    conn.Open();

                    // Bước 1: Kiểm tra trạng thái bàn
                    string sqlCheckBan = $"SELECT table_status FROM list_table WHERE table_ID = {idban}";
                    SqlCommand cmdCheck = new SqlCommand(sqlCheckBan, conn);
                    string tableStatus = cmdCheck.ExecuteScalar()?.ToString();

                    if (tableStatus == "Có người")
                    {
                        return -1; // Bàn đã có người, không thể đặt
                    }

                    // Bước 2: Thêm hóa đơn mới
                    string sqlHoadon = "SELECT * FROM bill";
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlHoadon, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataRow newRow = dt.NewRow();
                    newRow["day_creation"] = DateTime.Now;
                    newRow["form"] = 0;
                    newRow["bill_status"] = 0;
                    newRow["table_ID"] = idban;
                    newRow["total_bill"] = tongtien;

                    dt.Rows.Add(newRow);

                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update(dt);

                    // Bước 3: Lấy mã hóa đơn vừa thêm
                    int mahoadon;
                    if (newRow["bill_ID"] != DBNull.Value)
                    {
                        mahoadon = Convert.ToInt32(newRow["bill_ID"]);
                    }
                    else
                    {
                        string sql = "SELECT IDENT_CURRENT('bill') AS LastID";
                        cmd = new SqlCommand(sql, conn);
                        mahoadon = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Bước 4: Cập nhật trạng thái bàn
                    string sqlBan = $"UPDATE list_table SET table_status = N'Có người' WHERE table_ID = {idban}";
                    cmd = new SqlCommand(sqlBan, conn);
                    cmd.ExecuteNonQuery();

                    //Thêm chi tiết hóa đơn
                    string sqlChitiet = "SELECT * FROM detail_bill";
                    adapter = new SqlDataAdapter(sqlChitiet, conn);
                    dt = new DataTable();
                    adapter.Fill(dt);

                    return mahoadon; // Thành công
                }
                catch (Exception)
                {
                    return -2; // Lỗi
                }
            }
        }


        // LƯU CHI TIẾT HÓA ĐƠN
        public void LuuChiTietHoaDon(int mahoadon, List<DTO.ChiTietHoaDon> chiTietHoaDons)
        {
            try
            {
                string sqlChitiet = "SELECT * FROM detail_bill";
                adapter = new SqlDataAdapter(sqlChitiet, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (var item in chiTietHoaDons)
                {
                    DataRow newDetailRow = dt.NewRow();
                    newDetailRow["bill_ID"] = mahoadon;
                    newDetailRow["ID_dish"] = item.IdMenu;
                    newDetailRow["quantity"] = item.SoLuong;
                    newDetailRow["price"] = item.Gia;

                    dt.Rows.Add(newDetailRow);
                }

                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lưu chi tiết hóa đơn: " + ex.Message);
            }
        }

        public DataTable hienthiban(int idban)
        {
            string sqlChiTiet = $@"
                SELECT ct.ID_dish, m.dish_name, ct.quantity, (ct.quantity * m.price) as gia
                FROM list_table b
                INNER JOIN bill hd ON b.table_ID = hd.table_ID
                INNER JOIN detail_bill ct ON ct.bill_ID = hd.bill_ID
                INNER JOIN menu m ON m.ID_dish = ct.ID_dish
                WHERE b.table_ID = {idban} AND hd.bill_status = '0'";


            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sqlChiTiet;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            return dt;
        }

        public int ThanhToanBan(int idban)
        {
            if (idban == -1)
            {
                return -1;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(chuoikn)) // Tự động đóng kết nối
                {
                    conn.Open();

                    //kiểm tra trạng thái của bàn
                    string queryBan = $"SELECT * FROM list_table WHERE table_ID = {idban}";
                    DataTable dtBan = new DataTable();
                    SqlDataAdapter adapterBan = new SqlDataAdapter(queryBan, conn);
                    SqlCommandBuilder builderBan = new SqlCommandBuilder(adapterBan);
                    adapterBan.Fill(dtBan);

                    if (dtBan.Rows.Count > 0) //kiểm tra xem có dữ liệu trả về hay không 
                    {
                        DataRow rowBan = dtBan.Rows[0];// gán bàn vừa tìm được
                        if (rowBan["table_status"].ToString() == "Trống")
                        {
                            // Nếu bàn trống, thông báo không có hóa đơn
                            return -1; // Dừng thực hiện nếu bàn trống
                        }
                    }

                    //kiểm tra hóa đơn chưa thanh toán
                    string queryHoaDon = $"SELECT * FROM bill WHERE table_ID = {idban} AND bill_status = '0'";
                    DataTable dtHoaDon = new DataTable();
                    SqlDataAdapter adapterHoaDon = new SqlDataAdapter(queryHoaDon, conn);
                    SqlCommandBuilder builderHoaDon = new SqlCommandBuilder(adapterHoaDon);
                    adapterHoaDon.Fill(dtHoaDon);

                    int idHoaDon = -1;

                    // Nếu có hóa đơn chưa thanh toán, cập nhật trạng thái
                    if (dtHoaDon.Rows.Count > 0)
                    {
                        DataRow rowHoaDon = dtHoaDon.Rows[0];
                        rowHoaDon["bill_status"] = "1"; // Đánh dấu hóa đơn là đã thanh toán
                        adapterHoaDon.Update(dtHoaDon); // Cập nhật vào cơ sở dữ liệu

                        // Lấy mã hóa đơn
                        idHoaDon = Convert.ToInt32(rowHoaDon["bill_ID"]);
                    }

                    //cập nhật trạng thái bàn
                    if (dtBan.Rows.Count > 0)
                    {
                        DataRow rowBan = dtBan.Rows[0];
                        rowBan["table_status"] = "Trống"; // Đánh dấu bàn là trống
                        adapterBan.Update(dtBan); // Cập nhật vào cơ sở dữ liệu
                    }

                    // TRẢ VỀ MÃ HÓA ĐƠN ĐỂ HIỂN THỊ FORM QR
                    if (idHoaDon != -1)
                    {
                        return idHoaDon; // Trả về mã hóa đơn
                    }

                    else
                    {
                        return -2; // Không có hóa đơn nào chưa thanh toán
                    }
                        
                }
                //// Thông báo thành công

                //return idban;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }
    }
}
