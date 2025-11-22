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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlKhoSach = new System.Windows.Forms.TabControl();
            this.tabPageSach = new System.Windows.Forms.TabPage();
            this.btnfind = new System.Windows.Forms.Button();
            this.dsSach = new System.Windows.Forms.DataGridView();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
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
            this.dsLoaiSach = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTenLoaiSach = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaLoaiSach = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tabPageTacGia = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTenTacGia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaTacGia = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.dsTacGia = new System.Windows.Forms.DataGridView();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
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
            this.tabPageSach.Controls.Add(this.btnfind);
            this.tabPageSach.Controls.Add(this.dsSach);
            this.tabPageSach.Controls.Add(this.btnexit);
            this.tabPageSach.Controls.Add(this.btnclear);
            this.tabPageSach.Controls.Add(this.btnedit);
            this.tabPageSach.Controls.Add(this.btnadd);
            this.tabPageSach.Controls.Add(this.groupBox1);
            this.tabPageSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageSach.Location = new System.Drawing.Point(4, 34);
            this.tabPageSach.Name = "tabPageSach";
            this.tabPageSach.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSach.Size = new System.Drawing.Size(894, 596);
            this.tabPageSach.TabIndex = 0;
            this.tabPageSach.Text = "Sách";
            // 
            // btnfind
            // 
            this.btnfind.BackgroundImage = global::BookManagement.Properties.Resources.view;
            this.btnfind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnfind.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfind.Location = new System.Drawing.Point(140, 243);
            this.btnfind.Name = "btnfind";
            this.btnfind.Size = new System.Drawing.Size(93, 94);
            this.btnfind.TabIndex = 7;
            this.btnfind.UseVisualStyleBackColor = true;
            // 
            // dsSach
            // 
            this.dsSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dsSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dsSach.DefaultCellStyle = dataGridViewCellStyle4;
            this.dsSach.Location = new System.Drawing.Point(12, 356);
            this.dsSach.Name = "dsSach";
            this.dsSach.RowHeadersWidth = 62;
            this.dsSach.RowTemplate.Height = 28;
            this.dsSach.Size = new System.Drawing.Size(874, 232);
            this.dsSach.TabIndex = 6;
            this.dsSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dsSach_CellContentClick);
            // 
            // btnexit
            // 
            this.btnexit.BackgroundImage = global::BookManagement.Properties.Resources.icons8_exit_100__1_;
            this.btnexit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnexit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.Location = new System.Drawing.Point(677, 243);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(96, 94);
            this.btnexit.TabIndex = 5;
            this.btnexit.UseVisualStyleBackColor = true;
            // 
            // btnclear
            // 
            this.btnclear.BackgroundImage = global::BookManagement.Properties.Resources.clear;
            this.btnclear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.Location = new System.Drawing.Point(546, 243);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(96, 94);
            this.btnclear.TabIndex = 4;
            this.btnclear.UseVisualStyleBackColor = true;
            // 
            // btnedit
            // 
            this.btnedit.BackgroundImage = global::BookManagement.Properties.Resources.edit;
            this.btnedit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnedit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.Location = new System.Drawing.Point(417, 243);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(96, 94);
            this.btnedit.TabIndex = 3;
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnadd
            // 
            this.btnadd.BackgroundImage = global::BookManagement.Properties.Resources.add;
            this.btnadd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnadd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(277, 243);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(93, 94);
            this.btnadd.TabIndex = 1;
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
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
            this.label5.Size = new System.Drawing.Size(152, 27);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mã Loại Sách:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(420, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mã Tác Giả:";
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
            this.tabPageLoaiSach.Controls.Add(this.dsLoaiSach);
            this.tabPageLoaiSach.Controls.Add(this.button1);
            this.tabPageLoaiSach.Controls.Add(this.groupBox2);
            this.tabPageLoaiSach.Controls.Add(this.button2);
            this.tabPageLoaiSach.Controls.Add(this.button3);
            this.tabPageLoaiSach.Controls.Add(this.button4);
            this.tabPageLoaiSach.Controls.Add(this.button5);
            this.tabPageLoaiSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageLoaiSach.Location = new System.Drawing.Point(4, 34);
            this.tabPageLoaiSach.Name = "tabPageLoaiSach";
            this.tabPageLoaiSach.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLoaiSach.Size = new System.Drawing.Size(894, 596);
            this.tabPageLoaiSach.TabIndex = 1;
            this.tabPageLoaiSach.Text = "Loại sách";
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
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::BookManagement.Properties.Resources.view;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(47, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 94);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = true;
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
            // button2
            // 
            this.button2.BackgroundImage = global::BookManagement.Properties.Resources.icons8_exit_100__1_;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(584, 189);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 94);
            this.button2.TabIndex = 11;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::BookManagement.Properties.Resources.clear;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(453, 189);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 94);
            this.button3.TabIndex = 10;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::BookManagement.Properties.Resources.edit;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(324, 189);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 94);
            this.button4.TabIndex = 9;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::BookManagement.Properties.Resources.add;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(184, 189);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 94);
            this.button5.TabIndex = 8;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // tabPageTacGia
            // 
            this.tabPageTacGia.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tabPageTacGia.Controls.Add(this.button6);
            this.tabPageTacGia.Controls.Add(this.groupBox3);
            this.tabPageTacGia.Controls.Add(this.button7);
            this.tabPageTacGia.Controls.Add(this.dsTacGia);
            this.tabPageTacGia.Controls.Add(this.button8);
            this.tabPageTacGia.Controls.Add(this.button9);
            this.tabPageTacGia.Controls.Add(this.button10);
            this.tabPageTacGia.Location = new System.Drawing.Point(4, 34);
            this.tabPageTacGia.Name = "tabPageTacGia";
            this.tabPageTacGia.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTacGia.Size = new System.Drawing.Size(894, 596);
            this.tabPageTacGia.TabIndex = 2;
            this.tabPageTacGia.Text = "Tác giả";
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::BookManagement.Properties.Resources.view;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(30, 192);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 94);
            this.button6.TabIndex = 16;
            this.button6.UseVisualStyleBackColor = true;
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
            // button7
            // 
            this.button7.BackgroundImage = global::BookManagement.Properties.Resources.icons8_exit_100__1_;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(567, 192);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 94);
            this.button7.TabIndex = 15;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // dsTacGia
            // 
            this.dsTacGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dsTacGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dsTacGia.DefaultCellStyle = dataGridViewCellStyle5;
            this.dsTacGia.Location = new System.Drawing.Point(9, 308);
            this.dsTacGia.Name = "dsTacGia";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dsTacGia.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dsTacGia.RowHeadersWidth = 62;
            this.dsTacGia.RowTemplate.Height = 28;
            this.dsTacGia.Size = new System.Drawing.Size(660, 281);
            this.dsTacGia.TabIndex = 13;
            // 
            // button8
            // 
            this.button8.BackgroundImage = global::BookManagement.Properties.Resources.clear;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(436, 192);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(96, 94);
            this.button8.TabIndex = 14;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.BackgroundImage = global::BookManagement.Properties.Resources.edit;
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(307, 192);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(96, 94);
            this.button9.TabIndex = 13;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.BackgroundImage = global::BookManagement.Properties.Resources.add;
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(167, 192);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(93, 94);
            this.button10.TabIndex = 12;
            this.button10.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.TabPage tabPageTacGia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridView dsSach;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTenLoaiSach;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaLoaiSach;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dsTacGia;
        private System.Windows.Forms.TextBox txtTenTacGia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaTacGia;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnfind;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DataGridView dsLoaiSach;
        private System.Windows.Forms.TextBox txtLoaiSach;
        private System.Windows.Forms.TextBox txtTacGia;
    }
}