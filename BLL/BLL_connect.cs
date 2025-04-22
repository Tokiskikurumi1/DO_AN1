using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Button_form;
using DTO_DA;
namespace BLL
{
    public class BLL_connect
    {
        Login lg = new Login();
        Trang_chu tc = new Trang_chu();
        Quan_ly_ban qlb = new Quan_ly_ban();
        Quan_ly_menu qlymenu = new Quan_ly_menu();
        Quan_ly_hoa_don qlyhoadon = new Quan_ly_hoa_don();
        Quan_ly_nhan_vien qly_nv = new Quan_ly_nhan_vien();

        //=========================================================
        //===================ĐĂNG NHẬP=============================
        //=========================================================

        public bool Login(string username, string password, out int role_ID)
        {
            role_ID = lg.kiem_tra(username, password);
            return role_ID != -1; // Trả về true nếu đăng nhập thành công
        }
        //=========================================================
        //=========================================================

        // LOAD DATAGIRDVIEW TRANG 
        public DataTable trang_chu(string name_table)
        {
            return tc.load_menu(name_table);
        }

        //TÌM KIẾM MENU TRANG CHỦ
        public DataTable search(string name)
        {
            return tc.searchs_tt(name);
        }
        // QUẢN LÝ BÀN

        public int GetTableCount()
        {
            return qlb.Dem_ban();
        }

        public List<(int idban, string tenban, string trangthai)> GetAllTables()
        {
            return qlb.GetAllTables();
        }
        public int thanhtoanban(int idban)
        {
            return qlb.ThanhToanBan(idban);
        }
        public void AddTable()
        {
            int currentCount = GetTableCount() + 1;
            string tableName = $"Bàn {currentCount}";
            qlb.AddTable(tableName);
        }

        public void RemoveTable()
        {
            if (GetTableCount() > 0)
            {
                qlb.RemoveLastTable();
            }
            else
            {
                throw new Exception("Không còn bàn để xóa!");
            }
        }

        public int DatBan(int idban, int tongtien)
        {
            return qlb.DatBan(idban, tongtien);
        }

        public void LuuChiTiet(int mahoadon, List<DTO.ChiTietHoaDon> chitiet)
        {
            qlb.LuuChiTietHoaDon(mahoadon, chitiet);
        }

        public int ThanhToanHoaDon(int tongtien)
        {
            return tc.ThanhToanHoaDon(tongtien);
        }

        public DataTable hienthiban(int idban)
        {
            return qlb.hienthiban(idban);
        }

        public int thanhtoan(int idban)
        {
            return qlb.ThanhToanBan(idban);
        }

        public DataTable loadDM(char maDM)
        {
            return qlymenu.dboloadDM(maDM);
        }
        public DataTable quanlymenuload()
        {
            return qlymenu.load_menu();
        }

        //THÊM MÓN VÀO MENU
        public bool ThemMonAn(int id, string name, int gia, string maDanhMuc, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                errorMessage = "Tên không được để trống!";
                return false;
            }

            if (qlymenu.CheckIdExists(id))
            {
                errorMessage = "ID này đã tồn tại. Vui lòng chọn ID khác.";
                return false;
            }

            if (gia <= 0)
            {
                errorMessage = "Giá phải lớn hơn 0!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(maDanhMuc) || maDanhMuc == "Chọn danh mục")
            {
                errorMessage = "Vui lòng chọn 1 danh mục!";
                return false;
            }

            return qlymenu.ThemMon(id, name, gia, maDanhMuc);
        }
        //

        //SỬA MÓN TRONG MENU
        public bool SuaMonAn(int id, string name, int gia, string maDanhMuc, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                errorMessage = "Tên không được để trống!";
                return false;
            }

            if (!qlymenu.CheckIdExists(id))
            {
                errorMessage = "ID này không tồn tại trong menu!";
                return false;
            }

            if (gia <= 0)
            {
                errorMessage = "Giá phải lớn hơn 0!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(maDanhMuc) || maDanhMuc == "Chọn danh mục")
            {
                errorMessage = "Vui lòng chọn 1 danh mục!";
                return false;
            }

            return qlymenu.SuaMenu(id, name, gia, maDanhMuc);
        }
        //XÓA MÓN TRONG MENU
        public bool XoaMon(string name_table, int id, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!qlymenu.CheckIdExists(id))
            {
                errorMessage = "ID này không tồn tại trong menu!";
                return false;
            }

            return qlymenu.XoaMenu(name_table, id);
        }

