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
            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.");
                return;
            }
            if (dgvChiTietHD.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn phải có ít nhất một sản phẩm.");
                return;
            }

            // Tạo đối tượng HoaDon_DTO
            HoaDon_DTO hoaDon = new HoaDon_DTO
            {
                MaHD = txtMaHD.Text,
                MaKH = cboKhachHang.SelectedValue.ToString(),
                TenDangNhap = "admin",
                NgayLap = DateTime.Now,
                TongTien = 0 
            };

            // Tạo danh sách ChiTietHoaDon_DTO
            List<ChiTietHoaDon_DTO> listCTHD = new List<ChiTietHoaDon_DTO>();
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvChiTietHD.Rows)
            {
                if (row.IsNewRow) continue; 

                var maSPValue = row.Cells["MaSP"].Value;
                var soLuongValue = row.Cells["SoLuong"].Value;
                var donGiaValue = row.Cells["DonGia"].Value;
                var thanhTienValue = row.Cells["ThanhTien"].Value;

                if (maSPValue == null || soLuongValue == null || donGiaValue == null || thanhTienValue == null)
                    continue;

                ChiTietHoaDon_DTO cthd = new ChiTietHoaDon_DTO
                {
                    MaHD = hoaDon.MaHD,
                    MaSP = Convert.ToInt32(maSPValue),
                    SoLuong = Convert.ToInt32(soLuongValue),
                    DonGia = Convert.ToDecimal(donGiaValue)
                };
                listCTHD.Add(cthd);
                tongTien += Convert.ToDecimal(thanhTienValue);
            }
            hoaDon.TongTien = tongTien;

            // Gọi BLL để lưu
            if (hd_bll.TaoHoaDon(hoaDon, listCTHD))
            {
                MessageBox.Show("Tạo hóa đơn thành công!", "Thông báo");
                this.Close();
            }
            else
            {
                MessageBox.Show("Tạo hóa đơn thất bại!", "Lỗi");
            }
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}