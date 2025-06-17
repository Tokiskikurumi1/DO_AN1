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
    public partial class Quan_Ly_Ban : UserControl
    {
        private int chonban = -1;
        BLL_connect qlb = new BLL_connect();
        DataTable dt;
        private int quyenHan;
        public Quan_Ly_Ban(int quyen)
        {
            InitializeComponent();
            loadban();
            btn();

            this.quyenHan = quyen;
            kiem_tra();
            dgvhoadon_ban.CellPainting += dgvhoadon_ban_CellPainting;
            dgvhoadon_ban.RowPrePaint += dgvhoadon_ban_RowPrePaint;
        }

        private void kiem_tra()
        {
            if (quyenHan == 2)
            {
                btn_add_ban.Enabled = false;
                btn_xoa_ban.Enabled = false;
            }
        }

        private void Dgvhoadon_ban_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void Quan_Ly_Ban_Load(object sender, EventArgs e)
        {
            load_dgv_ban();
        }
        void btn()
        {
            // Lấy tất cả các button trong FlowLayoutPanel
            Button[] buttons = FLP_ban.Controls.OfType<Button>().ToArray();

            // Duyệt qua mảng và gắn sự kiện click
            foreach (Button btn in buttons)
            {
                btn.Click += btnBan_Click;
            }
        }

        void load_dgv_ban()
        {
            dgvhoadon_ban.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvhoadon_ban.Columns[0].FillWeight = 10;
            dgvhoadon_ban.Columns[1].FillWeight = 40;
            dgvhoadon_ban.Columns[2].FillWeight = 20;
            dgvhoadon_ban.Columns[3].FillWeight = 30;
            dgvhoadon_ban.Columns[4].Visible = false;
        }

        private void loadban()
        {
            FLP_ban.Controls.Clear();
            var ban = qlb.GetAllTables();

            foreach (var table in ban)
            {
                Button bantbn = new Button
                {
                    Size = new Size(165, 146), // Tăng chiều cao để có chỗ cho chữ
                    Margin = new Padding(5),
                    Tag = table.idban,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Font = new Font("Arial", 10, FontStyle.Bold), // Chữ rõ ràng hơn
                    TextAlign = ContentAlignment.BottomCenter, // Đưa chữ xuống dưới
                    TextImageRelation = TextImageRelation.ImageAboveText // Ảnh trên, chữ dưới
                };
                bantbn.FlatStyle = FlatStyle.Flat;
                bantbn.FlatAppearance.BorderSize = 0;
                // Đặt ảnh theo trạng thái bàn
                if (table.trangthai == "Trống")
                {
                    bantbn.BackgroundImage = Properties.Resources.trong_ver2;
                    bantbn.Text = $"{table.tenban}\n(Trống)"; // Hiển thị số bàn + trạng thái
                }
                else
                {
                    bantbn.BackgroundImage = Properties.Resources.co_nguoi_ver2;
                    bantbn.Text = $"{table.tenban}\n(Có người)";
                }

                // Thêm sự kiện click
                bantbn.Click += btnBan_Click;
                FLP_ban.Controls.Add(bantbn);
            }
        }

        private void btn_add_ban_Click(object sender, EventArgs e)
        {
            try
            {
                qlb.AddTable();
                loadban();
                MessageBox.Show($"Đã thêm bàn mới");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_xoa_ban_Click(object sender, EventArgs e)
        {
            try
            {
                qlb.RemoveTable();
                loadban();
                MessageBox.Show($"Đã xóa bàn cuối cùng");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgvhoadon_ban_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void btnBan_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                // Ép kiểu Tag về int để tránh lỗi
                if (clickedButton.Tag != null && int.TryParse(clickedButton.Tag.ToString(), out chonban))
                {
                    chonban = Convert.ToInt32(clickedButton.Tag);
                    string tableStatus = clickedButton.Text.Contains("Có người") ? "Có người" : "Trống";

                    if (tableStatus == "Có người")
                    {
                        dgvhoadon_ban.Rows.Clear();
                        try
                        {
                            //ketnoi();
                            HienThiThongTinBan(chonban);  // Hiển thị thông tin hóa đơn cho bàn
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi hiển thị hóa đơn: {ex.Message}");
                        }
                    }
                    else
                    {
                        dgvhoadon_ban.Rows.Clear();
                        int tongTien = 0;
                        lbtong.Text = $"{tongTien:N0} VND";
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi: Không thể xác định ID bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // HIỂN THỊ HÓA ĐƠN BÀN
        void HienThiThongTinBan(int idban)
        {
            try
            {
                int tongTien = 0;
                dt = qlb.hienthiban(idban);
                dgvhoadon_ban.Rows.Clear(); // Xóa các dòng cũ
                foreach (DataRow rowChiTiet in dt.Rows)
                {
                    string priceFormatted = "";
                    if (decimal.TryParse(rowChiTiet["gia"].ToString(), out decimal price))
                    {
                        priceFormatted = string.Format("{0:N0} VND", price);
                    }
                    dgvhoadon_ban.Rows.Add(rowChiTiet["ID_dish"], rowChiTiet["dish_name"], rowChiTiet["quantity"], priceFormatted, rowChiTiet["gia"]);
                    //dgvhoadon_ban.Rows.Add(rowChiTiet["ID_dish"], rowChiTiet["dish_name"], rowChiTiet["quantity"], rowChiTiet["gia"]);

                    // Tính tổng tiền
                    tongTien += Convert.ToInt32(rowChiTiet["gia"]);
                }

                // Hiển thị tổng tiền
                lbtong.Text = $"{tongTien:N0} VND"; // Định dạng tổng tiền
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btn_thanhtoanban_Click(object sender, EventArgs e)
        {
            int tra_ve = qlb.thanhtoanban(chonban);
            try
            {
                if (tra_ve == -1)
                {
                    MessageBox.Show("Bàn không có hóa đơn");
                    chonban = -1;
                }
                else if (tra_ve == -2)
                {
                    MessageBox.Show("Thanh toán lỗi");
                    chonban = -1;
                }
                else
                {
                    MessageBox.Show("Thanh toán thành công, bàn đã được làm trống!");
                    // Cập nhật lại giao diện
                    dgvhoadon_ban.Rows.Clear(); // Xóa danh sách hóa đơn hiện tại

                    //HIỆN FORM QR
                    Form_QR qR = new Form_QR(tra_ve,lbtong.Text);
                    qR.Show();
                    chonban = -1; // Reset bàn đã chọn
                    tonghoadon();
                    loadban();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thanh toán: {ex.Message}");
            }
        }

        void tonghoadon()
        {
            int tong = 0;
            foreach (DataGridViewRow row_tong in dgvhoadon_ban.Rows)
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

        private void dgvhoadon_ban_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvhoadon_ban_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgvhoadon_ban.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Peru; // Màu nâu
            }
        }
    }
}
