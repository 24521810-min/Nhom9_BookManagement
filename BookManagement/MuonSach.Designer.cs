namespace BookManagement
{
    partial class Muonsach
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_kedoc = new System.Windows.Forms.Panel();
            this.panel_thanhngang = new System.Windows.Forms.Panel();
            this.button_Muon = new System.Windows.Forms.Button();
            this.button_Tra = new System.Windows.Forms.Button();
            this.button_TrangChu = new System.Windows.Forms.Button();
            this.button_HSDKy = new System.Windows.Forms.Button();
            this.button_DXuat = new System.Windows.Forms.Button();
            this.button_quyengop = new System.Windows.Forms.Button();
            this.label_timkiem = new System.Windows.Forms.Label();
            this.textBox_timkiem = new System.Windows.Forms.TextBox();
            this.label_ds = new System.Windows.Forms.Label();
            this.bangds = new System.Windows.Forms.DataGridView();
            this.label_ngmuon = new System.Windows.Forms.Label();
            this.label_ngtradk = new System.Windows.Forms.Label();
            this.dateTimePicker_muon = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_tradk = new System.Windows.Forms.DateTimePicker();
            this.button_muonsach = new System.Windows.Forms.Button();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tensach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_masach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_tacgia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_sluongmuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_slconlai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bangds)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_kedoc
            // 
            this.panel_kedoc.BackColor = System.Drawing.Color.Black;
            this.panel_kedoc.Location = new System.Drawing.Point(1210, 98);
            this.panel_kedoc.Name = "panel_kedoc";
            this.panel_kedoc.Size = new System.Drawing.Size(2, 45);
            this.panel_kedoc.TabIndex = 14;
            // 
            // panel_thanhngang
            // 
            this.panel_thanhngang.BackColor = System.Drawing.Color.Black;
            this.panel_thanhngang.Location = new System.Drawing.Point(-2, 97);
            this.panel_thanhngang.Name = "panel_thanhngang";
            this.panel_thanhngang.Size = new System.Drawing.Size(1416, 2);
            this.panel_thanhngang.TabIndex = 8;
            // 
            // button_Muon
            // 
            this.button_Muon.BackColor = System.Drawing.Color.Tan;
            this.button_Muon.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_Muon.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Muon.ForeColor = System.Drawing.Color.SaddleBrown;
            this.button_Muon.Location = new System.Drawing.Point(246, 32);
            this.button_Muon.Name = "button_Muon";
            this.button_Muon.Size = new System.Drawing.Size(256, 66);
            this.button_Muon.TabIndex = 11;
            this.button_Muon.Text = "MƯỢN SÁCH";
            this.button_Muon.UseVisualStyleBackColor = false;
            // 
            // button_Tra
            // 
            this.button_Tra.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_Tra.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Tra.ForeColor = System.Drawing.Color.SaddleBrown;
            this.button_Tra.Location = new System.Drawing.Point(492, 32);
            this.button_Tra.Name = "button_Tra";
            this.button_Tra.Size = new System.Drawing.Size(256, 66);
            this.button_Tra.TabIndex = 9;
            this.button_Tra.Text = "TRẢ SÁCH";
            this.button_Tra.UseVisualStyleBackColor = true;
            this.button_Tra.Click += new System.EventHandler(this.button_Tra_Click);
            // 
            // button_TrangChu
            // 
            this.button_TrangChu.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_TrangChu.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_TrangChu.ForeColor = System.Drawing.Color.SaddleBrown;
            this.button_TrangChu.Location = new System.Drawing.Point(-2, 32);
            this.button_TrangChu.Name = "button_TrangChu";
            this.button_TrangChu.Size = new System.Drawing.Size(256, 66);
            this.button_TrangChu.TabIndex = 7;
            this.button_TrangChu.Text = "TRANG CHỦ";
            this.button_TrangChu.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button_TrangChu.UseVisualStyleBackColor = true;
            this.button_TrangChu.Click += new System.EventHandler(this.button_TrangChu_Click_1);
            // 
            // button_HSDKy
            // 
            this.button_HSDKy.FlatAppearance.BorderColor = System.Drawing.Color.FloralWhite;
            this.button_HSDKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_HSDKy.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_HSDKy.Location = new System.Drawing.Point(1210, 100);
            this.button_HSDKy.Name = "button_HSDKy";
            this.button_HSDKy.Size = new System.Drawing.Size(228, 54);
            this.button_HSDKy.TabIndex = 13;
            this.button_HSDKy.Text = "Hồ sơ đăng ký";
            this.button_HSDKy.UseVisualStyleBackColor = true;
            // 
            // button_DXuat
            // 
            this.button_DXuat.FlatAppearance.BorderColor = System.Drawing.Color.FloralWhite;
            this.button_DXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DXuat.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DXuat.Location = new System.Drawing.Point(1047, 94);
            this.button_DXuat.Name = "button_DXuat";
            this.button_DXuat.Size = new System.Drawing.Size(162, 65);
            this.button_DXuat.TabIndex = 12;
            this.button_DXuat.Text = "Đăng xuất";
            this.button_DXuat.UseVisualStyleBackColor = true;
            this.button_DXuat.Click += new System.EventHandler(this.button_DXuat_Click);
            // 
            // button_quyengop
            // 
            this.button_quyengop.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_quyengop.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_quyengop.ForeColor = System.Drawing.Color.SaddleBrown;
            this.button_quyengop.Location = new System.Drawing.Point(744, 32);
            this.button_quyengop.Name = "button_quyengop";
            this.button_quyengop.Size = new System.Drawing.Size(256, 66);
            this.button_quyengop.TabIndex = 15;
            this.button_quyengop.Text = "QUYÊN GÓP SÁCH";
            this.button_quyengop.UseVisualStyleBackColor = true;
            this.button_quyengop.Click += new System.EventHandler(this.button_quyengop_Click);
            // 
            // label_timkiem
            // 
            this.label_timkiem.AutoSize = true;
            this.label_timkiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_timkiem.Location = new System.Drawing.Point(46, 195);
            this.label_timkiem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_timkiem.Name = "label_timkiem";
            this.label_timkiem.Size = new System.Drawing.Size(119, 32);
            this.label_timkiem.TabIndex = 16;
            this.label_timkiem.Text = "Tìm kiếm";
            // 
            // textBox_timkiem
            // 
            this.textBox_timkiem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_timkiem.Location = new System.Drawing.Point(174, 190);
            this.textBox_timkiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_timkiem.Name = "textBox_timkiem";
            this.textBox_timkiem.Size = new System.Drawing.Size(460, 37);
            this.textBox_timkiem.TabIndex = 17;
            this.textBox_timkiem.Click += new System.EventHandler(this.textBox_timkiem_TextChanged);
            // 
            // label_ds
            // 
            this.label_ds.AutoSize = true;
            this.label_ds.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ds.Location = new System.Drawing.Point(46, 254);
            this.label_ds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ds.Name = "label_ds";
            this.label_ds.Size = new System.Drawing.Size(302, 32);
            this.label_ds.TabIndex = 18;
            this.label_ds.Text = "Danh sách sách khả dụng";
            // 
            // bangds
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bangds.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.bangds.ColumnHeadersHeight = 50;
            this.bangds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.tensach,
            this.Column_masach,
            this.Column_tacgia,
            this.Column_sluongmuon,
            this.Column_slconlai,
            this.Column_chon});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bangds.DefaultCellStyle = dataGridViewCellStyle2;
            this.bangds.Location = new System.Drawing.Point(21, 302);
            this.bangds.Name = "bangds";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bangds.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.bangds.RowHeadersVisible = false;
            this.bangds.RowHeadersWidth = 51;
            this.bangds.RowTemplate.Height = 40;
            this.bangds.Size = new System.Drawing.Size(1059, 270);
            this.bangds.TabIndex = 19;
            // 
            // label_ngmuon
            // 
            this.label_ngmuon.AutoSize = true;
            this.label_ngmuon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ngmuon.Location = new System.Drawing.Point(1120, 302);
            this.label_ngmuon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ngmuon.Name = "label_ngmuon";
            this.label_ngmuon.Size = new System.Drawing.Size(149, 32);
            this.label_ngmuon.TabIndex = 20;
            this.label_ngmuon.Text = "Ngày mượn";
            // 
            // label_ngtradk
            // 
            this.label_ngtradk.AutoSize = true;
            this.label_ngtradk.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ngtradk.Location = new System.Drawing.Point(1120, 398);
            this.label_ngtradk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ngtradk.Name = "label_ngtradk";
            this.label_ngtradk.Size = new System.Drawing.Size(206, 32);
            this.label_ngtradk.TabIndex = 21;
            this.label_ngtradk.Text = "Ngày trả dự kiến";
            // 
            // dateTimePicker_muon
            // 
            this.dateTimePicker_muon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_muon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_muon.Location = new System.Drawing.Point(1146, 343);
            this.dateTimePicker_muon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker_muon.Name = "dateTimePicker_muon";
            this.dateTimePicker_muon.Size = new System.Drawing.Size(248, 39);
            this.dateTimePicker_muon.TabIndex = 22;
            this.dateTimePicker_muon.Value = new System.DateTime(2025, 11, 20, 19, 21, 19, 0);
            // 
            // dateTimePicker_tradk
            // 
            this.dateTimePicker_tradk.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_tradk.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_tradk.Location = new System.Drawing.Point(1146, 445);
            this.dateTimePicker_tradk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker_tradk.Name = "dateTimePicker_tradk";
            this.dateTimePicker_tradk.Size = new System.Drawing.Size(248, 39);
            this.dateTimePicker_tradk.TabIndex = 23;
            this.dateTimePicker_tradk.Value = new System.DateTime(2025, 11, 20, 19, 21, 19, 0);
            // 
            // button_muonsach
            // 
            this.button_muonsach.BackColor = System.Drawing.Color.Tan;
            this.button_muonsach.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_muonsach.Location = new System.Drawing.Point(1004, 585);
            this.button_muonsach.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_muonsach.Name = "button_muonsach";
            this.button_muonsach.Size = new System.Drawing.Size(255, 68);
            this.button_muonsach.TabIndex = 24;
            this.button_muonsach.Text = "Mượn sách";
            this.button_muonsach.UseVisualStyleBackColor = false;
            this.button_muonsach.Click += new System.EventHandler(this.button_muonsach_Click);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MaxInputLength = 327;
            this.STT.MinimumWidth = 10;
            this.STT.Name = "STT";
            this.STT.Width = 50;
            // 
            // tensach
            // 
            this.tensach.HeaderText = "Tên sách";
            this.tensach.MinimumWidth = 10;
            this.tensach.Name = "tensach";
            this.tensach.Width = 127;
            // 
            // Column_masach
            // 
            this.Column_masach.HeaderText = "Mã sách";
            this.Column_masach.MaxInputLength = 327;
            this.Column_masach.MinimumWidth = 10;
            this.Column_masach.Name = "Column_masach";
            this.Column_masach.Width = 50;
            // 
            // Column_tacgia
            // 
            this.Column_tacgia.HeaderText = "Tác giả";
            this.Column_tacgia.MinimumWidth = 10;
            this.Column_tacgia.Name = "Column_tacgia";
            this.Column_tacgia.Width = 125;
            // 
            // Column_sluongmuon
            // 
            this.Column_sluongmuon.HeaderText = "Số lượng\nmượn";
            this.Column_sluongmuon.MinimumWidth = 10;
            this.Column_sluongmuon.Name = "Column_sluongmuon";
            this.Column_sluongmuon.Width = 125;
            // 
            // Column_slconlai
            // 
            this.Column_slconlai.HeaderText = "Số lượng\ncòn lại";
            this.Column_slconlai.MinimumWidth = 10;
            this.Column_slconlai.Name = "Column_slconlai";
            this.Column_slconlai.Width = 125;
            // 
            // Column_chon
            // 
            this.Column_chon.HeaderText = "Chọn";
            this.Column_chon.MinimumWidth = 10;
            this.Column_chon.Name = "Column_chon";
            this.Column_chon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_chon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column_chon.Width = 80;
            // 
            // Muonsach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1414, 667);
            this.Controls.Add(this.button_muonsach);
            this.Controls.Add(this.dateTimePicker_tradk);
            this.Controls.Add(this.dateTimePicker_muon);
            this.Controls.Add(this.label_ngtradk);
            this.Controls.Add(this.label_ngmuon);
            this.Controls.Add(this.bangds);
            this.Controls.Add(this.label_ds);
            this.Controls.Add(this.textBox_timkiem);
            this.Controls.Add(this.label_timkiem);
            this.Controls.Add(this.panel_kedoc);
            this.Controls.Add(this.panel_thanhngang);
            this.Controls.Add(this.button_Muon);
            this.Controls.Add(this.button_Tra);
            this.Controls.Add(this.button_TrangChu);
            this.Controls.Add(this.button_HSDKy);
            this.Controls.Add(this.button_DXuat);
            this.Controls.Add(this.button_quyengop);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Muonsach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mượn Sách";
            this.Load += new System.EventHandler(this.MuonSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bangds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_kedoc;
        private System.Windows.Forms.Panel panel_thanhngang;
        private System.Windows.Forms.Button button_Muon;
        private System.Windows.Forms.Button button_Tra;
        private System.Windows.Forms.Button button_TrangChu;
        private System.Windows.Forms.Button button_HSDKy;
        private System.Windows.Forms.Button button_DXuat;
        private System.Windows.Forms.Button button_quyengop;
        private System.Windows.Forms.Label label_timkiem;
        private System.Windows.Forms.TextBox textBox_timkiem;
        private System.Windows.Forms.Label label_ds;
        private System.Windows.Forms.DataGridView bangds;
        private System.Windows.Forms.Label label_ngmuon;
        private System.Windows.Forms.Label label_ngtradk;
        private System.Windows.Forms.DateTimePicker dateTimePicker_muon;
        private System.Windows.Forms.DateTimePicker dateTimePicker_tradk;
        private System.Windows.Forms.Button button_muonsach;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn tensach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_masach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_tacgia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_sluongmuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_slconlai;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_chon;
    }
}