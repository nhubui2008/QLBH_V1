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
    public partial class frmTKTheoNhanVien : Form
    {
        public frmTKTheoNhanVien()
        {
            InitializeComponent();
        }
        private void LoadNhanVien()
        {
            try
            {
                BUSNhanVien busNhanVien = new BUSNhanVien();
                List<NhanVien> dsNhanVien = busNhanVien.GetNhanVienList();
                dsNhanVien.Insert(0, new NhanVien() { MaNhanVien = string.Empty, HoTen = string.Format("--Tất cả--") });
                cboNhanVien.DataSource = dsNhanVien;
                cboNhanVien.ValueMember = "MaNhanVien";
                cboNhanVien.DisplayMember = "HoTen";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThongKeTheoNhanVien_Click(object sender, EventArgs e)
        {
            string maNV = cboNhanVien.SelectedValue.ToString();
            DateTime bd = dtPTuNgay.Value.Date;
            DateTime kt = dtPDenNgay.Value.Date;

            BUSThongKe bUSThongKe = new BUSThongKe();
            List<TKDoanhThuTheoNhanVien> result = bUSThongKe.GetTKDoanhThuTheoNhanVien(maNV, bd, kt);
            dgvTKTheoNhanVien.DataSource = result;
        }

        private void frmTKTheoNhanVien_Load(object sender, EventArgs e)
        {
            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtPTuNgay.Value = firstDayOfMonth;
            LoadNhanVien();

            btnThongKeTheoNhanVien_Click(sender, e);
        }
    }
}
