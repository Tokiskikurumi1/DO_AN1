namespace QUAN_LY_QUAN_NUOC.User_Controls
{
    partial class Quan_Ly_Ban
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
            this.FLP_ban = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_add_ban = new Guna.UI2.WinForms.Guna2Button();
            this.btn_xoa_ban = new Guna.UI2.WinForms.Guna2Button();
            this.dgvhoadon_ban = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbtong = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_thanhtoanban = new Guna.UI2.WinForms.Guna2Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLP_ban.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhoadon_ban)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FLP_ban
            // 
            this.FLP_ban.AutoScroll = true;
            this.FLP_ban.BackColor = System.Drawing.Color.White;
            this.FLP_ban.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FLP_ban.Controls.Add(this.button1);
            this.FLP_ban.Location = new System.Drawing.Point(40, 172);
            this.FLP_ban.Name = "FLP_ban";
            this.FLP_ban.Size = new System.Drawing.Size(952, 703);
            this.FLP_ban.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 146);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_add_ban
            // 
            this.btn_add_ban.BorderRadius = 6;
            this.btn_add_ban.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_add_ban.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_add_ban.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_add_ban.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_add_ban.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(68)))), ((int)(((byte)(62)))));
            this.btn_add_ban.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_add_ban.ForeColor = System.Drawing.Color.White;
            this.btn_add_ban.Location = new System.Drawing.Point(207, 95);
            this.btn_add_ban.Name = "btn_add_ban";
            this.btn_add_ban.Size = new System.Drawing.Size(180, 45);
            this.btn_add_ban.TabIndex = 3;
            this.btn_add_ban.Text = "Thêm bàn";
            this.btn_add_ban.Click += new System.EventHandler(this.btn_add_ban_Click);
            // 
            // btn_xoa_ban
            // 
            this.btn_xoa_ban.BorderRadius = 6;
            this.btn_xoa_ban.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_xoa_ban.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_xoa_ban.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_xoa_ban.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_xoa_ban.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(68)))), ((int)(((byte)(62)))));
            this.btn_xoa_ban.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_xoa_ban.ForeColor = System.Drawing.Color.White;
            this.btn_xoa_ban.Location = new System.Drawing.Point(487, 95);
            this.btn_xoa_ban.Name = "btn_xoa_ban";
            this.btn_xoa_ban.Size = new System.Drawing.Size(180, 45);
            this.btn_xoa_ban.TabIndex = 4;
            this.btn_xoa_ban.Text = "Xóa bàn";
            this.btn_xoa_ban.Click += new System.EventHandler(this.btn_xoa_ban_Click);
            // 
            // dgvhoadon_ban
            // 
            this.dgvhoadon_ban.AllowUserToAddRows = false;
            this.dgvhoadon_ban.BackgroundColor = System.Drawing.Color.White;
            this.dgvhoadon_ban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvhoadon_ban.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvhoadon_ban.GridColor = System.Drawing.Color.DarkGray;
            this.dgvhoadon_ban.Location = new System.Drawing.Point(9, 31);
            this.dgvhoadon_ban.Name = "dgvhoadon_ban";
            this.dgvhoadon_ban.ReadOnly = true;
            this.dgvhoadon_ban.RowHeadersWidth = 51;
            this.dgvhoadon_ban.RowTemplate.Height = 24;
            this.dgvhoadon_ban.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvhoadon_ban.Size = new System.Drawing.Size(521, 372);
            this.dgvhoadon_ban.TabIndex = 5;
            this.dgvhoadon_ban.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvhoadon_ban_CellClick);
            this.dgvhoadon_ban.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvhoadon_ban_CellPainting);
            this.dgvhoadon_ban.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvhoadon_ban_RowPrePaint);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lbtong);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_thanhtoanban);
            this.groupBox1.Controls.Add(this.dgvhoadon_ban);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(998, 344);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 531);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HÓA ĐƠN";
            // 
            // lbtong
            // 
            this.lbtong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbtong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtong.Location = new System.Drawing.Point(121, 432);
            this.lbtong.Name = "lbtong";
            this.lbtong.Size = new System.Drawing.Size(261, 74);
            this.lbtong.TabIndex = 8;
            this.lbtong.Text = "0 VND";
            this.lbtong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 74);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tổng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_thanhtoanban
            // 
            this.btn_thanhtoanban.BorderRadius = 6;
            this.btn_thanhtoanban.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_thanhtoanban.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_thanhtoanban.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_thanhtoanban.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_thanhtoanban.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(68)))), ((int)(((byte)(62)))));
            this.btn_thanhtoanban.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.btn_thanhtoanban.ForeColor = System.Drawing.Color.White;
            this.btn_thanhtoanban.Location = new System.Drawing.Point(398, 432);
            this.btn_thanhtoanban.Name = "btn_thanhtoanban";
            this.btn_thanhtoanban.Size = new System.Drawing.Size(125, 74);
            this.btn_thanhtoanban.TabIndex = 6;
            this.btn_thanhtoanban.Text = "Thanh toán";
            this.btn_thanhtoanban.Click += new System.EventHandler(this.btn_thanhtoanban_Click);
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
            // Column5
            // 
            this.Column5.HeaderText = "giagoc";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 125;
            // 
            // Quan_Ly_Ban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_xoa_ban);
            this.Controls.Add(this.btn_add_ban);
            this.Controls.Add(this.FLP_ban);
            this.Name = "Quan_Ly_Ban";
            this.Size = new System.Drawing.Size(1563, 878);
            this.Load += new System.EventHandler(this.Quan_Ly_Ban_Load);
            this.FLP_ban.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvhoadon_ban)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel FLP_ban;
        private Guna.UI2.WinForms.Guna2Button btn_add_ban;
        private Guna.UI2.WinForms.Guna2Button btn_xoa_ban;
        private System.Windows.Forms.DataGridView dgvhoadon_ban;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbtong;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_thanhtoanban;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}
