using BLL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        private NguoiDung_BLL nd_bll = new NguoiDung_BLL();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Hỏi xác nhận trước khi thoát
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Kiểm tra người dùng có nhập liệu không
            if (string.IsNullOrEmpty(txtTenDangNhap.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NguoiDung_DTO user = new NguoiDung_DTO
            {
                TenDangNhap = txtTenDangNhap.Text,
                MatKhau = txtMatKhau.Text
            };

            // Gọi BLL để kiểm tra
            if (nd_bll.CheckLogin(user))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo");

                // Mở form chính
                frmChinh f = new frmChinh();
                f.Show();

                // Ẩn form đăng nhập
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtTenDangNhap.Focus();
            }
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra lý do đóng form
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Gọi sự kiện nút Thoát để xử lý logic hỏi xác nhận
                btnThoat_Click(sender, e);
                e.Cancel = true; // Hủy sự kiện đóng form mặc định
            }
        }
    }
}