using System;

namespace DTO
{
    public class NguoiDung_DTO
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public int Quyen { get; set; } // 1: Admin, 2: Nhân viên

        public NguoiDung_DTO() { }
    }
}