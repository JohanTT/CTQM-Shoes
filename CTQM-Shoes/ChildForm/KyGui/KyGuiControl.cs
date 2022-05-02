using SHOESBUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTQM_Shoes.ChildForm
{
    public partial class KyGuiControl : UserControl
    {
        public KyGuiControl()
        {
            InitializeComponent();
        }
        public event EventHandler XoaKyGui;
        List<string> ColorList = new List<string>()
        {
                                                                    "#3F51B5",
                                                                    "#009688",
                                                                    "#FF5722",
                                                                    "#607D8B",
                                                                    "#FF9800",
                                                                    "#9C27B0",
                                                                    "#2196F3",
                                                                    "#EA676C",
                                                                    "#E41A4A",
                                                                    "#5978BB",
                                                                    "#018790",
                                                                    "#0E3441",
                                                                    "#00B0AD",
                                                                    "#721D47",
                                                                    "#EA4833",
                                                                    "#EF937E",
                                                                    "#F37521",
                                                                    "#A12059",
                                                                    "#126881",
                                                                    "#8BC240",
                                                                    "#364D5B",
                                                                    "#C7DC5B",
                                                                    "#0094BC",
                                                                    "#E4126B",
                                                                    "#43B76E",
                                                                    "#7BCFE9",
                                                                    "#B71C46"
        }; // tạo ra 1 đống màu để lấy màu ngẫu nhiên
        private Image _Anh1;
        private string _TenGiay;
        private string _MaGiay;
        private string _MaKhachHang;
        private long _DonGia;
        private string _ThoiHanGui;
        private string _DieuKien;
        public Image Anh1
        {
            get { return _Anh1; }
            set { _Anh1 = value; }
        }
        public string TenGiay
        {
            get { return _TenGiay; }
            set { _TenGiay = value; }
        }
        public string MaGiay
        {
            get { return _MaGiay; }
            set { _MaGiay = value; }
        }
        public string MaKhachHang
        {
            get { return _MaKhachHang;}
            set { _MaKhachHang = value;}
        }
        public long DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }
        public string ThoiHanGui
        {
            get { return _ThoiHanGui; }
            set { _ThoiHanGui = value; }
        }
        public string DieuKien
        {
            get { return _DieuKien; }
            set { _DieuKien = value;}
        }

        private void KyGuiControl_Load(object sender, EventArgs e)
        {
            Pic1.Image = _Anh1;
            TenGiaylb.Text = _TenGiay;
            Tienlb.Text = _DonGia.ToString();
            THKGlb.Text = _ThoiHanGui;
            DieuKienlb.Text = _DieuKien;
            Color tmp = LayMauNgauNhien();
            panel1.BackColor = tmp;
        }

        private Color LayMauNgauNhien()
        {
            Random rcolor = new Random();
            int i = rcolor.Next(0, ColorList.Count);
            string color = ColorList[i];
            return ColorTranslator.FromHtml(color);
        }

        private void Xoalb_MouseEnter(object sender, EventArgs e)
        {
            Xoalb.ForeColor = Color.DarkRed;
        }

        private void Xoalb_MouseLeave(object sender, EventArgs e)
        {
            Xoalb.ForeColor = Color.Red;
        }

        private void Xoalb_Click(object sender, EventArgs e)
        {
            if (this.XoaKyGui != null)
            {
                this.XoaKyGui(this, e);
            }
            DialogResult result = MessageBox.Show("Xoá sản phẩm ký gửi!?", "KÝ GỬI", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                KyGuiBUS.XoaKyGui(_MaGiay);
                MessageBox.Show("Xoá thành công!");
            }
        }

        private void KyGuiControl_MouseEnter(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Gray) BackColor = Color.Gray;
            else this.BackColor = Color.FromArgb(26, 59, 112);
        }

        private void KyGuiControl_MouseLeave(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Gray) BackColor = Color.Gray;
            else this.BackColor = Color.FromArgb(92, 131, 196);
        }
    }
}
