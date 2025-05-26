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
using CrystalDecisions.CrystalReports.Engine;
using BLL;
using QUAN_LY_QUAN_NUOC.reporting;

namespace QUAN_LY_QUAN_NUOC.User_Controls
{
    public partial class Quan_ly_hoa_don : UserControl
    {
        private int quyenHan;
        BLL_connect qlyhoadon = new BLL_connect();
        int Hoadon = -1;//cai nay de lay id hoa don, dung de so sanh khi hien crystal reports
        SqlDataAdapter adapter;
        DataTable dt;
        SqlDataReader rd;
        hoadoncr hdc;
        hoadonrp hd;
        public Quan_ly_hoa_don(int quyen)
        {
            InitializeComponent();
            this.quyenHan = quyen;
            kiem_tra();
            dgv_qlhd.CellPainting += dgv_qlhd_CellPainting;
            dgv_qlhd.RowPrePaint += dgv_qlhd_RowPrePaint;

            dgvtt.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            dgvtt.DefaultCellStyle.SelectionForeColor = Color.Peru;
            dgvtt.RowTemplate.Height = 40; // Đặt chiều cao của mỗi hàng
            dgvtt.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgv_qlhd.CellFormatting += dgv_qlhd_CellFormatting;
            dgvtt.CellFormatting += dgvtt_CellFormatting;

        }

        void kiem_tra()
        {
            if(quyenHan == 2)
            {
                btnxoa.Enabled = false;
            }
        }
        void loaddgv()
        {
            dgv_qlhd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvtt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_qlhd.TopLeftHeaderCell.Value = "STT";
            dgv_qlhd.Columns[0].FillWeight = 10;
            dgv_qlhd.Columns[1].FillWeight = 30;
            dgv_qlhd.Columns[2].FillWeight = 20;
            dgv_qlhd.Columns[3].FillWeight = 20;
            dgv_qlhd.Columns[4].FillWeight = 10;
            dgv_qlhd.Columns[5].FillWeight = 10;

            dgv_qlhd.Columns[0].HeaderText = "Mã hóa đơn";
            dgv_qlhd.Columns[1].HeaderText = "Ngày tạo";
            dgv_qlhd.Columns[2].HeaderText = "Hình thức";
            dgv_qlhd.Columns[3].HeaderText = "Tình trạng";
            dgv_qlhd.Columns[4].HeaderText = "ID bàn";
            dgv_qlhd.Columns[5].HeaderText = "Tổng tiền";

            dgvtt.Columns[0].FillWeight = 10;
            dgvtt.Columns[1].FillWeight = 40;
            dgvtt.Columns[2].FillWeight = 25;
            dgvtt.Columns[3].FillWeight = 25;

            dgvtt.Columns[4].Visible = false;

        }
        void load()
        {
            try
            {
                dt = qlyhoadon.trang_chu("bill");

                foreach (DataRow row in dt.Rows)
                {
                    // Check and update "hình thức" column
                    if (row[2] != DBNull.Value)
                    {
                        row[2] = Convert.ToInt32(row[2]) == 0 ? "Uống tại quán" : "Mang đi";
                    }

                    // Check and update "tình trạng" column
                    if (row[3] != DBNull.Value)
                    {
                        row[3] = Convert.ToInt32(row[3]) == 0 ? "Chưa thanh toán" : "Đã thanh toán";
                    }
                }

                dgv_qlhd.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Lỗi khi tải dữ liệu");
            }
        }




        private void HienThiChiTietHoaDon(int mahoadon)
        {

            try
            {
                dt = qlyhoadon.GetChiTietHoaDon(mahoadon);

                // Xóa dữ liệu cũ trong DataGridView
                dgvtt.Rows.Clear();

                // Kiểm tra nếu không có dữ liệu
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có chi tiết hóa đơn nào cho mã này.");
                    return;
                }

                // Hiển thị dữ liệu lên DataGridView
                foreach (DataRow row in dt.Rows)
                {
                    string priceFormatted = "";
                    if (decimal.TryParse(row["price"].ToString(), out decimal price))
                    {
                        priceFormatted = string.Format("{0:N0} VND", price);
                    }
                    dgvtt.Rows.Add(row["ID_dish"].ToString(), row["dish_name"], row["quantity"].ToString(),priceFormatted, row["price"].ToString());
                    //dgvtt.Rows.Add(row["ID_dish"].ToString(), row["dish_name"], row["quantity"].ToString(), row["price"].ToString());
                }
                // Gọi hàm tính tổng hóa đơn (giả sử đã có sẵn)
                tonghoadon();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi :{ex.Message}");
            }
        }


