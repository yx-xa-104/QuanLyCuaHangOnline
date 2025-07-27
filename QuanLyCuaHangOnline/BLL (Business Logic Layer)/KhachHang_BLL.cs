using DAL;
using DTO;
using System.Data;
using System.Text.RegularExpressions;

namespace BLL
{
    public class KhachHang_BLL
    {
        private KhachHang_DAL dalKhachHang = new KhachHang_DAL();

        public DataTable GetAllKhachHang()
        {
            return dalKhachHang.GetAllKhachHang();
        }

        public bool ThemKhachHang(KhachHang_DTO kh)
        {
            // Kiểm tra các trường thông tin không được để trống
            if (string.IsNullOrEmpty(kh.MaKH) || string.IsNullOrEmpty(kh.TenKH) || string.IsNullOrEmpty(kh.SoDienThoai))
            {
                return false;
            }

            // Kiểm tra định dạng số điện thoại
            if (!Regex.IsMatch(kh.SoDienThoai, @"^\d{10}$"))
            {
                return false;
            }

            return dalKhachHang.ThemKhachHang(kh);
        }

        public bool SuaKhachHang(KhachHang_DTO kh)
        {
            // Kiểm tra các điều kiện trước khi sửa
            if (string.IsNullOrEmpty(kh.MaKH) || string.IsNullOrEmpty(kh.TenKH) || string.IsNullOrEmpty(kh.SoDienThoai))
            {
                return false;
            }

            if (!Regex.IsMatch(kh.SoDienThoai, @"^\d{10}$"))
            {
                return false;
            }

            return dalKhachHang.SuaKhachHang(kh);
        }

        public bool XoaKhachHang(string maKH)
        {
            if (string.IsNullOrEmpty(maKH))
            {
                return false;
            }
            return dalKhachHang.XoaKhachHang(maKH);
        }
    }
}