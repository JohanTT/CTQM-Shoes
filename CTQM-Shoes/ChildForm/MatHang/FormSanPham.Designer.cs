namespace CTQM_Shoes.ChildForm
{
    partial class FormSanPham
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
            this.DSMatHangfl = new System.Windows.Forms.FlowLayoutPanel();
            this.CTMHpn = new System.Windows.Forms.Panel();
            this.ChiTietMatHangpn = new System.Windows.Forms.Panel();
            this.DSMatHangfl.SuspendLayout();
            this.SuspendLayout();
            // 
            // DSMatHangfl
            // 
            this.DSMatHangfl.AutoScroll = true;
            this.DSMatHangfl.Controls.Add(this.CTMHpn);
            this.DSMatHangfl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DSMatHangfl.Location = new System.Drawing.Point(0, 0);
            this.DSMatHangfl.Name = "DSMatHangfl";
            this.DSMatHangfl.Size = new System.Drawing.Size(1109, 721);
            this.DSMatHangfl.TabIndex = 4;
            // 
            // CTMHpn
            // 
            this.CTMHpn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CTMHpn.Location = new System.Drawing.Point(3, 3);
            this.CTMHpn.Name = "CTMHpn";
            this.CTMHpn.Size = new System.Drawing.Size(987, 0);
            this.CTMHpn.TabIndex = 0;
            this.CTMHpn.Visible = false;
            // 
            // ChiTietMatHangpn
            // 
            this.ChiTietMatHangpn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChiTietMatHangpn.Location = new System.Drawing.Point(0, 0);
            this.ChiTietMatHangpn.Name = "ChiTietMatHangpn";
            this.ChiTietMatHangpn.Size = new System.Drawing.Size(1109, 721);
            this.ChiTietMatHangpn.TabIndex = 1;
            // 
            // FormSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 721);
            this.Controls.Add(this.DSMatHangfl);
            this.Controls.Add(this.ChiTietMatHangpn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSanPham";
            this.Text = "Sản Phẩm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DSMatHangfl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel DSMatHangfl;
        private System.Windows.Forms.Panel CTMHpn;
        private System.Windows.Forms.Panel ChiTietMatHangpn;
    }
}