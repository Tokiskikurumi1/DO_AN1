using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;
using DAL.Button_form;
using DTO_DA;

namespace BLL.BLL
{
    public class QuanLyNhanVIen
    {
        Quan_ly_nhan_vien qly_nv = new Quan_ly_nhan_vien();

        //=============================================================
        //======================QUẢN LÝ NHÂN VIÊN======================
        //=============================================================

        //LOAD DGV QUẢN LÝ NHÂN VIÊN
        public DataTable dgv_nhanvien()
        {
            return qly_nv.load_NV();
        }

        //LOAD CCB VAI TRÒ
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
            //hàm này bỏ đi cũng được
            if (so_dt.Length > 10 || so_dt.Length <= 9 || so_dt.Any(char.IsLetter))
            {
                errorMessage = "Số điện thoại không hợp lệ \n (yêu cầu có 10 chữ số và không có ký tự chữ cái!)";
                return false;
            }
            //hàm này nữa
            if (so_dt.Contains(" "))
            {
                errorMessage = "Số điện thoại không được chứa ký tự khoảng cách!";
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

            if (!check_textbox(tai_khoan) || !check_textbox(mat_khau))
            {
                errorMessage = "Tài khoản và mật khẩu không được chứa khoảng cách!";
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

            if (so_dt.Contains(" "))
            {
                errorMessage = "Số điện thoại không được chứa khoảng cách!";
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

            if (!check_textbox(tai_khoan) || !check_textbox(mat_khau))
            {
                errorMessage = "Tài khoản và mật khẩu không được chứa ký tự có dấu!";
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

        // TÌM KIẾM NHÂN VIÊN
        public DataTable TimKiem_NV(string name)
        {
            return qly_nv.Tim_kiem(name);
        }


        //KIỂM TRA DẤU TÀI KHOẢN VÀ MẬT KHẨU 
        public bool check_textbox(string input)
        {
            // Không dấu, không khoảng trắng
            return Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
        }
    }
}
