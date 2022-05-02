using SHOESDAL;
using SHOESDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOESBUS
{
    public class NhanVienBUS
    {
        public static List<string> LayMaNhanVien()
        {
            return NhanVienDAL.LayMaNhanVien();
        }

        public static List<NhanVien> LayDSNhanVien()
        {
            return NhanVienDAL.LayDSNhanVien();
        }

        public static List<NhanVien> LayDSNhanVienWithMA(string MNV)
        {
            return NhanVienDAL.LayDSNhanVienWithMA(MNV);
        }

        public static bool ThemNhanVien(NhanVien nv)
        {
            int tuoi = DateTime.Now.Year - nv.NgaySinh.Year;
            if (tuoi < 18) return false;

            try
            {
                NhanVienDAL.ThemNhanVien(nv);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaNhanVien(string MaNV)
        {
            try
            {
                NhanVienDAL.XoaNhanVien(MaNV);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SuaNhanVien(NhanVien nv)
        {
            int tuoi = DateTime.Now.Year - nv.NgaySinh.Year;
            if (tuoi < 18) return false;

            try
            {
                NhanVienDAL.SuaNhanVien(nv);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
