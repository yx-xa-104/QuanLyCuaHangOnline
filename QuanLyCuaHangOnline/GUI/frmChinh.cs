using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmChinh : Form
    {
        public frmChinh()
        {
            InitializeComponent();
        }

        // Hàm kiểm tra xem một form đã mở hay chưa
        private Form KiemTraTonTai(Type formType)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formType)
                {
                    return f;
                }
            }
            return null;
        }

        // Sự kiện click cho menu "Sản phẩm" và nút toolbar "Sản phẩm"
        private void SanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmSanPham));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                frmSanPham f = new frmSanPham();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void ThoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Cập nhật đồng hồ trên thanh trạng thái
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void frmChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Xác nhận thoát ứng dụng
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true; // Hủy bỏ việc đóng form
            }
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = KiemTraTonTai(typeof(frmKhachHang));
            if (frm != null)
            {
                frm.Activate(); // Nếu form đã mở, chỉ cần kích hoạt lại
            }
            else
            {
                // Nếu form chưa mở, tạo mới và hiển thị
                frmKhachHang f = new frmKhachHang();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void tsbKhachHang_Click(object sender, EventArgs e)
        {
            kháchHàngToolStripMenuItem_Click(sender, e);
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaoHoaDon f = new frmTaoHoaDon();
            f.MdiParent = this;
            f.Show();
        }
    }
}