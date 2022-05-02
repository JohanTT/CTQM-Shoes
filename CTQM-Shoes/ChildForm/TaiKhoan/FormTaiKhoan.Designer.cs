namespace CTQM_Shoes.ChildForm
{
    partial class FormTaiKhoan
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
            this.Accountfpn = new System.Windows.Forms.FlowLayoutPanel();
            this.OhNolb = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TaiKhoanbtn = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TenGiaylb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Gialb = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.PTTTlb = new System.Windows.Forms.Label();
            this.NapTienbtn = new FontAwesome.Sharp.IconButton();
            this.Accountfpn.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Accountfpn
            // 
            this.Accountfpn.AutoScroll = true;
            this.Accountfpn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(89)))), ((int)(((byte)(157)))));
            this.Accountfpn.Controls.Add(this.OhNolb);
            this.Accountfpn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Accountfpn.Location = new System.Drawing.Point(0, 194);
            this.Accountfpn.Name = "Accountfpn";
            this.Accountfpn.Size = new System.Drawing.Size(1109, 527);
            this.Accountfpn.TabIndex = 9;
            // 
            // OhNolb
            // 
            this.OhNolb.AutoSize = true;
            this.OhNolb.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OhNolb.ForeColor = System.Drawing.Color.Silver;
            this.OhNolb.Location = new System.Drawing.Point(3, 0);
            this.OhNolb.Name = "OhNolb";
            this.OhNolb.Size = new System.Drawing.Size(457, 37);
            this.OhNolb.TabIndex = 2;
            this.OhNolb.Text = "Oh no! Bạn chưa mua sản phẩm nào!";
            this.OhNolb.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 37);
            this.label2.TabIndex = 42;
            this.label2.Text = "Lịch sử mua hàng";
            // 
            // TaiKhoanbtn
            // 
            this.TaiKhoanbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(34)))), ((int)(((byte)(78)))));
            this.TaiKhoanbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.TaiKhoanbtn.FlatAppearance.BorderSize = 0;
            this.TaiKhoanbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TaiKhoanbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaiKhoanbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.TaiKhoanbtn.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.TaiKhoanbtn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(129)))), ((int)(((byte)(37)))));
            this.TaiKhoanbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.TaiKhoanbtn.Location = new System.Drawing.Point(939, 12);
            this.TaiKhoanbtn.Name = "TaiKhoanbtn";
            this.TaiKhoanbtn.Size = new System.Drawing.Size(158, 51);
            this.TaiKhoanbtn.TabIndex = 43;
            this.TaiKhoanbtn.Text = "Tài khoản";
            this.TaiKhoanbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TaiKhoanbtn.UseVisualStyleBackColor = false;
            this.TaiKhoanbtn.Click += new System.EventHandler(this.TaiKhoanbtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(89)))), ((int)(((byte)(157)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.TenGiaylb);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Gialb);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 147);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1109, 47);
            this.panel1.TabIndex = 44;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(34)))), ((int)(((byte)(78)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1109, 10);
            this.panel2.TabIndex = 14;
            // 
            // TenGiaylb
            // 
            this.TenGiaylb.AllowDrop = true;
            this.TenGiaylb.AutoEllipsis = true;
            this.TenGiaylb.AutoSize = true;
            this.TenGiaylb.BackColor = System.Drawing.Color.Transparent;
            this.TenGiaylb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenGiaylb.ForeColor = System.Drawing.Color.White;
            this.TenGiaylb.Location = new System.Drawing.Point(37, 7);
            this.TenGiaylb.Name = "TenGiaylb";
            this.TenGiaylb.Size = new System.Drawing.Size(66, 21);
            this.TenGiaylb.TabIndex = 9;
            this.TenGiaylb.Text = "Tên giày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(406, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Số lượng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(708, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "Giảm";
            // 
            // Gialb
            // 
            this.Gialb.AutoSize = true;
            this.Gialb.BackColor = System.Drawing.Color.Transparent;
            this.Gialb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gialb.ForeColor = System.Drawing.Color.White;
            this.Gialb.Location = new System.Drawing.Point(560, 7);
            this.Gialb.Name = "Gialb";
            this.Gialb.Size = new System.Drawing.Size(33, 21);
            this.Gialb.TabIndex = 11;
            this.Gialb.Text = "Giá";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(850, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 21);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tổng tiền";
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 12;
            this.guna2Elipse3.TargetControl = this.TaiKhoanbtn;
            // 
            // PTTTlb
            // 
            this.PTTTlb.AutoSize = true;
            this.PTTTlb.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PTTTlb.ForeColor = System.Drawing.Color.White;
            this.PTTTlb.Location = new System.Drawing.Point(391, 60);
            this.PTTTlb.Name = "PTTTlb";
            this.PTTTlb.Size = new System.Drawing.Size(190, 37);
            this.PTTTlb.TabIndex = 6;
            this.PTTTlb.Text = "Số dư hiện có";
            // 
            // NapTienbtn
            // 
            this.NapTienbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(34)))), ((int)(((byte)(78)))));
            this.NapTienbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.NapTienbtn.FlatAppearance.BorderSize = 0;
            this.NapTienbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NapTienbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NapTienbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(155)))), ((int)(((byte)(81)))));
            this.NapTienbtn.IconChar = FontAwesome.Sharp.IconChar.Wallet;
            this.NapTienbtn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(129)))), ((int)(((byte)(37)))));
            this.NapTienbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.NapTienbtn.Location = new System.Drawing.Point(939, 69);
            this.NapTienbtn.Name = "NapTienbtn";
            this.NapTienbtn.Size = new System.Drawing.Size(158, 51);
            this.NapTienbtn.TabIndex = 43;
            this.NapTienbtn.Text = "Nạp tiền";
            this.NapTienbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NapTienbtn.UseVisualStyleBackColor = false;
            this.NapTienbtn.Click += new System.EventHandler(this.NapTienbtn_Click);
            // 
            // FormTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(112)))));
            this.ClientSize = new System.Drawing.Size(1109, 721);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PTTTlb);
            this.Controls.Add(this.NapTienbtn);
            this.Controls.Add(this.TaiKhoanbtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Accountfpn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTaiKhoan";
            this.Text = "Tài khoản";
            this.Load += new System.EventHandler(this.FormTaiKhoan_Load);
            this.Accountfpn.ResumeLayout(false);
            this.Accountfpn.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel Accountfpn;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton TaiKhoanbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TenGiaylb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Gialb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label OhNolb;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private System.Windows.Forms.Label PTTTlb;
        private FontAwesome.Sharp.IconButton NapTienbtn;
    }
}