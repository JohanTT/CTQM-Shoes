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
    public class KyGuiBUS
    {
        public static List<string> LayMaKyGui() 
        {
            return KyGuiDAL.LayMaKyGui();
        }

        public static List<KyGui> LayDSKyGui()
        {
            return KyGuiDAL.LayDSKyGui();
        }

        public static List<KyGui> LayDSKyGuiWithMA(string MKG)
        {
            return KyGuiDAL.LayDSKyGuiWithMA(MKG);
        }

        public static List<KyGui> LayDSKyGuiCho()
        {
            return KyGuiDAL.LayDSKyGuiCho();
        }

        public static bool LayDSKyGuiFrom(List<KyGui> listKG, string MKH)
        {
            try
            {
                KyGuiDAL.LayDSKyGuiFrom(listKG, MKH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LayDSKyGuiChoFrom(List<KyGui> listKG, string MKH)
        {
            try
            {
                KyGuiDAL.LayDSKyGuiChoFrom(listKG, MKH);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ThemKyGui(KyGui kg)
        {
            try
            {
                KyGuiDAL.ThemKyGui(kg);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaKyGui(string MKG)
        {
            try
            {
                KyGuiDAL.XoaKyGui(MKG);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SuaKyGui(KyGui kg)
        {
            try
            {
                KyGuiDAL.SuaKyGui(kg);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool ThemKyGuiCho(KyGui kg)
        {
            try
            {
                KyGuiDAL.ThemKyGuiCho(kg);
                MessageBox.Show("Thêm ký gửi chờ thành công");
                return true;
            }
            catch
            {
                MessageBox.Show("Thêm ký gửi chờ thất bại");
                return false;
            }
        }

        public static bool XoaKyGuiCho(string MKG)
        {
            try
            {
                KyGuiDAL.XoaKyGuiCho(MKG);
                MessageBox.Show("Xoá ký gửi chờ thành công");
                return true;
            }
            catch
            {
                MessageBox.Show("Xoá ký gửi chờ thất bại");
                return false;
            }
        }

        public static bool SuaKyGuiCho(KyGui kg)
        {
            try
            {
                KyGuiDAL.SuaKyGuiCho(kg);
                MessageBox.Show("Sửa ký gửi chờ thành công");
                return true;
            }
            catch
            {
                MessageBox.Show("Sửa ký gửi chờ thất bại");
                return false;
            }
        }
    }
}
