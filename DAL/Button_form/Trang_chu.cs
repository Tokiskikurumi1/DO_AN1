using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_DA;
using System.Data.SqlClient;
namespace DAL.Button_form
{
    public class Trang_chu:Main_SQL
    {
        DataTable dt = new DataTable();
        DTO dto = new DTO();
        public Trang_chu()
        {
            conn = new SqlConnection(chuoikn);
        }
        public DataTable load_menu(string name_table)
        {
            dt = dboload(name_table);
            return dt;
        }

        

        //
        public int ThanhToanHoaDon(int tongtien)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(chuoikn))
                {
                    conn.Open();

                    // Bước 1: Thêm hóa đơn mới
                    string sqlHoadon = "SELECT * FROM hoadon";
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlHoadon, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataRow newRow = dt.NewRow();
                    newRow["ngaytao"] = DateTime.Now;
                    newRow["hinhthuc"] = 1;  // Thanh toán ngay, không đặt bàn
                    newRow["tinhtrang"] = 1;  // Đã thanh toán
                    newRow["tongtien"] = tongtien;
                    dt.Rows.Add(newRow);

                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update(dt);
                    int mahoadon;
                    // Bước 2: Lấy mã hóa đơn mới
                    if (newRow["mahoadon"] != DBNull.Value)
                    {
                        mahoadon = Convert.ToInt32(newRow["mahoadon"]);
                    }
                    else
                    {
                        string getmahd = "SELECT IDENT_CURRENT('hoadon') AS LastID";
                        SqlCommand cmdgethd = new SqlCommand(getmahd, conn);
                        mahoadon = Convert.ToInt32(cmdgethd.ExecuteScalar());
                    }

                    // Bước 3: Lưu chi tiết hóa đơn
                    string sqlChitiet = "SELECT * FROM chitiethoadon";
                    adapter = new SqlDataAdapter(sqlChitiet, conn);
                    dt = new DataTable();
                    adapter.Fill(dt);
                    return mahoadon; // Thành công, trả về mã hóa đơn
                }
            }
            catch
            {
                return -1; // Lỗi xảy ra
            }
        }

        // TÌM KIẾM 
        public DataTable searchs_tt(string name)
        {
            return dboSearch(name);
        }

    }
}
