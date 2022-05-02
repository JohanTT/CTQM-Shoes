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
    public class HoaDonDAL
    {
        public static List<string> LayMaHoaDon()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<string> ListMHD = new List<string>();
            var thamchieu = (from hd in db.HOA_DONs
                             select hd).ToList();
            var khachhang = thamchieu.ToList();
            foreach (var tt in khachhang)
            {
                ListMHD.Add(tt.MaHoaDon);
            }
            return ListMHD;
        }

        public static List<string> LayMaHoaDonCho()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<string> ListMHD = new List<string>();
            var thamchieu = (from hd in db.DANH_SACH_HOA_DON_CHOs
                             select hd).ToList();
            var khachhang = thamchieu.ToList();
            foreach (var tt in khachhang)
            {
                ListMHD.Add(tt.MaHoaDon);
            }
            return ListMHD;
        }

        public static List<HoaDon> LayDSGiayTuBill(string mkh)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<HoaDon> listHD = new List<HoaDon>();
            var thamchieu = (from hd in db.HOA_DONs
                             from cthd in db.CHI_TIET_HOA_DONs
                             from mh in db.MAT_HANGs
                             where cthd.MaKhachHang == mkh
                             where cthd.MaHoaDon == hd.MaHoaDon
                             where hd.MaGiay == mh.MaGiay
                             select new
                             {
                                 MaGiay = mh.MaGiay,
                                 TenGiay = mh.TenGiay,
                                 PhuongThucThanhToan = hd.PhuongThucThanhToan,
                                 DonGiaBan = hd.DonGiaBan,
                                 SoLuongDat = cthd.SoLuong,
                                 KhuyenMai = hd.KhuyenMai,
                                 SizeDat = cthd.Size
                             }).ToList();
            foreach (var tt in thamchieu)
            {
                listHD.Add(new HoaDon
                {
                    MaGiay = tt.MaGiay,
                    DonGiaBan = tt.DonGiaBan,
                    PhuongThucThanhToan = tt.PhuongThucThanhToan,
                    SoLuong = tt.SoLuongDat,
                    Size = tt.SizeDat,
                    KhuyenMai = tt.KhuyenMai[0].ToString() + tt.KhuyenMai[1].ToString()
                });
            }
            return listHD;
        }

        public static List<HoaDon> LayDSGiayTuBillCho(string mkh)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<HoaDon> listHD = new List<HoaDon>();
            var thamchieu = (from dshdc in db.DANH_SACH_HOA_DON_CHOs
                             from mh in db.MAT_HANGs
                             where dshdc.MaKhachHang == mkh
                             where mh.MaGiay == dshdc.MaGiay
                             select new
                             {
                                 MaGiay = mh.MaGiay,
                                 TenGiay = mh.TenGiay,
                                 PhuongThucThanhToan = dshdc.PhuongThucThanhToan,
                                 DonGiaBan = dshdc.DonGiaBan,
                                 SoLuongDat = dshdc.SoLuong,
                                 KhuyenMai = dshdc.KhuyenMai,
                                 SizeDat = dshdc.Size,
                             }).ToList();
            foreach (var tt in thamchieu)
            {
                listHD.Add(new HoaDon
                {
                    MaGiay = tt.MaGiay,
                    PhuongThucThanhToan = tt.PhuongThucThanhToan,
                    DonGiaBan = tt.DonGiaBan,
                    SoLuong = tt.SoLuongDat,
                    Size = tt.SizeDat,
                    KhuyenMai = tt.KhuyenMai[0].ToString() + tt.KhuyenMai[1].ToString()
                });
            }
            return listHD;
        }

        public static List<HoaDon> LayDSHoaDonCho()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<HoaDon> hdList = new List<HoaDon>();
            var thamchieu = (from hdc in db.DANH_SACH_HOA_DON_CHOs
                             select hdc).ToList();
            foreach (var tt in thamchieu)
            {
                hdList.Add(new HoaDon()
                {
                    MaHoaDon = tt.MaHoaDon,
                    MaGiay = tt.MaGiay,
                    MaKhachHang = tt.MaKhachHang,
                    MaKhuyenMai = tt.MaKhuyenMai,
                    PhuongThucThanhToan = tt.PhuongThucThanhToan,
                    DonGiaBan = tt.DonGiaBan,
                    KhuyenMai = tt.KhuyenMai,
                    ThanhTien = tt.ThanhTien,
                    SoLuong = tt.SoLuong,
                    Size = tt.Size,
                    NgayThanhToan = tt.NgayThanhToan
                });
            }
            return hdList;
        }

        public static List<HoaDon> LayDSHoaDon()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<HoaDon> hdList = new List<HoaDon>();
            var thamchieu = (from hd in db.HOA_DONs
                             from cthd in db.CHI_TIET_HOA_DONs
                             where hd.MaHoaDon == cthd.MaHoaDon
                             select new
                             {
                                 Mã_Hoá_Đơn = hd.MaHoaDon,
                                 Mã_Giày = hd.MaGiay,
                                 Mã_Khách_Hàng = cthd.MaKhachHang,
                                 Mã_Nhân_Viên = cthd.MaNhanVien,
                                 Mã_Khuyến_Mãi = hd.MaKhuyenMai,
                                 Phương_Thức_Thanh_Toán = hd.PhuongThucThanhToan,
                                 Đơn_Giá_Bán = hd.DonGiaBan,
                                 Khuyến_Mãi = hd.KhuyenMai,
                                 Thành_Tiền = hd.ThanhTien,
                                 Số_Lượng = cthd.SoLuong,
                                 Size = cthd.Size,
                                 Ngày_Thanh_Toán = cthd.NgayThanhToan,
                                 Đánh_Giá = cthd.DanhGia
                             }).ToList();

            var hoadon = thamchieu.ToList();
            foreach (var tt in hoadon)
            {
                hdList.Add(new HoaDon()
                {
                    MaHoaDon = tt.Mã_Hoá_Đơn,
                    MaGiay = tt.Mã_Giày,
                    MaKhachHang = tt.Mã_Khách_Hàng,
                    MaNhanVien = tt.Mã_Nhân_Viên,
                    MaKhuyenMai = tt.Mã_Khuyến_Mãi,
                    PhuongThucThanhToan = tt.Phương_Thức_Thanh_Toán,
                    DonGiaBan = tt.Đơn_Giá_Bán,
                    KhuyenMai = tt.Khuyến_Mãi,
                    ThanhTien = tt.Thành_Tiền,
                    SoLuong = tt.Số_Lượng,
                    Size = tt.Size,
                    NgayThanhToan = tt.Ngày_Thanh_Toán,
                    DanhGia = tt.Đánh_Giá
                });
            }
            return hdList;
        }

        public static List<HoaDon> LayDSHoaDonWithMA(string MHD)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<HoaDon> hdList = new List<HoaDon>();
            var thamchieu = (from hd in db.HOA_DONs
                             from cthd in db.CHI_TIET_HOA_DONs
                             where hd.MaHoaDon == MHD
                             where hd.MaHoaDon == cthd.MaHoaDon
                             select new
                             {
                                 Mã_Hoá_Đơn = hd.MaHoaDon,
                                 Mã_Giày = hd.MaGiay,
                                 Mã_Khách_Hàng = cthd.MaKhachHang,
                                 Mã_Nhân_Viên = cthd.MaNhanVien,
                                 Mã_Khuyến_Mãi = hd.MaKhuyenMai,
                                 Đơn_Giá_Bán = hd.DonGiaBan,
                                 Khuyến_Mãi = hd.KhuyenMai,
                                 Thành_Tiền = hd.ThanhTien,
                                 Số_Lượng = cthd.SoLuong,
                                 Size = cthd.Size,
                                 Ngày_Thanh_Toán = cthd.NgayThanhToan,
                                 Đánh_Giá = cthd.DanhGia
                             }).ToList();

            var hoadon = thamchieu.ToList();
            foreach (var tt in hoadon)
            {
                hdList.Add(new HoaDon()
                {
                    MaHoaDon = tt.Mã_Hoá_Đơn,
                    MaGiay = tt.Mã_Giày,
                    MaKhachHang = tt.Mã_Khách_Hàng,
                    MaNhanVien = tt.Mã_Nhân_Viên,
                    MaKhuyenMai = tt.Mã_Khuyến_Mãi,
                    DonGiaBan = tt.Đơn_Giá_Bán,
                    KhuyenMai = tt.Khuyến_Mãi,
                    ThanhTien = tt.Thành_Tiền,
                    SoLuong = tt.Số_Lượng,
                    Size = tt.Size,
                    NgayThanhToan = tt.Ngày_Thanh_Toán,
                    DanhGia = tt.Đánh_Giá
                });
            }
            return hdList;
        }

        public static void ThemHoaDon(HoaDon n)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            HOA_DON hd = new HOA_DON
            {
                MaHoaDon = n.MaHoaDon,
                MaGiay = n.MaGiay,
                MaKhuyenMai = n.MaKhuyenMai,
                PhuongThucThanhToan = n.PhuongThucThanhToan,
                DonGiaBan = n.DonGiaBan,
                KhuyenMai = n.KhuyenMai,
                ThanhTien = n.ThanhTien
            };

            CHI_TIET_HOA_DON cthd = new CHI_TIET_HOA_DON
            {
                MaHoaDon = n.MaHoaDon,
                MaKhachHang = n.MaKhachHang,
                MaNhanVien = n.MaNhanVien,
                SoLuong = n.SoLuong,
                Size = n.Size,
                NgayThanhToan = n.NgayThanhToan,
                DanhGia = n.DanhGia
            };

            db.HOA_DONs.InsertOnSubmit(hd);
            db.CHI_TIET_HOA_DONs.InsertOnSubmit(cthd);
            db.SubmitChanges();
        }

        public static void XoaHoaDon(string MHD)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            HOA_DON hd = db.HOA_DONs.SingleOrDefault(p => p.MaHoaDon.Equals(MHD));
            CHI_TIET_HOA_DON cthd = db.CHI_TIET_HOA_DONs.SingleOrDefault(p => p.MaHoaDon.Equals(MHD));

            if (hd != null)
            {
                db.HOA_DONs.DeleteOnSubmit(hd);
            }
            if (cthd != null)
            {
                db.CHI_TIET_HOA_DONs.DeleteOnSubmit(cthd);
            }
            db.SubmitChanges();
        }

        public static void SuaHoaDon(HoaDon n)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            HOA_DON hd = db.HOA_DONs.SingleOrDefault(p => p.MaHoaDon.Equals(n.MaHoaDon));
            CHI_TIET_HOA_DON cthd = db.CHI_TIET_HOA_DONs.SingleOrDefault(p => p.MaHoaDon.Equals(n.MaHoaDon));

            if (hd != null)
            {
                hd.MaGiay = n.MaGiay;
                hd.MaKhuyenMai = n.MaKhuyenMai;
                hd.PhuongThucThanhToan = n.PhuongThucThanhToan;
                hd.DonGiaBan = n.DonGiaBan;
                hd.KhuyenMai = n.KhuyenMai;
                hd.ThanhTien = n.ThanhTien;
            }
            if (cthd != null)
            {
                cthd.MaKhachHang = n.MaKhachHang;
                cthd.MaNhanVien = n.MaNhanVien;
                cthd.SoLuong = n.SoLuong;
                cthd.Size = n.Size;
                cthd.NgayThanhToan = n.NgayThanhToan;
                cthd.DanhGia = n.DanhGia;
            }

            db.SubmitChanges();
        }

        public static void ThemVaoHoaDonCho(HoaDon n)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            DANH_SACH_HOA_DON_CHO hd = new DANH_SACH_HOA_DON_CHO
            {
                MaHoaDon = n.MaHoaDon,
                MaKhachHang = n.MaKhachHang,
                MaGiay = n.MaGiay,
                MaKhuyenMai = n.MaKhuyenMai,
                PhuongThucThanhToan = n.PhuongThucThanhToan,
                DonGiaBan = n.DonGiaBan,
                KhuyenMai = n.KhuyenMai,
                ThanhTien = n.ThanhTien,
                SoLuong = n.SoLuong,
                Size = n.Size,
                NgayThanhToan = n.NgayThanhToan
            };
            db.DANH_SACH_HOA_DON_CHOs.InsertOnSubmit(hd);
            db.SubmitChanges();
        }

        public static void XoaHoaDonCho(string MHD)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            DANH_SACH_HOA_DON_CHO hdc = db.DANH_SACH_HOA_DON_CHOs.SingleOrDefault(p => p.MaHoaDon.Equals(MHD));

            if (hdc != null)
            {
                db.DANH_SACH_HOA_DON_CHOs.DeleteOnSubmit(hdc);
            }
            db.SubmitChanges();
        }

        public static void SuaHoaDonCho(HoaDon n)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            DANH_SACH_HOA_DON_CHO hdc = db.DANH_SACH_HOA_DON_CHOs.SingleOrDefault(p => p.MaHoaDon.Equals(n.MaHoaDon));
            if (hdc != null)
            {
                hdc.MaHoaDon = n.MaHoaDon;
                hdc.MaKhachHang = n.MaKhachHang;
                hdc.MaGiay = n.MaGiay;
                hdc.MaKhuyenMai = n.MaKhuyenMai;
                hdc.PhuongThucThanhToan = n.PhuongThucThanhToan;
                hdc.DonGiaBan = n.DonGiaBan;
                hdc.KhuyenMai = n.KhuyenMai;
                hdc.ThanhTien = n.ThanhTien;
                hdc.SoLuong = n.SoLuong;
                hdc.Size = n.Size;
                hdc.NgayThanhToan = n.NgayThanhToan;
            }
            db.SubmitChanges();
        }
    }
}
