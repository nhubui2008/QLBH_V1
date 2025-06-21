using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_PolyCafe;
using Microsoft.Data.SqlClient;

namespace DAL_PolyCafe
{
    public class DALPhieuBanHang
    {
        public List<PhieuBanHang> selectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<PhieuBanHang> list = new List<PhieuBanHang>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    PhieuBanHang enity = new PhieuBanHang();
                    enity.MaPhieu = reader.GetString("MaPhieu");
                    enity.MaThe = reader.GetString("MaThe");
                    enity.MaNhanVien = reader.GetString("MaNhanVien");
                    enity.NgayTao = reader.GetDateTime("ngayTao");
                    enity.TrangThai = reader.GetBoolean("TrangThai");
                    list.Add(enity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        public List<PhieuBanHang> SelectAll(string maThe)
        {
            List<object> param = new List<object>();
            string sql = "SELECT phieu.MaPhieu, phieu.MaThe, the.ChuSoHuu, phieu.MaNhanVien, nv.HoTen, phieu.NgayTao, phieu.TrangThai " +
                "FROM PhieuBanHang phieu INNER JOIN NhanVien nv ON phieu.MaNhanVien = nv.MaNhanVien " +
                "INNER JOIN TheLuuDong the ON the.MaThe = phieu.MaThe";
            if (!string.IsNullOrEmpty(maThe))
            {
                sql = "SELECT phieu.MaPhieu, phieu.MaThe, the.ChuSoHuu, phieu.MaNhanVien, nv.HoTen, phieu.NgayTao, phieu.TrangThai " +
                "FROM PhieuBanHang phieu INNER JOIN NhanVien nv ON phieu.MaNhanVien = nv.MaNhanVien " +
                "INNER JOIN TheLuuDong the ON the.MaThe = phieu.MaThe " +
                "WHERE the.MaThe = @0";
                param.Add(maThe);
            }

            return selectBySql(sql, param);
        }
        public void Insert(PhieuBanHang enity)
        {
            string sql = "INSERT INTO PhieuBanHang (MaPhieu, MaThe, MaNhanVien, NgayTao, TrangThai) " +
                         "VALUES (@0, @1, @2, @3, @4)";
            List<object> p = new List<object>()
            {
                enity.MaPhieu,
                enity.MaThe,
                enity.MaNhanVien,
                enity.NgayTao,
                enity.TrangThai,
            };
            DBUtil.Update(sql, p);
        }
        public void Update(PhieuBanHang enity)
        {
            string sql = "UPDATE PhieuBanHang SET MaThe = @1, MaNhanVien = @2, NgayTao = @3, TrangThai = @4 " +
                         "WHERE MaPhieu = @0";
            List<object> p = new List<object>
            {
                enity.MaPhieu,
                enity.MaThe,
                enity.MaNhanVien,
                enity.NgayTao,
                enity.TrangThai
            };
            DBUtil.Update(sql, p);
        }
        public void Delete(string id)
        {
            string sql = "Delete from PhieuBanHang where MaPhieu = @0";
            List<object> p = new List<object> { id };
            DBUtil.Update(sql, p);
        }
        public string GenerateMaPhieu()
        {
            string prefix = "PBH";
            string sql = "select top 1 MaPhieu from PhieuBanHang order by MaPhieu desc";
            List<object> args = new List<object>();
            object result = DBUtil.ScalarQuery(sql, args);
            if (result == null || result == DBNull.Value)
            {
                return prefix + "0001";
            }
            else
            {
                string lastId = result.ToString();
                int number = int.Parse(lastId.Substring(prefix.Length));
                number++;
                return prefix + number.ToString("D4");
            }
        }
    }
}
