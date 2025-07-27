using System;

namespace DTO
{
    public class SanPham_DTO
    {
        // Các Properties tương ứng với các cột trong bảng tblSanPham
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string MaDanhMuc { get; set; }
        public int SoLuongTon { get; set; }
        public decimal DonGia { get; set; }
        public string HinhAnh { get; set; }

        // Constructor không tham số
        public SanPham_DTO() { }

        // Constructor có tham số
        public SanPham_DTO(int ma, string ten, string maDM, int soLuong, decimal gia, string hinh)
        {
            this.MaSP = ma;
            this.TenSP = ten;
            this.MaDanhMuc = maDM;
            this.SoLuongTon = soLuong;
            this.DonGia = gia;
            this.HinhAnh = hinh;
        }
    }
}