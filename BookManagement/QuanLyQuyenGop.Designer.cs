namespace BookManagement
{
    partial class QuanLyQuyenGop
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dsQuyengop = new System.Windows.Forms.DataGridView();
            this.btnTuchoi = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsQuyengop)).BeginInit();
            this.SuspendLayout();
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(769, 433);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(163, 62);
            this.button8.TabIndex = 20;
            this.button8.Text = "Thoát";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(518, 433);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(163, 62);
            this.button7.TabIndex = 19;
            this.button7.Text = "Xem";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // btnDuyet
            // 
            this.btnDuyet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDuyet.Location = new System.Drawing.Point(39, 433);
            this.btnDuyet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(163, 62);
            this.btnDuyet.TabIndex = 18;
            this.btnDuyet.Text = "Duyệt";
            this.btnDuyet.UseVisualStyleBackColor = true;
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dsQuyengop);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 33);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(1107, 372);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh sách Quyên Góp";
            // 
            // dsQuyengop
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dsQuyengop.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dsQuyengop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dsQuyengop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsQuyengop.EnableHeadersVisualStyles = false;
            this.dsQuyengop.Location = new System.Drawing.Point(27, 43);
            this.dsQuyengop.Name = "dsQuyengop";
            this.dsQuyengop.RowHeadersWidth = 62;
            this.dsQuyengop.RowTemplate.Height = 28;
            this.dsQuyengop.Size = new System.Drawing.Size(1058, 311);
            this.dsQuyengop.TabIndex = 7;
            // 
            // btnTuchoi
            // 
            this.btnTuchoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuchoi.Location = new System.Drawing.Point(277, 433);
            this.btnTuchoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTuchoi.Name = "btnTuchoi";
            this.btnTuchoi.Size = new System.Drawing.Size(163, 62);
            this.btnTuchoi.TabIndex = 21;
            this.btnTuchoi.Text = "Từ chối";
            this.btnTuchoi.UseVisualStyleBackColor = true;
            this.btnTuchoi.Click += new System.EventHandler(this.btnTuchoi_Click);
            // 
            // QuanLyQuyenGop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1131, 557);
            this.Controls.Add(this.btnTuchoi);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnDuyet);
            this.Controls.Add(this.groupBox4);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "QuanLyQuyenGop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuanLyQuyenGop";
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsQuyengop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dsQuyengop;
        private System.Windows.Forms.Button btnTuchoi;
    }
}