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
using UTIL_PolyCafe;

namespace GUI_Polycafe
{
    public partial class frmDangNhap : Form
    {
        BUSNhanVien BUSNhanVien = new BUSNhanVien();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void chkHTMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            {
                txtMatKhau.PasswordChar = chkHTMatKhau.Checked ? '\0' : '*';
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text;
            string password = txtMatKhau.Text;
            NhanVien nhanVien = BUSNhanVien.DangNhap(username, password);
            if (nhanVien == null)
            {
                MessageBox.Show(this, "Tài khoản không tồn tại");
            }
            else if (!nhanVien.MatKhau.Equals(password))
            {
                MessageBox.Show(this, "Mật khẩu chưa đúng");
            }
            else
            {
                if (nhanVien.TrangThai == false)
                {
                    MessageBox.Show(this, "Tài khoản đang tạm khóa, vui lòng viên hệ QTV!!!");
                    return;
                }
                AuthUtil.user = nhanVien;

                frmMain main = new frmMain();
                main.Show();
                this.Hide();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận thoát chương trình?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }

        }
    }
}
