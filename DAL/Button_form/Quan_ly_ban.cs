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
                string query = "SELECT COUNT(*) FROM ban";
                SqlCommand cmd = new SqlCommand(query, conn);
                return (int)cmd.ExecuteScalar();
            }
        }

        public List<(int idban, string tenban, string trangthai)> GetAllTables()
        {
            List<(int idban, string tenban, string trangthai)> tables = new List<(int, string, string)>();
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                conn.Open();
                string query = "SELECT idban, tenban, trangthai FROM ban";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tables.Add((reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
            }
            return tables;
        }

        public void AddTable(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                conn.Open();
                string query = "INSERT INTO ban (tenban, trangthai) VALUES (@tenban, N'Trống')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tenban", tableName);
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveLastTable()
        {
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                conn.Open();

                // Tìm ID bàn lớn nhất
                string getMaxIdQuery = "SELECT MAX(idban) FROM ban";
                SqlCommand getMaxIdCmd = new SqlCommand(getMaxIdQuery, conn);
                object result = getMaxIdCmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    int maxId = Convert.ToInt32(result);

                    // Xóa bàn có ID lớn nhất
                    string deleteQuery = "DELETE FROM ban WHERE idban = @maxId";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                    deleteCmd.Parameters.AddWithValue("@maxId", maxId);
                    deleteCmd.ExecuteNonQuery();

                    // Reset lại IDENTITY về ID lớn nhất vừa xóa
                    string reseedQuery = $"DBCC CHECKIDENT ('ban', RESEED, {maxId - 1})";
                    SqlCommand reseedCmd = new SqlCommand(reseedQuery, conn);
                    reseedCmd.ExecuteNonQuery();
                }
            }

        }

        //

        public int DatBan(int idban, int tongtien)
        {
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                try
                {
                    conn.Open();

                    // Bước 1: Kiểm tra trạng thái bàn
                    string sqlCheckBan = $"SELECT trangthai FROM ban WHERE idban = {idban}";
                    SqlCommand cmdCheck = new SqlCommand(sqlCheckBan, conn);
                    string tableStatus = cmdCheck.ExecuteScalar()?.ToString();

                    if (tableStatus == "Có người")
                    {
                        return -1; // Bàn đã có người, không thể đặt
                    }

                    // Bước 2: Thêm hóa đơn mới
                    string sqlHoadon = "SELECT * FROM hoadon";
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlHoadon, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataRow newRow = dt.NewRow();
                    newRow["ngaytao"] = DateTime.Now;
                    newRow["hinhthuc"] = 0;
                    newRow["tinhtrang"] = 0;
                    newRow["idban"] = idban;
                    newRow["tongtien"] = tongtien;

                    dt.Rows.Add(newRow);

                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update(dt);

                    // Bước 3: Lấy mã hóa đơn vừa thêm
                    int mahoadon;
                    if (newRow["mahoadon"] != DBNull.Value)
                    {
                        mahoadon = Convert.ToInt32(newRow["mahoadon"]);
                    }
                    else
                    {
                        string sql = "SELECT IDENT_CURRENT('hoadon') AS LastID";
                        cmd = new SqlCommand(sql, conn);
                        mahoadon = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Bước 4: Cập nhật trạng thái bàn
                    string sqlBan = $"UPDATE ban SET trangthai = N'Có người' WHERE idban = {idban}";
                    cmd = new SqlCommand(sqlBan, conn);
                    cmd.ExecuteNonQuery();

                    //Thêm chi tiết hóa đơn
                    string sqlChitiet = "SELECT * FROM chitiethoadon";
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
                string sqlChitiet = "SELECT * FROM chitiethoadon";
                adapter = new SqlDataAdapter(sqlChitiet, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (var item in chiTietHoaDons)
                {
                    DataRow newDetailRow = dt.NewRow();
                    newDetailRow["mahoadon"] = mahoadon;
                    newDetailRow["idmenu"] = item.IdMenu;
                    newDetailRow["soluong"] = item.SoLuong;
                    newDetailRow["gia"] = item.Gia;

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
                SELECT ct.idmenu, m.ten, ct.soluong, (ct.soluong * m.gia) as gia
                FROM ban b
                INNER JOIN hoadon hd ON b.idban = hd.idban
                INNER JOIN chitiethoadon ct ON ct.mahoadon = hd.mahoadon
                INNER JOIN menu m ON m.id = ct.idmenu
                WHERE b.idban = {idban} AND hd.tinhtrang = '0'";


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
                    string queryBan = $"SELECT * FROM ban WHERE idban = {idban}";
                    DataTable dtBan = new DataTable();
                    SqlDataAdapter adapterBan = new SqlDataAdapter(queryBan, conn);
                    SqlCommandBuilder builderBan = new SqlCommandBuilder(adapterBan);
                    adapterBan.Fill(dtBan);

                    if (dtBan.Rows.Count > 0) //kiểm tra xem có dữ liệu trả về hay không 
                    {
                        DataRow rowBan = dtBan.Rows[0];// gán bàn vừa tìm được
                        if (rowBan["trangthai"].ToString() == "Trống")
                        {
                            // Nếu bàn trống, thông báo không có hóa đơn
                            return -1; // Dừng thực hiện nếu bàn trống
                        }
                    }

                    //kiểm tra hóa đơn chưa thanh toán
                    string queryHoaDon = $"SELECT * FROM hoadon WHERE idban = {idban} AND tinhtrang = '0'";
                    DataTable dtHoaDon = new DataTable();
                    SqlDataAdapter adapterHoaDon = new SqlDataAdapter(queryHoaDon, conn);
                    SqlCommandBuilder builderHoaDon = new SqlCommandBuilder(adapterHoaDon);
                    adapterHoaDon.Fill(dtHoaDon);

                    // Nếu có hóa đơn chưa thanh toán, cập nhật trạng thái
                    if (dtHoaDon.Rows.Count > 0)
                    {
                        DataRow rowHoaDon = dtHoaDon.Rows[0];
                        rowHoaDon["tinhtrang"] = "1"; // Đánh dấu hóa đơn là đã thanh toán
                        adapterHoaDon.Update(dtHoaDon); // Cập nhật vào cơ sở dữ liệu
                    }

                    //cập nhật trạng thái bàn
                    if (dtBan.Rows.Count > 0)
                    {
                        DataRow rowBan = dtBan.Rows[0];
                        rowBan["trangthai"] = "Trống"; // Đánh dấu bàn là trống
                        adapterBan.Update(dtBan); // Cập nhật vào cơ sở dữ liệu
                    }
                }
                // Thông báo thành công
                return idban;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }
    }
}
