using DAL;
using System.Data;

namespace BLL
{
    public class DanhMuc_BLL
    {
        private DanhMuc_DAL dalDanhMuc = new DanhMuc_DAL();

        public DataTable GetAllDanhMuc()
        {
            return dalDanhMuc.GetAllDanhMuc();
        }
    }
}