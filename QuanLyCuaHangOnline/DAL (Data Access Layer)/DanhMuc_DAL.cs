using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DanhMuc_DAL : DBConnect
    {
        public DataTable GetAllDanhMuc()
        {
            string query = "SELECT * FROM tblDanhMuc";
            SqlDataAdapter da = new SqlDataAdapter(query, _conn);
            DataTable dtDanhMuc = new DataTable();
            da.Fill(dtDanhMuc);
            return dtDanhMuc;
        }
    }
}