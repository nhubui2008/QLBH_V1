using BLL_PolyCafe;
using DTO_PolyCafe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Polycafe
{
    public partial class frmLoaiSanPham : Form
    {
        public frmLoaiSanPham()
        {
            InitializeComponent();
        }
        private void ClearForm()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            txtMaLoai.Clear();
            txtGhiChu.Clear();
            txtTenLoai.Clear();
        }

        private void LoadDanhSachLoaiSP()
        {
            BUSLoaiSanPham busLoaiSp = new BUSLoaiSanPham();
            dgvDanhSachLoaiSP.DataSource = null;
            dgvDanhSachLoaiSP.DataSource = busLoaiSp.GetLoaiSanPhamList();
            dgvDanhSachLoaiSP.ColumnHeadersHeight = 40;
            dgvDanhSachLoaiSP.Columns["MaLoai"].HeaderText = "Mã Loại";
            dgvDanhSachLoaiSP.Columns["TenLoai"].HeaderText = "Tên Loại";
            dgvDanhSachLoaiSP.Columns["GhiChu"].HeaderText = "Ghi Chú";

            dgvDanhSachLoaiSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachLoaiSP();
        }

        private void dgvDanhSachLoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDanhSachLoaiSP.Rows[e.RowIndex];
            // Đổ dữ liệu vào các ô nhập liệu trên form
            txtMaLoai.Text = row.Cells["MaLoai"].Value.ToString();
            txtTenLoai.Text = row.Cells["TenLoai"].Value.ToString();
            txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();

            // Bật nút "Sửa"
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            // Tắt chỉnh sửa mã thẻ
            txtMaLoai.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maLoai = txtMaLoai.Text.Trim();
            string tenLoai = txtTenLoai.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();


            if (string.IsNullOrEmpty(tenLoai))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin thẻ lưu động.");
                return;
            }

            LoaiSanPham loai = new LoaiSanPham
            {
                MaLoai = maLoai,
                TenLoai = tenLoai,
                GhiChu = ghiChu
            };
            BUSLoaiSanPham bus = new BUSLoaiSanPham();
            string result = bus.InsertLoaiSanPham(loai);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                ClearForm();
                LoadDanhSachLoaiSP();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaLoai.Text = "";
            ClearForm();
            LoadDanhSachLoaiSP();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maLoai = txtMaLoai.Text.Trim();
            string tenLoai = txtTenLoai.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();


            if (string.IsNullOrEmpty(tenLoai))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin loại sản phẩm.");
                return;
            }
            LoaiSanPham loaiSanPham = new LoaiSanPham
            {
                MaLoai = maLoai,
                TenLoai = tenLoai,
                GhiChu = ghiChu
            };
            BUSLoaiSanPham bus = new BUSLoaiSanPham();
            string result = bus.UpdateLoaiSanPham(loaiSanPham);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                ClearForm();
                LoadDanhSachLoaiSP();
            }
            else
            {
                MessageBox.Show(result);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maLoai = txtMaLoai.Text.Trim();
            string tenLoai = txtTenLoai.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();
            if (string.IsNullOrEmpty(maLoai))
            {
                if (dgvDanhSachLoaiSP.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvDanhSachLoaiSP.SelectedRows[0];
                    maLoai = selectedRow.Cells["MaLoai"].Value.ToString();
                    tenLoai = selectedRow.Cells["TenLoai"].Value.ToString();
                    ghiChu = selectedRow.Cells["GhiChu"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thông tin loại sản phẩm cần xóa xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (string.IsNullOrEmpty(maLoai))
            {
                MessageBox.Show("Xóa không thành công.");
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa loại sản phẩm {maLoai} - {tenLoai}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                BUSLoaiSanPham bus = new BUSLoaiSanPham();
                string kq = bus.DeleteLoaiSanPham(maLoai);

                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show($"Xóa thông tin loại sản phẩm {maLoai} - {tenLoai} thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachLoaiSP();
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
