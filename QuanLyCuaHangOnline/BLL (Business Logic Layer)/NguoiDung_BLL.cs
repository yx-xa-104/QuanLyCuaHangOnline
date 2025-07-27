using DAL;
using DTO;

namespace BLL
{
    public class NguoiDung_BLL
    {
        private NguoiDung_DAL dalNguoiDung = new NguoiDung_DAL();

        public bool CheckLogin(NguoiDung_DTO user)
        {
            // Kiểm tra tên đăng nhập và mật khẩu không được rỗng
            if (string.IsNullOrEmpty(user.TenDangNhap) || string.IsNullOrEmpty(user.MatKhau))
            {
                return false;
            }
            return dalNguoiDung.CheckLogin(user);
        }
    }
}