using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHOESDTO;
using SHOESDAL;

namespace SHOESBUS
{
    public class KhachHangBUS
    {
        public static List<string> LayMaKhachHangKGC()
        {
            return KhachHangDAL.LayMaKhachHangKGC();
        }

            public static List<string> LayMaKhachHang()
        {
            return KhachHangDAL.LayMaKhachHang();
        }

        public static List<KhachHang> LayDSKhachHang()
        {
            return KhachHangDAL.LayDSKhachHang();
        }

        public static List<KhachHang> LayDSKhachHangWithMA(string tmp)
        {
            return KhachHangDAL.LayDSKhachHangWithMA(tmp);
        }

        public static bool ThemKhachHang(KhachHang kh)
        {
            int tuoi = DateTime.Now.Year - kh.NgaySinh.Year;
            if (tuoi < 18) return false;
            
            try
            {
                KhachHangDAL.ThemKhachHang(kh);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool XoaKhachHang(string MaKH)
        {
            try
            {
                KhachHangDAL.XoaKhachHang(MaKH);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public static bool SuaKhachHang(KhachHang kh)
        {
            try
            {
                KhachHangDAL.SuaKhachHang(kh);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ChuyenGhiChu(string MaKH)
        {
            try
            {
                KhachHangDAL.ChuyenGhiChu(MaKH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ThemTaiKhoan(string hoten, string taikhoan, string matkhau)
        {
            try
            {
                KhachHangDAL.ThemTaiKhoan(hoten, taikhoan, matkhau);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LayTaiKhoanMatKhau(string[,] TK, ref int dem)
        {
            try
            {
                KhachHangDAL.LayTaiKhoanMatKhau(TK, ref dem);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static long LayTienVDT(string MKH)
        {
            return KhachHangDAL.LayTienVDT(MKH);
        }

        public static long LayTienPayPal(string MKH)
        {
            return KhachHangDAL.LayTienPayPal(MKH);
        }

        public static bool GiamTienVDT(string MKH, long Tien)
        {
            try
            {
                KhachHangDAL.GiamTienVDT(MKH, Tien);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool GiamTienPayPal(string MKH, long Tien)
        {
            try
            {
                KhachHangDAL.GiamTienPayPal(MKH, Tien);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool NapTienVDT(string MKH, long Tien)
        {
            try
            {
                KhachHangDAL.NapTienVDT(MKH, Tien);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DoiMaBaoMat(string MKH, string MBM)
        {
            try
            {
                KhachHangDAL.DoiMaBaoMat(MKH, MBM);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
