using DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DAL
{
    public class HoaDon_DAL : DBConnect
    {
        public DataTable GetAllHoaDon()
        {
            DataTable dt = new DataTable();
            try
            {
                _conn.Open();
                string query = @"SELECT hd.MaHD, kh.TenKH, hd.MaKH, hd.TenDangNhap, hd.NgayLap, hd.TongTien 
                         FROM tblHoaDon hd
                         JOIN tblKhachHang kh ON hd.MaKH = kh.MaKH
                         ORDER BY hd.NgayLap DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, _conn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách hóa đơn: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return dt;
        }

        public bool ThemHoaDon(HoaDon_DTO hd)
        {
            try
            {
                _conn.Open();
                string query = "INSERT INTO tblHoaDon (MaHD, MaKH, TenDangNhap, NgayLap, TongTien) VALUES (@MaHD, @MaKH, @TenDangNhap, @NgayLap, @TongTien)";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaHD", hd.MaHD);
                cmd.Parameters.AddWithValue("@MaKH", hd.MaKH);
                cmd.Parameters.AddWithValue("@TenDangNhap", hd.TenDangNhap);
                cmd.Parameters.AddWithValue("@NgayLap", hd.NgayLap);
                cmd.Parameters.AddWithValue("@TongTien", hd.TongTien);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm hóa đơn: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool TaoHoaDon(HoaDon_DTO hd, List<ChiTietHoaDon_DTO> list_cthd)
        {
            SqlTransaction transaction = null;
            try
            {
                _conn.Open();
                transaction = _conn.BeginTransaction();

                // Thêm Hóa đơn
                string hdQuery = "INSERT INTO tblHoaDon (MaHD, MaKH, TenDangNhap, NgayLap, TongTien) VALUES (@MaHD, @MaKH, @TenDangNhap, @NgayLap, @TongTien)";
                SqlCommand hdCmd = new SqlCommand(hdQuery, _conn, transaction);
                hdCmd.Parameters.AddWithValue("@MaHD", hd.MaHD);
                hdCmd.Parameters.AddWithValue("@MaKH", hd.MaKH);
                hdCmd.Parameters.AddWithValue("@TenDangNhap", hd.TenDangNhap);
                hdCmd.Parameters.AddWithValue("@NgayLap", hd.NgayLap);
                hdCmd.Parameters.AddWithValue("@TongTien", hd.TongTien);
                hdCmd.ExecuteNonQuery();

                // Thêm Chi tiết hóa đơn
                foreach (ChiTietHoaDon_DTO cthd in list_cthd)
                {
                    string cthdQuery = "INSERT INTO tblChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia) VALUES (@MaHD, @MaSP, @SoLuong, @DonGia)";
                    SqlCommand cthdCmd = new SqlCommand(cthdQuery, _conn, transaction);
                    cthdCmd.Parameters.AddWithValue("@MaHD", cthd.MaHD);

                    cthdCmd.Parameters.AddWithValue("@MaSP", cthd.MaSP);
                    cthdCmd.Parameters.AddWithValue("@SoLuong", cthd.SoLuong);
                    cthdCmd.Parameters.AddWithValue("@DonGia", cthd.DonGia);
                    cthdCmd.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                // "Ném" lỗi chi tiết ra ngoài để giao diện bắt được
                throw ex;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}