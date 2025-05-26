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
using System.Data.SqlClient;

namespace BLL.BLL
{
    public class QuanLyMenu
    {
        private readonly IQuanLyMenuDal qlymenu;

        public QuanLyMenu() : this(new Quan_ly_menu())
        {
        }

        public QuanLyMenu(IQuanLyMenuDal quanLyMenu)
        {
            qlymenu = quanLyMenu;
        }

        //LOAD DGV THEO DANH MỤC 
        public DataTable loadDM(char maDM)
        {
            return qlymenu.dboloadDM(maDM);
        }

        // LOAD DGV MENU
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
        public bool XoaMon(int id, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!qlymenu.CheckIdExists(id))
            {
                errorMessage = "ID này không tồn tại trong menu!";
                return false;
            }

            return qlymenu.XoaMenu(id);
        }

        //TÌM MÓN ĂN
        public DataTable Search(string name_table, string name)
        {
            return qlymenu.dboSearch(name);
        }

        //LOAD CCB DANH MỤC MENU
        public DataTable loadCCB()
        {
            return qlymenu.GetDanhMuc();
        }
        public DataTable search(string name)
        {
            return qlymenu.searchs_tt(name);
        }
    }
}
