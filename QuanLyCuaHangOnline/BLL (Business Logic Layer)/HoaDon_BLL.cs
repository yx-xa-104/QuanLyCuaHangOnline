using DAL;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class HoaDon_BLL
    {
        private HoaDon_DAL dalHoaDon = new HoaDon_DAL();

        public bool TaoHoaDon(HoaDon_DTO hd, List<ChiTietHoaDon_DTO> list_cthd)
        {
            // Kiểm tra điều kiện
            if (string.IsNullOrEmpty(hd.MaHD) || string.IsNullOrEmpty(hd.MaKH) || list_cthd.Count == 0)
            {
                return false;
            }
            // Gọi DAL để thực hiện
            return dalHoaDon.TaoHoaDon(hd, list_cthd);
        }
        public DataTable GetAllHoaDon()
        {
            return dalHoaDon.GetAllHoaDon();
        }
    }
}