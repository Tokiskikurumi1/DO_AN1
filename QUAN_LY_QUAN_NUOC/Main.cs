using QUAN_LY_QUAN_NUOC.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.Data.SqlClient;
namespace QUAN_LY_QUAN_NUOC
{
    public partial class Main : Form
    {
        private int Quyen_Han;
        BLL_connect bll = new BLL_connect();
        DataTable dt;
        public Main(int quyen_han)
        {
            InitializeComponent();
            this.Quyen_Han = quyen_han;
            kiemtra_quyenhan();
            ShowControl(new Trang_chu());
            hideMenu();

        }

        private void kiemtra_quyenhan()
        {
            if (Quyen_Han == 2)
            {
                btnthongke.Enabled = false;
                btn_Quan_ly_nv.Enabled = false;
                btn_quan_ly_menu.Enabled = false;
            }
        }

        private void btnTrang_chu_Click(object sender, EventArgs e)
        {
            ShowControl(new Trang_chu());
        }


        private void btnqly_Click(object sender, EventArgs e)
        {
            showHide(panel_quanly);
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            showHide(Panel_Thongke);
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ShowControl(UserControl control)
        {
            panel_container.Controls.Clear(); // Xóa control cũ trong panel
            control.Dock = DockStyle.Fill; // Cho UserControl vừa với Panel
            panel_container.Controls.Add(control); // Thêm UserControl vào Panel
            control.BringToFront(); // Đưa lên trên cùng
        }

        private void hideMenu()
        {
            panel_quanly.Visible = false;
            Panel_Thongke.Visible = false;
        }

        private void kiemtra_an()
        {
            if (panel_quanly.Visible == true)
            {
                panel_quanly.Visible = false;
            }
            if (Panel_Thongke.Visible == true)
            {
                Panel_Thongke.Visible = false;
            }
        }

        private void showHide(Panel panel_name)
        {
            if (panel_name.Visible == false)
            {
                panel_name.Visible = true;
            }
            else
            {
                panel_name.Visible = false;
            }
        }


        private void btn_quan_ly_menu_Click(object sender, EventArgs e)
        {
            ShowControl(new Quan_ly_menu());
        }

        private void btn_quan_ly_hoa_don_Click(object sender, EventArgs e)
        {
            Quan_ly_hoa_don qlhd = new Quan_ly_hoa_don(Quyen_Han);
            ShowControl(new Quan_ly_hoa_don(Quyen_Han));
        }

        private void Thong_ke_doanh_thu_Click(object sender, EventArgs e)
        {
            ShowControl(new Thong_ke_doanh_thu());  
        }

        private void btn_Quan_ly_ban_Click(object sender, EventArgs e)
        {
            Quan_Ly_Ban qlb = new Quan_Ly_Ban(Quyen_Han);
            ShowControl(new Quan_Ly_Ban(Quyen_Han));
        }

        private void btn_Quan_ly_nv_Click(object sender, EventArgs e)
        {
            ShowControl(new Quan_ly_nhan_vien());
        }
    }
}
