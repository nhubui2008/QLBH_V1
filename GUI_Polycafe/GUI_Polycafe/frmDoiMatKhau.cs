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
using UTIL_PolyCafe;

namespace GUI_Polycafe
{
    public partial class frmDoiMatKhau : Form
    {
        BUSNhanVien BUSNhanVien = new BUSNhanVien();
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void chkHTMatKhauCu_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhauCu.PasswordChar = chkHTMatKhauCu.Checked ? '\0' : '*';
        }

        private void chkHTMatKhauMoi_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhauMoi.PasswordChar = chkHTMatKhauMoi.Checked ? '\0' : '*';
        }

        private void chkHTXacNhanMat_CheckedChanged(object sender, EventArgs e)
        {
            txtXacNhanMatKhau.PasswordChar = chkHTXacNhanMat.Checked ? '\0' : '*';
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (!AuthUtil.user.MatKhau.Equals(txtMatKhauCu.Text))
            {
                MessageBox.Show(this, "Mật khẩu cũ chưa đúng!!!");
            }
            else
            {
                if (!AuthUtil.user.MatKhau.Equals(txtMatKhauCu.Text))
                {
                    MessageBox.Show(this, "Mật khẩu cũ chưa đúng!!!");
                }
                else
                {
                    if (!txtMatKhauMoi.Text.Equals(txtXacNhanMatKhau.Text))
                    {
                        MessageBox.Show(this, "Xác nhận mật khẩu mới chưa trùng khớp!!!");
                    }
                    else
                    {
                        AuthUtil.user.MatKhau = txtMatKhauMoi.Text;

                        if (BUSNhanVien.ResetMatKhau(AuthUtil.user.Email, txtMatKhauMoi.Text))
                        {
                            MessageBox.Show("Cập nhật mật khẩu thành công!!!");
                            frmDangNhap login = new frmDangNhap();
                            login.Show();
                            this.Hide();
                        }
                        else MessageBox.Show("Đổi mật khẩu thất bại, vui lòng kiểm tra lại!!!");
                    }
                }
            }
        }
    }
}
