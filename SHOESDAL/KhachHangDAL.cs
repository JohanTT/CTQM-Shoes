using SHOESDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SHOESDAL
{
    public class KhachHangDAL
    {
        public static List<string> LayMaKhachHang()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<string> ListMKH = new List<string>();
            var thamchieu = (from kh in db.KHACH_HANGs
                             select kh).ToList();
            var khachhang = thamchieu.ToList();
            foreach (var tt in khachhang)
            {
                ListMKH.Add(tt.MaKhachHang);
            }
            return ListMKH;
        }

        public static List<string> LayMaKhachHangKGC()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<string> ListMKH = new List<string>();
            var thamchieu = (from kh in db.DANH_SACH_KY_GUI_CHOs
                             select kh).ToList();
            var khachhang = thamchieu.ToList();
            foreach (var tt in khachhang)
            {
                ListMKH.Add(tt.MaKhachHang);
            }
            return ListMKH;
        }

        public static List<KhachHang> LayDSKhachHang()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<KhachHang> khList = new List<KhachHang>();
            var thamchieu = (from kh in db.KHACH_HANGs
                             select kh).ToList();
            var khachhang = thamchieu.ToList();

            foreach (var tt in khachhang)
            {
                khList.Add(new KhachHang()
                {
                    MaKhachHang = tt.MaKhachHang,
                    TenKhachHang = tt.TenKhachHang,
                    SoDienThoai = tt.SoDienThoai,
                    DiaChi = tt.DiaChi,
                    NgaySinh = DateTime.Parse(tt.NgaySinh.ToString()),
                    GioiTinh = tt.GioiTinh,
                    TaiKhoan = tt.TaiKhoan,
                    MatKhau = tt.MatKhau,
                    TienVDT = (long)tt.TienVDT,
                    MaBaoMat = tt.MaBaoMat
                });
            }
            return khList;
        }

        public static List<KhachHang> LayDSKhachHangWithMA(string MaKH)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<KhachHang> khList = new List<KhachHang>();
            var thamchieu = (from kh in db.KHACH_HANGs
                             where kh.MaKhachHang == MaKH
                             select kh).ToList();
            var khachhang = thamchieu.ToList();

            foreach (var tt in khachhang)
            {
                khList.Add(new KhachHang()
                {
                    MaKhachHang = tt.MaKhachHang,
                    TenKhachHang = tt.TenKhachHang,
                    SoDienThoai = tt.SoDienThoai,
                    DiaChi = tt.DiaChi,
                    NgaySinh = DateTime.Parse(tt.NgaySinh.ToString()),
                    GioiTinh = tt.GioiTinh,
                    TaiKhoan = tt.TaiKhoan,
                    MatKhau = tt.MatKhau
                });
            }
            return khList;
        }

        public static void ThemKhachHang(KhachHang n)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            KHACH_HANG kh = new KHACH_HANG()
            {
                MaKhachHang = n.MaKhachHang,
                TenKhachHang = n.TenKhachHang,
                SoDienThoai = n.SoDienThoai,
                DiaChi = n.DiaChi,
                NgaySinh = n.NgaySinh,
                GioiTinh = n.GioiTinh,
                TaiKhoan = n.TaiKhoan,
                MatKhau = n.MatKhau,
                TienVDT = n.TienVDT,
                MaBaoMat = n.MaBaoMat
            };
            db.KHACH_HANGs.InsertOnSubmit(kh);
            db.SubmitChanges();
        }
        
        public static void XoaKhachHang(string MKH)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            KHACH_HANG kh = db.KHACH_HANGs.SingleOrDefault(p => p.MaKhachHang.Equals(MKH));
            CHI_TIET_HOA_DON cthd = db.CHI_TIET_HOA_DONs.SingleOrDefault(p => p.MaKhachHang.Equals(MKH));
            KY_GUI kg = db.KY_GUIs.SingleOrDefault(p => p.MaKhachHang.Equals(MKH));
            if (kh != null)
            {
                db.KHACH_HANGs.DeleteOnSubmit(kh);
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

        public static void SuaKhachHang(KhachHang n)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            KHACH_HANG kh = db.KHACH_HANGs.SingleOrDefault(p => p.MaKhachHang.Equals(n.MaKhachHang));
            if (kh != null)
            {
                kh.TenKhachHang = n.TenKhachHang;
                kh.SoDienThoai = n.SoDienThoai;
                kh.DiaChi = n.DiaChi;
                kh.NgaySinh = n.NgaySinh;
                kh.GioiTinh = n.GioiTinh;
                kh.TienVDT = n.TienVDT;
                kh.MaBaoMat = n.MaBaoMat;
            }
            db.SubmitChanges();
        }

        public static void ChuyenGhiChu(string taikhoan)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            KHACH_HANG tk = db.KHACH_HANGs.SingleOrDefault(p => p.TaiKhoan.Equals(taikhoan));
            tk.GhiChu = "TRUE";
            db.SubmitChanges();
        }

        public static int DemKhachHang()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<KhachHang> khList = new List<KhachHang>();
            var thamchieu = (from kh in db.KHACH_HANGs
                             select kh).ToList();
            var khachhang = thamchieu.ToList();
            int dem = 0;
            foreach (var tt in khachhang)
            {
                dem++;
            }
            return dem;
        }

        public static void ThemTaiKhoan(string hoten, string taikhoan, string matkhau)
        {
            long Ma = 4601104000 + DemKhachHang();
            Shoes2DataContext db = new Shoes2DataContext();
            KHACH_HANG kh = new KHACH_HANG()
            {
                MaKhachHang = Ma++.ToString(),
                TenKhachHang = hoten,
                TaiKhoan = taikhoan,
                MatKhau = matkhau,
                GhiChu = "FALSE",
                TienVDT = 0,
                MaBaoMat = "0000"
            };
            db.KHACH_HANGs.InsertOnSubmit(kh);
            db.SubmitChanges();
        }

        public static string[,] LayTaiKhoanMatKhau(string[,] TK, ref int dem)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            var thamchieu = (from kh in db.KHACH_HANGs
                             where kh.GhiChu == "TRUE" // lấy những tài khoản có ghi nhớ
                             select kh).ToList();
            foreach (var tt in thamchieu)
            {
                TK[0, dem] = tt.TaiKhoan;   // lấy 0 cho tài khoản
                TK[1, dem] = tt.MatKhau;    // lấy 1 cho mật khẩu
                dem++;  // đếm số tài khoản
            }
            return TK;
        }

        public static long LayTienVDT(string MKH)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            long Tien = 0;
            var thamchieu = (from kh in db.KHACH_HANGs
                             where kh.MaKhachHang == MKH
                             select kh).ToList();
            foreach (var tt in thamchieu)
            {
                Tien = (long)tt.TienVDT;
            }
            return Tien;
        }

        public static long LayTienPayPal(string MKH)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            long Tien = 0;
            var thamchieu = (from kh in db.PAYPALs
                             where kh.MaKhachHang == MKH
                             select kh).ToList();
            foreach (var tt in thamchieu)
            {
                Tien = (long)tt.Tien;
            }
            return Tien;
        }

        public static void GiamTienVDT(string MKH, long Tien)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            KHACH_HANG kh = db.KHACH_HANGs.SingleOrDefault(p => p.MaKhachHang.Equals(MKH));
            if (kh != null)
            {
                kh.TienVDT -= Tien;
            }
            db.SubmitChanges();
        }

        public static void GiamTienPayPal(string MKH, long Tien)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            PAYPAL kh = db.PAYPALs.SingleOrDefault(p => p.MaKhachHang.Equals(MKH));
            if (kh != null)
            {
                kh.Tien -= Tien;
            }
            db.SubmitChanges();
        }

        public static void NapTienVDT(string MKH, long Tien)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            KHACH_HANG kh = db.KHACH_HANGs.SingleOrDefault(p => p.MaKhachHang.Equals(MKH));
            if (kh != null)
            {
                kh.TienVDT += Tien;
            }
            db.SubmitChanges();
        }

        public static void DoiMaBaoMat(string MKH, string MBM)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            KHACH_HANG kh = db.KHACH_HANGs.SingleOrDefault(p => p.MaKhachHang.Equals(MKH));
            if (kh != null)
            {
                kh.MaBaoMat = MBM;
            }
            db.SubmitChanges();
        }
    }
}
