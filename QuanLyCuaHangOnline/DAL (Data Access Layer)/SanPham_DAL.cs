using DTO; // Sử dụng các đối tượng từ lớp DTO
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SanPham_DAL : DBConnect
    {
        public DataTable GetAllSanPham()
        {
            string query = "SELECT MaSP, TenSP, MaDanhMuc, SoLuongTon, DonGia FROM tblSanPham";
            SqlDataAdapter da = new SqlDataAdapter(query, _conn);
            DataTable dtSanPham = new DataTable();
            da.Fill(dtSanPham);
            return dtSanPham;
        }

        public bool ThemSanPham(SanPham_DTO sp)
        {
            try
            {
                _conn.Open();
                string query = "INSERT INTO tblSanPham (TenSP, MaDanhMuc, SoLuongTon, DonGia, HinhAnh) VALUES (@TenSP, @MaDanhMuc, @SoLuongTon, @DonGia, @HinhAnh)";
                SqlCommand cmd = new SqlCommand(query, _conn);

                cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
                cmd.Parameters.AddWithValue("@MaDanhMuc", sp.MaDanhMuc);
                cmd.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);
                cmd.Parameters.AddWithValue("@DonGia", sp.DonGia);
                cmd.Parameters.AddWithValue("@HinhAnh", sp.HinhAnh);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool SuaSanPham(SanPham_DTO sp)
        {
            try
            {
                _conn.Open();

                string query = "UPDATE tblSanPham SET TenSP = @TenSP, MaDanhMuc = @MaDanhMuc, SoLuongTon = @SoLuongTon, DonGia = @DonGia WHERE MaSP = @MaSP";

                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
                cmd.Parameters.AddWithValue("@MaDanhMuc", sp.MaDanhMuc);
                cmd.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);
                cmd.Parameters.AddWithValue("@DonGia", sp.DonGia);
                cmd.Parameters.AddWithValue("@MaSP", sp.MaSP);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex) { }
            finally
            {
                _conn.Close();
            }

            return false;
        }

        public bool XoaSanPham(int maSP)
        {
            try
            {
                _conn.Open();
                string query = "DELETE FROM tblSanPham WHERE MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex) { }
            finally
            {
                _conn.Close();
            }

            return false;
        }
    }
}