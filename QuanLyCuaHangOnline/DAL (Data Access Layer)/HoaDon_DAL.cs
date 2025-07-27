using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

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
    }
}