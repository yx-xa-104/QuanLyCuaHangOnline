namespace GUI
{
    partial class frmTaoHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            txtMaHD = new TextBox();
            label2 = new Label();
            cboKhachHang = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnThemVaoHD = new Button();
            nmSoLuong = new NumericUpDown();
            label4 = new Label();
            cboSanPham = new ComboBox();
            label3 = new Label();
            dgvChiTietHD = new DataGridView();
            MaSP = new DataGridViewTextBoxColumn();
            TenSP = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            label5 = new Label();
            lblTongTien = new Label();
            btnTaoHoaDon = new Button();
            btnHuy = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietHD).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtMaHD);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboKhachHang);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(10, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(751, 52);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin chung";
            // 
            // txtMaHD
            // 
            txtMaHD.Location = new Point(497, 20);
            txtMaHD.Margin = new Padding(3, 2, 3, 2);
            txtMaHD.Name = "txtMaHD";
            txtMaHD.ReadOnly = true;
            txtMaHD.Size = new Size(238, 23);
            txtMaHD.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(413, 22);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 2;
            label2.Text = "Mã hóa đơn";
            // 
            // cboKhachHang
            // 
            cboKhachHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhachHang.FormattingEnabled = true;
            cboKhachHang.Location = new Point(94, 20);
            cboKhachHang.Margin = new Padding(3, 2, 3, 2);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(295, 23);
            cboKhachHang.TabIndex = 1;
            cboKhachHang.SelectedIndexChanged += cboKhachHang_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 22);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 0;
            label1.Text = "Khách hàng";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnThemVaoHD);
            groupBox2.Controls.Add(nmSoLuong);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(cboSanPham);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(10, 66);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(751, 52);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thêm sản phẩm";
            // 
            // btnThemVaoHD
            // 
            btnThemVaoHD.Location = new Point(612, 19);
            btnThemVaoHD.Margin = new Padding(3, 2, 3, 2);
            btnThemVaoHD.Name = "btnThemVaoHD";
            btnThemVaoHD.Size = new Size(122, 22);
            btnThemVaoHD.TabIndex = 4;
            btnThemVaoHD.Text = "Thêm vào HĐ";
            btnThemVaoHD.UseVisualStyleBackColor = true;
            btnThemVaoHD.Click += btnThemVaoHD_Click;
            // 
            // nmSoLuong
            // 
            nmSoLuong.Location = new Point(497, 20);
            nmSoLuong.Margin = new Padding(3, 2, 3, 2);
            nmSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmSoLuong.Name = "nmSoLuong";
            nmSoLuong.Size = new Size(82, 23);
            nmSoLuong.TabIndex = 3;
            nmSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(432, 22);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 2;
            label4.Text = "Số lượng";
            // 
            // cboSanPham
            // 
            cboSanPham.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSanPham.FormattingEnabled = true;
            cboSanPham.Location = new Point(94, 20);
            cboSanPham.Margin = new Padding(3, 2, 3, 2);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(295, 23);
            cboSanPham.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 22);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 0;
            label3.Text = "Sản phẩm";
            // 
            // dgvChiTietHD
            // 
            dgvChiTietHD.AllowUserToAddRows = false;
            dgvChiTietHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietHD.Columns.AddRange(new DataGridViewColumn[] { MaSP, TenSP, SoLuong, DonGia, ThanhTien });
            dgvChiTietHD.Location = new Point(10, 123);
            dgvChiTietHD.Margin = new Padding(3, 2, 3, 2);
            dgvChiTietHD.Name = "dgvChiTietHD";
            dgvChiTietHD.ReadOnly = true;
            dgvChiTietHD.RowHeadersWidth = 51;
            dgvChiTietHD.Size = new Size(751, 206);
            dgvChiTietHD.TabIndex = 2;
            // 
            // MaSP
            // 
            MaSP.HeaderText = "Mã SP";
            MaSP.MinimumWidth = 6;
            MaSP.Name = "MaSP";
            MaSP.ReadOnly = true;
            // 
            // TenSP
            // 
            TenSP.HeaderText = "Tên Sản Phẩm";
            TenSP.MinimumWidth = 6;
            TenSP.Name = "TenSP";
            TenSP.ReadOnly = true;
            // 
            // SoLuong
            // 
            SoLuong.HeaderText = "Số Lượng";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            // 
            // DonGia
            // 
            DonGia.HeaderText = "Đơn Giá";
            DonGia.MinimumWidth = 6;
            DonGia.Name = "DonGia";
            DonGia.ReadOnly = true;
            // 
            // ThanhTien
            // 
            ThanhTien.HeaderText = "Thành Tiền";
            ThanhTien.MinimumWidth = 6;
            ThanhTien.Name = "ThanhTien";
            ThanhTien.ReadOnly = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(497, 339);
            label5.Name = "label5";
            label5.Size = new Size(87, 21);
            label5.TabIndex = 3;
            label5.Text = "Tổng tiền:";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.Red;
            lblTongTien.Location = new Point(599, 339);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(59, 21);
            lblTongTien.TabIndex = 4;
            lblTongTien.Text = "0 VNĐ";
            // 
            // btnTaoHoaDon
            // 
            btnTaoHoaDon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTaoHoaDon.Location = new Point(578, 373);
            btnTaoHoaDon.Margin = new Padding(3, 2, 3, 2);
            btnTaoHoaDon.Name = "btnTaoHoaDon";
            btnTaoHoaDon.Size = new Size(184, 30);
            btnTaoHoaDon.TabIndex = 5;
            btnTaoHoaDon.Text = "TẠO HÓA ĐƠN";
            btnTaoHoaDon.UseVisualStyleBackColor = true;
            btnTaoHoaDon.Click += btnTaoHoaDon_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(476, 373);
            btnHuy.Margin = new Padding(3, 2, 3, 2);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(96, 30);
            btnHuy.TabIndex = 6;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // 
            // frmTaoHoaDon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 415);
            Controls.Add(btnHuy);
            Controls.Add(btnTaoHoaDon);
            Controls.Add(lblTongTien);
            Controls.Add(label5);
            Controls.Add(dgvChiTietHD);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmTaoHoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo Hóa Đơn Mới";
            Load += frmTaoHoaDon_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietHD).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox txtMaHD;
        private Label label2;
        private ComboBox cboKhachHang;
        private GroupBox groupBox2;
        private Button btnThemVaoHD;
        private NumericUpDown nmSoLuong;
        private Label label4;
        private ComboBox cboSanPham;
        private Label label3;
        private DataGridView dgvChiTietHD;
        private Label label5;
        private Label lblTongTien;
        private Button btnTaoHoaDon;
        private Button btnHuy;
        private DataGridViewTextBoxColumn MaSP;
        private DataGridViewTextBoxColumn TenSP;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewTextBoxColumn ThanhTien;
    }
}