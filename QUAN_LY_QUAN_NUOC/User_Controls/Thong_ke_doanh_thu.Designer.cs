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
            this.btnxuatbc = new System.Windows.Forms.Button();
            this.lbtdt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbshd = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvtk = new System.Windows.Forms.DataGridView();
            this.btntk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtdenngay = new System.Windows.Forms.DateTimePicker();
            this.dttungay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtk)).BeginInit();
            this.SuspendLayout();
            // 
            // btnxuatbc
            // 
            this.btnxuatbc.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxuatbc.Location = new System.Drawing.Point(597, 781);
            this.btnxuatbc.Name = "btnxuatbc";
            this.btnxuatbc.Size = new System.Drawing.Size(391, 46);
            this.btnxuatbc.TabIndex = 21;
            this.btnxuatbc.Text = "Xuất báo cáo";
            this.btnxuatbc.UseVisualStyleBackColor = true;
            this.btnxuatbc.Click += new System.EventHandler(this.btnxuatbc_Click);
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
            this.dgvtk.BackgroundColor = System.Drawing.Color.White;
            this.dgvtk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtk.Location = new System.Drawing.Point(153, 176);
            this.dgvtk.Name = "dgvtk";
            this.dgvtk.ReadOnly = true;
            this.dgvtk.RowHeadersWidth = 51;
            this.dgvtk.RowTemplate.Height = 24;
            this.dgvtk.Size = new System.Drawing.Size(1314, 433);
            this.dgvtk.TabIndex = 16;
            // 
            // btntk
            // 
            this.btntk.AutoSize = true;
            this.btntk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntk.Location = new System.Drawing.Point(1068, 122);
            this.btntk.Name = "btntk";
            this.btntk.Size = new System.Drawing.Size(104, 31);
            this.btntk.TabIndex = 15;
            this.btntk.Text = "Thống kê";
            this.btntk.UseVisualStyleBackColor = true;
            this.btntk.Click += new System.EventHandler(this.btntk_Click);
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
            // Thong_ke_doanh_thu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.btnxuatbc);
            this.Controls.Add(this.lbtdt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbshd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvtk);
            this.Controls.Add(this.btntk);
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

        private System.Windows.Forms.Button btnxuatbc;
        private System.Windows.Forms.Label lbtdt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbshd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvtk;
        private System.Windows.Forms.Button btntk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtdenngay;
        private System.Windows.Forms.DateTimePicker dttungay;
        private System.Windows.Forms.Label label1;
    }
}
