using System;

namespace DTO
{
    public class ChiTietHoaDon_DTO
    {
        public string MaHD { get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; } // Đơn giá tại thời điểm bán

        public ChiTietHoaDon_DTO() { }
    }
}