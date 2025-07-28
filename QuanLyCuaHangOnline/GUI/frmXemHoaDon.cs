using BLL;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmXemHoaDon : Form
    {
        private HoaDon_BLL hd_bll = new HoaDon_BLL();
        private ChiTietHoaDon_BLL cthd_bll = new ChiTietHoaDon_BLL();
        private DataTable dtHoaDon; // Lưu trữ danh sách hóa đơn gốc

        public frmXemHoaDon()
        {
            InitializeComponent();
        }

        private void frmXemHoaDon_Load(object sender, System.EventArgs e)
        {
            LoadAllHoaDon();
        }

        private void LoadAllHoaDon()
        {
            dtHoaDon = hd_bll.GetAllHoaDon();
            dgvHoaDon.DataSource = dtHoaDon;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo người dùng click vào một dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy MaHD từ dòng được chọn
                string maHD = dgvHoaDon.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();

                // Tải chi tiết hóa đơn tương ứng
                dgvChiTietHD.DataSource = cthd_bll.GetChiTietByMaHD(maHD);
            }
        }

        private void txtTimKiem_TextChanged(object sender, System.EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            // Sử dụng DataView để lọc trên DataTable gốc mà không cần truy vấn lại CSDL
            DataView dv = new DataView(dtHoaDon);
            dv.RowFilter = $"MaHD LIKE '%{keyword}%' OR MaKH LIKE '%{keyword}%'";
            dgvHoaDon.DataSource = dv;
        }

        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {
            // Nút này dùng để tải lại toàn bộ danh sách và xóa bộ lọc
            txtTimKiem.Clear();
            LoadAllHoaDon();
        }
    }
}