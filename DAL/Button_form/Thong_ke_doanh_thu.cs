using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Button_form
{
    public class Thong_ke_doanh_thu:Main_SQL
    {
        public Thong_ke_doanh_thu()
        {

        }
        public DataTable Load_Thong_ke()
        {
            string sql = "select bill_ID, day_creation, form, total_bill from bill";
            cmd = new SqlCommand(sql, conn);
            dt = new DataTable();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public DataTable Thongketheongay(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT bill_ID, day_creation, form, total_bill from bill
                          WHERE day_creation BETWEEN @FromDate AND @ToDate";


            try
            {
                KetNoi();
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy xuất dữ liệu: " + ex.Message);
            }
            finally
            {
                // Đóng và giải phóng tài nguyên thủ công
                if (adapter != null)
                {
                    adapter.Dispose();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return dt;
        }


        public DataTable GetAllInvoices()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT bill_ID, day_creation, form, total_bill from bill";

            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tất cả hóa đơn: " + ex.Message);
            }
            return dt;
        }

        // Lấy hóa đơn theo khoảng thời gian
        public DataTable GetInvoicesByDateRange(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT bill_ID, day_creation, form, total_bill from bill 
                          WHERE day_creation BETWEEN @FromDate AND @ToDate";

            try
            {
                KetNoi();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy hóa đơn theo ngày: " + ex.Message);
            }
            return dt;
        }
    }
}
