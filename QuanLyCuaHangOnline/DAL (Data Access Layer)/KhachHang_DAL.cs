using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class KhachHang_DAL : DBConnect
    {
        // Hàm lấy tất cả khách hàng
        public DataTable GetAllKhachHang()
        {
            string query = "SELECT * FROM tblKhachHang";
            SqlDataAdapter da = new SqlDataAdapter(query, _conn);
            DataTable dtKhachHang = new DataTable();
            da.Fill(dtKhachHang);
            return dtKhachHang;
        }

        // Hàm thêm một khách hàng mới
        public bool ThemKhachHang(KhachHang_DTO kh)
        {
            try
            {
                _conn.Open();
                string query = "INSERT INTO tblKhachHang (MaKH, TenKH, SoDienThoai, DiaChi) VALUES (@MaKH, @TenKH, @SoDienThoai, @DiaChi)";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
                cmd.Parameters.AddWithValue("@TenKH", kh.TenKH);
                cmd.Parameters.AddWithValue("@SoDienThoai", kh.SoDienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm khách hàng: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Hàm sửa thông tin khách hàng
        public bool SuaKhachHang(KhachHang_DTO kh)
        {
            try
            {
                _conn.Open();
                string query = "UPDATE tblKhachHang SET TenKH = @TenKH, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@TenKH", kh.TenKH);
                cmd.Parameters.AddWithValue("@SoDienThoai", kh.SoDienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);
                cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi sửa khách hàng: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Hàm xóa khách hàng
        public bool XoaKhachHang(string maKH)
        {
            try
            {
                _conn.Open();
                string query = "DELETE FROM tblKhachHang WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaKH", maKH);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa khách hàng: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
    }
}