        //TÌM MÓN ĂN
        public DataTable Search(string name_table,string name)
        {
            return tc.dboSearch(name);
        }
        public DataTable loadCCB()
        {
            return qlymenu.GetDanhMuc();
        }

        public DataTable GetChiTietHoaDon(int maHoaDon)
        {
            try
            {
                return qlyhoadon.GetChiTietHoaDon(maHoaDon);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xử lý chi tiết hóa đơn: " + ex.Message);
            }
        }
        //

        public DataTable chitietHD(int maHoaDon)
        {
            try
            {
                DataTable dt = qlyhoadon.GetChiTietHoaDon(maHoaDon);
                return dt; // Có thể thêm logic xử lý dữ liệu ở đây nếu cần
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xử lý chi tiết hóa đơn: " + ex.Message);
            }
        }
        public DataTable loadtong(string name_table)
        {
            return qlymenu.dboload(name_table);
        }

        public DataTable GetDuLieuInHoaDon(int maHoaDon)
        {
            try
            {
                DataTable dt = qlyhoadon.LayDuLieuInHoaDon(maHoaDon);
                return dt; // Có thể thêm logic xử lý nếu cần
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xử lý dữ liệu để in hóa đơn: " + ex.Message);
            }
        }
        //=======================================================================================================
        //=======================================================================================================
        // QUẢN LÝ NHÂN VIÊN
        public DataTable dgv_nhanvien()
        {
            return qly_nv.load_NV();
        }

        public DataTable dbocbb_Roles()
        {
            return qly_nv.lay_Roles();
        }

        //THÊM NHÂN VIÊN
        public bool ThemNV(int id, string ten, DateTime ngaysinh, string so_dt, string ca_lam, string tai_khoan, string mat_khau, string chuc_vu, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(ten))
            {
                errorMessage = "Tên không được để trống!";
                return false;
            }

            if (qly_nv.kiemtra_ID(id))
            {
                errorMessage = "ID này đã tồn tại. Vui lòng chọn ID khác.";
                return false;
            }


            int age = DateTime.Now.Year - ngaysinh.Year;
            if (DateTime.Now < ngaysinh.AddYears(age)) age--; // Điều chỉnh nếu chưa đến sinh nhật
            if (age < 18)
            {
                errorMessage = "Nhân viên phải từ 18 tuổi trở lên!";
                return false;
            }

            if (so_dt.Length  > 10 || so_dt.Length <= 9 || so_dt.Any(char.IsLetter))
            {
                errorMessage = "Số điện thoại không hợp lệ \n (yêu cầu có 10 chữ số và không có ký tự chữ cái!)";
                return false;
            }

            if (string.IsNullOrWhiteSpace(ca_lam) || ca_lam == "Chọn ca")
            {
                errorMessage = "Vui lòng chọn ca làm";
                return false;
            }

            if(string.IsNullOrWhiteSpace(tai_khoan) || string.IsNullOrWhiteSpace(mat_khau))
            {
                errorMessage = "Không được để trống tài khoản hoặc mật khẩu!";
                return false;
            }
            if(tai_khoan.Contains(" ") || mat_khau.Contains(" ") || tai_khoan.Length > 30 || mat_khau.Length > 30)
            {
                errorMessage = "Tài khoản và mật khẩu không được nhiều hơn 30 ký tự và không được có khoảng cách!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(chuc_vu) || chuc_vu == "Chọn chức vụ")
            {
                errorMessage = "Vui lòng chọn chức vụ!";
                return false;
            }

            return qly_nv.add_NV(id, ten, ngaysinh, so_dt, ca_lam, tai_khoan, mat_khau, chuc_vu);
        }

        //SỬA NHÂN VIÊN
        public bool SuaNV(int id, string ten, DateTime ngaysinh, string so_dt, string ca_lam, string tai_khoan, string mat_khau, string chuc_vu, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(ten))
            {
                errorMessage = "Tên không được để trống!";
                return false;
            }

            if (!qly_nv.kiemtra_ID(id))
            {
                errorMessage = "ID này không tồn tại!";
                return false;
            }

            int age = DateTime.Now.Year - ngaysinh.Year;
            if (DateTime.Now < ngaysinh.AddYears(age)) age--; // Điều chỉnh nếu chưa đến sinh nhật
            if (age < 18)
            {
                errorMessage = "Nhân viên phải từ 18 tuổi trở lên!";
                return false;
            }

