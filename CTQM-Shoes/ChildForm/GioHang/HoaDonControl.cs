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
    public partial class HoaDonControl : UserControl
    {
        public HoaDonControl()
        {
            InitializeComponent();
        }
        private string _MaHoaDon;
        private string _MaGioHang;
        private string _TenGiay;
        private string _MaGiay;
        private int _SoLuongMua;
        private string _SizeMua;
        private long _DonGiaMua;
        private int _KhuyenMai;
        private long _TongMua;
        public string MaHoaDon
        {
            get { return _MaHoaDon; }   
            set { _MaHoaDon = value; }
        }
        public string MaGioHang
        {
            get { return _MaGioHang; }
            set { _MaGioHang = value; }
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
        public int SoLuongMua
        {
            get { return _SoLuongMua; }
            set { _SoLuongMua = value; }
        }
        public string SizeMua
        {
            get { return _SizeMua; }
            set { _SizeMua = value; }
        }
        public long DonGiaMua
        {
            get { return _DonGiaMua; }
            set { _DonGiaMua = value; }
        }
        public int KhuyenMai
        {
            get { return _KhuyenMai; }
            set { _KhuyenMai = value; }
        }
        public long TongMua
        {
            get { return _TongMua; }
            set { _TongMua = value; }
        }

        private void HoaDonControl_Load(object sender, EventArgs e) //cái ngắn nhất luôn
        {
            SLlb.Text = _SoLuongMua.ToString();
            TenGiaylb.Text = _TenGiay;
            DonGialb.Text = _DonGiaMua.ToString();
            _TongMua = ((_DonGiaMua * _SoLuongMua) * (100 - _KhuyenMai))/100;
            Giamlb.Text = _KhuyenMai.ToString() + "%";
            Tonglb.Text = _TongMua.ToString();
            Sizelb.Text = _SizeMua;
        }
    }
}
