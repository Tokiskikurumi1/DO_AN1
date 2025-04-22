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
        public DataTable GetChiTietHoaDon(int maHoaDon)
        {
            try
            {
                KetNoi();
                string sqlChiTiet = "SELECT m.id, m.ten, ct.soluong, ct.gia " +
                                   "FROM menu m " +
                                   "INNER JOIN chitiethoadon ct ON m.id = ct.idmenu " +
                                   "INNER JOIN hoadon hd ON hd.mahoadon = ct.mahoadon " +
                                   "WHERE hd.mahoadon = '" + maHoaDon + "'";

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
        public bool XoaHoaDon(int id)
        {
            try
            {
                KetNoi();
                dt = new DataTable();
                cmd = new SqlCommand();
                cmd.CommandText = $"delete from hoadon where mahoadon = {id}";
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

        public bool CheckMHD(int id)
        {
            KetNoi();
            string query = $"SELECT COUNT(*) FROM hoadon WHERE mahoadon =  {id}"; // Giả sử cột là "id"
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
                string sqlThongKe = @"SELECT mahoadon, ngaytao, hinhthuc, tinhtrang, tongtien
                                    FROM hoadon
                                    WHERE ngaytao BETWEEN @tuNgay AND @denNgay";
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

        public DataTable LayDuLieuInHoaDon(int maHoaDon)
        {
            try
            {
                KetNoi();
                string sql = "SELECT m.id, m.ten, ct.soluong, ct.gia " +
                            "FROM menu m " +
                            "INNER JOIN chitiethoadon ct ON m.id = ct.idmenu " +
                            "INNER JOIN hoadon hd ON hd.mahoadon = ct.mahoadon " +
                            "WHERE hd.mahoadon = '" + maHoaDon + "'";

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
