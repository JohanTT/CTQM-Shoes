using SHOESDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOESDAL
{
    public class GioHangDAL
    {

        public static List<GioHangDTO> LayDSGioHangFrom(List<GioHangDTO> listGH, string MKH)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            var thamchieu = (from gh in db.GIO_HANGs
                             from mh in db.MAT_HANGs
                             from kh in db.KHACH_HANGs
                             where gh.MaKhachHang == MKH
                             where kh.MaKhachHang == gh.MaKhachHang
                             where mh.MaGiay == gh.MaGiay
                             select new
                             {
                                 MaGioHang = gh.MaGioHang,
                                 MaGiay = mh.MaGiay,
                                 MaKhachHang = kh.MaKhachHang,
                                 TenGiay = mh.TenGiay,
                                 DonGiaBan = mh.DonGiaBan,
                                 Size = mh.Size,
                                 SizeC = gh.SizeDat,
                                 Anh1 = mh.Anh1,
                                 SoLuongmh = mh.SoLuong,
                                 SoLuongDat = gh.SoLuongDat
                             }).ToList();
            foreach (var tt in thamchieu)
            {
                byte[] Pic1 = tt.Anh1.ToArray();
                MemoryStream trPic1 = new MemoryStream(Pic1);
                Image img1 = Image.FromStream(trPic1);
                listGH.Add(new GioHangDTO()
                {
                    MaGioHang = tt.MaGioHang,
                    MaGiay = tt.MaGiay,
                    TenGiay = tt.TenGiay,
                    DonGiaBan = (long)tt.DonGiaBan,
                    HinhGiay = img1,
                    SoLuongMatHang = int.Parse(tt.SoLuongmh.ToString()),
                    SoLuongDat = int.Parse(tt.SoLuongDat.ToString()),
                    SizeDat = tt.SizeC,
                    TongSize = tt.Size
                });
            }
            return listGH;
        }

        public static List<GioHangDTO> LayDSThanhToanFrom(List<GioHangDTO> listGH, string MKH)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            var thamchieu = (from gh in db.GIO_HANGs
                             from mh in db.MAT_HANGs
                             from kh in db.KHACH_HANGs
                             where gh.MaKhachHang == MKH
                             where kh.MaKhachHang == gh.MaKhachHang
                             where mh.MaGiay == gh.MaGiay
                             where gh.SoLuongDat != 0
                             select new
                             {
                                 MaGioHang = gh.MaGioHang,
                                 MaGiay = mh.MaGiay,
                                 TenGiay = mh.TenGiay,
                                 DonGiaBan = mh.DonGiaBan,
                                 SizeC = gh.SizeDat,
                                 SoLuongDat = gh.SoLuongDat,
                                 TenKhachHang = kh.TenKhachHang,
                                 SoDienThoai = kh.SoDienThoai,
                                 DiaChi = kh.DiaChi
                             }).ToList();
            foreach (var tt in thamchieu)
            {
                listGH.Add(new GioHangDTO()
                {
                    MaGioHang = tt.MaGioHang,
                    MaGiay = tt.MaGiay,
                    TenGiay = tt.TenGiay,
                    DonGiaBan = (long)tt.DonGiaBan,
                    SoLuongDat = int.Parse(tt.SoLuongDat.ToString()),
                    SizeDat = tt.SizeC,
                    TenKhachHang = tt.TenKhachHang,
                    SoDienThoai = tt.SoDienThoai,
                    DiaChi = tt.DiaChi
                });
            }
            return listGH;
        }

        public static void ThemVaoGioHang(GioHangDTO n)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            GIO_HANG gh = new GIO_HANG
            {
                MaGioHang = n.MaGioHang,
                MaGiay = n.MaGiay,
                MaKhachHang = n.MaKhachHang,
                SoLuongDat = n.SoLuongDat,
                SizeDat = n.SizeDat,
                SizeMatHang = n.TongSize,
                SoLuongMatHang = n.SoLuongMatHang
            };
            db.GIO_HANGs.InsertOnSubmit(gh);
            db.SubmitChanges();
        }

        public static void SuaSoLuong(string MaGioHang, int SoLuong)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            GIO_HANG gh = db.GIO_HANGs.SingleOrDefault(p => p.MaGioHang.Equals(MaGioHang));
            if (gh != null)
            {
                gh.SoLuongDat = SoLuong;
            }
            db.SubmitChanges();
        }

        public static void SuaSize(string MaGioHang, string size)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            GIO_HANG gh = db.GIO_HANGs.SingleOrDefault(p => p.MaGioHang.Equals(MaGioHang));
            if (gh != null)
            {
                gh.SizeDat = size;
            }
            db.SubmitChanges();
        }

        public static void XoaKhoiGioHang(string MaGioHang)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            GIO_HANG gh = db.GIO_HANGs.SingleOrDefault(p => p.MaGioHang.Equals(MaGioHang));
            if (gh != null) db.GIO_HANGs.DeleteOnSubmit(gh);
            db.SubmitChanges();
        }
    }
}
