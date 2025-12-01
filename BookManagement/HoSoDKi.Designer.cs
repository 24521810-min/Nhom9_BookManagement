using System.Drawing;
using System.Windows.Forms;

namespace BookManagement
{
    partial class HoSoDKi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HoSoDKi));
            this.label_hoso = new System.Windows.Forms.Label();
            this.label_ttCaNhan = new System.Windows.Forms.Label();
            this.label_ttTaiKhoan = new System.Windows.Forms.Label();
            this.label_HoTen = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label_sdt = new System.Windows.Forms.Label();
            this.label_NgSinh = new System.Windows.Forms.Label();
            this.label_GioiTinh = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.label_status = new System.Windows.Forms.Label();
            this.groupBox_muon = new System.Windows.Forms.GroupBox();
            this.label_tsMuon = new System.Windows.Forms.Label();
            this.label_tongmuon = new System.Windows.Forms.Label();
            this.groupBox_tra = new System.Windows.Forms.GroupBox();
            this.label_tsTra = new System.Windows.Forms.Label();
            this.label_tongtra = new System.Windows.Forms.Label();
            this.groupBox_quyengop = new System.Windows.Forms.GroupBox();
            this.label_tsQuyenGop = new System.Windows.Forms.Label();
            this.label_tongquyengop = new System.Windows.Forms.Label();
            this.textBox_hoten = new System.Windows.Forms.TextBox();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.textBox_sdt = new System.Windows.Forms.TextBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.dateTimePicker_ngSinh = new System.Windows.Forms.DateTimePicker();
            this.comboBox_gioitinh = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_update = new System.Windows.Forms.Button();
            this.pictureBox_home = new System.Windows.Forms.PictureBox();
            this.groupBox_muon.SuspendLayout();
            this.groupBox_tra.SuspendLayout();
            this.groupBox_quyengop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_home)).BeginInit();
            this.SuspendLayout();
            // 
            // label_hoso
            // 
            this.label_hoso.AutoSize = true;
            this.label_hoso.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hoso.Location = new System.Drawing.Point(356, 18);
            this.label_hoso.Name = "label_hoso";
            this.label_hoso.Size = new System.Drawing.Size(253, 41);
            this.label_hoso.TabIndex = 0;
            this.label_hoso.Text = "HỒ SƠ ĐĂNG KÝ";
            // 
            // label_ttCaNhan
            // 
            this.label_ttCaNhan.AutoSize = true;
            this.label_ttCaNhan.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ttCaNhan.Location = new System.Drawing.Point(33, 78);
            this.label_ttCaNhan.Name = "label_ttCaNhan";
            this.label_ttCaNhan.Size = new System.Drawing.Size(208, 31);
            this.label_ttCaNhan.TabIndex = 1;
            this.label_ttCaNhan.Text = "Thông tin cá nhân";
            // 
            // label_ttTaiKhoan
            // 
            this.label_ttTaiKhoan.AutoSize = true;
            this.label_ttTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ttTaiKhoan.Location = new System.Drawing.Point(555, 78);
            this.label_ttTaiKhoan.Name = "label_ttTaiKhoan";
            this.label_ttTaiKhoan.Size = new System.Drawing.Size(226, 31);
            this.label_ttTaiKhoan.TabIndex = 2;
            this.label_ttTaiKhoan.Text = "Thông tin tài khoản";
            // 
            // label_HoTen
            // 
            this.label_HoTen.AutoSize = true;
            this.label_HoTen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_HoTen.Location = new System.Drawing.Point(34, 131);
            this.label_HoTen.Name = "label_HoTen";
            this.label_HoTen.Size = new System.Drawing.Size(72, 28);
            this.label_HoTen.TabIndex = 5;
            this.label_HoTen.Text = "Họ Tên";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_email.Location = new System.Drawing.Point(34, 178);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(59, 28);
            this.label_email.TabIndex = 6;
            this.label_email.Text = "Email";
            // 
            // label_sdt
            // 
            this.label_sdt.AutoSize = true;
            this.label_sdt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sdt.Location = new System.Drawing.Point(34, 225);
            this.label_sdt.Name = "label_sdt";
            this.label_sdt.Size = new System.Drawing.Size(128, 28);
            this.label_sdt.TabIndex = 7;
            this.label_sdt.Text = "Số điện thoại";
            // 
            // label_NgSinh
            // 
            this.label_NgSinh.AutoSize = true;
            this.label_NgSinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NgSinh.Location = new System.Drawing.Point(34, 275);
            this.label_NgSinh.Name = "label_NgSinh";
            this.label_NgSinh.Size = new System.Drawing.Size(99, 28);
            this.label_NgSinh.TabIndex = 8;
            this.label_NgSinh.Text = "Ngày sinh";
            // 
            // label_GioiTinh
            // 
            this.label_GioiTinh.AutoSize = true;
            this.label_GioiTinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_GioiTinh.Location = new System.Drawing.Point(34, 320);
            this.label_GioiTinh.Name = "label_GioiTinh";
            this.label_GioiTinh.Size = new System.Drawing.Size(87, 28);
            this.label_GioiTinh.TabIndex = 9;
            this.label_GioiTinh.Text = "Giới tính";
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_username.Location = new System.Drawing.Point(565, 131);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(140, 28);
            this.label_username.TabIndex = 10;
            this.label_username.Text = "Tên đăng nhập";
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.Location = new System.Drawing.Point(565, 181);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(184, 28);
            this.label_status.TabIndex = 12;
            this.label_status.Text = "Trạng thái tài khoản";
            // 
            // groupBox_muon
            // 
            this.groupBox_muon.BackColor = System.Drawing.Color.Tan;
            this.groupBox_muon.Controls.Add(this.label_tsMuon);
            this.groupBox_muon.Controls.Add(this.label_tongmuon);
            this.groupBox_muon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_muon.Location = new System.Drawing.Point(70, 420);
            this.groupBox_muon.Name = "groupBox_muon";
            this.groupBox_muon.Size = new System.Drawing.Size(244, 85);
            this.groupBox_muon.TabIndex = 13;
            this.groupBox_muon.TabStop = false;
            this.groupBox_muon.Text = "Sách đã mượn";
            // 
            // label_tsMuon
            // 
            this.label_tsMuon.AutoSize = true;
            this.label_tsMuon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tsMuon.Location = new System.Drawing.Point(105, 43);
            this.label_tsMuon.Name = "label_tsMuon";
            this.label_tsMuon.Size = new System.Drawing.Size(23, 28);
            this.label_tsMuon.TabIndex = 24;
            this.label_tsMuon.Text = "0";
            // 
            // label_tongmuon
            // 
            this.label_tongmuon.AutoSize = true;
            this.label_tongmuon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tongmuon.Location = new System.Drawing.Point(24, 43);
            this.label_tongmuon.Name = "label_tongmuon";
            this.label_tongmuon.Size = new System.Drawing.Size(61, 28);
            this.label_tongmuon.TabIndex = 23;
            this.label_tongmuon.Text = "Tổng:";
            // 
            // groupBox_tra
            // 
            this.groupBox_tra.BackColor = System.Drawing.Color.Tan;
            this.groupBox_tra.Controls.Add(this.label_tsTra);
            this.groupBox_tra.Controls.Add(this.label_tongtra);
            this.groupBox_tra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_tra.Location = new System.Drawing.Point(363, 420);
            this.groupBox_tra.Name = "groupBox_tra";
            this.groupBox_tra.Size = new System.Drawing.Size(244, 85);
            this.groupBox_tra.TabIndex = 14;
            this.groupBox_tra.TabStop = false;
            this.groupBox_tra.Text = "Sách đã trả";
            // 
            // label_tsTra
            // 
            this.label_tsTra.AutoSize = true;
            this.label_tsTra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tsTra.Location = new System.Drawing.Point(116, 43);
            this.label_tsTra.Name = "label_tsTra";
            this.label_tsTra.Size = new System.Drawing.Size(23, 28);
            this.label_tsTra.TabIndex = 25;
            this.label_tsTra.Text = "0";
            // 
            // label_tongtra
            // 
            this.label_tongtra.AutoSize = true;
            this.label_tongtra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tongtra.Location = new System.Drawing.Point(35, 43);
            this.label_tongtra.Name = "label_tongtra";
            this.label_tongtra.Size = new System.Drawing.Size(61, 28);
            this.label_tongtra.TabIndex = 24;
            this.label_tongtra.Text = "Tổng:";
            // 
            // groupBox_quyengop
            // 
            this.groupBox_quyengop.BackColor = System.Drawing.Color.Tan;
            this.groupBox_quyengop.Controls.Add(this.label_tsQuyenGop);
            this.groupBox_quyengop.Controls.Add(this.label_tongquyengop);
            this.groupBox_quyengop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_quyengop.Location = new System.Drawing.Point(651, 420);
            this.groupBox_quyengop.Name = "groupBox_quyengop";
            this.groupBox_quyengop.Size = new System.Drawing.Size(244, 85);
            this.groupBox_quyengop.TabIndex = 15;
            this.groupBox_quyengop.TabStop = false;
            this.groupBox_quyengop.Text = "Sách đã quyên góp";
            // 
            // label_tsQuyenGop
            // 
            this.label_tsQuyenGop.AutoSize = true;
            this.label_tsQuyenGop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tsQuyenGop.Location = new System.Drawing.Point(115, 43);
            this.label_tsQuyenGop.Name = "label_tsQuyenGop";
            this.label_tsQuyenGop.Size = new System.Drawing.Size(23, 28);
            this.label_tsQuyenGop.TabIndex = 25;
            this.label_tsQuyenGop.Text = "0";
            // 
            // label_tongquyengop
            // 
            this.label_tongquyengop.AutoSize = true;
            this.label_tongquyengop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tongquyengop.Location = new System.Drawing.Point(34, 43);
            this.label_tongquyengop.Name = "label_tongquyengop";
            this.label_tongquyengop.Size = new System.Drawing.Size(61, 28);
            this.label_tongquyengop.TabIndex = 24;
            this.label_tongquyengop.Text = "Tổng:";
            // 
            // textBox_hoten
            // 
            this.textBox_hoten.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_hoten.Location = new System.Drawing.Point(163, 128);
            this.textBox_hoten.Name = "textBox_hoten";
            this.textBox_hoten.Size = new System.Drawing.Size(284, 34);
            this.textBox_hoten.TabIndex = 16;
            // 
            // textBox_email
            // 
            this.textBox_email.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_email.Location = new System.Drawing.Point(163, 175);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(284, 34);
            this.textBox_email.TabIndex = 17;
            // 
            // textBox_sdt
            // 
            this.textBox_sdt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_sdt.Location = new System.Drawing.Point(163, 222);
            this.textBox_sdt.Name = "textBox_sdt";
            this.textBox_sdt.Size = new System.Drawing.Size(284, 34);
            this.textBox_sdt.TabIndex = 18;
            // 
            // textBox_username
            // 
            this.textBox_username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_username.Location = new System.Drawing.Point(725, 128);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(227, 34);
            this.textBox_username.TabIndex = 19;
            // 
            // dateTimePicker_ngSinh
            // 
            this.dateTimePicker_ngSinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_ngSinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_ngSinh.Location = new System.Drawing.Point(163, 270);
            this.dateTimePicker_ngSinh.Name = "dateTimePicker_ngSinh";
            this.dateTimePicker_ngSinh.Size = new System.Drawing.Size(284, 34);
            this.dateTimePicker_ngSinh.TabIndex = 20;
            // 
            // comboBox_gioitinh
            // 
            this.comboBox_gioitinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_gioitinh.FormattingEnabled = true;
            this.comboBox_gioitinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.comboBox_gioitinh.Location = new System.Drawing.Point(163, 317);
            this.comboBox_gioitinh.Name = "comboBox_gioitinh";
            this.comboBox_gioitinh.Size = new System.Drawing.Size(284, 36);
            this.comboBox_gioitinh.TabIndex = 21;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(755, 178);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(197, 34);
            this.textBox1.TabIndex = 22;
            // 
            // button_update
            // 
            this.button_update.BackColor = System.Drawing.Color.Tan;
            this.button_update.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_update.Location = new System.Drawing.Point(651, 275);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(231, 47);
            this.button_update.TabIndex = 23;
            this.button_update.Text = "Cập nhật";
            this.button_update.UseVisualStyleBackColor = false;
            // 
            // pictureBox_home
            // 
            this.pictureBox_home.BackColor = System.Drawing.Color.FloralWhite;
            this.pictureBox_home.BackgroundImage = global::BookManagement.Properties.Resources.florawhit;
            this.pictureBox_home.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_home.Image")));
            this.pictureBox_home.Location = new System.Drawing.Point(898, 11);
            this.pictureBox_home.Name = "pictureBox_home";
            this.pictureBox_home.Size = new System.Drawing.Size(54, 48);
            this.pictureBox_home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_home.TabIndex = 24;
            this.pictureBox_home.TabStop = false;
            this.pictureBox_home.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // HoSoDKi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(964, 524);
            this.Controls.Add(this.pictureBox_home);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox_gioitinh);
            this.Controls.Add(this.dateTimePicker_ngSinh);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.textBox_sdt);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.textBox_hoten);
            this.Controls.Add(this.groupBox_quyengop);
            this.Controls.Add(this.groupBox_tra);
            this.Controls.Add(this.groupBox_muon);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.label_GioiTinh);
            this.Controls.Add(this.label_NgSinh);
            this.Controls.Add(this.label_sdt);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_HoTen);
            this.Controls.Add(this.label_ttTaiKhoan);
            this.Controls.Add(this.label_ttCaNhan);
            this.Controls.Add(this.label_hoso);
            this.Name = "HoSoDKi";
            this.Text = "Hồ Sơ Đăng Ký";
            this.Load += new System.EventHandler(this.HoSoDKi_Load);
            this.groupBox_muon.ResumeLayout(false);
            this.groupBox_muon.PerformLayout();
            this.groupBox_tra.ResumeLayout(false);
            this.groupBox_tra.PerformLayout();
            this.groupBox_quyengop.ResumeLayout(false);
            this.groupBox_quyengop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_home)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_hoso;
        private System.Windows.Forms.Label label_ttCaNhan;
        private System.Windows.Forms.Label label_ttTaiKhoan;
        private System.Windows.Forms.Label label_HoTen;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Label label_sdt;
        private System.Windows.Forms.Label label_NgSinh;
        private System.Windows.Forms.Label label_GioiTinh;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.GroupBox groupBox_muon;
        private System.Windows.Forms.GroupBox groupBox_tra;
        private System.Windows.Forms.GroupBox groupBox_quyengop;
        private System.Windows.Forms.TextBox textBox_hoten;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.TextBox textBox_sdt;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ngSinh;
        private System.Windows.Forms.ComboBox comboBox_gioitinh;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_tsMuon;
        private System.Windows.Forms.Label label_tongmuon;
        private System.Windows.Forms.Label label_tsTra;
        private System.Windows.Forms.Label label_tongtra;
        private System.Windows.Forms.Label label_tsQuyenGop;
        private System.Windows.Forms.Label label_tongquyengop;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.PictureBox pictureBox_home;
    }
}