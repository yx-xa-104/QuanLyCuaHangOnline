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
            string query = "SELECT * FROM tblHoaDon";
            SqlDataAdapter da = new SqlDataAdapter(query, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
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
                // Bắt đầu transaction
                transaction = _conn.BeginTransaction();

                // Thêm Hóa đơn vào tblHoaDon
                string hdQuery = "INSERT INTO tblHoaDon (MaHD, MaKH, TenDangNhap, NgayLap, TongTien) VALUES (@MaHD, @MaKH, @TenDangNhap, @NgayLap, @TongTien)";
                SqlCommand hdCmd = new SqlCommand(hdQuery, _conn, transaction);
                hdCmd.Parameters.AddWithValue("@MaHD", hd.MaHD);
                hdCmd.Parameters.AddWithValue("@MaKH", hd.MaKH);
                hdCmd.Parameters.AddWithValue("@TenDangNhap", hd.TenDangNhap);
                hdCmd.Parameters.AddWithValue("@NgayLap", hd.NgayLap);
                hdCmd.Parameters.AddWithValue("@TongTien", hd.TongTien);
                hdCmd.ExecuteNonQuery();

                // Thêm từng Chi tiết hóa đơn vào tblChiTietHoaDon
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

                // Nếu tất cả thành công, commit transaction
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, hủy bỏ tất cả các thay đổi
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                Console.WriteLine("Lỗi khi tạo hóa đơn (DAL): " + ex.Message);
                return false;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}