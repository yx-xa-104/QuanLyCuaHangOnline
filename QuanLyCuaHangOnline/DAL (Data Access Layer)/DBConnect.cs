using System;
using System.Data.SqlClient;

namespace DAL
{
    public class DBConnect
    {
        // Kết nối đến cơ sở dữ liệu SQL Server LocalDB
        protected SqlConnection _conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuanLyCuaHang;Integrated Security=True");
    }
}