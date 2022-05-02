using SHOESBUS;
using SHOESDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTQM_Shoes
{
    public partial class FormThemKyGui : Form
    {
        public event EventHandler Quaylaiclick; // Event để khi người dùng bấm quay lại sẽ show form ký gửi
        public FormThemKyGui()
        {
            InitializeComponent();
        }

        public string MaKhachHangThemKG { get; set; }

        private void Pic1_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog layhinh = new OpenFileDialog();
            PictureBox p = sender as PictureBox;
            if (p != null)
            {
                layhinh.Filter = "(*.jpg;*.jpeg;*.bmp;*.png)| *.jpg; *.jpeg; *.bmp; *.png";
                if (layhinh.ShowDialog() == DialogResult.OK)
                {
                    p.Image = Image.FromFile(layhinh.FileName);
                }
            }
        }

        private void Thembtn_Click(object sender, EventArgs e)
        {
            KyGui kg = new KyGui()
            {
                MaKhachHang = MaKhachHangThemKG,
                TenGiay = TenGiaytxt.Text,
                Anh1 = Pic1.Image,
                Anh2 = Pic2.Image,
                Anh3 = Pic3.Image,
                Anh4 = Pic4.Image,
                SoLuong = int.Parse(SoLuongtxt.Text),
                MauSac = MauSactxt.Text,
                Size = Sizecbx.Text,
                ChatLieu = ChatLieucbx.Text,
                BaoHanh = BaoHanhcbx.Text,
                DieuKien = DieuKiencbx.Text,
                GhiChu = GhiChutxt.Text,
                NgayKyGui = NgayPick1.Value,
                ThoiGianKyGui = ThoiGianGuicbx.Text,
                PhiKyGui = int.Parse(PhiKGtxt.Text),
                DonGiaNhap = int.Parse(DonGiatxt.Text)
            };
            KyGuiBUS.ThemKyGuiCho(kg);
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            if (this.Quaylaiclick != null)
            {
                this.Quaylaiclick(this, e);
            }
            this.Close();
        }

        private void ThoiGianGuicbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tmp = "";
            string tmp2 = ThoiGianGuicbx.SelectedItem as string;
            int tong = 0;
            for (int i = 0; i < tmp2.Length; i++)
            {
                if (tmp2[i] == ' ') break;
                tmp = tmp + tmp2[i];
            }
            tong = int.Parse(tmp) * 30000;
            PhiKGtxt.Text = tong.ToString();
        }
    }
}
