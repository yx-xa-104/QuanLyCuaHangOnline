using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class NguoiDung_DAL : DBConnect
    {
        //Phương thức kiểm tra đăng nhập
        public bool CheckLogin(NguoiDung_DTO user)
        {
            try
            {
                _conn.Open();
                string query = "SELECT * FROM tblNguoiDung WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", user.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", user.MatKhau);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi kiểm tra đăng nhập: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
    }
}