        void tonghoadon()
        {
            int tong = 0;
            foreach (DataGridViewRow row_tong in dgvtt.Rows)
            {
                if (row_tong.Cells[4].Value != null)
                {
                    int trave;
                    if (int.TryParse(row_tong.Cells[4].Value.ToString(), out trave))
                    {
                        tong += trave;
                    }
                }
            }
            lbtong.Text = $"{tong:N0} VND";
        }


        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string rowNumber = (e.RowIndex + 1).ToString();

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv_qlhd.RowHeadersWidth, e.RowBounds.Height);

            using (var centerFormat = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.DrawString(rowNumber, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
            }
        }

        private void Quan_ly_hoa_don_Load_1(object sender, EventArgs e)
        {
            load();
            loaddgv();
            dgv_qlhd.RowPostPaint += dataGridView1_RowPostPaint;
        }

        private void dgv_qlhd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có click vào dòng hợp lệ không
            if (e.RowIndex >= 0)
            {
                // Kiểm tra nếu là dòng trống
                if (dgv_qlhd.Rows[e.RowIndex].Cells[0].Value == DBNull.Value || dgv_qlhd.Rows[e.RowIndex].Cells[0].Value == null)
                {
                    dgvtt.Rows.Clear();
                    lbtong.Text = "0 VND";  // Cập nhật tổng tiền về 0
                    return;
                }

                // Kiểm tra giá trị của ô có phải là DBNull không
                if (dgv_qlhd.Rows[e.RowIndex].Cells[0].Value != DBNull.Value)
                {
                    // Lấy mahoadon từ cột đầu tiên (giả sử cột mahoadon nằm ở index 0)
                    int mahoadon = Convert.ToInt32(dgv_qlhd.Rows[e.RowIndex].Cells[0].Value);
                    Hoadon = Convert.ToInt32(dgv_qlhd.Rows[e.RowIndex].Cells[0].Value);
                    // Hiển thị thông tin chi tiết hóa đơn bên phải
                    HienThiChiTietHoaDon(mahoadon);
                }
            }
        }

        private void btnin_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Hoadon != -1)
                {
                    // Gọi tầng BLL để lấy dữ liệu hóa đơn
                    DataTable dt = qlyhoadon.GetDuLieuInHoaDon(Hoadon);

                    if (dt == null || dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để in cho hóa đơn này.", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    // Kiểm tra dữ liệu chi tiết món
                    dt.TableName = "detail_bill";
                    // Thiết lập dữ liệu cho Crystal Reports
                    hd = new hoadonrp();
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt.Copy());
                    hd.SetDataSource(ds);

                    // Hiển thị report trong form hoadoncr
                    hdc = new hoadoncr();
                    hdc.crystalReportViewer1.ReportSource = hd;
                    hdc.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn 1 hóa đơn để in ra!!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (dgv_qlhd.SelectedRows.Count > 0)
                {
                    // Lấy mã hóa đơn từ cột đầu tiên của dòng được chọn
                    int mahoadon = Convert.ToInt32(dgv_qlhd.SelectedRows[0].Cells[0].Value);

                    // Kiểm tra xem có phải dòng trống không
                    if (mahoadon == 0 || dgv_qlhd.SelectedRows[0].Cells[0].Value == DBNull.Value || dgv_qlhd.SelectedRows[0].Index == -1)
                    {
                        MessageBox.Show("Không có hóa đơn nào để xóa");
                        return; // Dừng việc xóa nếu là dòng trống
                    }

                    //string sql = "DELETE FROM hoadon WHERE mahoadon = '"+mahoadon+"'";


                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn không?", "Thông báo", MessageBoxButtons.YesNo);
                    {
                        if (result == DialogResult.Yes)
                        {
                            string Mess;
                            if (qlyhoadon.XoaHD(mahoadon, out Mess))
                            {
                                load();
                                loaddgv();
                                MessageBox.Show("Xóa hóa đơn thành công!");
                            }
                            else
                            {
                                MessageBox.Show("Xóa thất bại");
                            }
                            reset();
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn cần xóa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            DateTime tungay = dtpdau.Value.Date;
            DateTime denngay = dtpcuoi.Value.Date.AddDays(1).AddSeconds(-1); // Kết thúc trong ngày

            try
            {

                if (qlyhoadon.GetThongKeHoaDon(tungay, denngay) == null || qlyhoadon.GetThongKeHoaDon(tungay, denngay).Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu thống kê trong khoảng thời gian này.");
                    return;
                }

                // Hiển thị dữ liệu trong DataGridView
                dgv_qlhd.DataSource = qlyhoadon.GetThongKeHoaDon(tungay, denngay);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message);
            }
        }

        private void dgv_qlhd_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgv_qlhd_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dgv_qlhd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Peru; // Màu nâu
            }
        }

        void reset()
        {
            dgvtt.Rows.Clear();
        }

        private void dgv_qlhd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_qlhd.Columns[e.ColumnIndex].Name == "total_bill" && e.Value != null)
            {
                try
                {
                    if (decimal.TryParse(e.Value.ToString(), out decimal price))
                    {
                        e.Value = string.Format("{0:N0} VND", price);
                        e.FormattingApplied = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi định dạng giá: {ex.Message}");
                }
            }
        }

        private void dgvtt_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvtt.Columns[e.ColumnIndex].Name == "price" && e.Value != null)
            {
                try
                {
                    if (decimal.TryParse(e.Value.ToString(), out decimal price))
                    {
                        e.Value = string.Format("{0:N0} VND", price);
                        e.FormattingApplied = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi định dạng giá: {ex.Message}");
                }
            }
        }
    }
}
