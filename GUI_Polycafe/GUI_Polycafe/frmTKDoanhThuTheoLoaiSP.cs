using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_PolyCafe;
using DTO_PolyCafe;

namespace GUI_Polycafe
{
    public partial class frmTKDoanhThuTheoLoaiSP : Form
    {
        public frmTKDoanhThuTheoLoaiSP()
        {
            InitializeComponent();
        }
        private void LoadLoaiSanPham()
        {
            try
            {
                BUSLoaiSanPham bUSLoaiSanPham = new BUSLoaiSanPham();
                List<LoaiSanPham> dsLoai = bUSLoaiSanPham.GetLoaiSanPhamList();

                dsLoai.Insert(0, new LoaiSanPham() { MaLoai = string.Empty, TenLoai = string.Format("--Tất cả--") });
                cboLoaiSP.DataSource = dsLoai;
                cboLoaiSP.ValueMember = "MaLoai";
                cboLoaiSP.DisplayMember = "TenLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại sản phẩm" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string loai = cboLoaiSP.SelectedValue.ToString();
            DateTime bd = dtPTuNgay.Value.Date;
            DateTime kt = dtPDenNgay.Value.Date;

            BUSThongKe bUSThongKe = new BUSThongKe();
            List<TKDoanhThuTheoLoaiSP> result = bUSThongKe.GetThongkeLoaiSP(loai, bd, kt);
            dgvTKTheoLoaiSP.DataSource = result;
        }

        private void frmTKDoanhThuTheoLoaiSP_Load(object sender, EventArgs e)
        {
            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtPTuNgay.Value = firstDayOfMonth;
            LoadLoaiSanPham();
            btnThongKeTheoLoaiSP_Click(sender, e);
        }

        private void btnThongKeTheoLoaiSP_Click(object sender, EventArgs e)
        {
            string loai = cboLoaiSP.SelectedValue.ToString();
            DateTime bd = dtPTuNgay.Value.Date;
            DateTime kt = dtPDenNgay.Value.Date;

            BUSThongKe bUSThongKe = new BUSThongKe();
            List<TKDoanhThuTheoLoaiSP> result = bUSThongKe.GetThongkeLoaiSP(loai, bd, kt);
            dgvTKTheoLoaiSP.DataSource = result;
        }
    }
}
