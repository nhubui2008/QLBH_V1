namespace GUI_Polycafe
{
    partial class frmDoiMatKhau
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
            btnDoiMatKhau = new Button();
            txtTenNhanVien = new TextBox();
            txtMaNhanVien = new TextBox();
            txtXacNhanMatKhau = new TextBox();
            txtMatKhauMoi = new TextBox();
            txtMatKhauCu = new TextBox();
            chkHTMatKhauCu = new CheckBox();
            chkHTXacNhanMat = new CheckBox();
            chkHTMatKhauMoi = new CheckBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.Font = new Font("Segoe UI", 12F);
            btnDoiMatKhau.Location = new Point(299, 355);
            btnDoiMatKhau.Margin = new Padding(2);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(125, 43);
            btnDoiMatKhau.TabIndex = 29;
            btnDoiMatKhau.Text = "Đổi mật khẩu";
            btnDoiMatKhau.UseVisualStyleBackColor = true;
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            // 
            // txtTenNhanVien
            // 
            txtTenNhanVien.Enabled = false;
            txtTenNhanVien.Font = new Font("Segoe UI", 15F);
            txtTenNhanVien.Location = new Point(187, 95);
            txtTenNhanVien.Margin = new Padding(2);
            txtTenNhanVien.Name = "txtTenNhanVien";
            txtTenNhanVien.Size = new Size(431, 34);
            txtTenNhanVien.TabIndex = 28;
            // 
            // txtMaNhanVien
            // 
            txtMaNhanVien.Enabled = false;
            txtMaNhanVien.Font = new Font("Segoe UI", 15F);
            txtMaNhanVien.Location = new Point(187, 35);
            txtMaNhanVien.Margin = new Padding(2);
            txtMaNhanVien.Name = "txtMaNhanVien";
            txtMaNhanVien.Size = new Size(431, 34);
            txtMaNhanVien.TabIndex = 27;
            // 
            // txtXacNhanMatKhau
            // 
            txtXacNhanMatKhau.Font = new Font("Segoe UI", 15F);
            txtXacNhanMatKhau.Location = new Point(187, 287);
            txtXacNhanMatKhau.Margin = new Padding(2);
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.Size = new Size(325, 34);
            txtXacNhanMatKhau.TabIndex = 26;
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Font = new Font("Segoe UI", 15F);
            txtMatKhauMoi.Location = new Point(187, 223);
            txtMatKhauMoi.Margin = new Padding(2);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(325, 34);
            txtMatKhauMoi.TabIndex = 25;
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Font = new Font("Segoe UI", 15F);
            txtMatKhauCu.Location = new Point(187, 158);
            txtMatKhauCu.Margin = new Padding(2);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.Size = new Size(325, 34);
            txtMatKhauCu.TabIndex = 24;
            // 
            // chkHTMatKhauCu
            // 
            chkHTMatKhauCu.AutoSize = true;
            chkHTMatKhauCu.Font = new Font("Segoe UI", 12F);
            chkHTMatKhauCu.Location = new Point(535, 161);
            chkHTMatKhauCu.Margin = new Padding(2);
            chkHTMatKhauCu.Name = "chkHTMatKhauCu";
            chkHTMatKhauCu.Size = new Size(83, 25);
            chkHTMatKhauCu.TabIndex = 23;
            chkHTMatKhauCu.Text = "Hiển thị";
            chkHTMatKhauCu.UseVisualStyleBackColor = true;
            chkHTMatKhauCu.CheckedChanged += chkHTMatKhauCu_CheckedChanged;
            // 
            // chkHTXacNhanMat
            // 
            chkHTXacNhanMat.AutoSize = true;
            chkHTXacNhanMat.Font = new Font("Segoe UI", 12F);
            chkHTXacNhanMat.Location = new Point(535, 292);
            chkHTXacNhanMat.Margin = new Padding(2);
            chkHTXacNhanMat.Name = "chkHTXacNhanMat";
            chkHTXacNhanMat.Size = new Size(83, 25);
            chkHTXacNhanMat.TabIndex = 22;
            chkHTXacNhanMat.Text = "Hiển thị";
            chkHTXacNhanMat.UseVisualStyleBackColor = true;
            chkHTXacNhanMat.CheckedChanged += chkHTXacNhanMat_CheckedChanged;
            // 
            // chkHTMatKhauMoi
            // 
            chkHTMatKhauMoi.AutoSize = true;
            chkHTMatKhauMoi.Font = new Font("Segoe UI", 12F);
            chkHTMatKhauMoi.Location = new Point(535, 224);
            chkHTMatKhauMoi.Margin = new Padding(2);
            chkHTMatKhauMoi.Name = "chkHTMatKhauMoi";
            chkHTMatKhauMoi.Size = new Size(83, 25);
            chkHTMatKhauMoi.TabIndex = 21;
            chkHTMatKhauMoi.Text = "Hiển thị";
            chkHTMatKhauMoi.UseVisualStyleBackColor = true;
            chkHTMatKhauMoi.CheckedChanged += chkHTMatKhauMoi_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(33, 287);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(130, 28);
            label5.TabIndex = 20;
            label5.Text = "Xác nhận mật";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(33, 219);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(133, 28);
            label4.TabIndex = 19;
            label4.Text = "Mật khẩu mới";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(33, 158);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(119, 28);
            label3.TabIndex = 18;
            label3.Text = "Mật khẩu cũ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(33, 95);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(130, 28);
            label2.TabIndex = 17;
            label2.Text = "Tên nhân viên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(33, 35);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(129, 28);
            label1.TabIndex = 16;
            label1.Text = "Mã nhân viên";
            // 
            // frmDoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(687, 422);
            Controls.Add(btnDoiMatKhau);
            Controls.Add(txtTenNhanVien);
            Controls.Add(txtMaNhanVien);
            Controls.Add(txtXacNhanMatKhau);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(txtMatKhauCu);
            Controls.Add(chkHTMatKhauCu);
            Controls.Add(chkHTXacNhanMat);
            Controls.Add(chkHTMatKhauMoi);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmDoiMatKhau";
            Text = "frmDoiMatKhau";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDoiMatKhau;
        private TextBox txtTenNhanVien;
        private TextBox txtMaNhanVien;
        private TextBox txtXacNhanMatKhau;
        private TextBox txtMatKhauMoi;
        private TextBox txtMatKhauCu;
        private CheckBox chkHTMatKhauCu;
        private CheckBox chkHTXacNhanMat;
        private CheckBox chkHTMatKhauMoi;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}