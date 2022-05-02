namespace CTQM_Shoes.ChildForm
{
    partial class HoaDonControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tonglb = new System.Windows.Forms.Label();
            this.DonGialb = new System.Windows.Forms.Label();
            this.TenGiaylb = new System.Windows.Forms.Label();
            this.SLlb = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Sizelb = new System.Windows.Forms.Label();
            this.Giamlb = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tonglb
            // 
            this.Tonglb.AutoSize = true;
            this.Tonglb.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tonglb.Location = new System.Drawing.Point(493, 10);
            this.Tonglb.Name = "Tonglb";
            this.Tonglb.Size = new System.Drawing.Size(49, 20);
            this.Tonglb.TabIndex = 3;
            this.Tonglb.Text = "TỔNG";
            // 
            // DonGialb
            // 
            this.DonGialb.AutoSize = true;
            this.DonGialb.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DonGialb.Location = new System.Drawing.Point(258, 10);
            this.DonGialb.Name = "DonGialb";
            this.DonGialb.Size = new System.Drawing.Size(70, 20);
            this.DonGialb.TabIndex = 4;
            this.DonGialb.Text = "ĐƠN GIÁ";
            // 
            // TenGiaylb
            // 
            this.TenGiaylb.AutoSize = true;
            this.TenGiaylb.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenGiaylb.Location = new System.Drawing.Point(3, 0);
            this.TenGiaylb.Name = "TenGiaylb";
            this.TenGiaylb.Size = new System.Drawing.Size(71, 20);
            this.TenGiaylb.TabIndex = 5;
            this.TenGiaylb.Text = "TÊN GIÀY";
            // 
            // SLlb
            // 
            this.SLlb.AutoSize = true;
            this.SLlb.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SLlb.Location = new System.Drawing.Point(12, 10);
            this.SLlb.Name = "SLlb";
            this.SLlb.Size = new System.Drawing.Size(24, 20);
            this.SLlb.TabIndex = 6;
            this.SLlb.Text = "SL";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.TenGiaylb);
            this.flowLayoutPanel1.Controls.Add(this.Sizelb);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(75, 10);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(165, 74);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // Sizelb
            // 
            this.Sizelb.AutoSize = true;
            this.Sizelb.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sizelb.Location = new System.Drawing.Point(80, 0);
            this.Sizelb.Name = "Sizelb";
            this.Sizelb.Size = new System.Drawing.Size(36, 20);
            this.Sizelb.TabIndex = 5;
            this.Sizelb.Text = "Size";
            // 
            // Giamlb
            // 
            this.Giamlb.AutoSize = true;
            this.Giamlb.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Giamlb.Location = new System.Drawing.Point(398, 10);
            this.Giamlb.Name = "Giamlb";
            this.Giamlb.Size = new System.Drawing.Size(46, 20);
            this.Giamlb.TabIndex = 4;
            this.Giamlb.Text = "GIẢM";
            // 
            // HoaDonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Tonglb);
            this.Controls.Add(this.Giamlb);
            this.Controls.Add(this.DonGialb);
            this.Controls.Add(this.SLlb);
            this.Name = "HoaDonControl";
            this.Size = new System.Drawing.Size(569, 98);
            this.Load += new System.EventHandler(this.HoaDonControl_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Tonglb;
        private System.Windows.Forms.Label DonGialb;
        private System.Windows.Forms.Label TenGiaylb;
        private System.Windows.Forms.Label SLlb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label Sizelb;
        private System.Windows.Forms.Label Giamlb;
    }
}
