using SHOESDAL;
using SHOESDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHOESBUS
{
    public class HoaDonBUS
    {
        public static List<string> LayMaHoaDon()
        {
            return HoaDonDAL.LayMaHoaDon();
        }

        public static List<string> LayMaHoaDonCho()
        {
            return HoaDonDAL.LayMaHoaDonCho();
        }

        public static List<HoaDon> LayDSGiayTuBill(string mkh)
        {
            return HoaDonDAL.LayDSGiayTuBill(mkh);
        }

        public static List<HoaDon> LayDSGiayTuBillCho(string mkh)
        {
            return HoaDonDAL.LayDSGiayTuBillCho(mkh);
        }

        public static List<HoaDon> LayDSHoaDonCho()
        {
            return HoaDonDAL.LayDSHoaDonCho();
        }

        public static List<HoaDon> LayDSHoaDon()
        {
            return HoaDonDAL.LayDSHoaDon();
        }

        public static List<HoaDon> LayDSHoaDonWithMA(string MHD)
        {
            return HoaDonDAL.LayDSHoaDonWithMA(MHD);
        }

        public static bool ThemHoaDon(HoaDon hd)
        {
            try
            {
                HoaDonDAL.ThemHoaDon(hd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaHoaDon(string mhd)
        {
            try
            {
                HoaDonDAL.XoaHoaDon(mhd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SuaHoaDon(HoaDon hd)
        {
            try
            {
                HoaDonDAL.SuaHoaDon(hd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ThemVaoHoaDonCho(HoaDon n)
        {
            try
            {
                HoaDonDAL.ThemVaoHoaDonCho(n);
                MessageBox.Show("Thanh toán thành công. Đợi phê duyệt để được giao hàng nhé");
                return true;
            }
            catch
            {
                MessageBox.Show("Thanh toán thất bại");
                return false;
            }
        }

        public static bool XoaHoaDonCho(string MHD)
        {
            try
            {
                HoaDonDAL.XoaHoaDonCho(MHD);
                MessageBox.Show("Xoá hoá đơn chờ thành công");
                return true;
            }
            catch
            {
                MessageBox.Show("Xoá hoá đơn chờ thất bại");
                return false;
            }
        }

        public static bool SuaHoaDonCho(HoaDon n)
        {
            try
            {
                HoaDonDAL.SuaHoaDonCho(n);
                MessageBox.Show("Sửa hoá đơn chờ thành công");
                return true;
            }
            catch
            {
                MessageBox.Show("Sửa hoá đơn chờ thất bại");
                return false;
            }
        }
    }
}
