namespace Otp_Stealer
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tmrSystem = new System.Windows.Forms.Timer(this.components);
            this.listIslemler = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(541, 14);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(176, 56);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Başlat";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tmrSystem
            // 
            this.tmrSystem.Tick += new System.EventHandler(this.tmrSystem_Tick);
            // 
            // listIslemler
            // 
            this.listIslemler.FormattingEnabled = true;
            this.listIslemler.Location = new System.Drawing.Point(541, 76);
            this.listIslemler.Name = "listIslemler";
            this.listIslemler.Size = new System.Drawing.Size(176, 381);
            this.listIslemler.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(724, 469);
            this.Controls.Add(this.listIslemler);
            this.Controls.Add(this.btnLogin);
            this.Name = "frmMain";
            this.Text = "OTPÇAL";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Timer tmrSystem;
        private System.Windows.Forms.ListBox listIslemler;
    }
}

