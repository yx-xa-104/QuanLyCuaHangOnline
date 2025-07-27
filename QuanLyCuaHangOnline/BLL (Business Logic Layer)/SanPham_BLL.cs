using DAL; // Sử dụng lớp DAL
using DTO; // Sử dụng lớp DTO
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class SanPham_BLL : DBConnect
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
            try
            {
                _conn.Open();
                string query = "UPDATE tblSanPham SET TenSP = @TenSP, MaDanhMuc = @MaDanhMuc, SoLuongTon = @SoLuongTon, DonGia = @DonGia, HinhAnh = @HinhAnh WHERE MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(query, _conn);

                cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
                cmd.Parameters.AddWithValue("@MaDanhMuc", sp.MaDanhMuc);
                cmd.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);
                cmd.Parameters.AddWithValue("@DonGia", sp.DonGia);
                cmd.Parameters.AddWithValue("@HinhAnh", sp.HinhAnh);
                cmd.Parameters.AddWithValue("@MaSP", sp.MaSP); // sp.MaSP bây giờ đã là kiểu int

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi sửa sản phẩm: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool XoaSanPham(int maSP)
        {
            // Kiểm tra mã sản phẩm hợp lệ
            if (maSP <= 0)
            {
                return false;
            }
            return dalSanPham.XoaSanPham(maSP);
        }
    }
}