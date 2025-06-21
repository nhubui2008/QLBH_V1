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
using GUI_Polycafe.Helper;

namespace GUI_Polycafe
{
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }
        private void ClearForm()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtDonGia.Clear();
            rdoDangHoatDong.Checked = true;
            pbHinhAnh.Image = null;
        }
        private void LoadDanhSachSanPham()
        {
            BUSSanPham bUSSanPham = new BUSSanPham();
            dgvSanPham.DataSource = null;
            List<SanPham> lstSP = bUSSanPham.GetSanPhamList();
            dgvSanPham.DataSource = lstSP;
        }
        private void LoadLoaiSanPham()
        {
            try
            {
                BUSLoaiSanPham bUSLoaiSanPham = new BUSLoaiSanPham();
                List<LoaiSanPham> dsLoai = bUSLoaiSanPham.GetLoaiSanPhamList();
                cboLoaiSP.DataSource = dsLoai;
                cboLoaiSP.ValueMember = "MaLoai";
                cboLoaiSP.DisplayMember = "TenLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại sản phẩm" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenSP = txtTenSP.Text.Trim();
                string donGiaText = txtDonGia.Text.Trim();
                string maLoai = cboLoaiSP.SelectedValue?.ToString();
                bool trangThai = rdoDangHoatDong.Checked;
                string SavePath = ImageUtil.SaveImage(pbHinhAnh.Image, "Uploads");

                // Kiểm tra dữ liệu nhập vào
                if (string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(donGiaText) || string.IsNullOrEmpty(maLoai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi đơn giá
                if (!decimal.TryParse(donGiaText, out decimal donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo đối tượng sản phẩm
                SanPham sp = new SanPham
                {
                    TenSanPham = tenSP,
                    DonGia = donGia,
                    MaLoai = maLoai,
                    TrangThai = trangThai,
                    HinhAnh = SavePath
                };

                // Thêm sản phẩm vào cơ sở dữ liệu
                BUSSanPham bUSSanPham = new BUSSanPham();
                bUSSanPham.InsertSanPham(sp);

                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới form sau khi thêm
                ClearForm();
                LoadDanhSachSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string tenSP = txtTenSP.Text.Trim();
                string donGiaText = txtDonGia.Text.Trim();
                string maLoai = cboLoaiSP.SelectedValue?.ToString();
                bool trangThai = rdoDangHoatDong.Checked;
                string maSP = txtMaSP.Text.Trim();
                string SavePath = ImageUtil.SaveImage(pbHinhAnh.Image, "Uploads");

                // Kiểm tra dữ liệu nhập vào
                if (string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(donGiaText) || string.IsNullOrEmpty(maLoai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi đơn giá
                if (!decimal.TryParse(donGiaText, out decimal donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo đối tượng sản phẩm
                SanPham sp = new SanPham
                {
                    MaSanPham = maSP,
                    TenSanPham = tenSP,
                    DonGia = donGia,
                    MaLoai = maLoai,
                    TrangThai = trangThai,
                    HinhAnh = SavePath
                };

                // Thêm sản phẩm vào cơ sở dữ liệu
                BUSSanPham bUSSanPham = new BUSSanPham();
                string result = bUSSanPham.UpdateSanPham(sp);

                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Cập nhật thông tin thành công");
                    ClearForm();
                    LoadDanhSachSanPham();
                }
                else
                {
                    MessageBox.Show(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text.Trim();
            string tenSP = string.Empty;
            string hinhAnh = string.Empty;

            if (string.IsNullOrEmpty(maSP))
            {
                if (dgvSanPham.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvSanPham.SelectedRows[0];
                    maSP = selectedRow.Cells["MaSanPham"].Value.ToString();
                    tenSP = selectedRow.Cells["TenSanPham"].Value.ToString();
                    hinhAnh = selectedRow.Cells["HinhAnh"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                tenSP = txtTenSP.Text.Trim();
            }

            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Xóa không thành công.");
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm {maSP} - {tenSP}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                BUSSanPham bus = new BUSSanPham();
                string kq = bus.DeleteSanPham(maSP);

                if (string.IsNullOrEmpty(kq))
                {

                    MessageBox.Show($"Xóa thông tin sản phẩm {maSP} - {tenSP} thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachSanPham();
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
            LoadLoaiSanPham();
            ClearForm();
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
            txtMaSP.Text = row.Cells["MaSanPham"].Value.ToString();
            txtTenSP.Text = row.Cells["TenSanPham"].Value.ToString();
            txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
            cboLoaiSP.SelectedValue = row.Cells["MaLoai"].Value.ToString();
            pbHinhAnh.Image = ImageUtil.LoadImage(row.Cells["HinhAnh"].Value.ToString());
            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            if (trangThai)
            {
                rdoDangHoatDong.Checked = true;
            }
            else
            {
                rdoDangHoatDong.Checked = true;
            }
            // Bật nút "Sửa"
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachSanPham();
            LoadLoaiSanPham();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbHinhAnh.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
    }
}
