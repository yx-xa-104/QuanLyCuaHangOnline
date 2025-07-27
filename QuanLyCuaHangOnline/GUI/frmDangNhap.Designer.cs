namespace GUI
{
    partial class frmDangNhap
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
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            btnThoat = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 84);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 131);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(176, 81);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(258, 27);
            txtTenDangNhap.TabIndex = 0;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(176, 128);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(258, 27);
            txtMatKhau.TabIndex = 1;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDangNhap.Location = new Point(292, 178);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(142, 38);
            btnDangNhap.TabIndex = 2;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(176, 178);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 38);
            btnThoat.TabIndex = 3;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.HotTrack;
            label3.Location = new Point(108, 20);
            label3.Name = "label3";
            label3.Size = new Size(286, 38);
            label3.TabIndex = 6;
            label3.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // frmDangNhap
            // 
            AcceptButton = btnDangNhap;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnThoat;
            ClientSize = new Size(482, 253);
            Controls.Add(label3);
            Controls.Add(btnThoat);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            FormClosing += frmDangNhap_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtTenDangNhap;
        private TextBox txtMatKhau;
        private Button btnDangNhap;
        private Button btnThoat;
        private Label label3;
    }
}