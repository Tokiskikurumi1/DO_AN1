using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace QUAN_LY_QUAN_NUOC
{
    public partial class Form1 : Form
    {
        BLL_connect blc = new BLL_connect();
        public Form1()
        {
            InitializeComponent();
            txttk.KeyDown += new KeyEventHandler(TextBox_KeyDown);
            txtmk.KeyDown += new KeyEventHandler(TextBox_KeyDown);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDN.PerformClick();
            }
        }


        void check()
        {
            if (sw_check.Checked)
            {
                txtmk.UseSystemPasswordChar = false;
            }
            else
            {
                txtmk.UseSystemPasswordChar = true;
            }
        }

        private void btnDN_Click_1(object sender, EventArgs e)
        {
            string username = txttk.Text;
            string password = txtmk.Text;

            if (blc.Login(username, password, out int role_ID))
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo");
                Main main = new Main(role_ID);
                this.Hide();
                main.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng. Vui lòng thử lại.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sw_check_CheckedChanged_1(object sender, EventArgs e)
        {
            check();
        }
    }
}
