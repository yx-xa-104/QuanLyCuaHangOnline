using System;

namespace DTO
{
    public class HoaDon_DTO
    {
        public string MaHD { get; set; }
        public string MaKH { get; set; }
        public string TenDangNhap { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }

        public HoaDon_DTO() { }
    }
}