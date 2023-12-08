namespace MNM2
{
    partial class fThongKeDoanhThu
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
            this.components = new System.ComponentModel.Container();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvNhap = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTime_Den = new System.Windows.Forms.DateTimePicker();
            this.dateTime_Tu = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNhapSL = new System.Windows.Forms.TextBox();
            this.txtTienXuat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvXuat = new System.Windows.Forms.DataGridView();
            this.txtTienNhap = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtXuatSL = new System.Windows.Forms.TextBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhap)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXuat)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvNhap);
            this.groupBox3.Location = new System.Drawing.Point(42, 217);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(419, 264);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thống kê hàng nhập";
            // 
            // dgvNhap
            // 
            this.dgvNhap.AllowUserToAddRows = false;
            this.dgvNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhap.Location = new System.Drawing.Point(3, 25);
            this.dgvNhap.MultiSelect = false;
            this.dgvNhap.Name = "dgvNhap";
            this.dgvNhap.ReadOnly = true;
            this.dgvNhap.RowHeadersVisible = false;
            this.dgvNhap.RowHeadersWidth = 51;
            this.dgvNhap.Size = new System.Drawing.Size(412, 239);
            this.dgvNhap.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTime_Den);
            this.groupBox2.Controls.Add(this.dateTime_Tu);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnLamMoi);
            this.groupBox2.Location = new System.Drawing.Point(42, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 117);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin doanh thu";
            // 
            // dateTime_Den
            // 
            this.dateTime_Den.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTime_Den.Location = new System.Drawing.Point(135, 52);
            this.dateTime_Den.Name = "dateTime_Den";
            this.dateTime_Den.Size = new System.Drawing.Size(182, 20);
            this.dateTime_Den.TabIndex = 37;
            this.dateTime_Den.ValueChanged += new System.EventHandler(this.dateTime_Den_ValueChanged);
            // 
            // dateTime_Tu
            // 
            this.dateTime_Tu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTime_Tu.Location = new System.Drawing.Point(135, 19);
            this.dateTime_Tu.Name = "dateTime_Tu";
            this.dateTime_Tu.Size = new System.Drawing.Size(182, 20);
            this.dateTime_Tu.TabIndex = 36;
            this.dateTime_Tu.ValueChanged += new System.EventHandler(this.dateTime_Tu_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(18, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Đến ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(15, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Từ ";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(242, 88);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoi.TabIndex = 31;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(348, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(339, 39);
            this.label2.TabIndex = 29;
            this.label2.Text = "Thống kê doanh thu";
            // 
            // txtNhapSL
            // 
            this.txtNhapSL.Location = new System.Drawing.Point(355, 500);
            this.txtNhapSL.Name = "txtNhapSL";
            this.txtNhapSL.ReadOnly = true;
            this.txtNhapSL.Size = new System.Drawing.Size(100, 20);
            this.txtNhapSL.TabIndex = 35;
            // 
            // txtTienXuat
            // 
            this.txtTienXuat.Location = new System.Drawing.Point(801, 535);
            this.txtTienXuat.Name = "txtTienXuat";
            this.txtTienXuat.ReadOnly = true;
            this.txtTienXuat.Size = new System.Drawing.Size(100, 20);
            this.txtTienXuat.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 535);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Tổng giá trị hàng nhập";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(491, 539);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Tổng giá trị hàng xuất";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvXuat);
            this.groupBox1.Location = new System.Drawing.Point(493, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 264);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê hàng xuất";
            // 
            // dgvXuat
            // 
            this.dgvXuat.AllowUserToAddRows = false;
            this.dgvXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXuat.Location = new System.Drawing.Point(3, 25);
            this.dgvXuat.MultiSelect = false;
            this.dgvXuat.Name = "dgvXuat";
            this.dgvXuat.ReadOnly = true;
            this.dgvXuat.RowHeadersVisible = false;
            this.dgvXuat.RowHeadersWidth = 51;
            this.dgvXuat.Size = new System.Drawing.Size(412, 239);
            this.dgvXuat.TabIndex = 0;
            // 
            // txtTienNhap
            // 
            this.txtTienNhap.Location = new System.Drawing.Point(355, 535);
            this.txtTienNhap.Name = "txtTienNhap";
            this.txtTienNhap.ReadOnly = true;
            this.txtTienNhap.Size = new System.Drawing.Size(100, 20);
            this.txtTienNhap.TabIndex = 39;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 504);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Tổng số lượng Sản phẩm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(491, 507);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Tổng số lượng Sản phẩm";
            // 
            // txtXuatSL
            // 
            this.txtXuatSL.Location = new System.Drawing.Point(801, 504);
            this.txtXuatSL.Name = "txtXuatSL";
            this.txtXuatSL.ReadOnly = true;
            this.txtXuatSL.Size = new System.Drawing.Size(100, 20);
            this.txtXuatSL.TabIndex = 41;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(725, 108);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(173, 20);
            this.txtTongTien.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(636, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Tổng doanh thu";
            // 
            // fThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtXuatSL);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTienNhap);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTienXuat);
            this.Controls.Add(this.txtNhapSL);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fThongKeDoanhThu";
            this.Size = new System.Drawing.Size(933, 598);
            this.Load += new System.EventHandler(this.fThongKeDoanhThu_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhap)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvXuat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvNhap;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTime_Den;
        private System.Windows.Forms.DateTimePicker dateTime_Tu;
        private System.Windows.Forms.TextBox txtNhapSL;
        private System.Windows.Forms.TextBox txtTienXuat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvXuat;
        private System.Windows.Forms.TextBox txtTienNhap;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtXuatSL;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label10;
    }
}
