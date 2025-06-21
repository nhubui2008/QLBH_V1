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
    public class DALThongKe
    {
        public List<TKDoanhThuTheoLoaiSP> GetDoanhThuTheoLoaiSP(string maLoaiSP, DateTime tuNgay, DateTime denNgay)
        {
            // Gọi stored procedure dưới dạng câu SQL bình thường, dùng tham số @0, @1, @2 tương ứng với DBUtil
            string sql = "EXEC TKDoanhThuTheoLoaiSP @0, @1, @2";
            var args = new List<object> { maLoaiSP, tuNgay, denNgay };

            SqlCommand cmd = DBUtil.GetCommand(sql, args, CommandType.Text); // CommandType.Text vì gọi exec dưới dạng text
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<TKDoanhThuTheoLoaiSP> ds = new List<TKDoanhThuTheoLoaiSP>();
            while (reader.Read())
            {
                TKDoanhThuTheoLoaiSP item = new TKDoanhThuTheoLoaiSP
                {
                    MaSanPham = reader["MaSanPham"].ToString(),
                    TenSanPham = reader["TenSanPham"].ToString(),
                    SoLy = Convert.ToInt32(reader["SoLy"]),
                    SoLuongPhieu = Convert.ToInt32(reader["SoLuongPhieu"]),
                    NgayBan = Convert.ToDateTime(reader["NgayBan"]).ToString("dd/MM/yyyy"),
                    TongTien = reader["TongTien"].ToString(),
                    DaThanhToan = reader["TrangThai"].ToString()
                };
                ds.Add(item);
            }

            reader.Close();
            cmd.Connection.Close();

            return ds;
        }
        public List<TKDoanhThuTheoNhanVien> GetDoanhThuTheoNhanVien(string maNV, DateTime tuNgay, DateTime denNgay)
        {
            // Gọi stored procedure dưới dạng câu SQL bình thường, dùng tham số @0, @1, @2 tương ứng với DBUtil
            string sql = "EXEC TKDoanhThuTheoNhanVien @0, @1, @2";
            var args = new List<object> { maNV, tuNgay, denNgay };

            SqlCommand cmd = DBUtil.GetCommand(sql, args, CommandType.Text); // CommandType.Text vì gọi exec dưới dạng text
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<TKDoanhThuTheoNhanVien> ds = new List<TKDoanhThuTheoNhanVien>();
            while (reader.Read())
            {
                TKDoanhThuTheoNhanVien item = new TKDoanhThuTheoNhanVien
                {
                    MaNhanVien = reader["MaNhanVien"].ToString(),
                    HoTen = reader["HoTen"].ToString(),
                    SoLy = Convert.ToInt32(reader["SoLy"]),
                    SoLuongPhieu = Convert.ToInt32(reader["SoLuongPhieu"]),
                    NgayBan = Convert.ToDateTime(reader["NgayBan"]).ToString("dd/MM/yyyy"),
                    TongTien = reader["TongTien"].ToString(),
                    TrangThai = reader["TrangThai"].ToString()
                };
                ds.Add(item);
            }

            reader.Close();
            cmd.Connection.Close();

            return ds;
        }
    }
}
