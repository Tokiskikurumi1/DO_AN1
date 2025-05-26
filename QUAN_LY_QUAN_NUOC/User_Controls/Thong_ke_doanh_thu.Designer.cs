namespace QUAN_LY_QUAN_NUOC.User_Controls
{
    partial class Thong_ke_doanh_thu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbtdt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbshd = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvtk = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dtdenngay = new System.Windows.Forms.DateTimePicker();
            this.dttungay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_TK = new Guna.UI2.WinForms.Guna2Button();
            this.btn_xuatBC = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtk)).BeginInit();
            this.SuspendLayout();
            // 
            // lbtdt
            // 
            this.lbtdt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbtdt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbtdt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtdt.Location = new System.Drawing.Point(753, 715);
            this.lbtdt.Name = "lbtdt";
            this.lbtdt.Size = new System.Drawing.Size(235, 39);
            this.lbtdt.TabIndex = 20;
            this.lbtdt.Text = "0 VND";
            this.lbtdt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(593, 723);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 23);
            this.label5.TabIndex = 19;
            this.label5.Text = "Tổng doanh thu:";
            // 
            // lbshd
            // 
            this.lbshd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbshd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbshd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbshd.Location = new System.Drawing.Point(753, 653);
            this.lbshd.Name = "lbshd";
            this.lbshd.Size = new System.Drawing.Size(235, 40);
            this.lbshd.TabIndex = 18;
            this.lbshd.Text = "0";
            this.lbshd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(631, 662);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 23);
            this.label3.TabIndex = 17;
            this.label3.Text = "Số hóa đơn:";
            // 
            // dgvtk
            // 
            this.dgvtk.AllowUserToAddRows = false;
            this.dgvtk.BackgroundColor = System.Drawing.Color.White;
            this.dgvtk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvtk.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvtk.Location = new System.Drawing.Point(153, 176);
            this.dgvtk.Name = "dgvtk";
            this.dgvtk.ReadOnly = true;
            this.dgvtk.RowHeadersWidth = 51;
            this.dgvtk.RowTemplate.Height = 24;
            this.dgvtk.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvtk.Size = new System.Drawing.Size(1314, 433);
            this.dgvtk.TabIndex = 16;
            this.dgvtk.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvtk_CellFormatting);
            this.dgvtk.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvtk_CellPainting);
            this.dgvtk.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvtk_RowPrePaint);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(688, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Đến ngày";
            // 
            // dtdenngay
            // 
            this.dtdenngay.CustomFormat = "dd/MM/yyyy\n";
            this.dtdenngay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtdenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtdenngay.Location = new System.Drawing.Point(818, 125);
            this.dtdenngay.Name = "dtdenngay";
            this.dtdenngay.Size = new System.Drawing.Size(200, 27);
            this.dtdenngay.TabIndex = 13;
            // 
            // dttungay
            // 
            this.dttungay.CalendarForeColor = System.Drawing.Color.Black;
            this.dttungay.CalendarMonthBackground = System.Drawing.Color.White;
            this.dttungay.CustomFormat = "dd/MM/yyyy\n";
            this.dttungay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dttungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dttungay.Location = new System.Drawing.Point(453, 125);
            this.dttungay.Name = "dttungay";
            this.dttungay.Size = new System.Drawing.Size(200, 27);
            this.dttungay.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(645, 60);
            this.label1.TabIndex = 11;
            this.label1.Text = "THỐNG KÊ DOANH THU";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_TK
            // 
            this.btn_TK.BorderRadius = 6;
            this.btn_TK.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_TK.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_TK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_TK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_TK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.btn_TK.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_TK.ForeColor = System.Drawing.Color.White;
            this.btn_TK.Location = new System.Drawing.Point(1074, 118);
            this.btn_TK.Name = "btn_TK";
            this.btn_TK.Size = new System.Drawing.Size(140, 35);
            this.btn_TK.TabIndex = 22;
            this.btn_TK.Text = "Thống kê";
            this.btn_TK.Click += new System.EventHandler(this.btn_TK_Click);
            // 
            // btn_xuatBC
            // 
            this.btn_xuatBC.BorderRadius = 6;
            this.btn_xuatBC.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_xuatBC.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_xuatBC.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_xuatBC.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_xuatBC.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(67)))), ((int)(((byte)(65)))));
            this.btn_xuatBC.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xuatBC.ForeColor = System.Drawing.Color.White;
            this.btn_xuatBC.Location = new System.Drawing.Point(627, 775);
            this.btn_xuatBC.Name = "btn_xuatBC";
            this.btn_xuatBC.Size = new System.Drawing.Size(391, 45);
            this.btn_xuatBC.TabIndex = 23;
            this.btn_xuatBC.Text = "Xuất báo cáo";
            this.btn_xuatBC.Click += new System.EventHandler(this.btn_xuatBC_Click);
            // 
            // Thong_ke_doanh_thu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.btn_xuatBC);
            this.Controls.Add(this.btn_TK);
            this.Controls.Add(this.lbtdt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbshd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvtk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtdenngay);
            this.Controls.Add(this.dttungay);
            this.Controls.Add(this.label1);
            this.Name = "Thong_ke_doanh_thu";
            this.Size = new System.Drawing.Size(1563, 878);
            this.Load += new System.EventHandler(this.Thong_ke_doanh_thu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvtk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbtdt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbshd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvtk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtdenngay;
        private System.Windows.Forms.DateTimePicker dttungay;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_TK;
        private Guna.UI2.WinForms.Guna2Button btn_xuatBC;
    }
}
