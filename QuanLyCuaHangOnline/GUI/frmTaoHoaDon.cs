using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTaoHoaDon : Form
    {
        private KhachHang_BLL kh_bll = new KhachHang_BLL();
        private SanPham_BLL sp_bll = new SanPham_BLL();
        private HoaDon_BLL hd_bll = new HoaDon_BLL();

        private DataTable dtSanPham; // Lưu trữ danh sách sản phẩm để truy xuất giá

        public frmTaoHoaDon()
        {
            InitializeComponent();
        }

        private void frmTaoHoaDon_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            LoadSanPham();

            // Tạo mã hóa đơn dựa trên thời gian hiện tại
            txtMaHD.Text = "HD" + DateTime.Now.ToString("yyMMddHHmmss");
        }

        private void LoadKhachHang()
        {
            cboKhachHang.DataSource = kh_bll.GetAllKhachHang();
            cboKhachHang.DisplayMember = "TenKH";
            cboKhachHang.ValueMember = "MaKH";
        }

        private void LoadSanPham()
        {
            dtSanPham = sp_bll.GetAllSanPham();
            cboSanPham.DataSource = dtSanPham;
            cboSanPham.DisplayMember = "TenSP";
            cboSanPham.ValueMember = "MaSP";
        }

        private void btnThemVaoHD_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm.");
                return;
            }

            string maSP = cboSanPham.SelectedValue.ToString();
            string tenSP = cboSanPham.Text;
            int soLuong = (int)nmSoLuong.Value;

            // Lấy đơn giá từ DataTable sản phẩm đã tải
            DataRow[] rows = dtSanPham.Select($"MaSP = '{maSP}'");
            if (rows.Length > 0)
            {
                decimal donGia = (decimal)rows[0]["DonGia"];
                decimal thanhTien = soLuong * donGia;

                // Thêm vào DataGridView
                dgvChiTietHD.Rows.Add(maSP, tenSP, soLuong, donGia, thanhTien);
                CapNhatTongTien();
            }
        }

        private void CapNhatTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvChiTietHD.Rows)
            {
                tongTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
            }
            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            // Kiểm tra các điều kiện đầu vào
            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvChiTietHD.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn phải có ít nhất một sản phẩm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMaHD.Text))
            {
                MessageBox.Show("Mã hóa đơn không được để trống.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tạo đối tượng HoaDon_DTO
                HoaDon_DTO hoaDon = new HoaDon_DTO
                {
                    MaHD = txtMaHD.Text.Trim(),
                    MaKH = cboKhachHang.SelectedValue.ToString(),
                    TenDangNhap = "admin", // Giả định người dùng đăng nhập là admin
                    NgayLap = DateTime.Now,
                    TongTien = 0 // Sẽ được tính lại từ chi tiết
                };

                // Tạo danh sách ChiTietHoaDon_DTO từ DataGridView
                List<ChiTietHoaDon_DTO> listCTHD = new List<ChiTietHoaDon_DTO>();
                decimal tongTien = 0;

                foreach (DataGridViewRow row in dgvChiTietHD.Rows)
                {
                    ChiTietHoaDon_DTO cthd = new ChiTietHoaDon_DTO
                    {
                        MaHD = hoaDon.MaHD,        
                        MaSP = Convert.ToInt32(row.Cells["MaSP"].Value),
                        SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                        DonGia = Convert.ToDecimal(row.Cells["DonGia"].Value)
                    };
                    listCTHD.Add(cthd);
                    tongTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                }
                hoaDon.TongTien = tongTien;

                // Gọi BLL để thực hiện lưu và bắt lỗi chi tiết
                if (hd_bll.TaoHoaDon(hoaDon, listCTHD))
                {
                    MessageBox.Show("Tạo hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tạo hóa đơn thất bại vì một lý do không xác định.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi chi tiết từ CSDL
                MessageBox.Show("Đã xảy ra lỗi khi tạo hóa đơn:\n\n" + ex.Message,
                                "Lỗi Cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}