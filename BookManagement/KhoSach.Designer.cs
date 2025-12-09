namespace BookManagement
{
    partial class KhoSach
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
            this.tabControlKhoSach = new System.Windows.Forms.TabControl();
            this.tabPageSach = new System.Windows.Forms.TabPage();
            this.btnsearchSach = new System.Windows.Forms.Button();
            this.btnviewSach = new System.Windows.Forms.Button();
            this.dsSach = new System.Windows.Forms.DataGridView();
            this.btnexitSach = new System.Windows.Forms.Button();
            this.btnclearSach = new System.Windows.Forms.Button();
            this.btneditSach = new System.Windows.Forms.Button();
            this.btnaddSach = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLoaiSach = new System.Windows.Forms.TextBox();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageLoaiSach = new System.Windows.Forms.TabPage();
            this.btnsearchLoaiSach = new System.Windows.Forms.Button();
            this.btnviewLoaiSach = new System.Windows.Forms.Button();
            this.btnexitLoaiSach = new System.Windows.Forms.Button();
            this.btnclearLoaiSach = new System.Windows.Forms.Button();
            this.btnaddLoaiSach = new System.Windows.Forms.Button();
            this.dsLoaiSach = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTenLoaiSach = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaLoaiSach = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPageTacGia = new System.Windows.Forms.TabPage();
            this.btnsearchTacGia = new System.Windows.Forms.Button();
            this.btnviewTacGia = new System.Windows.Forms.Button();
            this.btnexitTacGia = new System.Windows.Forms.Button();
            this.btnclearTacGia = new System.Windows.Forms.Button();
            this.btnaddTacGia = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTenTacGia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaTacGia = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dsTacGia = new System.Windows.Forms.DataGridView();
            this.btneditTacGia = new System.Windows.Forms.Button();
            this.btneditLoaiSach = new System.Windows.Forms.Button();
            this.tabControlKhoSach.SuspendLayout();
            this.tabPageSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsSach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPageLoaiSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsLoaiSach)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPageTacGia.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsTacGia)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlKhoSach
            // 
            this.tabControlKhoSach.CausesValidation = false;
            this.tabControlKhoSach.Controls.Add(this.tabPageSach);
            this.tabControlKhoSach.Controls.Add(this.tabPageLoaiSach);
            this.tabControlKhoSach.Controls.Add(this.tabPageTacGia);
            this.tabControlKhoSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlKhoSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlKhoSach.ItemSize = new System.Drawing.Size(120, 30);
            this.tabControlKhoSach.Location = new System.Drawing.Point(0, 0);
            this.tabControlKhoSach.Name = "tabControlKhoSach";
            this.tabControlKhoSach.SelectedIndex = 0;
            this.tabControlKhoSach.Size = new System.Drawing.Size(902, 634);
            this.tabControlKhoSach.TabIndex = 0;
            // 
            // tabPageSach
            // 
            this.tabPageSach.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tabPageSach.Controls.Add(this.btnsearchSach);
            this.tabPageSach.Controls.Add(this.btnviewSach);
            this.tabPageSach.Controls.Add(this.dsSach);
            this.tabPageSach.Controls.Add(this.btnexitSach);
            this.tabPageSach.Controls.Add(this.btnclearSach);
            this.tabPageSach.Controls.Add(this.btneditSach);
            this.tabPageSach.Controls.Add(this.btnaddSach);
            this.tabPageSach.Controls.Add(this.groupBox1);
            this.tabPageSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageSach.Location = new System.Drawing.Point(4, 34);
            this.tabPageSach.Name = "tabPageSach";
            this.tabPageSach.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSach.Size = new System.Drawing.Size(894, 596);
            this.tabPageSach.TabIndex = 0;
            this.tabPageSach.Text = "Sách";
            // 
            // btnsearchSach
            // 
            this.btnsearchSach.BackgroundImage = global::BookManagement.Properties.Resources.search;
            this.btnsearchSach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsearchSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearchSach.Location = new System.Drawing.Point(196, 243);
            this.btnsearchSach.Name = "btnsearchSach";
            this.btnsearchSach.Size = new System.Drawing.Size(93, 94);
            this.btnsearchSach.TabIndex = 8;
            this.btnsearchSach.UseVisualStyleBackColor = true;
            this.btnsearchSach.Click += new System.EventHandler(this.btnsearchSach_Click);
            // 
            // btnviewSach
            // 
            this.btnviewSach.BackgroundImage = global::BookManagement.Properties.Resources.view;
            this.btnviewSach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnviewSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewSach.Location = new System.Drawing.Point(69, 243);
            this.btnviewSach.Name = "btnviewSach";
            this.btnviewSach.Size = new System.Drawing.Size(93, 94);
            this.btnviewSach.TabIndex = 7;
            this.btnviewSach.UseVisualStyleBackColor = true;
            this.btnviewSach.Click += new System.EventHandler(this.btnviewSach_Click);
            // 
            // dsSach
            // 
            this.dsSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dsSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsSach.Location = new System.Drawing.Point(12, 356);
            this.dsSach.Name = "dsSach";
            this.dsSach.RowHeadersWidth = 62;
            this.dsSach.RowTemplate.Height = 28;
            this.dsSach.Size = new System.Drawing.Size(874, 232);
            this.dsSach.TabIndex = 6;
            this.dsSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dsSach_CellClick);
            // 
            // btnexitSach
            // 
            this.btnexitSach.BackgroundImage = global::BookManagement.Properties.Resources.icons8_exit_100__1_;
            this.btnexitSach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnexitSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexitSach.Location = new System.Drawing.Point(720, 243);
            this.btnexitSach.Name = "btnexitSach";
            this.btnexitSach.Size = new System.Drawing.Size(96, 94);
            this.btnexitSach.TabIndex = 5;
            this.btnexitSach.UseVisualStyleBackColor = true;
            this.btnexitSach.Click += new System.EventHandler(this.btnexitSach_Click);
            // 
            // btnclearSach
            // 
            this.btnclearSach.BackgroundImage = global::BookManagement.Properties.Resources.clear;
            this.btnclearSach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclearSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclearSach.Location = new System.Drawing.Point(587, 243);
            this.btnclearSach.Name = "btnclearSach";
            this.btnclearSach.Size = new System.Drawing.Size(96, 94);
            this.btnclearSach.TabIndex = 4;
            this.btnclearSach.UseVisualStyleBackColor = true;
            this.btnclearSach.Click += new System.EventHandler(this.btnclearSach_Click);
            // 
            // btneditSach
            // 
            this.btneditSach.BackgroundImage = global::BookManagement.Properties.Resources.edit;
            this.btneditSach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btneditSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneditSach.Location = new System.Drawing.Point(454, 243);
            this.btneditSach.Name = "btneditSach";
            this.btneditSach.Size = new System.Drawing.Size(96, 94);
            this.btneditSach.TabIndex = 3;
            this.btneditSach.UseVisualStyleBackColor = true;
            this.btneditSach.Click += new System.EventHandler(this.btneditSach_Click);
            // 
            // btnaddSach
            // 
            this.btnaddSach.BackgroundImage = global::BookManagement.Properties.Resources.add;
            this.btnaddSach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnaddSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddSach.Location = new System.Drawing.Point(322, 243);
            this.btnaddSach.Name = "btnaddSach";
            this.btnaddSach.Size = new System.Drawing.Size(93, 94);
            this.btnaddSach.TabIndex = 1;
            this.btnaddSach.UseVisualStyleBackColor = true;
            this.btnaddSach.Click += new System.EventHandler(this.btnaddSach_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLoaiSach);
            this.groupBox1.Controls.Add(this.txtTacGia);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSoLuong);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTenSach);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaSach);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(876, 219);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết Sách";
            // 
            // txtLoaiSach
            // 
            this.txtLoaiSach.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoaiSach.Location = new System.Drawing.Point(564, 100);
            this.txtLoaiSach.Name = "txtLoaiSach";
            this.txtLoaiSach.Size = new System.Drawing.Size(257, 35);
            this.txtLoaiSach.TabIndex = 11;
            // 
            // txtTacGia
            // 
            this.txtTacGia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTacGia.Location = new System.Drawing.Point(564, 42);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(257, 35);
            this.txtTacGia.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(400, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 27);
            this.label5.TabIndex = 9;
            this.label5.Text = "Loại Sách:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(420, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tác Giả:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(128, 158);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(257, 35);
            this.txtSoLuong.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số lượng:";
            // 
            // txtTenSach
            // 
            this.txtTenSach.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSach.Location = new System.Drawing.Point(128, 100);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(257, 35);
            this.txtTenSach.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Sách:";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSach.Location = new System.Drawing.Point(128, 42);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(257, 35);
            this.txtMaSach.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Sách:";
            // 
            // tabPageLoaiSach
            // 
            this.tabPageLoaiSach.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tabPageLoaiSach.Controls.Add(this.btnsearchLoaiSach);
            this.tabPageLoaiSach.Controls.Add(this.btnviewLoaiSach);
            this.tabPageLoaiSach.Controls.Add(this.btnexitLoaiSach);
            this.tabPageLoaiSach.Controls.Add(this.btnclearLoaiSach);
            this.tabPageLoaiSach.Controls.Add(this.btnaddLoaiSach);
            this.tabPageLoaiSach.Controls.Add(this.dsLoaiSach);
            this.tabPageLoaiSach.Controls.Add(this.groupBox2);
            this.tabPageLoaiSach.Controls.Add(this.btneditLoaiSach);
            this.tabPageLoaiSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageLoaiSach.Location = new System.Drawing.Point(4, 34);
            this.tabPageLoaiSach.Name = "tabPageLoaiSach";
            this.tabPageLoaiSach.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLoaiSach.Size = new System.Drawing.Size(894, 596);
            this.tabPageLoaiSach.TabIndex = 1;
            this.tabPageLoaiSach.Text = "Loại sách";
            // 
            // btnsearchLoaiSach
            // 
            this.btnsearchLoaiSach.BackgroundImage = global::BookManagement.Properties.Resources.search;
            this.btnsearchLoaiSach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsearchLoaiSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearchLoaiSach.Location = new System.Drawing.Point(133, 189);
            this.btnsearchLoaiSach.Name = "btnsearchLoaiSach";
            this.btnsearchLoaiSach.Size = new System.Drawing.Size(93, 94);
            this.btnsearchLoaiSach.TabIndex = 20;
            this.btnsearchLoaiSach.UseVisualStyleBackColor = true;
            this.btnsearchLoaiSach.Click += new System.EventHandler(this.btnsearchLoaiSach_Click);
            // 
            // btnviewLoaiSach
            // 
            this.btnviewLoaiSach.BackgroundImage = global::BookManagement.Properties.Resources.view;
            this.btnviewLoaiSach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnviewLoaiSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewLoaiSach.Location = new System.Drawing.Point(6, 189);
            this.btnviewLoaiSach.Name = "btnviewLoaiSach";
            this.btnviewLoaiSach.Size = new System.Drawing.Size(93, 94);
            this.btnviewLoaiSach.TabIndex = 19;
            this.btnviewLoaiSach.UseVisualStyleBackColor = true;
            this.btnviewLoaiSach.Click += new System.EventHandler(this.btnviewLoaiSach_Click);
            // 
            // btnexitLoaiSach
            // 
            this.btnexitLoaiSach.BackgroundImage = global::BookManagement.Properties.Resources.icons8_exit_100__1_;
            this.btnexitLoaiSach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnexitLoaiSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexitLoaiSach.Location = new System.Drawing.Point(657, 189);
            this.btnexitLoaiSach.Name = "btnexitLoaiSach";
            this.btnexitLoaiSach.Size = new System.Drawing.Size(96, 94);
            this.btnexitLoaiSach.TabIndex = 18;
            this.btnexitLoaiSach.UseVisualStyleBackColor = true;
            this.btnexitLoaiSach.Click += new System.EventHandler(this.btnexitLoaiSach_Click);
            // 
            // btnclearLoaiSach
            // 
            this.btnclearLoaiSach.BackgroundImage = global::BookManagement.Properties.Resources.clear;
            this.btnclearLoaiSach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclearLoaiSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclearLoaiSach.Location = new System.Drawing.Point(524, 189);
            this.btnclearLoaiSach.Name = "btnclearLoaiSach";
            this.btnclearLoaiSach.Size = new System.Drawing.Size(96, 94);
            this.btnclearLoaiSach.TabIndex = 17;
            this.btnclearLoaiSach.UseVisualStyleBackColor = true;
            this.btnclearLoaiSach.Click += new System.EventHandler(this.btnclearLoaiSach_Click);
            // 
            // btnaddLoaiSach
            // 
            this.btnaddLoaiSach.BackgroundImage = global::BookManagement.Properties.Resources.add;
            this.btnaddLoaiSach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnaddLoaiSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddLoaiSach.Location = new System.Drawing.Point(259, 189);
            this.btnaddLoaiSach.Name = "btnaddLoaiSach";
            this.btnaddLoaiSach.Size = new System.Drawing.Size(93, 94);
            this.btnaddLoaiSach.TabIndex = 15;
            this.btnaddLoaiSach.UseVisualStyleBackColor = true;
            this.btnaddLoaiSach.Click += new System.EventHandler(this.btnaddLoaiSach_Click);
            // 
            // dsLoaiSach
            // 
            this.dsLoaiSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dsLoaiSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsLoaiSach.Location = new System.Drawing.Point(34, 307);
            this.dsLoaiSach.Name = "dsLoaiSach";
            this.dsLoaiSach.RowHeadersWidth = 62;
            this.dsLoaiSach.RowTemplate.Height = 28;
            this.dsLoaiSach.Size = new System.Drawing.Size(687, 281);
            this.dsLoaiSach.TabIndex = 14;
            this.dsLoaiSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dsLoaiSach_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTenLoaiSach);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtMaLoaiSach);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(876, 176);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết Loại Sách";
            // 
            // txtTenLoaiSach
            // 
            this.txtTenLoaiSach.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLoaiSach.Location = new System.Drawing.Point(193, 100);
            this.txtTenLoaiSach.Name = "txtTenLoaiSach";
            this.txtTenLoaiSach.Size = new System.Drawing.Size(293, 35);
            this.txtTenLoaiSach.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 27);
            this.label9.TabIndex = 2;
            this.label9.Text = "Tên Loại Sách:";
            // 
            // txtMaLoaiSach
            // 
            this.txtMaLoaiSach.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLoaiSach.Location = new System.Drawing.Point(193, 42);
            this.txtMaLoaiSach.Name = "txtMaLoaiSach";
            this.txtMaLoaiSach.Size = new System.Drawing.Size(293, 35);
            this.txtMaLoaiSach.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 27);
            this.label10.TabIndex = 0;
            this.label10.Text = "Mã Loại Sách:";
            // 
            // tabPageTacGia
            // 
            this.tabPageTacGia.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tabPageTacGia.Controls.Add(this.btnsearchTacGia);
            this.tabPageTacGia.Controls.Add(this.btnviewTacGia);
            this.tabPageTacGia.Controls.Add(this.btnexitTacGia);
            this.tabPageTacGia.Controls.Add(this.btnclearTacGia);
            this.tabPageTacGia.Controls.Add(this.btnaddTacGia);
            this.tabPageTacGia.Controls.Add(this.groupBox3);
            this.tabPageTacGia.Controls.Add(this.dsTacGia);
            this.tabPageTacGia.Controls.Add(this.btneditTacGia);
            this.tabPageTacGia.Location = new System.Drawing.Point(4, 34);
            this.tabPageTacGia.Name = "tabPageTacGia";
            this.tabPageTacGia.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTacGia.Size = new System.Drawing.Size(894, 596);
            this.tabPageTacGia.TabIndex = 2;
            this.tabPageTacGia.Text = "Tác giả";
            // 
            // btnsearchTacGia
            // 
            this.btnsearchTacGia.BackgroundImage = global::BookManagement.Properties.Resources.search;
            this.btnsearchTacGia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsearchTacGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearchTacGia.Location = new System.Drawing.Point(142, 193);
            this.btnsearchTacGia.Name = "btnsearchTacGia";
            this.btnsearchTacGia.Size = new System.Drawing.Size(93, 94);
            this.btnsearchTacGia.TabIndex = 26;
            this.btnsearchTacGia.UseVisualStyleBackColor = true;
            this.btnsearchTacGia.Click += new System.EventHandler(this.btnsearchTacGia_Click);
            // 
            // btnviewTacGia
            // 
            this.btnviewTacGia.BackgroundImage = global::BookManagement.Properties.Resources.view;
            this.btnviewTacGia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnviewTacGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewTacGia.Location = new System.Drawing.Point(15, 193);
            this.btnviewTacGia.Name = "btnviewTacGia";
            this.btnviewTacGia.Size = new System.Drawing.Size(93, 94);
            this.btnviewTacGia.TabIndex = 25;
            this.btnviewTacGia.UseVisualStyleBackColor = true;
            this.btnviewTacGia.Click += new System.EventHandler(this.btnviewTacGia_Click);
            // 
            // btnexitTacGia
            // 
            this.btnexitTacGia.BackgroundImage = global::BookManagement.Properties.Resources.icons8_exit_100__1_;
            this.btnexitTacGia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnexitTacGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexitTacGia.Location = new System.Drawing.Point(666, 193);
            this.btnexitTacGia.Name = "btnexitTacGia";
            this.btnexitTacGia.Size = new System.Drawing.Size(96, 94);
            this.btnexitTacGia.TabIndex = 24;
            this.btnexitTacGia.UseVisualStyleBackColor = true;
            this.btnexitTacGia.Click += new System.EventHandler(this.btnexitTacGia_Click);
            // 
            // btnclearTacGia
            // 
            this.btnclearTacGia.BackgroundImage = global::BookManagement.Properties.Resources.clear;
            this.btnclearTacGia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclearTacGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclearTacGia.Location = new System.Drawing.Point(533, 193);
            this.btnclearTacGia.Name = "btnclearTacGia";
            this.btnclearTacGia.Size = new System.Drawing.Size(96, 94);
            this.btnclearTacGia.TabIndex = 23;
            this.btnclearTacGia.UseVisualStyleBackColor = true;
            this.btnclearTacGia.Click += new System.EventHandler(this.btnclearTacGia_Click);
            // 
            // btnaddTacGia
            // 
            this.btnaddTacGia.BackgroundImage = global::BookManagement.Properties.Resources.add;
            this.btnaddTacGia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnaddTacGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddTacGia.Location = new System.Drawing.Point(268, 193);
            this.btnaddTacGia.Name = "btnaddTacGia";
            this.btnaddTacGia.Size = new System.Drawing.Size(93, 94);
            this.btnaddTacGia.TabIndex = 21;
            this.btnaddTacGia.UseVisualStyleBackColor = true;
            this.btnaddTacGia.Click += new System.EventHandler(this.btnaddTacGia_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTenTacGia);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtMaTacGia);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(9, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(876, 167);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi tiết Tác Giả";
            // 
            // txtTenTacGia
            // 
            this.txtTenTacGia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenTacGia.Location = new System.Drawing.Point(193, 101);
            this.txtTenTacGia.Name = "txtTenTacGia";
            this.txtTenTacGia.Size = new System.Drawing.Size(293, 35);
            this.txtTenTacGia.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 27);
            this.label7.TabIndex = 8;
            this.label7.Text = "Tên Tác Giả:";
            // 
            // txtMaTacGia
            // 
            this.txtMaTacGia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaTacGia.Location = new System.Drawing.Point(193, 43);
            this.txtMaTacGia.Name = "txtMaTacGia";
            this.txtMaTacGia.Size = new System.Drawing.Size(293, 35);
            this.txtMaTacGia.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 27);
            this.label11.TabIndex = 6;
            this.label11.Text = "Mã Tác Giả:";
            // 
            // dsTacGia
            // 
            this.dsTacGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dsTacGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsTacGia.Location = new System.Drawing.Point(34, 307);
            this.dsTacGia.Name = "dsTacGia";
            this.dsTacGia.RowHeadersWidth = 62;
            this.dsTacGia.RowTemplate.Height = 28;
            this.dsTacGia.Size = new System.Drawing.Size(660, 281);
            this.dsTacGia.TabIndex = 13;
            this.dsTacGia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dsTacGia_CellClick);
            // 
            // btneditTacGia
            // 
            this.btneditTacGia.BackgroundImage = global::BookManagement.Properties.Resources.edit;
            this.btneditTacGia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btneditTacGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneditTacGia.Location = new System.Drawing.Point(400, 193);
            this.btneditTacGia.Name = "btneditTacGia";
            this.btneditTacGia.Size = new System.Drawing.Size(96, 94);
            this.btneditTacGia.TabIndex = 22;
            this.btneditTacGia.UseVisualStyleBackColor = true;
            this.btneditTacGia.Click += new System.EventHandler(this.btneditTacGia_Click);
            // 
            // btneditLoaiSach
            // 
            this.btneditLoaiSach.BackgroundImage = global::BookManagement.Properties.Resources.edit;
            this.btneditLoaiSach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btneditLoaiSach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneditLoaiSach.Location = new System.Drawing.Point(391, 189);
            this.btneditLoaiSach.Name = "btneditLoaiSach";
            this.btneditLoaiSach.Size = new System.Drawing.Size(96, 94);
            this.btneditLoaiSach.TabIndex = 16;
            this.btneditLoaiSach.UseVisualStyleBackColor = true;
            this.btneditLoaiSach.Click += new System.EventHandler(this.btneditLoaiSach_Click);
            // 
            // KhoSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(902, 634);
            this.Controls.Add(this.tabControlKhoSach);
            this.Name = "KhoSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KhoSach";
            this.tabControlKhoSach.ResumeLayout(false);
            this.tabPageSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsSach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageLoaiSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsLoaiSach)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPageTacGia.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsTacGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlKhoSach;
        private System.Windows.Forms.TabPage tabPageSach;
        private System.Windows.Forms.TabPage tabPageLoaiSach;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.Button btnaddSach;
        private System.Windows.Forms.Button btneditSach;
        private System.Windows.Forms.Button btnclearSach;
        private System.Windows.Forms.Button btnexitSach;
        private System.Windows.Forms.DataGridView dsSach;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTenLoaiSach;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaLoaiSach;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnviewSach;
        private System.Windows.Forms.DataGridView dsLoaiSach;
        private System.Windows.Forms.TextBox txtLoaiSach;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.Button btnsearchSach;
        private System.Windows.Forms.Button btnsearchLoaiSach;
        private System.Windows.Forms.Button btnviewLoaiSach;
        private System.Windows.Forms.Button btnexitLoaiSach;
        private System.Windows.Forms.Button btnclearLoaiSach;
        private System.Windows.Forms.Button btnaddLoaiSach;
        private System.Windows.Forms.TabPage tabPageTacGia;
        private System.Windows.Forms.Button btnsearchTacGia;
        private System.Windows.Forms.Button btnviewTacGia;
        private System.Windows.Forms.Button btnexitTacGia;
        private System.Windows.Forms.Button btnclearTacGia;
        private System.Windows.Forms.Button btnaddTacGia;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTenTacGia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaTacGia;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dsTacGia;
        private System.Windows.Forms.Button btneditLoaiSach;
        private System.Windows.Forms.Button btneditTacGia;
    }
}