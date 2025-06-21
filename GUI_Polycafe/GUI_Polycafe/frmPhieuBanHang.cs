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
    public partial class frmPhieuBanHang : Form
    {
        private bool isLoadingTheLuuDongData = true;
        public frmPhieuBanHang()
        {
            InitializeComponent();
        }
        private void LoadNhanVien()
        {
            try
            {
                BUSNhanVien busNhanVien = new BUSNhanVien();
                List<NhanVien> dsloai = busNhanVien.GetNhanVienList();
                dsloai.Insert(0, new NhanVien() { MaNhanVien = string.Empty, HoTen = string.Format("--Vui lòng chọn nhân viên--") });
                cboNhanVien.DataSource = dsloai;
                cboNhanVien.ValueMember = "MaNhanVien";
                cboNhanVien.DisplayMember = "HoTen";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại sản phẩm" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTheLuuDong()
        {
            BUSTheLuuDong bUSTheLuuDong = new BUSTheLuuDong();
            List<TheLuuDong> lst = bUSTheLuuDong.GetTheLuuDongList();
            lst.Insert(0, new TheLuuDong() { MaThe = string.Empty, ChuSoHuu = string.Format("--Tất cả--") });
            cboMaThe.DataSource = lst;
            cboMaThe.ValueMember = "MaThe";
            cboMaThe.DisplayMember = "ChuSoHuu";
            isLoadingTheLuuDongData = false;
        }
        private void LoadDanhSachPhieu(string maThe)
        {
            BUSPhieuBanHang bUSPhieuBanHang = new BUSPhieuBanHang();
            List<PhieuBanHang> lst = bUSPhieuBanHang.GetListPhieuBanHang(maThe);
            dgvDanhSachPhieu.DataSource = lst;

            DataGridViewImageColumn buttonColumn = new DataGridViewImageColumn();
            buttonColumn.Name = "ThanhToan";
            buttonColumn.HeaderText = "ThanhToan";

            if (dgvDanhSachPhieu.Columns.Contains("ThanhToan"))
            {
                dgvDanhSachPhieu.Columns.Add(buttonColumn);
            }
        }
        private void ClearForm(string maThe)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            txtMaPhieu.Clear();
            cboNhanVien.Enabled = true;
            dtPNgayTao.Enabled = true;
            dtPNgayTao.Value = DateTime.Now;
            chkChoXacNhan.Enabled = true;
            chkDaThanhToan.Enabled = true;
            dtPNgayTao.Value = DateTime.Now;
            chkChoXacNhan.Checked = true;
        }

        private void frmPhieuBanHang_Load(object sender, EventArgs e)
        {
            ClearForm("");
            LoadDanhSachPhieu("");
            LoadNhanVien();
            LoadTheLuuDong();
        }

        private void dgvDanhSachPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDanhSachPhieu.Rows[e.RowIndex];
            cboMaThe.SelectedValue = row.Cells["MaThe"].Value.ToString();
            txtMaPhieu.Text = row.Cells["MaPhieu"].Value.ToString();
            cboNhanVien.SelectedValue = row.Cells["MaNhanVien"].Value.ToString();
            dtPNgayTao.Text = row.Cells["NgayTao"].Value.ToString();
            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            if (trangThai)
            {
                chkDaThanhToan.Checked = true;
                chkDaThanhToan.Enabled = false;
                chkChoXacNhan.Enabled = false;
                cboNhanVien.Enabled = false;

                dtPNgayTao.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                chkDaThanhToan.Checked = false;
                chkDaThanhToan.Enabled = true;
                chkChoXacNhan.Enabled = true;
                cboNhanVien.Enabled = true;
                chkChoXacNhan.Checked = true;
                chkChoXacNhan.Enabled = true;

                // Bật nút "Sửa"
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maThe = cboMaThe.SelectedValue?.ToString();
            string maNhanVien = cboNhanVien?.SelectedValue?.ToString();
            DateTime ngayTao = dtPNgayTao.Value;

            bool trangthai;
            if (chkChoXacNhan.Checked)
            {
                trangthai = false;
            }
            else
            {
                trangthai = true;
            }
            if (string.IsNullOrEmpty(maNhanVien) || string.IsNullOrEmpty(maThe))
            {
                MessageBox.Show("Vui lòng điển đẩy đủ thông tin phiếu");
                return;
            }
            PhieuBanHang theLuuDong = new PhieuBanHang
            {
                MaThe = maThe,
                MaNhanVien = maNhanVien,
                NgayTao = ngayTao,
                TrangThai = trangthai
            };
            BUSPhieuBanHang bus = new BUSPhieuBanHang();
            string result = bus.InsertPhieuBanHang(theLuuDong);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                ClearForm(maThe);
                LoadDanhSachPhieu("");
                LoadNhanVien();
                LoadTheLuuDong();
                cboMaThe.SelectedValue = maThe;
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maThe = cboMaThe.SelectedValue?.ToString();
            string maPhieu = txtMaPhieu.Text.Trim();
            string chuSoHuu = cboMaThe.Text;
            if (string.IsNullOrEmpty(maPhieu))
            {
                if (dgvDanhSachPhieu.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvDanhSachPhieu.SelectedRows[0];
                    maPhieu = selectedRow.Cells["MaPhieu"].Value.ToString();
                    maThe = selectedRow.Cells["MaThe"].Value.ToString();
                    chuSoHuu = selectedRow.Cells["chuSoHuu"].ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thông tin cần xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (string.IsNullOrEmpty(maPhieu))
            {
                MessageBox.Show("Xóa không thành công");
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa {maPhieu} - {chuSoHuu}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                BUSPhieuBanHang bus = new BUSPhieuBanHang();
                string kq = bus.DeletePhieuBanHang(maPhieu);

                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show($"Xóa thông tin {maPhieu} - {chuSoHuu} thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearForm(maThe);
                    LoadTheLuuDong();
                    LoadNhanVien();
                    LoadDanhSachPhieu("");

                    cboMaThe.SelectedValue = maThe;
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maThe = cboMaThe.SelectedValue?.ToString();
            string maPhieu = txtMaPhieu.Text;
            string maNhanVien = cboNhanVien.SelectedValue?.ToString();
            DateTime ngayTao = dtPNgayTao.Value;
            bool trangThai;
            if (chkChoXacNhan.Checked)
            {
                trangThai = false;
            }
            else
            {
                trangThai = true;
            }
            if (string.IsNullOrEmpty(maNhanVien) || string.IsNullOrEmpty(maThe))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin phếu");
                return;
            }

            PhieuBanHang theLuuDong = new PhieuBanHang()
            {
                MaPhieu = maPhieu,
                MaThe = maThe,
                MaNhanVien = maNhanVien,
                NgayTao = ngayTao,
                TrangThai = trangThai
            };
            BUSPhieuBanHang bus = new BUSPhieuBanHang();
            string result = bus.UpdatePhieuBanHang(theLuuDong);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                ClearForm(maThe);
                LoadDanhSachPhieu("");
                LoadNhanVien();
                LoadTheLuuDong();
                cboMaThe.SelectedValue = maThe;
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            ClearForm("");
            LoadDanhSachPhieu("");
            LoadNhanVien();
            LoadTheLuuDong();
        }

        private void dgvDanhSachPhieu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string maPhieu = dgvDanhSachPhieu.Rows[e.RowIndex].Cells["MaPhieu"].Value.ToString();
            string maThe = dgvDanhSachPhieu.Rows[e.RowIndex].Cells["MaThe"].Value.ToString();
            string maNV = dgvDanhSachPhieu.Rows[e.RowIndex].Cells["MaNhanVien"].Value.ToString();
            PhieuBanHang phieu = (PhieuBanHang)dgvDanhSachPhieu.CurrentRow.DataBoundItem;
            TheLuuDong the = new TheLuuDong();
            NhanVien nv = new NhanVien();
            foreach (TheLuuDong item in cboMaThe.Items)
            {
                if (item.MaThe == maThe)
                {
                    the = item;
                    break;
                }
            }

            foreach (NhanVien item in cboNhanVien.Items)
            {
                if (item.MaNhanVien == maNV)
                {
                    nv = item;
                    break;
                }
            }
            frmChiTietBanHang frmChiTiet = new frmChiTietBanHang(the, phieu, nv);
            frmChiTiet.ShowDialog();
        }
    }
}
