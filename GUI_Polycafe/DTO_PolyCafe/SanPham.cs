using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_PolyCafe
{
    public class SanPham
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public decimal DonGia { get; set; }
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string HinhAnh { get; set; }
        public bool TrangThai { get; set; }
    }
}
