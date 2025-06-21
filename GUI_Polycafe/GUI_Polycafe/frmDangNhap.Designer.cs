namespace GUI_Polycafe
{
    partial class frmDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnThoat = new Button();
            btnDangNhap = new Button();
            chkHTMatKhau = new CheckBox();
            txtMatKhau = new TextBox();
            txtTenDangNhap = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(255, 128, 128);
            btnThoat.Font = new Font("Segoe UI", 15F);
            btnThoat.ForeColor = Color.Snow;
            btnThoat.Location = new Point(63, 414);
            btnThoat.Margin = new Padding(2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(315, 49);
            btnThoat.TabIndex = 15;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.CornflowerBlue;
            btnDangNhap.Font = new Font("Segoe UI", 15F);
            btnDangNhap.ForeColor = Color.Snow;
            btnDangNhap.Location = new Point(62, 347);
            btnDangNhap.Margin = new Padding(2);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(315, 51);
            btnDangNhap.TabIndex = 14;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // chkHTMatKhau
            // 
            chkHTMatKhau.AutoSize = true;
            chkHTMatKhau.Location = new Point(62, 287);
            chkHTMatKhau.Margin = new Padding(2);
            chkHTMatKhau.Name = "chkHTMatKhau";
            chkHTMatKhau.Size = new Size(121, 19);
            chkHTMatKhau.TabIndex = 13;
            chkHTMatKhau.Text = "Hiển thị mật khẩu";
            chkHTMatKhau.UseVisualStyleBackColor = true;
            chkHTMatKhau.CheckedChanged += chkHTMatKhau_CheckedChanged;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 12F);
            txtMatKhau.Location = new Point(62, 244);
            txtMatKhau.Margin = new Padding(2);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(316, 29);
            txtMatKhau.TabIndex = 12;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new Font("Segoe UI", 12F);
            txtTenDangNhap.Location = new Point(61, 153);
            txtTenDangNhap.Margin = new Padding(2);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(316, 29);
            txtTenDangNhap.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(62, 212);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(75, 21);
            label3.TabIndex = 10;
            label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(62, 121);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(111, 21);
            label2.TabIndex = 9;
            label2.Text = "Tên đăng nhập";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(122, 55);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(200, 46);
            label1.TabIndex = 8;
            label1.Text = "Đăng Nhập";
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 519);
            Controls.Add(btnThoat);
            Controls.Add(btnDangNhap);
            Controls.Add(chkHTMatKhau);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmDangNhap";
            Text = "frmDangNhap";
            FormClosing += frmDangNhap_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnThoat;
        private Button btnDangNhap;
        private CheckBox chkHTMatKhau;
        private TextBox txtMatKhau;
        private TextBox txtTenDangNhap;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}