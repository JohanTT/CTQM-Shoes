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
    public class GioHangBUS
    {
        public static bool LayDSGioHangFrom(List<GioHangDTO> listGH, string MKH)
        {
            try
            {
                GioHangDAL.LayDSGioHangFrom(listGH, MKH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LayDSThanhToanFrom(List<GioHangDTO> listGH, string MKH)
        {
            try
            {
                GioHangDAL.LayDSThanhToanFrom(listGH, MKH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ThemVaoGioHang(GioHangDTO n)
        {
            try
            {
                GioHangDAL.ThemVaoGioHang(n);            
                MessageBox.Show("Sản phẩm đã được thêm vào giỏ hàng");
                return true;
            }
            catch
            {
                MessageBox.Show("Thêm vào giỏ hàng thất bại");
                return false;
            }
        }

        public static bool SuaSoLuong(string MaGioHang, int SoLuong)
        {
            try
            {
                GioHangDAL.SuaSoLuong(MaGioHang, SoLuong);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SuaSize(string MaGioHang, string size)
        {
            try
            {
                GioHangDAL.SuaSize(MaGioHang, size);
                return true;
            }
            catch { return false; }
        }

        public static bool XoaKhoiGioHang(string MaGioHang)
        {
            try
            {
                GioHangDAL.XoaKhoiGioHang(MaGioHang);
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
