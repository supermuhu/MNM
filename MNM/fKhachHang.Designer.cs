namespace MNM2
{
    partial class fKhachHang
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dateCapNhat = new System.Windows.Forms.CheckBox();
            this.tkDateCapNhat = new System.Windows.Forms.DateTimePicker();
            this.tkDateTao = new System.Windows.Forms.DateTimePicker();
            this.dateTao = new System.Windows.Forms.CheckBox();
            this.tkDiaChi = new System.Windows.Forms.TextBox();
            this.chkboDiaChi = new System.Windows.Forms.CheckBox();
            this.tkSDT = new System.Windows.Forms.TextBox();
            this.chkboSDT = new System.Windows.Forms.CheckBox();
            this.tkEmail = new System.Windows.Forms.TextBox();
            this.chkboEmail = new System.Windows.Forms.CheckBox();
            this.tkTen = new System.Windows.Forms.TextBox();
            this.chkboTen = new System.Windows.Forms.CheckBox();
            this.tkMa = new System.Windows.Forms.TextBox();
            this.chkboMa = new System.Windows.Forms.CheckBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.a = new System.Windows.Forms.Label();
            this.txtCapNhat = new System.Windows.Forms.TextBox();
            this.b = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.ddd = new System.Windows.Forms.Label();
            this.txtNgayTao = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(357, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 39);
            this.label2.TabIndex = 47;
            this.label2.Text = "Khách hàng";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(85, 579);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoi.TabIndex = 54;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dateCapNhat);
            this.groupBox4.Controls.Add(this.tkDateCapNhat);
            this.groupBox4.Controls.Add(this.tkDateTao);
            this.groupBox4.Controls.Add(this.dateTao);
            this.groupBox4.Controls.Add(this.tkDiaChi);
            this.groupBox4.Controls.Add(this.chkboDiaChi);
            this.groupBox4.Controls.Add(this.tkSDT);
            this.groupBox4.Controls.Add(this.chkboSDT);
            this.groupBox4.Controls.Add(this.tkEmail);
            this.groupBox4.Controls.Add(this.chkboEmail);
            this.groupBox4.Controls.Add(this.tkTen);
            this.groupBox4.Controls.Add(this.chkboTen);
            this.groupBox4.Controls.Add(this.tkMa);
            this.groupBox4.Controls.Add(this.chkboMa);
            this.groupBox4.Controls.Add(this.btnTimKiem);
            this.groupBox4.Location = new System.Drawing.Point(373, 97);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(573, 171);
            this.groupBox4.TabIndex = 57;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tìm kiếm khách hàng";
            // 
            // dateCapNhat
            // 
            this.dateCapNhat.AutoSize = true;
            this.dateCapNhat.Location = new System.Drawing.Point(233, 111);
            this.dateCapNhat.Name = "dateCapNhat";
            this.dateCapNhat.Size = new System.Drawing.Size(96, 17);
            this.dateCapNhat.TabIndex = 61;
            this.dateCapNhat.Text = "Ngày cập nhật";
            this.dateCapNhat.UseVisualStyleBackColor = true;
            this.dateCapNhat.CheckedChanged += new System.EventHandler(this.dateCapNhat_CheckedChanged);
            // 
            // tkDateCapNhat
            // 
            this.tkDateCapNhat.Enabled = false;
            this.tkDateCapNhat.Location = new System.Drawing.Point(233, 134);
            this.tkDateCapNhat.Name = "tkDateCapNhat";
            this.tkDateCapNhat.Size = new System.Drawing.Size(234, 20);
            this.tkDateCapNhat.TabIndex = 60;
            // 
            // tkDateTao
            // 
            this.tkDateTao.Enabled = false;
            this.tkDateTao.Location = new System.Drawing.Point(233, 77);
            this.tkDateTao.Name = "tkDateTao";
            this.tkDateTao.Size = new System.Drawing.Size(234, 20);
            this.tkDateTao.TabIndex = 59;
            // 
            // dateTao
            // 
            this.dateTao.AutoSize = true;
            this.dateTao.Location = new System.Drawing.Point(232, 54);
            this.dateTao.Name = "dateTao";
            this.dateTao.Size = new System.Drawing.Size(69, 17);
            this.dateTao.TabIndex = 58;
            this.dateTao.Text = "Ngày tạo";
            this.dateTao.UseVisualStyleBackColor = true;
            this.dateTao.CheckedChanged += new System.EventHandler(this.dateTao_CheckedChanged);
            // 
            // tkDiaChi
            // 
            this.tkDiaChi.Enabled = false;
            this.tkDiaChi.Location = new System.Drawing.Point(293, 19);
            this.tkDiaChi.Name = "tkDiaChi";
            this.tkDiaChi.Size = new System.Drawing.Size(138, 20);
            this.tkDiaChi.TabIndex = 57;
            // 
            // chkboDiaChi
            // 
            this.chkboDiaChi.AutoSize = true;
            this.chkboDiaChi.Location = new System.Drawing.Point(232, 21);
            this.chkboDiaChi.Name = "chkboDiaChi";
            this.chkboDiaChi.Size = new System.Drawing.Size(59, 17);
            this.chkboDiaChi.TabIndex = 56;
            this.chkboDiaChi.Text = "Địa chỉ";
            this.chkboDiaChi.UseVisualStyleBackColor = true;
            this.chkboDiaChi.CheckedChanged += new System.EventHandler(this.chkboDiaChi_CheckedChanged);
            // 
            // tkSDT
            // 
            this.tkSDT.Enabled = false;
            this.tkSDT.Location = new System.Drawing.Point(75, 133);
            this.tkSDT.Name = "tkSDT";
            this.tkSDT.Size = new System.Drawing.Size(138, 20);
            this.tkSDT.TabIndex = 55;
            // 
            // chkboSDT
            // 
            this.chkboSDT.AutoSize = true;
            this.chkboSDT.Location = new System.Drawing.Point(14, 135);
            this.chkboSDT.Name = "chkboSDT";
            this.chkboSDT.Size = new System.Drawing.Size(48, 17);
            this.chkboSDT.TabIndex = 54;
            this.chkboSDT.Text = "SĐT";
            this.chkboSDT.UseVisualStyleBackColor = true;
            this.chkboSDT.CheckedChanged += new System.EventHandler(this.chkboSDT_CheckedChanged);
            // 
            // tkEmail
            // 
            this.tkEmail.Enabled = false;
            this.tkEmail.Location = new System.Drawing.Point(75, 95);
            this.tkEmail.Name = "tkEmail";
            this.tkEmail.Size = new System.Drawing.Size(138, 20);
            this.tkEmail.TabIndex = 53;
            // 
            // chkboEmail
            // 
            this.chkboEmail.AutoSize = true;
            this.chkboEmail.Location = new System.Drawing.Point(14, 97);
            this.chkboEmail.Name = "chkboEmail";
            this.chkboEmail.Size = new System.Drawing.Size(51, 17);
            this.chkboEmail.TabIndex = 52;
            this.chkboEmail.Text = "Email";
            this.chkboEmail.UseVisualStyleBackColor = true;
            this.chkboEmail.CheckedChanged += new System.EventHandler(this.chkboEmail_CheckedChanged);
            // 
            // tkTen
            // 
            this.tkTen.Enabled = false;
            this.tkTen.Location = new System.Drawing.Point(75, 57);
            this.tkTen.Name = "tkTen";
            this.tkTen.Size = new System.Drawing.Size(138, 20);
            this.tkTen.TabIndex = 51;
            // 
            // chkboTen
            // 
            this.chkboTen.AutoSize = true;
            this.chkboTen.Location = new System.Drawing.Point(14, 59);
            this.chkboTen.Name = "chkboTen";
            this.chkboTen.Size = new System.Drawing.Size(45, 17);
            this.chkboTen.TabIndex = 50;
            this.chkboTen.Text = "Tên";
            this.chkboTen.UseVisualStyleBackColor = true;
            this.chkboTen.CheckedChanged += new System.EventHandler(this.chkboTen_CheckedChanged);
            // 
            // tkMa
            // 
            this.tkMa.Enabled = false;
            this.tkMa.Location = new System.Drawing.Point(75, 19);
            this.tkMa.Name = "tkMa";
            this.tkMa.Size = new System.Drawing.Size(138, 20);
            this.tkMa.TabIndex = 49;
            // 
            // chkboMa
            // 
            this.chkboMa.AutoSize = true;
            this.chkboMa.Location = new System.Drawing.Point(14, 21);
            this.chkboMa.Name = "chkboMa";
            this.chkboMa.Size = new System.Drawing.Size(41, 17);
            this.chkboMa.TabIndex = 40;
            this.chkboMa.Text = "Mã";
            this.chkboMa.UseVisualStyleBackColor = true;
            this.chkboMa.CheckedChanged += new System.EventHandler(this.chkboMa_CheckedChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(495, 37);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(63, 105);
            this.btnTimKiem.TabIndex = 39;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Location = new System.Drawing.Point(188, 560);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(178, 56);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tác vụ";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(6, 19);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(92, 19);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvKhachHang);
            this.groupBox3.Location = new System.Drawing.Point(373, 274);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(573, 342);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách khách hàng";
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.AllowUserToAddRows = false;
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.Location = new System.Drawing.Point(14, 19);
            this.dgvKhachHang.MultiSelect = false;
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.ReadOnly = true;
            this.dgvKhachHang.RowHeadersVisible = false;
            this.dgvKhachHang.RowHeadersWidth = 51;
            this.dgvKhachHang.Size = new System.Drawing.Size(544, 311);
            this.dgvKhachHang.TabIndex = 22;
            this.dgvKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtDiaChi);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDienThoai);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.a);
            this.groupBox2.Controls.Add(this.txtCapNhat);
            this.groupBox2.Controls.Add(this.b);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtMaKH);
            this.groupBox2.Controls.Add(this.txtTenKH);
            this.groupBox2.Controls.Add(this.ddd);
            this.groupBox2.Controls.Add(this.txtNgayTao);
            this.groupBox2.Location = new System.Drawing.Point(11, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 457);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin khách hàng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(6, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 16);
            this.label10.TabIndex = 48;
            this.label10.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(52, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 16);
            this.label7.TabIndex = 47;
            this.label7.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(16, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 16);
            this.label6.TabIndex = 46;
            this.label6.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(58, 292);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(124, 289);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(174, 20);
            this.txtDiaChi.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(48, 289);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 16);
            this.label8.TabIndex = 43;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Số điện thoại:";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(124, 226);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(173, 20);
            this.txtDienThoai.TabIndex = 42;
            this.txtDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDienThoai_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(125, 163);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(173, 20);
            this.txtEmail.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(6, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "*";
            // 
            // a
            // 
            this.a.AutoSize = true;
            this.a.Location = new System.Drawing.Point(16, 44);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(85, 13);
            this.a.TabIndex = 17;
            this.a.Text = "Mã khách hàng:";
            // 
            // txtCapNhat
            // 
            this.txtCapNhat.Location = new System.Drawing.Point(125, 415);
            this.txtCapNhat.Name = "txtCapNhat";
            this.txtCapNhat.ReadOnly = true;
            this.txtCapNhat.Size = new System.Drawing.Size(173, 20);
            this.txtCapNhat.TabIndex = 32;
            // 
            // b
            // 
            this.b.AutoSize = true;
            this.b.Location = new System.Drawing.Point(16, 103);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(89, 13);
            this.b.TabIndex = 18;
            this.b.Text = "Tên khách hàng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Ngày cập nhật:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(125, 37);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.ReadOnly = true;
            this.txtMaKH.Size = new System.Drawing.Size(73, 20);
            this.txtMaKH.TabIndex = 19;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(125, 100);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(173, 20);
            this.txtTenKH.TabIndex = 20;
            // 
            // ddd
            // 
            this.ddd.AutoSize = true;
            this.ddd.Location = new System.Drawing.Point(48, 355);
            this.ddd.Name = "ddd";
            this.ddd.Size = new System.Drawing.Size(53, 13);
            this.ddd.TabIndex = 23;
            this.ddd.Text = "Ngày tạo:";
            // 
            // txtNgayTao
            // 
            this.txtNgayTao.Location = new System.Drawing.Point(123, 352);
            this.txtNgayTao.Name = "txtNgayTao";
            this.txtNgayTao.ReadOnly = true;
            this.txtNgayTao.Size = new System.Drawing.Size(173, 20);
            this.txtNgayTao.TabIndex = 24;
            // 
            // fKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fKhachHang";
            this.Size = new System.Drawing.Size(1032, 712);
            this.Load += new System.EventHandler(this.fKhachHang_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox dateCapNhat;
        private System.Windows.Forms.DateTimePicker tkDateCapNhat;
        private System.Windows.Forms.DateTimePicker tkDateTao;
        private System.Windows.Forms.CheckBox dateTao;
        private System.Windows.Forms.TextBox tkDiaChi;
        private System.Windows.Forms.CheckBox chkboDiaChi;
        private System.Windows.Forms.TextBox tkSDT;
        private System.Windows.Forms.CheckBox chkboSDT;
        private System.Windows.Forms.TextBox tkEmail;
        private System.Windows.Forms.CheckBox chkboEmail;
        private System.Windows.Forms.TextBox tkTen;
        private System.Windows.Forms.CheckBox chkboTen;
        private System.Windows.Forms.TextBox tkMa;
        private System.Windows.Forms.CheckBox chkboMa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label a;
        private System.Windows.Forms.TextBox txtCapNhat;
        private System.Windows.Forms.Label b;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label ddd;
        private System.Windows.Forms.TextBox txtNgayTao;
    }
}
