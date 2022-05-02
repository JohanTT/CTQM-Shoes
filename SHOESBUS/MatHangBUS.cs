using SHOESDAL;
using SHOESDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOESBUS
{
    public class MatHangBUS
    {
        public static List<string> LayMaMatHang()
        {
            return MatHangDAL.LayMaMatHang();
        }
        public static List<MatHang> LayDSMatHangForm()
        {
            return MatHangDAL.LayDSMatHangForm();
        }

        public static MatHang LayDSMatHangChiTietForm(string MaGiay)
        {
                return MatHangDAL.LayDSMatHangChiTietForm(MaGiay);
        }

        public static List<MatHang> LayDSMatHang()
        {
            return MatHangDAL.LayDSMatHang();
        }

        public static List<MatHang> LayDSMatHangWithMA(string MMH)
        {
            return MatHangDAL.LayDSMatHangWithMA(MMH);
        }

        public static bool ThemMatHang(MatHang mh)
        {
            try
            {
                MatHangDAL.ThemMatHang(mh);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaMatHang(string MMH)
        {
            try
            {
                MatHangDAL.XoaMatHang(MMH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SuaMatHang(MatHang mh)
        {
            try
            {
                MatHangDAL.SuaMatHang(mh);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool GiamSoLuongMatHang(string MMH)
        {
            try
            {
                MatHangDAL.GiamSoLuongMatHang(MMH);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
