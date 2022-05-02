using Guna.UI2.WinForms;
using SHOESBUS;
using SHOESDAL;
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

namespace CTQM_Shoes.ChildForm
{
    public partial class GioHangControl : UserControl
    {
        public GioHangControl()
        {
            InitializeComponent();
        }

        public event EventHandler XoaGioHang; // Even đi chung để khi người dùng xoá sẽ tự động load lại
        private string _MaGioHang;
        private Image _HinhGiay;
        private string _TenGiay;
        private string _TienGiay;
        private int _SoLuong;
        private int _Giam;
        private string _MaGiay;
        private string _SizeG;
        private string _SizeC;
        private long _TongTienG;
        private string _ALLSize;
        private int _SLMH;
        bool _Fixclick = false; // kiểm tra khi người dùng nhấn sữa thì sẽ hiện các chức năng tương ứng để người dugnf chọn sữa hay sửa đm cái nào cugnx được

        public string MaGioHangGH
        {
            get { return _MaGioHang; }
            set { _MaGioHang = value; }
        }
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
        public string TienGiay
        {
            get { return _TienGiay; }
            set { _TienGiay = value; }
        }
        public string MaGiay
        {
            get { return _MaGiay; }
            set { _MaGiay = value; }
        }
        public int SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
        public int Giam
        {
            get { return _Giam; }
            set { _Giam = value; }
        }
        public string SizeG
        {
            get { return _SizeG; }
            set { _SizeG = value; }
        }
        public string SizeC
        {
            get { return _SizeC; }
            set { _SizeC = value; }
        }
        public long TongTienG
        {
            get { return _TongTienG; }
            set { _TongTienG = value; }
        }
        public string AllSize
        {
            get { return _ALLSize; }
            set { _ALLSize = value; }
        }
        public int SLMH
        {
            get { return _SLMH; }
            set { _SLMH = value; }
        }
        public bool Fixclick
        {
            get { return _Fixclick; }
            set { _Fixclick = value; }
        }

        Image ByteToImage(byte[] b) // chuyển byte thành hình
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }

        private void LaySize() // cũng là lấy size tương tự như thằng kia 
        {
            if (_SizeG != null)
            {
                string sizeH = "", sizeT = ""; // size đầu và size cuối
                bool check = false; // Kiểm tra có dấu - hay không
                if (_SizeG.Contains('-'))
                {
                    check = true;
                    sizeH = _SizeG[0].ToString() + _SizeG[1].ToString();
                    sizeT = _SizeG[3].ToString() + _SizeG[4].ToString();
                }
                else sizeH = _SizeG;
                int dem, tmp;
                if (check == true) // Nếu có dấu - thì thêm từ đầu tới cuối vào cbx
                {
                    int sodau = int.Parse(sizeH), socuoi = int.Parse(sizeT);
                    for (int i = 1; i <= socuoi - sodau + 1; i++)
                    {
                        dem = i;
                        tmp = sodau;
                        foreach (var ctl in panelbtnsize.Controls)
                        {
                            if (tmp <= socuoi && ((Guna2Button)ctl).TabIndex == dem)
                            {
                                ((Guna2Button)ctl).Visible = true;
                                ((Guna2Button)ctl).Text += " " + (tmp + i - 1).ToString();
                                if (tmp + i - 1 == int.Parse(_SizeC))
                                {
                                    ((Guna2Button)ctl).FillColor = Color.OrangeRed;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Button1.Visible = true; // Nếu không thì thêm thẳng size vào
                    Button1.Text += " " + sizeH;
                    Button1.FillColor = Color.OrangeRed;
                }
            }
        }

        private void LayThongTinGiay()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            MAT_HANG mh = db.MAT_HANGs.SingleOrDefault(p => p.MaGiay.Equals(_MaGiay));
            if (mh != null)
            {
                _TenGiay = mh.TenGiay;
                _HinhGiay = ByteToImage(mh.Anh1.ToArray());
                _SLMH = (int)mh.SoLuong;
            }
        }

        private void GioHangControl_Load(object sender, EventArgs e) // load dữ liệu lên thôi
        {
            LayThongTinGiay();
            if (_Fixclick == false)
            {
                panelbtnsize.Visible = false;
                SoLuongN.Visible = false;
                Xoalb.Visible = false;
                Sizelb.Visible = true;
                SoLuonglb.Visible = true;
            }
            if (_Fixclick == true)
            {
                panelbtnsize.Visible = true;
                SoLuongN.Visible = true;
                Xoalb.Visible = true;
                Sizelb.Visible = false;
                SoLuonglb.Visible = false;
            }
            HinhGiaypb.Image = _HinhGiay;
            TenGiaylb.Text = _TenGiay;
            Gia1.Text = _TienGiay;
            KhuyenMailb.Text = _Giam.ToString() + "%";
            SoLuongN.Value = _SoLuong;
            _TongTienG = (long.Parse(_TienGiay) * int.Parse(SoLuongN.Value.ToString()) * (100 - _Giam))/100;
            TongTien.Text = _TongTienG.ToString();
            Sizelb.Text = _SizeC;
            SoLuonglb.Text = _SoLuong.ToString();
            LaySize();
        }

        private void SoLuongN_ValueChanged(object sender, EventArgs e) // khi mà số lượng thay đổi thì sẽ cập nhật lại
        {
            if (SoLuongN.Value > _SLMH) // nếu số lượng chọn lớn hơn số lượng hiện có
            {
                SoLuongN.Value--;
                MessageBox.Show("Bạn đã mua nhiều hơn số lượng hiện có", "Số lượng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (SoLuongN.Value >= 0)
            {
                _SoLuong = int.Parse(SoLuongN.Value.ToString());
            }
            GioHangDAL.SuaSoLuong(_MaGioHang, _SoLuong); // sửa lại dữ liệu
            _TongTienG = long.Parse(_TienGiay) * int.Parse(SoLuongN.Value.ToString());
        }

        private void Xoalb_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.XoaGioHang != null)
            {
                this.XoaGioHang(this, e);
            }
            GioHangDAL.XoaKhoiGioHang(_MaGioHang); // xoá khỏi giỏ hàng 
        }
        // hiện ứng các thứ
        private void Xoalb_MouseEnter(object sender, EventArgs e)
        {
            Xoalb.ForeColor = Color.DarkRed;
        }

        private void Xoalb_MouseLeave(object sender, EventArgs e)
        {
            Xoalb.ForeColor = Color.Red;
        }
        // cũng giống như thằng bên kia thôi được copy paste ra
        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (var xbtn in panelbtnsize.Controls)
            {
                if (xbtn.GetType() == typeof(Guna2Button))
                {
                    ((Guna2Button)xbtn).FillColor = Color.FromArgb(251, 155, 81);
                }
            }
            Guna2Button btn = (Guna2Button)sender;
            string tmp = btn.Text;
            bool check = false; // Kiểm tra đã tới dấu cách chưa để lấy số
            string result = ""; // Lấy kết quả
            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i] == ' ') check = true;
                if (check == true)
                {
                    result += tmp[i];
                }
            }
            _SizeC = result;
            btn.FillColor = Color.OrangeRed;
            GioHangDAL.SuaSize(_MaGioHang, _SizeC);
        }
    }
}
