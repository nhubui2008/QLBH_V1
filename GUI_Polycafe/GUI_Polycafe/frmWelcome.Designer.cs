namespace GUI_Polycafe
{
    partial class frmWelcome
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
            progressBar = new ProgressBar();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 370);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(776, 68);
            progressBar.TabIndex = 1;
            // 
            // frmWelcome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.logo_XÀI_TẠM_01;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(800, 450);
            Controls.Add(progressBar);
            DoubleBuffered = true;
            Name = "frmWelcome";
            Text = "frmWelcome";
            FormClosing += frmWelcome_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar;
    }
}