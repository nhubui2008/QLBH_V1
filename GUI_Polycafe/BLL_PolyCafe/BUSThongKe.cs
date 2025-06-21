using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_PolyCafe;
using DTO_PolyCafe;

namespace BLL_PolyCafe
{
    public class BUSThongKe
    {
        DALThongKe DAL_ThongKe = new DALThongKe();
        public List<TKDoanhThuTheoLoaiSP> GetThongkeLoaiSP(string loaiSP, DateTime NgayBD, DateTime NgayKT)
        {
            return DAL_ThongKe.GetDoanhThuTheoLoaiSP(loaiSP, NgayBD, NgayKT);
        }
        public List<TKDoanhThuTheoNhanVien> GetTKDoanhThuTheoNhanVien(string maNV, DateTime NgayBD, DateTime NgayKT)
        {
            return DAL_ThongKe.GetDoanhThuTheoNhanVien(maNV, NgayBD, NgayKT);
        }
    }
}
