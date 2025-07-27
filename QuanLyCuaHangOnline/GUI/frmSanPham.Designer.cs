namespace GUI
{
    partial class frmSanPham
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtMaSP = new TextBox();
            txtTenSP = new TextBox();
            txtMaDanhMuc = new TextBox();
            txtSoLuongTon = new TextBox();
            txtDonGia = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnBoQua = new Button();
            dgvSanPham = new DataGridView();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            picHinhAnh = new PictureBox();
            btnMoFile = new Button();
            txtTimKiem = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 40);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã sản phẩm\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(164, 42);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 1;
            label2.Text = "Tên sản phẩm";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(355, 48);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 2;
            label3.Text = "Mã danh mục\n";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(503, 48);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 3;
            label4.Text = "Số lượng tồn\n";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(698, 48);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 4;
            label5.Text = "Đơn giá";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(835, 40);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 5;
            label6.Text = "Hình ảnh\n";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(979, 42);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 6;
            label7.Text = "Tìm kiếm";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1096, 48);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 7;
            label8.Text = "label8";
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(12, 58);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(100, 23);
            txtMaSP.TabIndex = 8;
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(164, 58);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(100, 23);
            txtTenSP.TabIndex = 9;
            // 
            // txtMaDanhMuc
            // 
            txtMaDanhMuc.Location = new Point(336, 66);
            txtMaDanhMuc.Name = "txtMaDanhMuc";
            txtMaDanhMuc.Size = new Size(100, 23);
            txtMaDanhMuc.TabIndex = 10;
            // 
            // txtSoLuongTon
            // 
            txtSoLuongTon.Location = new Point(502, 66);
            txtSoLuongTon.Name = "txtSoLuongTon";
            txtSoLuongTon.Size = new Size(100, 23);
            txtSoLuongTon.TabIndex = 11;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(674, 66);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(100, 23);
            txtDonGia.TabIndex = 12;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(12, 214);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 23);
            btnThem.TabIndex = 13;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(99, 214);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 23);
            btnSua.TabIndex = 14;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(189, 214);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 23);
            btnXoa.TabIndex = 15;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(336, 214);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(75, 23);
            btnLuu.TabIndex = 16;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnBoQua
            // 
            btnBoQua.Location = new Point(428, 214);
            btnBoQua.Name = "btnBoQua";
            btnBoQua.Size = new Size(75, 23);
            btnBoQua.TabIndex = 17;
            btnBoQua.Text = "Bỏ qua";
            btnBoQua.UseVisualStyleBackColor = true;
            btnBoQua.Click += btnBoQua_Click;
            // 
            // dgvSanPham
            // 
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Location = new Point(99, 357);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.Size = new Size(240, 150);
            dgvSanPham.TabIndex = 18;
            dgvSanPham.CellClick += dgvSanPham_CellClick;
            dgvSanPham.CellContentClick += dgvSanPham_CellContentClick;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(428, 277);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(308, 230);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(884, 277);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 221);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách sản phẩm";
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(835, 58);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(100, 50);
            picHinhAnh.TabIndex = 21;
            picHinhAnh.TabStop = false;
            // 
            // btnMoFile
            // 
            btnMoFile.Location = new Point(845, 132);
            btnMoFile.Name = "btnMoFile";
            btnMoFile.Size = new Size(75, 23);
            btnMoFile.TabIndex = 22;
            btnMoFile.Text = "Mở file";
            btnMoFile.UseVisualStyleBackColor = true;
            btnMoFile.Click += btnMoFile_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(960, 66);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(100, 23);
            txtTimKiem.TabIndex = 23;
            // 
            // frmSanPham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 585);
            Controls.Add(txtTimKiem);
            Controls.Add(btnMoFile);
            Controls.Add(picHinhAnh);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvSanPham);
            Controls.Add(btnBoQua);
            Controls.Add(btnLuu);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtDonGia);
            Controls.Add(txtSoLuongTon);
            Controls.Add(txtMaDanhMuc);
            Controls.Add(txtTenSP);
            Controls.Add(txtMaSP);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmSanPham";
            Text = "frmSanPham";
            Load += frmSanPham_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtMaSP;
        private TextBox txtTenSP;
        private TextBox txtMaDanhMuc;
        private TextBox txtSoLuongTon;
        private TextBox txtDonGia;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnBoQua;
        private DataGridView dgvSanPham;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private PictureBox picHinhAnh;
        private Button btnMoFile;
        private TextBox txtTimKiem;
    }
}