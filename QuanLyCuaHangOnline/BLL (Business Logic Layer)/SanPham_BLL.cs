using DAL; // Sử dụng lớp DAL
using DTO; // Sử dụng lớp DTO
using System.Data;

namespace BLL
{
    public class SanPham_BLL
    {
        private SanPham_DAL dalSanPham = new SanPham_DAL();

        public DataTable GetAllSanPham()
        {
            return dalSanPham.GetAllSanPham();
        }

        public bool ThemSanPham(SanPham_DTO sp)
        {
            // Tên sản phẩm không được rỗng
            if (string.IsNullOrEmpty(sp.TenSP))
            {
                return false;
            }
            // Đơn giá phải lớn hơn 0
            if (sp.DonGia <= 0)
            {
                return false;
            }

            return dalSanPham.ThemSanPham(sp);
        }

        public bool SuaSanPham(SanPham_DTO sp)
        {
            // Có thể thêm các logic kiểm tra tương tự ở đây
            if (string.IsNullOrEmpty(sp.MaSP) || string.IsNullOrEmpty(sp.TenSP))
            {
                return false;
            }

            // Đơn giá phải lớn hơn 0
            if (sp.DonGia <= 0)
            {
                return false;
            }

            // Số lượng tồn phải lớn hơn hoặc bằng 0
            if (sp.SoLuongTon < 0)
            {
                return false;
            }

            // Kiểm tra mã sản phẩm không được rỗng
            if (string.IsNullOrEmpty(sp.MaSP))
            {
                return false;
            }

            // Kiểm tra tên sản phẩm không được rỗng
            if (string.IsNullOrEmpty(sp.TenSP))
            {
                return false;
            }

            // Kiểm tra mã danh mục không được rỗng
            if (string.IsNullOrEmpty(sp.MaDanhMuc))
            {
                return false;
            }

            // Kiểm tra số lượng tồn không được âm
            if (sp.SoLuongTon < 0)
            {
                return false;
            }

            // Kiểm tra đơn giá phải lớn hơn 0
            if (sp.DonGia <= 0)
            {
                return false;
            }
            return dalSanPham.SuaSanPham(sp);
        }

        public bool XoaSanPham(string maSP)
        {
            // Kiểm tra mã SP không được rỗng
            if (string.IsNullOrEmpty(maSP))
            {
                return false;
            }
            return dalSanPham.XoaSanPham(maSP);
        }
    }
}