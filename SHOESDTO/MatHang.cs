using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SHOESDTO
{
    public class MatHang
    {
        private Image _Anh1;
        private Image _Anh2;
        private Image _Anh3;
        private Image _Anh4;

        public string MaGiay { get; set; }
        public string TenGiay { get; set; }
        public Image Anh1 
        {
            get { return _Anh1; } 
            set { _Anh1 = value; }
        }
        public Image Anh2
        {
            get { return _Anh2; }
            set { _Anh2 = value; }
        }
        public Image Anh3
        {
            get { return _Anh3; }
            set { _Anh3 = value; }
        }
        public Image Anh4
        {
            get { return _Anh4; }
            set { _Anh4 = value; }
        }

        public string Loai { get; set; }
        public double SoLuong { get; set; }
        public string MauSac { get; set; }
        public string Size { get; set; }   
        public double DonGiaBan { get; set; }
        public double DonGiaNhap { get; set; }
        public string ChatLieu { get; set; }
        public string BaoHanh { get; set; }
        public string DieuKien { get; set; }
        public string GhiChu { get; set; }
    }
}