            if (so_dt.Length > 10 || so_dt.Length <= 9 || so_dt.Any(char.IsLetter))
            {
                errorMessage = "Số điện thoại không hợp lệ \n (yêu cầu có 10 chữ số và không có ký tự chữ cái!)";
                return false;
            }

            if (string.IsNullOrWhiteSpace(ca_lam) || ca_lam == "Chọn ca")
            {
                errorMessage = "Vui lòng chọn ca làm";
                return false;
            }

            if (string.IsNullOrWhiteSpace(tai_khoan) || string.IsNullOrWhiteSpace(mat_khau))
            {
                errorMessage = "Không được để trống tài khoản hoặc mật khẩu!";
                return false;
            }
            if (tai_khoan.Contains(" ") || mat_khau.Contains(" ") || tai_khoan.Length > 30 || mat_khau.Length > 30)
            {
                errorMessage = "Tài khoản và mật khẩu không được nhiều hơn 30 ký tự và không được có khoảng cách!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(chuc_vu) || chuc_vu == "Chọn chức vụ")
            {
                errorMessage = "Vui lòng chọn chức vụ!";
                return false;
            }

            return qly_nv.Sua_nv(id, ten, ngaysinh, so_dt, ca_lam, tai_khoan, mat_khau, chuc_vu);
        }

        //XÓA NHÂN VIÊN

        public bool XoaNV(int id, out string Errormess)
        {
            Errormess = string.Empty;

            if (!qly_nv.kiemtra_ID(id))
            {
                Errormess = "Không tồn tại ID để xoá!";
                return false;
            }
            return qly_nv.Xoa_NV(id);
        }

        public DataTable TimKiem_NV(string name)
        {
            return qly_nv.Tim_kiem(name);
        }

        //=======================================================================================================
        //=======================================================================================================

        //THỐNG KÊ HÓA ĐƠN
        public DataTable GetThongKeHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                DataTable dt = qlyhoadon.ThongKeHoaDon(tuNgay, denNgay);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        // Xử lý cột "hinhthuc"
                        if (row[2] != DBNull.Value)
                        {
                            int HoaDon_convert = Convert.ToInt32(row[2]);
                            row[2] = HoaDon_convert == 0 ? "Uống tại quán" : "Mang đi";
                        }

                        // Xử lý cột "tinhtrang"
                        if (row["tinhtrang"] != DBNull.Value)
                        {
                            row["tinhtrang"] = Convert.ToInt32(row["tinhtrang"]) == 0 ? "Chưa thanh toán" : "Đã thanh toán";
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xử lý dữ liệu thống kê: " + ex.Message);
            }
        }

        public bool XoaHD(int id, out string Mess)
        {
            Mess = string.Empty;
            if (!qlyhoadon.CheckMHD(id))
            {
                Mess = "ID này không tồn tại trong hóa đơn!";
                return false;
            }
            return qlyhoadon.XoaHoaDon(id);
        }

        //

        Thong_ke_doanh_thu th_ke = new Thong_ke_doanh_thu();
        public DataTable DGV_Thongke()
        {
            try
            {
                DataTable dt = th_ke.Load_Thong_ke();

                foreach (DataRow row in dt.Rows)
                {
                    if (row[2] != DBNull.Value) // Kiểm tra giá trị không null
                    {
                        int hinhThucValue = Convert.ToInt32(row[2]);
                        row[2] = hinhThucValue == 0 ? "Uống tại quán" : "Mang đi";
                    }
                }

                // Trả về DataTable đã được xử lý
                return dt;
            }
            catch (Exception ex)
            {

            }
            return th_ke.Load_Thong_ke();
        }

        public DataTable ThongKeTheoNgay(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = th_ke.Thongketheongay(fromDate, toDate);

            // Xử lý logic nghiệp vụ: chuyển đổi giá trị hinhthuc
            foreach (DataRow row in dt.Rows)
            {
                // Check and update "hình thức" column
                if (row[2] != DBNull.Value)
                {
                    row[2] = Convert.ToInt32(row[2]) == 0 ? "Uống tại quán" : "Mang đi";
                }
            }
            return dt;
        }

        public DataTable GetAllInvoicesForReport()
        {
            DataTable dt = th_ke.GetAllInvoices();
            return dt;
        }

        // Lấy hóa đơn theo khoảng thời gian cho báo cáo
        public DataTable GetInvoicesByDateRangeForReport(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = th_ke.GetInvoicesByDateRange(fromDate, toDate);
            return dt;
        }
    }
}
