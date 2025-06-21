using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_PolyCafe;
using DTO_PolyCafe;

namespace BLL_PolyCafe
{
    public class BUSPhieuBanHang
    {
        DALPhieuBanHang dalPhieuBanHang = new DALPhieuBanHang();

        public List<PhieuBanHang> GetListPhieuBanHang(string maThe)
        {
            return dalPhieuBanHang.SelectAll(maThe);
        }

        public string InsertPhieuBanHang(PhieuBanHang pbh)
        {
            try
            {
                pbh.MaPhieu = dalPhieuBanHang.GenerateMaPhieu();
                if (string.IsNullOrEmpty(pbh.MaPhieu))
                {
                    return "Mã phiếu bán hàng không hợp lệ.";
                }

                dalPhieuBanHang.Insert(pbh);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Thêm mới không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string UpdatePhieuBanHang(PhieuBanHang pbh)
        {
            try
            {
                if (string.IsNullOrEmpty(pbh.MaPhieu))
                {
                    return "Mã phiếu không hợp lệ.";
                }

                dalPhieuBanHang.Update(pbh);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Cập nhật không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }

        public string DeletePhieuBanHang(string maPhieu)
        {
            try
            {
                if (string.IsNullOrEmpty(maPhieu))
                {
                    return "Mã phiếu bán hàng không hợp lệ.";
                }

                dalPhieuBanHang.Delete(maPhieu);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Xóa không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }
    }
}
