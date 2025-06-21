using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTIL_PolyCafe;

namespace GUI_Polycafe
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private Form currentFormChild;

        private void openChildForm(Form formChild)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = formChild;
            formChild.TopLevel = false;
            formChild.FormBorderStyle = FormBorderStyle.None;
            formChild.Dock = DockStyle.Fill;
            pnMain.Controls.Add(formChild);
            pnMain.Tag = formChild;
            formChild.BringToFront();
            formChild.Show();
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTKTheoNhanVien());
        }

        private void theoLoạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTKDoanhThuTheoLoaiSP());
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmDoiMatKhau());
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhanVien());
        }

        private void sảnPhẩmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openChildForm(new frmSanPham());
        }

        private void loạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmLoaiSanPham());
        }

        private void thẻLưuĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTheLuuDong());
        }

        private void phiếuBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmPhieuBanHang());
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthUtil.user = null;
            frmDangNhap login = new frmDangNhap();
            login.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
