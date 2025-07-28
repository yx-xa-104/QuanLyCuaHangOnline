using DAL;
using System.Data;

namespace BLL
{
    public class ChiTietHoaDon_BLL
    {
        private ChiTietHoaDon_DAL dalChiTietHoaDon = new ChiTietHoaDon_DAL();

        public DataTable GetChiTietByMaHD(string maHD)
        {
            if (string.IsNullOrWhiteSpace(maHD))
            {
                return null;
            }
            return dalChiTietHoaDon.GetChiTietByMaHD(maHD);
        }
    }
}