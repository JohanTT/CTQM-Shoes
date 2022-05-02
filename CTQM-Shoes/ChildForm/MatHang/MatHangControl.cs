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
    public partial class MatHangControl : UserControl
    {
        public MatHangControl()
        {
            InitializeComponent();
        }
        public event EventHandler XemGiay; // để biết khi nào người dùng bấm vào xem chi tiết
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
        private Image _HinhGiay;
        private string _MaGiay;
        private string _TenGiay;
        private string _TienGiay;
        private string _ChatLieu;
        private string _BaoHanh;
        private string _Loai;
        public Image HinhGiay
        {
            get { return _HinhGiay; }
            set { _HinhGiay = value; }
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
        public string TienGiay
        {
            get { return _TienGiay; }
            set { _TienGiay = value; }
        }
        public string ChatLieu
        {
            get { return _ChatLieu; }
            set { _ChatLieu = value; }
        }
        public string BaoHanh
        {
            get { return _BaoHanh; }
            set { _BaoHanh = value; }
        }
        public string Loai
        {
            get { return _Loai; }
            set { _Loai = value; }
        }
        // hiện ứng hiện ủng các thứ
        private void MatHangControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(34, 30, 30);
        }

        private void MatHangControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(34, 36, 49);
        }

        private Color LayMauNgauNhien()
        {
            Random rcolor = new Random();
            int i = rcolor.Next(0, ColorList.Count);
            string color = ColorList[i];
            return ColorTranslator.FromHtml(color);
        }

        private void MatHangControl_Load(object sender, EventArgs e) // laị là load dữ liệu lên form thôi
        {
            HinhGiaypb.Image = _HinhGiay;
            TenGiaylb.Text = _TenGiay;
            ChatLieulb.Text = _ChatLieu;
            BaoHanhlb.Text = _BaoHanh;
            XemGiathoi.Text = _TienGiay + " VNĐ";
            Loailb.Text = _Loai;
            Color tmp = LayMauNgauNhien();
            panel1.BackColor = tmp;
            XemGiathoi.FillColor = tmp;
        }
        // vẫn là để thêm hiện ứng
        private void HinhGiaypb_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(34, 30, 30);
        }

        private void HinhGiaypb_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(34, 36, 49);
        }

        private void XemGiathoi_Click(object sender, EventArgs e)
        {
            if (this.XemGiay != null)
            {
                this.XemGiay(this, e);
            }
        }
        // và cái nút giá không có tác dụng gì đâu đừng có bấm nữa
    }
}
