using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BLL;
using DTO_DA;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
namespace QUAN_LY_QUAN_NUOC.User_Controls
{
    public partial class Trang_chu : UserControl
    {
        DataTable dt;
        BLL_connect bll = new BLL_connect();
        public Trang_chu tc;
        public Trang_chu()
        {
            InitializeComponent();
            txtsearch.KeyDown += TextBox_KeyDown;
            dgvmenu.RowPrePaint += dgvmenu_RowPrePaint;
            dgvmenu.CellPainting += dgvmenu_CellPainting;
            dgvmenu.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            dgvmenu.DefaultCellStyle.SelectionForeColor = Color.Peru;
            dgvmenu.RowTemplate.Height = 40; // Đặt chiều cao của mỗi hàng
            dgvmenu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void Trang_chu_Load(object sender, EventArgs e)
        {
            load();
            chinhdgv();
            
        }

        public void load()
        {
            try
            {
                dt = bll.trang_chu("menu");
                dgvmenu.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nốt: {ex.Message}");
            }
        }

        public void chinhdgv()
        {
            // Đặt chế độ tự động điều chỉnh độ rộng cột
            dgvmenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvhoadon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgvmenu.Columns[0].FillWeight = 10;
            dgvmenu.Columns[1].FillWeight = 70;
            dgvmenu.Columns[2].FillWeight = 20;

            dgvmenu.TopLeftHeaderCell.Value = "STT";
            dgvmenu.RowPostPaint += dgvmenu_RowPostPaint;
            dgvmenu.Columns["id"].HeaderText = "ID";
            dgvmenu.Columns["ten"].HeaderText = "Tên món";
            dgvmenu.Columns["gia"].HeaderText = "Giá";

            //HÓA ĐƠN

            dgvhoadon.Columns[0].FillWeight = 10;
            dgvhoadon.Columns[1].FillWeight = 55;
            dgvhoadon.Columns[2].FillWeight = 20;
            dgvhoadon.Columns[3].FillWeight = 25;

            //ẨN CỘT
            dgvmenu.Columns[0].Visible = false;
            dgvmenu.Columns[3].Visible = false;
            dgvhoadon.Columns[0].Visible = false;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnsearch.PerformClick();
            }
        }
        private void dgvmenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // tránh ấn vào cột tiêu đề
            {
                int i = e.RowIndex;
                txttenmon.Text = dgvmenu[1, i].Value.ToString();
                txtgiatien.Text = dgvmenu[2, i].Value.ToString();
            }
        }


        public void tonghoadon()
        {
            int tong = 0;
            foreach (DataGridViewRow row_tong in dgvhoadon.Rows)
            {
                if (row_tong.Cells[3].Value != null)
                {
                    int trave;
                    if (int.TryParse(row_tong.Cells[3].Value.ToString(), out trave))
                    {
                        tong += trave;
                    }
                }
            }
            lbtong.Text = $"{tong:N0} VND";
        }

        private void btnthemmon_Click(object sender, EventArgs e)
        {
            if (dgvmenu.SelectedRows.Count >= 0)
            {
                try
                {
                    if (countsl.Value == 0)
                    {
                        MessageBox.Show("Số lượng tối thiêu là 1");
                        countsl.Value = 1;
                        return;
                    }
                    int gia;
                    if (int.TryParse(txtgiatien.Text, out gia))
                    {
                        gia = gia * (int)countsl.Value;
                        dgvhoadon.Rows.Add(dgvmenu.SelectedRows[0].Cells["id"].Value, txttenmon.Text, countsl.Value, gia);
                        txttenmon.Clear();
                        txtgiatien.Clear();
                        countsl.Value = 1;

                        tonghoadon();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm món: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một món để thêm.");
            }
        }

        private void dgvmenu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string rowNumber = (e.RowIndex + 1).ToString();

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvmenu.RowHeadersWidth, e.RowBounds.Height);

            Font rowNumberFont = new Font(this.Font.FontFamily, 12, FontStyle.Bold);

            using (var centerFormat = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.DrawString(rowNumber, rowNumberFont, SystemBrushes.ControlText, headerBounds, centerFormat);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dgvhoadon.Rows.Count > 0)//dung de tranh viec chon hang tieu de trong datagirdview
            {
                foreach (DataGridViewRow row_xoa in dgvhoadon.SelectedRows)
                {
                    if (!row_xoa.IsNewRow) // kiem tra xem nguoi dung co an vao dong cuoi khong
                    {
                        dgvhoadon.Rows.Remove(row_xoa);

                        tonghoadon();
                    }
                }
            }
        }

