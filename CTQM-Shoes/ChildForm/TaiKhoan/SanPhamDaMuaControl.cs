using Guna.UI2.WinForms;
using SHOESDAL;
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
    public partial class SanPhamDaMuaControl : UserControl
    {
        public SanPhamDaMuaControl()
        {
            InitializeComponent();
        }

        private Image _HinhGiay;
        private string _TenGiay;
        private string _TienGiay;
        private int _SoLuong;
        private int _Giam;
        private string _MaGiay;
        private string _SizeC;
        private long _TongTienG;
        private string _PTTT;

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
        public string PTTT
        {
            get { return _PTTT; }
            set { _PTTT = value; }
        }

        Image ByteToImage(byte[] b) // chuyển byte thành hình
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }

        private void LayThongTinGiay()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            MAT_HANG mh = db.MAT_HANGs.SingleOrDefault(p => p.MaGiay.Equals(_MaGiay));
            if (mh != null)
            {
                _TenGiay = mh.TenGiay;
                _HinhGiay = ByteToImage(mh.Anh1.ToArray());
            }
        }

        private void GioHangControl_Load(object sender, EventArgs e) // load dữ liệu lên thôi
        {
            LayThongTinGiay();
            HinhGiaypb.Image = _HinhGiay;
            TenGiaylb.Text = _TenGiay;
            Gia1.Text = _TienGiay;
            KhuyenMailb.Text = _Giam.ToString() + "%";
            _TongTienG = (long.Parse(_TienGiay) * (_SoLuong * (100 - _Giam)) / 100);
            TongTien.Text = _TongTienG.ToString();
            Sizelb.Text = _SizeC;
            SoLuonglb.Text = _SoLuong.ToString();
            PTTTpn.Text = _PTTT;
        }
    }
}
