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
using QUAN_LY_QUAN_NUOC.reporting;
namespace QUAN_LY_QUAN_NUOC.User_Controls
{
    public partial class Thong_ke_doanh_thu : UserControl
    {
        
        public Thong_ke_doanh_thu()
        {
            InitializeComponent();
        }
        BLL_connect tk_doanhthu = new BLL_connect();
        DataTable dt;
        DateTime tungay;
        DateTime denngay;
        void load()
        {
            dt = tk_doanhthu.DGV_Thongke();
            dgvtk.DataSource = dt;
            tongdoanthu();
            tonghoadon();
        }
        void tongdoanthu()
        {
            int tong = 0;
            foreach (DataGridViewRow row_tong in dgvtk.Rows)
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
            lbtdt.Text = $"{tong:N0} VND";
        }
        void tonghoadon()
        {
            int soluong = 0;
            foreach (DataGridViewRow row_soluong in dgvtk.Rows)
            {
                if (row_soluong.Cells[0].Value != null)
                {
                    soluong++;
                }
            }
            lbshd.Text = $"{soluong}";
        }

        void loaddgv()
        {
            dgvtk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvtk.TopLeftHeaderCell.Value = "STT";
            dgvtk.RowPostPaint += dgvtk_RowPostPaint;
            //if(dgvtk.Rows.Count > 0)
            //{
            dgvtk.Columns[0].FillWeight = 10;
            dgvtk.Columns[0].FillWeight = 30;
            dgvtk.Columns[0].FillWeight = 30;
            dgvtk.Columns[0].FillWeight = 30;

            dgvtk.Columns[0].HeaderText = "Mã hóa đơn";
            dgvtk.Columns[1].HeaderText = "Ngày tạo";
            dgvtk.Columns[2].HeaderText = "Hình thức";
            dgvtk.Columns[3].HeaderText = "Tổng tiền";
            //}
        }



        private void dgvtk_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string rowNumber = (e.RowIndex + 1).ToString();

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvtk.RowHeadersWidth, e.RowBounds.Height);

            using (var centerFormat = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.DrawString(rowNumber, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
            }
        }

        private void Thong_ke_doanh_thu_Load(object sender, EventArgs e)
        {
            load();
            loaddgv();
        }

        private void btntk_Click(object sender, EventArgs e)
        {
            DateTime tungay = dttungay.Value.Date;
            DateTime denngay = dtdenngay.Value.Date.AddDays(1).AddSeconds(-1); // Kết thúc trong ngày

            try
            {
                DataTable dt = tk_doanhthu.ThongKeTheoNgay(tungay, denngay);
                dgvtk.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message);
            }

            tongdoanthu();
            tonghoadon();
        }

        private void btnxuatbc_Click(object sender, EventArgs e)
        {
            try
            {
                tungay = dttungay.Value.Date;
                denngay = dtdenngay.Value.Date.AddDays(1).AddSeconds(-1);
                DataTable dt;
                // Kiểm tra nếu ngày không được chọn (default)
                if (tungay == default(DateTime) || denngay == default(DateTime))
                {
                    dt = tk_doanhthu.GetAllInvoicesForReport();
                }
                else
                {
                    dt = tk_doanhthu.GetInvoicesByDateRangeForReport(tungay, denngay);
                }
                // Thiết lập báo cáo Crystal Reports
                rpdoanhthu rp = new rpdoanhthu();
                rp.SetDataSource(dt);

                doanhthucry dcr = new doanhthucry();
                dcr.crystalReportViewer1.ReportSource = rp;
                dcr.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
