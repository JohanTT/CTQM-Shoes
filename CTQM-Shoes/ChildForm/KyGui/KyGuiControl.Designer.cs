namespace CTQM_Shoes.ChildForm
{
    partial class KyGuiControl
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
            this.components = new System.ComponentModel.Container();
            this.Pic1 = new System.Windows.Forms.PictureBox();
            this.TenGiaylb = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.THKGlb = new System.Windows.Forms.Label();
            this.DieuKienlb = new System.Windows.Forms.Label();
            this.Tienlb = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.Xoalb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Pic1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pic1
            // 
            this.Pic1.BackColor = System.Drawing.Color.Transparent;
            this.Pic1.Location = new System.Drawing.Point(3, 5);
            this.Pic1.Name = "Pic1";
            this.Pic1.Size = new System.Drawing.Size(144, 79);
            this.Pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Pic1.TabIndex = 0;
            this.Pic1.TabStop = false;
            // 
            // TenGiaylb
            // 
            this.TenGiaylb.AutoSize = true;
            this.TenGiaylb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenGiaylb.ForeColor = System.Drawing.Color.Black;
            this.TenGiaylb.Location = new System.Drawing.Point(3, 0);
            this.TenGiaylb.Name = "TenGiaylb";
            this.TenGiaylb.Size = new System.Drawing.Size(50, 15);
            this.TenGiaylb.TabIndex = 1;
            this.TenGiaylb.Text = "Tên giày";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.TenGiaylb);
            this.flowLayoutPanel1.Enabled = false;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(153, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(178, 32);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // THKGlb
            // 
            this.THKGlb.AutoSize = true;
            this.THKGlb.Enabled = false;
            this.THKGlb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.THKGlb.Location = new System.Drawing.Point(156, 49);
            this.THKGlb.Name = "THKGlb";
            this.THKGlb.Size = new System.Drawing.Size(88, 15);
            this.THKGlb.TabIndex = 2;
            this.THKGlb.Text = "Thời hạn ký gửi";
            // 
            // DieuKienlb
            // 
            this.DieuKienlb.AutoSize = true;
            this.DieuKienlb.Enabled = false;
            this.DieuKienlb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DieuKienlb.Location = new System.Drawing.Point(157, 97);
            this.DieuKienlb.Name = "DieuKienlb";
            this.DieuKienlb.Size = new System.Drawing.Size(56, 15);
            this.DieuKienlb.TabIndex = 2;
            this.DieuKienlb.Text = "Điều kiện";
            // 
            // Tienlb
            // 
            this.Tienlb.AutoSize = true;
            this.Tienlb.Enabled = false;
            this.Tienlb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tienlb.Location = new System.Drawing.Point(157, 73);
            this.Tienlb.Name = "Tienlb";
            this.Tienlb.Size = new System.Drawing.Size(29, 15);
            this.Tienlb.TabIndex = 2;
            this.Tienlb.Text = "Tiền";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 12;
            this.guna2Elipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.Pic1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 122);
            this.panel1.TabIndex = 4;
            // 
            // Xoalb
            // 
            this.Xoalb.AutoSize = true;
            this.Xoalb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xoalb.ForeColor = System.Drawing.Color.Red;
            this.Xoalb.Location = new System.Drawing.Point(356, 95);
            this.Xoalb.Name = "Xoalb";
            this.Xoalb.Size = new System.Drawing.Size(99, 17);
            this.Xoalb.TabIndex = 6;
            this.Xoalb.Text = "Xoá sản phẩm";
            this.Xoalb.Click += new System.EventHandler(this.Xoalb_Click);
            this.Xoalb.MouseEnter += new System.EventHandler(this.Xoalb_MouseEnter);
            this.Xoalb.MouseLeave += new System.EventHandler(this.Xoalb_MouseLeave);
            // 
            // KyGuiControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(131)))), ((int)(((byte)(196)))));
            this.Controls.Add(this.Xoalb);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Tienlb);
            this.Controls.Add(this.DieuKienlb);
            this.Controls.Add(this.THKGlb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "KyGuiControl";
            this.Size = new System.Drawing.Size(482, 122);
            this.Load += new System.EventHandler(this.KyGuiControl_Load);
            this.MouseEnter += new System.EventHandler(this.KyGuiControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.KyGuiControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.Pic1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Pic1;
        private System.Windows.Forms.Label TenGiaylb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label THKGlb;
        private System.Windows.Forms.Label DieuKienlb;
        private System.Windows.Forms.Label Tienlb;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Xoalb;
    }
}