        private void btndatban_Click(object sender, EventArgs e)
        {
            if (dgvhoadon.Rows.Count == 0 || dgvhoadon.Rows.Cast<DataGridViewRow>().All(r => r.Cells.Cast<DataGridViewCell>().All(c => c.Value == null || string.IsNullOrEmpty(c.Value.ToString()))))
            {
                MessageBox.Show("Vui lòng chọn món ăn trước khi đặt bàn!");
                return;
            }

            using (form_datban selectForm = new form_datban(dgvhoadon))
            {
                selectForm.tc = this;  // Đảm bảo `tc` không bị null

                if (selectForm.ShowDialog() == DialogResult.OK)
                {
                    form_datban frm = new form_datban(dgvhoadon);
                    frm.tc = this;  // Gán form chính vào form đặt bàn
                    frm.ShowDialog();

                    tc.LoadTables();

                }
            }
        }

        private void LoadTables()
        {
            tc.Controls.Clear();
            var tables = bll.GetAllTables();

            foreach (var table in tables)
            {
                Button tableButton = new Button
                {
                    Text = $"{table.tenban}\n({table.trangthai})",
                    Size = new Size(100, 100),
                    Margin = new Padding(5),
                    Tag = table.idban
                };

                tableButton.BackColor = table.trangthai == "Trống" ? System.Drawing.Color.LightGreen : System.Drawing.Color.LightCoral;
                tc.Controls.Add(tableButton);
            }
        }

        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (!hoadontrong(dgvhoadon))
                {
                    //ketnoi();
                    string tongText = Regex.Replace(lbtong.Text, @"[^\d]", ""); // Giữ lại các chữ số
                    int tongtien = 0;

                    if (!int.TryParse(tongText, out tongtien))
                    {
                        MessageBox.Show("Tổng tiền không hợp lệ. Vui lòng kiểm tra lại.");
                        return;
                    }
                    int mahoadon = bll.ThanhToanHoaDon(tongtien);
                    List<DTO.ChiTietHoaDon> danhSach = new List<DTO.ChiTietHoaDon>();

                    foreach (DataGridViewRow row in dgvhoadon.Rows)
                    {
                        if (row.IsNewRow) continue;

                        danhSach.Add(new DTO.ChiTietHoaDon
                        {
                            MaHoaDon = mahoadon,
                            IdMenu = Convert.ToInt32(row.Cells[0].Value),
                            SoLuong = Convert.ToInt32(row.Cells[2].Value),
                            Gia = Convert.ToInt32(row.Cells[3].Value)
                        });
                    }
                    bll.LuuChiTiet(mahoadon, danhSach);
                    MessageBox.Show("Thanh toán thành công");
                    dgvhoadon.Rows.Clear();
                    tonghoadon();
                    //ngatkn();
                }
                else
                {
                    MessageBox.Show("Hóa đơn trống", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thanh toán: {ex.Message}");
            }
        }
        ///HÓA ĐƠN TRỐNG
        private bool hoadontrong(DataGridView dgv)
        {
            // Duyệt qua tất cả các hàng
            foreach (DataGridViewRow row in dgv.Rows)
            {
                // Nếu hàng không phải là hàng mới (thường xuất hiện ở cuối DataGridView)
                if (!row.IsNewRow)
                {
                    // Kiểm tra cột đầu tiên (hoặc bất kỳ cột nào) có dữ liệu hay không
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            return false; // Có dữ liệu
                        }
                    }
                }
            }
            return true; // Không có dữ liệu
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void coffee_Click(object sender, EventArgs e)
        {
            dt = bll.loadDM('1');
            dgvmenu.DataSource = dt;
        }

        private void tra_sua_Click(object sender, EventArgs e)
        {
            dt = bll.loadDM('2');
            dgvmenu.DataSource = dt;
        }

        private void tra_Click(object sender, EventArgs e)
        {
            dt = bll.loadDM('3');
            dgvmenu.DataSource = dt;
        }

        private void sinh_to_Click(object sender, EventArgs e)
        {
            dt = bll.loadDM('4');
            dgvmenu.DataSource = dt;
        }
        //TÔ MÀU CHO DGV MENU
        private void dgvmenu_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
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

        private void dgvmenu_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvmenu.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Peru; // Màu nâu
            }
        }

        private void dgvhoadon_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvhoadon_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvhoadon.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Peru; // Màu nâu
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            dgvmenu.DataSource = bll.search(txtsearch.Text);
        }
    }
}
