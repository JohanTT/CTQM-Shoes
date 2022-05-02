using SHOESDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOESDAL
{
    public class NhanVienDAL
    {
        public static List<string> LayMaNhanVien()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<string> ListMNV = new List<string>();
            var thamchieu = (from vs in db.NHAN_VIENs
                             select vs).ToList();
            var khachhang = thamchieu.ToList();
            foreach (var tt in khachhang)
            {
                ListMNV.Add(tt.MaNhanVien);
            }
            return ListMNV;
        }

        public static List<NhanVien> LayDSNhanVien()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<NhanVien> nvList = new List<NhanVien>();
            var thamchieu = (from nv in db.NHAN_VIENs
                             select nv).ToList();
            var nhanvien = thamchieu.ToList();

            foreach (var tt in nhanvien)
            {
                nvList.Add(new NhanVien()
                {
                    MaNhanVien = tt.MaNhanVien,
                    TenNhanVien = tt.TenNhanVien,
                    SoDienThoai = tt.SoDienThoai,
                    DiaChi = tt.DiaChi,
                    NgaySinh = tt.NgaySinh,
                    GioiTinh = tt.GioiTinh
                });
            }
            return nvList;
        }

        public static List<NhanVien> LayDSNhanVienWithMA(string tmp)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<NhanVien> khList = new List<NhanVien>();
            var thamchieu = (from kh in db.NHAN_VIENs
                             where kh.MaNhanVien == tmp
                             select kh).ToList();
            var khachhang = thamchieu.ToList();

            foreach (var tt in khachhang)
            {
                khList.Add(new NhanVien()
                {
                    MaNhanVien = tt.MaNhanVien,
                    TenNhanVien = tt.TenNhanVien,
                    SoDienThoai = tt.SoDienThoai,
                    DiaChi = tt.DiaChi,
                    NgaySinh = tt.NgaySinh,
                    GioiTinh = tt.GioiTinh
                });
            }
            return khList;
        }

        public static void ThemNhanVien(NhanVien n)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            NHAN_VIEN nv = new NHAN_VIEN()
            {
                MaNhanVien = n.MaNhanVien,
                TenNhanVien = n.TenNhanVien,
                SoDienThoai = n.SoDienThoai,
                DiaChi = n.DiaChi,
                NgaySinh = n.NgaySinh,
                GioiTinh = n.GioiTinh
            };
            db.NHAN_VIENs.InsertOnSubmit(nv);
            db.SubmitChanges();
        }

        public static void XoaNhanVien(string MNV)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            NHAN_VIEN nv = db.NHAN_VIENs.SingleOrDefault(p => p.MaNhanVien.Equals(MNV));
            CHI_TIET_HOA_DON cthd = db.CHI_TIET_HOA_DONs.SingleOrDefault(p => p.MaNhanVien.Equals(MNV));
            KY_GUI kg = db.KY_GUIs.SingleOrDefault(p => p.MaNhanVien.Equals(MNV));
            if (nv != null)
            {
                db.NHAN_VIENs.DeleteOnSubmit(nv);
            }
            if (cthd != null)
            {
                db.CHI_TIET_HOA_DONs.DeleteOnSubmit(cthd);
            }
            if (kg != null)
            {
                db.KY_GUIs.DeleteOnSubmit(kg);
            }
            db.SubmitChanges();
        }

        public static void SuaNhanVien(NhanVien n)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            NHAN_VIEN kh = db.NHAN_VIENs.SingleOrDefault(p => p.MaNhanVien.Equals(n.MaNhanVien));
            if (kh != null)
            {
                kh.TenNhanVien = n.TenNhanVien;
                kh.SoDienThoai = n.SoDienThoai;
                kh.DiaChi = n.DiaChi;
                kh.NgaySinh = n.NgaySinh;
                kh.GioiTinh = n.GioiTinh;
            }
            db.SubmitChanges();
        }
    }
}
