namespace QUAN_LY_QUAN_NUOC.User_Controls
{
    partial class Quan_ly_hoa_don
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnthongke = new Guna.UI2.WinForms.Guna2Button();
            this.dtpcuoi = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpdau = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dgv_qlhd = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnin = new System.Windows.Forms.Button();
            this.lbtong = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnxoa = new System.Windows.Forms.Button();
            this.dgvtt = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_qlhd)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtt)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnthongke);
            this.panel1.Controls.Add(this.dtpcuoi);
            this.panel1.Controls.Add(this.dtpdau);
            this.panel1.Controls.Add(this.dgv_qlhd);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1524, 878);
            this.panel1.TabIndex = 0;
            // 
            // btnthongke
            // 
            this.btnthongke.BorderRadius = 6;
            this.btnthongke.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnthongke.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnthongke.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnthongke.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnthongke.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnthongke.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnthongke.ForeColor = System.Drawing.Color.Black;
            this.btnthongke.Image = global::QUAN_LY_QUAN_NUOC.Properties.Resources.thongke_icon_removebg_preview;
            this.btnthongke.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnthongke.ImageSize = new System.Drawing.Size(40, 40);
            this.btnthongke.Location = new System.Drawing.Point(660, 132);
            this.btnthongke.Name = "btnthongke";
            this.btnthongke.Size = new System.Drawing.Size(180, 45);
            this.btnthongke.TabIndex = 16;
            this.btnthongke.Text = "Thống kê";
            this.btnthongke.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnthongke.Click += new System.EventHandler(this.btnthongke_Click);
            // 
            // dtpcuoi
            // 
            this.dtpcuoi.BorderRadius = 6;
            this.dtpcuoi.Checked = true;
            this.dtpcuoi.CustomFormat = "dd/MM/yyyy";
            this.dtpcuoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(68)))), ((int)(((byte)(62)))));
            this.dtpcuoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpcuoi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpcuoi.Location = new System.Drawing.Point(356, 132);
            this.dtpcuoi.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpcuoi.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpcuoi.Name = "dtpcuoi";
            this.dtpcuoi.Size = new System.Drawing.Size(200, 45);
            this.dtpcuoi.TabIndex = 15;
            this.dtpcuoi.Value = new System.DateTime(2025, 3, 19, 21, 44, 22, 267);
            // 
            // dtpdau
            // 
            this.dtpdau.BorderRadius = 6;
            this.dtpdau.Checked = true;
            this.dtpdau.CustomFormat = "dd/MM/yyyy";
            this.dtpdau.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(68)))), ((int)(((byte)(62)))));
            this.dtpdau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpdau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdau.Location = new System.Drawing.Point(105, 132);
            this.dtpdau.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpdau.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpdau.Name = "dtpdau";
            this.dtpdau.Size = new System.Drawing.Size(200, 45);
            this.dtpdau.TabIndex = 14;
            this.dtpdau.Value = new System.DateTime(2025, 3, 19, 21, 43, 50, 246);
            // 
            // dgv_qlhd
            // 
            this.dgv_qlhd.AllowUserToAddRows = false;
            this.dgv_qlhd.BackgroundColor = System.Drawing.Color.White;
            this.dgv_qlhd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_qlhd.Location = new System.Drawing.Point(28, 190);
            this.dgv_qlhd.Name = "dgv_qlhd";
            this.dgv_qlhd.ReadOnly = true;
            this.dgv_qlhd.RowHeadersWidth = 51;
            this.dgv_qlhd.RowTemplate.Height = 24;
            this.dgv_qlhd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_qlhd.Size = new System.Drawing.Size(812, 676);
            this.dgv_qlhd.TabIndex = 8;
            this.dgv_qlhd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_qlhd_CellClick);
            this.dgv_qlhd.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_qlhd_CellPainting);
            this.dgv_qlhd.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_qlhd_RowPrePaint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnin);
            this.groupBox1.Controls.Add(this.lbtong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnxoa);
            this.groupBox1.Controls.Add(this.dgvtt);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(882, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 664);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hóa đơn";
            // 
            // btnin
            // 
            this.btnin.Location = new System.Drawing.Point(316, 589);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(173, 47);
            this.btnin.TabIndex = 6;
            this.btnin.Text = "In hóa đơn";
            this.btnin.UseVisualStyleBackColor = true;
            this.btnin.Click += new System.EventHandler(this.btnin_Click_1);
            // 
            // lbtong
            // 
            this.lbtong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbtong.Location = new System.Drawing.Point(225, 513);
            this.lbtong.Name = "lbtong";
            this.lbtong.Size = new System.Drawing.Size(264, 41);
            this.lbtong.TabIndex = 5;
            this.lbtong.Text = "0 VND";
            this.lbtong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(110, 513);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 41);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tổng: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(110, 589);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(184, 47);
            this.btnxoa.TabIndex = 2;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click_1);
            // 
            // dgvtt
            // 
            this.dgvtt.AllowUserToAddRows = false;
            this.dgvtt.BackgroundColor = System.Drawing.Color.White;
            this.dgvtt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvtt.Location = new System.Drawing.Point(7, 33);
            this.dgvtt.Name = "dgvtt";
            this.dgvtt.ReadOnly = true;
            this.dgvtt.RowHeadersWidth = 51;
            this.dgvtt.RowTemplate.Height = 24;
            this.dgvtt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvtt.Size = new System.Drawing.Size(588, 432);
            this.dgvtt.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Số lượng";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Giá";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(239)))));
            this.guna2HtmlLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(0, 0);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(1524, 61);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "QUẢN LÝ HÓA ĐƠN";
            this.guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Quan_ly_hoa_don
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.panel1);
            this.Name = "Quan_ly_hoa_don";
            this.Size = new System.Drawing.Size(1524, 878);
            this.Load += new System.EventHandler(this.Quan_ly_hoa_don_Load_1);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_qlhd)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvtt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_qlhd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnin;
        private System.Windows.Forms.Label lbtong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.DataGridView dgvtt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnthongke;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpcuoi;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpdau;
    }
}
