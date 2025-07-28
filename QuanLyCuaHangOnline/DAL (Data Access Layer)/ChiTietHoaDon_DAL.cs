using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ChiTietHoaDon_DAL : DBConnect
    {
        public bool ThemChiTietHoaDon(ChiTietHoaDon_DTO cthd)
        {
            try
            {
                _conn.Open();
                string query = "INSERT INTO tblChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia) VALUES (@MaHD, @MaSP, @SoLuong, @DonGia)";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaHD", cthd.MaHD);
                cmd.Parameters.AddWithValue("@MaSP", cthd.MaSP);
                cmd.Parameters.AddWithValue("@SoLuong", cthd.SoLuong);
                cmd.Parameters.AddWithValue("@DonGia", cthd.DonGia);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable GetChiTietByMaHD(string maHD)
        {
            DataTable dt = new DataTable();
            try
            {
                _conn.Open();
                // Sử dụng JOIN để lấy Tên sản phẩm 
                string query = @"SELECT ct.MaSP, sp.TenSP, ct.SoLuong, ct.DonGia, (ct.SoLuong * ct.DonGia) AS ThanhTien
                         FROM tblChiTietHoaDon ct
                         JOIN tblSanPham sp ON ct.MaSP = sp.MaSP
                         WHERE ct.MaHD = @MaHD";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy chi tiết hóa đơn: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return dt;
        }
    }
}