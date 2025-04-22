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
namespace QUAN_LY_QUAN_NUOC.User_Controls
{
    public partial class Quan_ly_menu : UserControl
    {
        BLL_connect qlymenu = new BLL_connect();
        DataTable dt;
        public Trang_chu frm;
        public Quan_ly_menu()
        {
            InitializeComponent();
            frm = new Trang_chu();
        }


        void loadccb()
        {
            ccbmenu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbchonmenu.DropDownStyle = ComboBoxStyle.DropDownList;
            ccbmenu.Items.Add("Tất cả");
            ccbmenu.Items.Add("Cà phê");
            ccbmenu.Items.Add("Trà sữa");
            ccbmenu.Items.Add("Trà");
            ccbmenu.Items.Add("Sinh tố");
            ccbmenu.SelectedIndex = 0;
        }

        //LOAD MENU THEO COMBOBOX
        private void LoadMenu(string item)
        {
            try
            {
                if (item == "Tất cả")
                {
                    dt = qlymenu.quanlymenuload();
                }
                else if (item == "Cà phê")
                {

                    dt = qlymenu.loadDM('1');
                }
                else if (item == "Trà sữa")
                {
                    dt = qlymenu.loadDM('2');
                }
                else if (item == "Trà")
                {
                    dt = qlymenu.loadDM('3');
                }
                else if (item == "Sinh tố")
                {
                    dt = qlymenu.loadDM('4');
                }
                dgvqlmenu.DataSource = dt;
                frm.load();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }


        private void chinhcolumns()
        {
            dgvqlmenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvqlmenu.TopLeftHeaderCell.Value = "STT";
            dgvqlmenu.Columns[0].FillWeight = 10;
            dgvqlmenu.Columns[1].FillWeight = 50;
            dgvqlmenu.Columns[2].FillWeight = 20;
            dgvqlmenu.Columns[3].FillWeight = 20;

            dgvqlmenu.Columns["id"].HeaderText = "ID";
            dgvqlmenu.Columns["ten"].HeaderText = "Tên";
            dgvqlmenu.Columns["gia"].HeaderText = "Giá";
            dgvqlmenu.Columns["madanhmuc"].HeaderText = "Mã danh mục";

            dgvqlmenu.Columns["madanhmuc"].Visible = false;

        }



        private void ccbmenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string danhmuc = ccbmenu.SelectedItem.ToString();
            LoadMenu(danhmuc);
        }



        private void btntk_Click(object sender, EventArgs e)
        {
            try
            {
                dt = qlymenu.Search("menu",txtSearch.Text);
                dgvqlmenu.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}");
            }
        }

        private void loadcombobox()
        {
            try
            {
                //dt = qlymenu.loadCCB();
                cbbchonmenu.DisplayMember = "tendanhmuc";
                cbbchonmenu.ValueMember = "madanhmuc";
                cbbchonmenu.DataSource = qlymenu.loadCCB();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void tbnmoi_Click(object sender, EventArgs e)
        {
            reset();
        }
        void reset()
        {
            txtID.Clear();
            txtName.Clear();
            txtGia.Clear();
            txtSearch.Clear();
            ccbmenu.SelectedIndex = 0;
            cbbchonmenu.SelectedIndex = 0;
        }


        private void dgvqlmenu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string rowNumber = (e.RowIndex + 1).ToString();

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvqlmenu.RowHeadersWidth, e.RowBounds.Height);

            using (var centerFormat = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.DrawString(rowNumber, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
            }
        }

        private void Quan_ly_menu_Load(object sender, EventArgs e)
        {
            ccbmenu.SelectedIndexChanged += ccbmenu_SelectedIndexChanged;
            loadccb();
            LoadMenu("Tất cả");
            loadcombobox();
            chinhcolumns();
            //
            dgvqlmenu.RowPrePaint += dgvqlmenu_RowPrePaint;
            dgvqlmenu.CellPainting += dgvqlmenu_CellPainting;
            dgvqlmenu.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            dgvqlmenu.DefaultCellStyle.SelectionForeColor = Color.Peru;
            dgvqlmenu.RowTemplate.Height = 40; // Đặt chiều cao của mỗi hàng
            dgvqlmenu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }


        private void dgvqlmenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int i = e.RowIndex;
                txtID.Text = dgvqlmenu[0, i].Value.ToString();
                txtName.Text = dgvqlmenu[1, i].Value.ToString();
                txtGia.Text = dgvqlmenu[2, i].Value.ToString();
                cbbchonmenu.SelectedValue = dgvqlmenu[3, i].Value.ToString();
            }
        }

        private void btnmoi_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int id;
            string name = txtName.Text;
            int gia;
            string maDanhMuc = cbbchonmenu.SelectedValue?.ToString();
            if (string.IsNullOrWhiteSpace(txtID.Text) || !int.TryParse(txtID.Text, out id))
            {
                MessageBox.Show("Không được để trống ID và ID phải là số nguyên!");
                return;
            }
            if(!int.TryParse(txtGia.Text, out gia) || string.IsNullOrWhiteSpace(txtGia.Text))
            {
                MessageBox.Show("Giá phải là số nguyên!");
                return;
            }
            string ErrorMess;
            bool result = qlymenu.ThemMonAn(id, name, gia, maDanhMuc, out ErrorMess);
            if (result)
            {
                MessageBox.Show("Thêm món thành công!");
                reset();
                LoadMenu("Tất cả");
            }
            else
            {
                MessageBox.Show(ErrorMess);
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int id;
            string name = txtName.Text;
            int gia;
            string maDanhMuc = cbbchonmenu.SelectedValue?.ToString();

            string errormess;

            if(!int.TryParse(txtID.Text, out id))
            {
                MessageBox.Show("ID không chứa chữ cái!");
                return;
            }
            if (!int.TryParse(txtGia.Text, out gia))
            {
                MessageBox.Show("Giá phải là số nguyên ");
            }

            bool resut = qlymenu.SuaMonAn(id, name, gia, maDanhMuc,out errormess);
            if (resut)
            {
                MessageBox.Show("Thay đổi thông tin thành công!");
            }
            else
            {
                MessageBox.Show(errormess);
            }
            LoadMenu("Tất cả");
            reset();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                LoadMenu("Tất cả");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void dgvqlmenu_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvqlmenu.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Peru; // Màu nâu
            }
        }

        private void dgvqlmenu_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //TÔ MÀU CHO DGV MENU
            if (e.RowIndex == -1) // Header
            {
                if (e.ColumnIndex == 0) // Cột STT
                {
                    e.Graphics.FillRectangle(Brushes.LightBlue, e.CellBounds);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds);
                }

                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            }
        }

        private void dgvqlmenu_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string rowNumber = (e.RowIndex + 1).ToString();

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvqlmenu.RowHeadersWidth, e.RowBounds.Height);

            Font rowNumberFont = new Font(this.Font.FontFamily, 12, FontStyle.Bold);

            using (var centerFormat = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.DrawString(rowNumber, rowNumberFont, SystemBrushes.ControlText, headerBounds, centerFormat);
            }
        }
    }
}
