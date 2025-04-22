using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using QUAN_LY_QUAN_NUOC.User_Controls;
using DTO_DA;
namespace QUAN_LY_QUAN_NUOC
{
    public partial class form_datban : Form
    {
        DTO dto = new DTO();
        BLL_connect datban = new BLL_connect();
        public Trang_chu tc;
        private int chonban = -1; // Lưu idban của bàn được chọn
        private DataGridView dgvhoadon; // Tham chiếu đến dgvhoadon từ Form1
        public form_datban(DataGridView dgvhoadon)
        {
            InitializeComponent();
            this.dgvhoadon = dgvhoadon;
            // Gán tc nếu chưa được truyền vào
            if (tc == null)
            {
                tc = Application.OpenForms.OfType<Trang_chu>().FirstOrDefault();
            }
            load_ban();
            btn();

        }

        void btn()
        {
            // Lấy tất cả các button trong FlowLayoutPanel
            Button[] buttons = FLP_datban.Controls.OfType<Button>().ToArray();

            // Duyệt qua mảng và gắn sự kiện click
            foreach (Button btn in buttons)
            {
                btn.Click += btnBan_Click;
            }
        }
        private void load_ban()
        {
            //FLP_datban.Controls.Clear();
            //var tables = datban.GetAllTables();

            //foreach (var table in tables)
            //{
            //    Button tableButton = new Button
            //    {
            //        Text = $"{table.tenban}\n({table.trangthai})",
            //        Size = new Size(100, 100),
            //        Margin = new Padding(5),
            //        Tag = table.idban // Lưu idban để dùng sau này nếu cần
            //    };

            //    // Đổi màu dựa trên trạng thái
            //    tableButton.BackColor = table.trangthai == "Trống" ? System.Drawing.Color.LightGreen : System.Drawing.Color.LightCoral;
            //    FLP_datban.Controls.Add(tableButton);
            //}

            FLP_datban.Controls.Clear();
            var ban = datban.GetAllTables();

            foreach (var table in ban)
            {
                Button bantbn = new Button
                {
                    Size = new Size(137, 111), // Tăng chiều cao để có chỗ cho chữ
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
                FLP_datban.Controls.Add(bantbn);
            }
        }

        private void btnhuydatban_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //ĐẶT BÀN

        //private void btndat_ban_Click(object sender, EventArgs e)
        //{
        //    if (chonban != -1)
        //    {
        //        try
        //        {
        //            if (dgvhoadon.Rows.Count == 0 || dgvhoadon.Rows[0].Cells[0].Value == null)
        //            {
        //                MessageBox.Show("Không có món ăn nào trong hóa đơn.");
        //                return;
        //            }

        //            string tongText = Regex.Replace(tc.lbtong.Text, @"[^\d]", "");
        //            int tongtien = int.TryParse(tongText, out int total) ? total : 0;

        //            if (tongtien == 0)
        //            {
        //                MessageBox.Show("Tổng tiền không hợp lệ.");
        //                return;
        //            }

        //            int mahoadon = datban.DatBan(chonban, tongtien);

        //            if (mahoadon > 0)
        //            {
        //                MessageBox.Show("Bàn đã được đặt thành công!");

        //                List<DTO.ChiTietHoaDon> danhSach = new List<DTO.ChiTietHoaDon>();

        //                foreach (DataGridViewRow row in dgvhoadon.Rows)
        //                {
        //                    if (row.IsNewRow) continue;

        //                    danhSach.Add(new DTO.ChiTietHoaDon
        //                    {
        //                        MaHoaDon = mahoadon,
        //                        IdMenu = Convert.ToInt32(row.Cells[0].Value),
        //                        SoLuong = Convert.ToInt32(row.Cells[2].Value),
        //                        Gia = Convert.ToInt32(row.Cells[3].Value)
        //                    });
        //                }

        //                datban.LuuChiTiet(mahoadon, danhSach); // Gọi phương thức mới

        //                dgvhoadon.Rows.Clear();
        //                tc.tonghoadon();
        //                load_ban();

        //            }
        //            else
        //            {
        //                MessageBox.Show("Bàn đã có người đặt.");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Lỗi đặt bàn: {ex.Message}");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Vui lòng chọn bàn trước khi đặt!");
        //    }
        //}
       
        private void btnBan_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                // Ép kiểu Tag về int để tránh lỗi
                if (clickedButton.Tag != null && int.TryParse(clickedButton.Tag.ToString(), out chonban))
                {
                    chonban = Convert.ToInt32(clickedButton.Tag);
                }
                else
                {
                    MessageBox.Show("Lỗi: Không thể xác định ID bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btndat_ban_Click_1(object sender, EventArgs e)
        {
            if (chonban != -1)
            {
                try
                {
                    if (dgvhoadon.Rows.Count == 0 || dgvhoadon.Rows[0].Cells[0].Value == null)
                    {
                        MessageBox.Show("Không có món ăn nào trong hóa đơn.");
                        return;
                    }

                    string tongText = Regex.Replace(tc.lbtong.Text, @"[^\d]", "");
                    int tongtien = int.TryParse(tongText, out int total) ? total : 0;

                    if (tongtien == 0)
                    {
                        MessageBox.Show("Tổng tiền không hợp lệ.");
                        return;
                    }

                    int mahoadon = datban.DatBan(chonban, tongtien);

                    if (mahoadon > 0)
                    {
                        MessageBox.Show("Bàn đã được đặt thành công!");

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

                        datban.LuuChiTiet(mahoadon, danhSach); // Gọi phương thức mới

                        dgvhoadon.Rows.Clear();
                        tc.tonghoadon();
                        load_ban();

                    }
                    else
                    {
                        MessageBox.Show("Bàn đã có người đặt.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi đặt bàn: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi đặt!");
            }
        }
    }
}
