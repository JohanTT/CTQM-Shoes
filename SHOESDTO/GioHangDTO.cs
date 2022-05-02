using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOESDTO
{
    public class GioHangDTO
    {
        public string MaGioHang { get; set; }
        public string MaGiay { get; set; }
        public string MaKhachHang { get; set; }
        public string TenGiay { get; set; }
        public Image HinhGiay { get; set; }
        public long DonGiaBan { get; set; }
        public int Giam { get; set; }
        public long TongTien { get; set; }
        public int SoLuongDat { get; set; }
        public string SizeDat { get; set; }
        public int SoLuongMatHang { get; set; }
        public string TongSize { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
    }
}
