using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Button_form
{
    public class Quan_ly_hoa_don:Main_SQL
    {
        public Quan_ly_hoa_don()
        {

        }
        // XEM CHI TIẾT HÓA ĐƠN 
        public DataTable GetChiTietHoaDon(int maHoaDon)
        {
            try
            {
                KetNoi();
                string sqlChiTiet = "SELECT m.ID_dish, m.dish_name, ct.quantity, ct.price " +
                                   "FROM menu m " +
                                   "INNER JOIN detail_bill ct ON m.ID_dish = ct.ID_dish " +
                                   "INNER JOIN bill hd ON hd.bill_ID = ct.bill_ID " +
                                   "WHERE hd.bill_ID = '" + maHoaDon + "'";

                cmd = new SqlCommand(sqlChiTiet, conn);
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                NgatKn();
                return dt;
            }
            catch (Exception ex)
            {
                NgatKn();
                throw new Exception("Lỗi khi lấy chi tiết hóa đơn: " + ex.Message);
            }
        }
        // XÓA HÓA ĐƠN
        public bool XoaHoaDon(int id)
        {
            try
            {
                KetNoi();
                dt = new DataTable();
                cmd = new SqlCommand();
                cmd.CommandText = $"delete from bill where bill_ID = {id}";
                cmd.Connection = conn;
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                NgatKn();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // LẤY ID HÓA ĐƠN
        public bool CheckMHD(int id)
        {
            KetNoi();
            string query = $"SELECT COUNT(*) FROM bill WHERE bill_ID =  {id}"; // lấy từ cột id ẩn
            cmd = new SqlCommand(query, conn);
            int i = (int)cmd.ExecuteScalar();
            NgatKn();
            return i > 0;
        }

        //Thống kê doanh thu
        public DataTable ThongKeHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                KetNoi();
                string sqlThongKe = @"SELECT bill_ID, day_creation, form, bill_status, total_bill
                                    FROM bill
                                    WHERE day_creation BETWEEN @tuNgay AND @denNgay";
                cmd = new SqlCommand(sqlThongKe, conn);
                cmd.Parameters.AddWithValue("@tuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@denNgay", denNgay);
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                NgatKn();
                return dt;
            }
            catch (Exception ex)
            {
                NgatKn();
                throw new Exception("Lỗi khi lấy dữ liệu thống kê: " + ex.Message);
            }
        }

        // LẤY DỮ LIỆU HÓA ĐƠN
        public DataTable LayDuLieuInHoaDon(int maHoaDon)
        {
            try
            {
                KetNoi();
                string sql = "SELECT m.ID_dish, m.dish_name, ct.quantity, ct.price " +
                            "FROM menu m " +
                            "INNER JOIN detail_bill ct ON m.ID_dish = ct.ID_dish " +
                            "INNER JOIN bill hd ON hd.bill_ID = ct.bill_ID " +
                            "WHERE hd.bill_ID = '" + maHoaDon + "'";

                cmd = new SqlCommand(sql, conn);
                DataTable dt = new DataTable();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                NgatKn();
                return dt;
            }
            catch (Exception ex)
            {
                NgatKn();
                throw new Exception("Lỗi khi lấy dữ liệu để in hóa đơn: " + ex.Message);
            }
        }
    }
}
