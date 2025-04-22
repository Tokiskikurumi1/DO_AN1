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
using CrystalDecisions.Shared.Json;
namespace QUAN_LY_QUAN_NUOC.User_Controls
{
    public partial class Quan_ly_nhan_vien : UserControl
    {
        private BLL_connect bll_qly = new BLL_connect();
        public Quan_ly_nhan_vien()
        {
            InitializeComponent();
            cbb_calam.Items.Add("Chọn ca");
            cbb_calam.Items.Add("Ca 1");
            cbb_calam.Items.Add("Ca 2");
            cbb_calam.Items.Add("Full");
        }
        void load()
        {
            dgvqly_nv.ReadOnly = true;
            cbb_chucvu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbb_calam.DropDownStyle = ComboBoxStyle.DropDownList;
            cbb_calam.SelectedIndex = 0;
            dgvqly_nv.DataSource =  bll_qly.dgv_nhanvien();
        }

        void loadcbb_Roles()
        {
            try
            {
                //dt = qlymenu.loadCCB();
                cbb_chucvu.DisplayMember = "role_name";
                cbb_chucvu.ValueMember = "role_ID";
                cbb_chucvu.DataSource = bll_qly.dbocbb_Roles();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        // CHỈNH COLUMN
        void loadcolumn()
        {
            dgvqly_nv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvqly_nv.TopLeftHeaderCell.Value = "STT";
            dgvqly_nv.Columns[0].FillWeight = 10;
            dgvqly_nv.Columns[1].FillWeight = 90/4;
            dgvqly_nv.Columns[2].FillWeight = 90 / 4;
            dgvqly_nv.Columns[3].FillWeight = 90 / 4;
            dgvqly_nv.Columns[4].FillWeight = 90 / 4;

            dgvqly_nv.Columns[0].HeaderText = "ID";
            dgvqly_nv.Columns[1].HeaderText = "Tên nhân viên";
            dgvqly_nv.Columns[2].HeaderText = "Ngày sinh";
            dgvqly_nv.Columns[3].HeaderText = "Số điện thoại";
            dgvqly_nv.Columns[4].HeaderText = "Ca làm";
            dgvqly_nv.Columns[5].HeaderText = "uername";
            dgvqly_nv.Columns[6].HeaderText = "pass";
            dgvqly_nv.Columns[7].HeaderText = "quyen_han";

            dgvqly_nv.Columns[5].Visible = false;
            dgvqly_nv.Columns[6].Visible = false;
            dgvqly_nv.Columns[7].Visible = false;
        }
        private void Quan_ly_nhan_vien_Load(object sender, EventArgs e)
        {
            load();
            loadcbb_Roles();
            loadcolumn();
            dgvqly_nv.RowPrePaint += dgvqly_nv_RowPrePaint;
            dgvqly_nv.CellPainting += dgvqly_nv_CellPainting;
            dgvqly_nv.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            dgvqly_nv.DefaultCellStyle.SelectionForeColor = Color.Peru;
            dgvqly_nv.RowTemplate.Height = 40; // Đặt chiều cao của mỗi hàng
            dgvqly_nv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void dgvqly_nv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                int i = e.RowIndex;
                txtID.Text = dgvqly_nv[0, i].Value.ToString();
                txtname.Text = dgvqly_nv[1, i].Value.ToString();
                tpk_ngaysinh.Text = dgvqly_nv[2, i].Value.ToString();
                txtphone_number.Text = dgvqly_nv[3, i].Value.ToString();
                cbb_calam.Text = dgvqly_nv[4,i].Value.ToString();
                txtuser.Text = dgvqly_nv[5, i].Value.ToString();
                txtpass.Text = dgvqly_nv[6, i].Value.ToString();
                cbb_chucvu.SelectedValue = dgvqly_nv[7, i].Value.ToString();
            }
        }
        

        private void dgvqly_nv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvqly_nv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvqly_nv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Peru; // Màu nâu
            }
        }
        // LÀM MỚI
        private void btn_new_Click(object sender, EventArgs e)
        {
            reset();
        }

        void reset()
        {
            txtID.Clear();
            txtname.Clear();
            tpk_ngaysinh.ResetText();
            txtphone_number.Clear();
            cbb_calam.SelectedIndex = 0;
            txtuser.Clear();
            txtpass.Clear();
            cbb_chucvu.SelectedIndex = 0;
        }

        //THÊM NHÂN VIÊN
        private void btn_addNV_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                string ten = txtname.Text;
                DateTime ngaysinh = tpk_ngaysinh.Value;
                string phonenumber = txtphone_number.Text;
                string ca_lam = cbb_calam.SelectedItem?.ToString();
                string username = txtuser.Text;
                string pass = txtpass.Text;
                string chuc_vu = cbb_chucvu.SelectedValue?.ToString();

                string check_id = txtID.Text;
                if(!int.TryParse(check_id, out id))
                {
                    MessageBox.Show("ID phải là số nguyên!");
                    return;
                }

                string errormess;
                bool result = bll_qly.ThemNV(id, ten, ngaysinh, phonenumber, ca_lam, username, pass, chuc_vu, out errormess);

                if (result)
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset(); // Xóa các trường nhập liệu sau khi thêm thành công
                    load();
                }
                else
                {
                    MessageBox.Show(errormess);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        // SỦA NHÂN VIÊN
        private void btn_suaNV_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                string ten = txtname.Text;
                DateTime ngaysinh = tpk_ngaysinh.Value;
                string phonenumber = txtphone_number.Text;
                string ca_lam = cbb_calam.SelectedItem?.ToString();
                string username = txtuser.Text;
                string pass = txtpass.Text;
                string chuc_vu = cbb_chucvu.SelectedValue?.ToString();

                string check_id = txtID.Text;
                if (!int.TryParse(check_id, out id) || string.IsNullOrWhiteSpace(check_id))
                {
                    MessageBox.Show("ID không được để trống hoặc có chữ cái!");
                    return;
                }

                string errormess;
                bool result = bll_qly.SuaNV(id, ten, ngaysinh, phonenumber, ca_lam, username, pass, chuc_vu, out errormess);

                if (result)
                {
                    MessageBox.Show("Thay đổi thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset(); // Xóa các trường nhập liệu sau khi thêm thành công
                    load();
                }
                else
                {
                    MessageBox.Show(errormess);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        //XÓA NHÂN VIÊN
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                int id;

                string check_id = txtID.Text;
                if (!int.TryParse(check_id, out id) || string.IsNullOrWhiteSpace(check_id))
                {
                    MessageBox.Show("ID không được để trống hoặc có chữ cái!");
                    return;
                }
                string mess;
                bool resutl = bll_qly.XoaNV(id, out mess);
                if (resutl)
                {
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    load();
                }
                else
                {
                    MessageBox.Show(mess);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex}");
            }
        }
        // TÌM KIẾM
        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                dgvqly_nv.DataSource = bll_qly.TimKiem_NV(txtTK.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex}");
            }

        }
    }
}
