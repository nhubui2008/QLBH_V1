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
using DAL_PolyCafe;
using DTO_PolyCafe;

namespace GUI_Polycafe
{
    public partial class frmChiTietBanHang : Form
    {
        public frmChiTietBanHang(TheLuuDong the, PhieuBanHang phieu, NhanVien nv)
        {
            InitializeComponent();
            theLuuDong = the;
            phieuBanHang = phieu;
            nhanVien = nv;
            lstChiTiet = new List<ChiTietPhieu>();
            lstSanPham = new List<SanPham>();
            isActive = phieu.TrangThai;
        }
        private TheLuuDong theLuuDong;
        private PhieuBanHang phieuBanHang;
        private NhanVien nhanVien;
        private List<ChiTietPhieu> lstChiTiet;
        private List<SanPham> lstSanPham;
        bool isActive = true;

        private void activeTranfer()
        {
            if (isActive)
            {
                btnThemChiTiet.Enabled = false;
                btnXoaChiTiet.Enabled = false;
                txtPhanTram.Enabled = false;
            }
        }

        private void LoadInfo()
        {
            txtChuSoHuu.Text = $"{theLuuDong.MaThe} - {theLuuDong.ChuSoHuu}";
            txtMaPhieu.Text = phieuBanHang.MaPhieu;
            txtNgayLap.Text = phieuBanHang.NgayTao.ToString("dd/MM/yyyy");
        }
        private void loadSanPham()
        {
            BUSSanPham sp = new BUSSanPham();
            lstSanPham = sp.GetSanPhamList(1);
            dgvSanPham.DataSource = lstSanPham;
            dgvSanPham.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
            dgvSanPham.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
            dgvSanPham.Columns["DonGia"].HeaderText = "Đơn Gía";
            dgvSanPham.Columns["TenLoai"].HeaderText = "Loại Sản Phẩm";
            dgvSanPham.Columns["HinhAnh"].HeaderText = "Hình Ảnh";


            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void loadChiTietPhieu(string maPhieu)
        {
            BUSChiTietPhieu bus = new BUSChiTietPhieu();
            lstChiTiet = bus.GetChiTietPhieuList(maPhieu);
            dgvChiTiet.DataSource = lstChiTiet;
            dgvChiTiet.Columns["MaChiTiet"].Visible = false;
            dgvChiTiet.Columns["MaPhieu"].Visible = false;
            dgvChiTiet.Columns["MaSanPham"].Visible = false;
            dgvChiTiet.Columns["TenSanPham"].HeaderText = "Sản Phẩm";
            dgvChiTiet.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            dgvChiTiet.Columns["SoLuong"].ReadOnly = false;

            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn col in dgvChiTiet.Columns)
            {
                col.ReadOnly = true;
            }
            dgvChiTiet.Columns["SoLuong"].ReadOnly = false;
        }
        private void transfer(SanPham sp, int soLuong = 1)
        {
            if (isActive)
            {
                return;
            }
            if (sp != null)
            {
                BUSChiTietPhieu bus = new BUSChiTietPhieu();
                ChiTietPhieu existingItem = lstChiTiet.FirstOrDefault(item => item.MaSanPham == sp.MaSanPham);
                if (existingItem != null)
                {
                    existingItem.SoLuong += soLuong;
                    string result = bus.UpdateSoLuong(existingItem);
                    if (!string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show("Thêm sản phẩm không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    ChiTietPhieu ct = new ChiTietPhieu()
                    {
                        MaPhieu = phieuBanHang.MaPhieu,
                        MaSanPham = sp.MaSanPham,
                        SoLuong = soLuong,
                        DonGia = sp.DonGia,
                    };
                    string result = bus.InsertChiTietPhieu(ct);
                    if (!string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show("Thêm sản phẩm không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                loadChiTietPhieu(phieuBanHang.MaPhieu);

            }
        }

        private void deleteChiTiet()
        {
            if (dgvChiTiet.CurrentRow != null)
            {
                string id = Convert.ToString(dgvChiTiet.CurrentRow.Cells["MaChiTiet"].Value);
                string name = Convert.ToString(dgvChiTiet.CurrentRow.Cells["TenSanPham"].Value);
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phầm {name}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    BUSChiTietPhieu bus = new BUSChiTietPhieu();
                    string kq = bus.DeleteChiTiet(id); ;
                    if (string.IsNullOrEmpty(kq))
                    {
                        loadChiTietPhieu(phieuBanHang.MaPhieu);
                    }
                }
            }
        }
        private void loadThanhToan()
        {
            txtTong.Text = "0";
            txtGiamGia.Text = "0";
            txtPhanTram.Text = "0";
            txtThanhTien.Text = "0";
            txtDichVu.Text = "0";
        }

        private void frmChiTietBanHang_Load(object sender, EventArgs e)
        {
            loadThanhToan();
            LoadInfo();
            loadSanPham();
            loadChiTietPhieu(phieuBanHang.MaPhieu);
            activeTranfer();

        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isActive)
            {
                return;
            }
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                // Tạo đối tượng từ dữ liệu hàng
                SanPham sanPham = new SanPham
                {
                    MaSanPham = row.Cells["MaSanPham"].Value.ToString(),
                    TenSanPham = row.Cells["TenSanPham"].Value.ToString(),
                    DonGia = Convert.ToInt32(row.Cells["DonGia"].Value)
                };

                transfer(sanPham);
            }

        }

        private void dgvSanPham_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (isActive)
            {
                return;
            }

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                BUSChiTietPhieu bus = new BUSChiTietPhieu();
                ChiTietPhieu ct = lstChiTiet[e.RowIndex];
                int newQuantity;
                if (int.TryParse(dgvChiTiet.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString(), out newQuantity))
                {
                    ct.SoLuong = newQuantity;
                    string result = bus.UpdateSoLuong(ct);
                    if (!string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show("Thêm sản phẩm không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //Đảm bảo ko lỗi khi đang edit mà chuyển ô
                    this.BeginInvoke((Action)(() =>
                    {
                        loadChiTietPhieu(phieuBanHang.MaPhieu);
                    }));
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if (isActive)
            {
                return;
            }
            deleteChiTiet();
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (isActive)
            {
                return;
            }
            if (dgvSanPham.CurrentRow != null)
            {
                string id = Convert.ToString(dgvSanPham.CurrentRow.Cells["MaSanPham"].Value);
                string ten = Convert.ToString(dgvSanPham.CurrentRow.Cells["TenSanPham"].Value);
                decimal dongia = Convert.ToDecimal(dgvSanPham.CurrentRow.Cells["DonGia"].Value);
                SanPham sanPham = new SanPham
                {
                    MaSanPham = id,
                    TenSanPham = ten,
                    DonGia = dongia
                };

                transfer(sanPham);
            }

        }
    }
}
