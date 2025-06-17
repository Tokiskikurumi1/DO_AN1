using BLL;
using QUAN_LY_QUAN_NUOC.reporting;
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

namespace QUAN_LY_QUAN_NUOC
{
    public partial class Form_QR : Form
    {
        private string tongtien;
        private int idHD;
        public Form_QR(int idHD, string tongtien)
        {
            InitializeComponent();
            this.idHD = idHD;
            this.tongtien = tongtien;
            load();
            
        }

        void load()
        {
            txtPrice.Text = tongtien;
        }


        private void btn_In_hd_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi từ nơi chứa logic, ví dụ từ BLL hoặc qlb nếu cần
                BLL_connect qlb = new BLL_connect();
                DataTable dt = qlb.GetDuLieuInHoaDon(idHD);
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để in.");
                    return;
                }

                dt.TableName = "detail_bill";

                hoadonrp hd = new hoadonrp();
                DataSet ds = new DataSet();
                ds.Tables.Add(dt.Copy());
                hd.SetDataSource(ds);

                hoadoncr hdc = new hoadoncr();
                hdc.crystalReportViewer1.ReportSource = hd;
                hdc.crystalReportViewer1.Refresh();
                hdc.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi in hóa đơn: {ex.Message}");
            }
        }
    }
}
