using SHOESDTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SHOESDAL
{
    public class MatHangDAL
    {
        public static List<string> LayMaMatHang()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<string> ListMMH = new List<string>();
            var thamchieu = (from mh in db.MAT_HANGs
                             select mh).ToList();
            var khachhang = thamchieu.ToList();
            foreach (var tt in khachhang)
            {
                ListMMH.Add(tt.MaGiay);
            }
            return ListMMH;
        }

        public static List<MatHang> LayDSMatHangForm()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<MatHang> mhList = new List<MatHang>(100);
            var thamchieu = (from mh in db.MAT_HANGs
                             from ctmh in db.CHI_TIET_MAT_HANGs
                             where ctmh.MaGiay == mh.MaGiay
                             where mh.SoLuong >= 1
                             select new
                             {
                                 MaGiay = mh.MaGiay,
                                 TenGiay = mh.TenGiay,
                                 DonGiaBan = mh.DonGiaBan,
                                 Anh1 = mh.Anh1,
                                 ChatLieu = ctmh.ChatLieu,
                                 BaoHanh = ctmh.BaoHanh,
                                 Loai = mh.Loai
                             }).ToList();
            foreach (var tt in thamchieu)
            {
                byte[] Pic1 = tt.Anh1.ToArray();
                MemoryStream trPic1 = new MemoryStream(Pic1);
                Image img1 = Image.FromStream(trPic1);
                mhList.Add(new MatHang()
                {
                    MaGiay = tt.MaGiay,
                    TenGiay = tt.TenGiay,
                    Anh1 = img1,
                    Loai = tt.Loai,
                    DonGiaBan = tt.DonGiaBan,
                    ChatLieu = tt.ChatLieu,
                    BaoHanh = tt.BaoHanh
                });
            }
            return mhList;
        }

        public static MatHang LayDSMatHangChiTietForm(string MaGiay)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            MatHang MH = new MatHang();
            var thamchieu = (from mh in db.MAT_HANGs
                             from mh2 in db.CHI_TIET_MAT_HANGs
                             where mh.MaGiay == MaGiay
                             where mh2.MaGiay == mh.MaGiay
                             select new
                             {
                                 Mã_Giày = mh.MaGiay,
                                 Tên_Sản_Phẩm = mh.TenGiay,
                                 Số_Lượng = mh.SoLuong,
                                 Màu_Sắc = mh.MauSac,
                                 Size = mh.Size,
                                 Anh1 = mh.Anh1,
                                 Anh2 = mh.Anh2,
                                 Anh3 = mh.Anh3,
                                 Anh4 = mh.Anh4,
                                 Đơn_Giá_Bán = mh.DonGiaBan,
                                 Chất_Liệu = mh2.ChatLieu,
                                 Bảo_Hành = mh2.BaoHanh,
                                 Điều_Kiện = mh2.DieuKien,
                                 Ghi_Chú = mh2.GhiChu
                             }).ToList();
            foreach (var tt in thamchieu)
            {
                byte[] Pic1 = tt.Anh1.ToArray();
                byte[] Pic2 = tt.Anh2.ToArray();
                byte[] Pic3 = tt.Anh3.ToArray();
                byte[] Pic4 = tt.Anh4.ToArray();
                MemoryStream trPic1 = new MemoryStream(Pic1);
                MemoryStream trPic2 = new MemoryStream(Pic2);
                MemoryStream trPic3 = new MemoryStream(Pic3);
                MemoryStream trPic4 = new MemoryStream(Pic4);
                Image img1 = Image.FromStream(trPic1);
                Image img2 = Image.FromStream(trPic2);
                Image img3 = Image.FromStream(trPic3);
                Image img4 = Image.FromStream(trPic4);
                MH = new MatHang()
                {
                    MaGiay = tt.Mã_Giày,
                    TenGiay = tt.Tên_Sản_Phẩm,
                    Anh1 = img1,
                    Anh2 = img2,
                    Anh3 = img3,
                    Anh4 = img4,
                    SoLuong = tt.Số_Lượng,
                    MauSac = tt.Màu_Sắc,
                    Size = tt.Size,
                    DonGiaBan = tt.Đơn_Giá_Bán,
                    ChatLieu = tt.Chất_Liệu,
                    BaoHanh = tt.Bảo_Hành,
                    DieuKien = tt.Điều_Kiện,
                    GhiChu = tt.Ghi_Chú
                };
            }
            return MH;
        }

        public static List<MatHang> LayDSMatHang()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<MatHang> mhList = new List<MatHang>();
            var thamchieu = (from mh in db.MAT_HANGs
                             from ctmh in db.CHI_TIET_MAT_HANGs
                             where mh.MaGiay == ctmh.MaGiay
                             select new
                             {
                                 Mã_Giày = mh.MaGiay,
                                 Tên_Sản_Phẩm = mh.TenGiay,
                                 Anh1 = mh.Anh1,
                                 Anh2 = mh.Anh2,
                                 Anh3 = mh.Anh3,
                                 Anh4 = mh.Anh4,
                                 Loai = mh.Loai,
                                 Số_Lượng = mh.SoLuong,
                                 Màu_Sắc = mh.MauSac,
                                 Size = mh.Size,
                                 Đơn_Giá_Bán = mh.DonGiaBan,
                                 Đơn_Giá_Nhập = ctmh.DonGiaNhap,
                                 Chất_Liệu = ctmh.ChatLieu,
                                 Bảo_Hành = ctmh.BaoHanh,
                                 Điều_Kiện = ctmh.DieuKien,
                                 Ghi_Chú = ctmh.GhiChu
                             }).ToList();
            foreach (var tt in thamchieu)
            {
                byte[] Pic1 = tt.Anh1.ToArray();
                byte[] Pic2 = tt.Anh2.ToArray();
                byte[] Pic3 = tt.Anh3.ToArray();
                byte[] Pic4 = tt.Anh4.ToArray();
                MemoryStream trPic1 = new MemoryStream(Pic1);
                MemoryStream trPic2 = new MemoryStream(Pic2);
                MemoryStream trPic3 = new MemoryStream(Pic3);
                MemoryStream trPic4 = new MemoryStream(Pic4);
                Image img1 = Image.FromStream(trPic1);
                Image img2 = Image.FromStream(trPic2);
                Image img3 = Image.FromStream(trPic3);
                Image img4 = Image.FromStream(trPic4);
                mhList.Add(new MatHang()
                {
                    MaGiay = tt.Mã_Giày,
                    TenGiay = tt.Tên_Sản_Phẩm,
                    Anh1 = img1,
                    Anh2 = img2,
                    Anh3 = img3,
                    Anh4 = img4,
                    Loai = tt.Loai,
                    SoLuong = tt.Số_Lượng,
                    MauSac = tt.Màu_Sắc,
                    Size = tt.Size,
                    DonGiaBan = tt.Đơn_Giá_Bán,
                    DonGiaNhap = tt.Đơn_Giá_Nhập,
                    ChatLieu = tt.Chất_Liệu,
                    BaoHanh = tt.Bảo_Hành,
                    DieuKien = tt.Điều_Kiện,
                    GhiChu = tt.Ghi_Chú
                });
            }
            return mhList;
        }

        public static List<MatHang> LayDSMatHangWithMA(string MAMH)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<MatHang> mhList = new List<MatHang>();
            var thamchieu = (from mh in db.MAT_HANGs
                             from ctmh in db.CHI_TIET_MAT_HANGs
                             where mh.MaGiay == MAMH
                             where mh.MaGiay == ctmh.MaGiay
                             select new
                             {
                                 Mã_Giày = mh.MaGiay,
                                 Tên_Sản_Phẩm = mh.TenGiay,
                                 Anh1 = mh.Anh1,
                                 Anh2 = mh.Anh2,
                                 Anh3 = mh.Anh3,
                                 Anh4 = mh.Anh4,
                                 Loai = mh.Loai,
                                 Số_Lượng = mh.SoLuong,
                                 Màu_Sắc = mh.MauSac,
                                 Size = mh.Size,
                                 Đơn_Giá_Bán = mh.DonGiaBan,
                                 Đơn_Giá_Nhập = ctmh.DonGiaNhap,
                                 Chất_Liệu = ctmh.ChatLieu,
                                 Bảo_Hành = ctmh.BaoHanh,
                                 Điều_Kiện = ctmh.DieuKien,
                                 Ghi_Chú = ctmh.GhiChu
                             }).ToList();
            foreach (var tt in thamchieu)
            {
                byte[] Pic1 = tt.Anh1.ToArray();
                byte[] Pic2 = tt.Anh2.ToArray();
                byte[] Pic3 = tt.Anh3.ToArray();
                byte[] Pic4 = tt.Anh4.ToArray();
                MemoryStream trPic1 = new MemoryStream(Pic1);
                MemoryStream trPic2 = new MemoryStream(Pic2);
                MemoryStream trPic3 = new MemoryStream(Pic3);
                MemoryStream trPic4 = new MemoryStream(Pic4);
                Image img1 = Image.FromStream(trPic1);
                Image img2 = Image.FromStream(trPic2);
                Image img3 = Image.FromStream(trPic3);
                Image img4 = Image.FromStream(trPic4);
                mhList.Add(new MatHang()
                {
                    MaGiay = tt.Mã_Giày,
                    TenGiay = tt.Tên_Sản_Phẩm,
                    Anh1 = img1,
                    Anh2 = img2,
                    Anh3 = img3,
                    Anh4 = img4,
                    Loai = tt.Loai,
                    SoLuong = tt.Số_Lượng,
                    MauSac = tt.Màu_Sắc,
                    Size = tt.Size,
                    DonGiaBan = tt.Đơn_Giá_Bán,
                    DonGiaNhap = tt.Đơn_Giá_Nhập,
                    ChatLieu = tt.Chất_Liệu,
                    BaoHanh = tt.Bảo_Hành,
                    DieuKien = tt.Điều_Kiện,
                    GhiChu = tt.Ghi_Chú
                });
            }
            return mhList;
        }

        public static void ThemMatHang(MatHang n)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            MemoryStream Pic1 = new MemoryStream();
            MemoryStream Pic2 = new MemoryStream();
            MemoryStream Pic3 = new MemoryStream();
            MemoryStream Pic4 = new MemoryStream();
            n.Anh1.Save(Pic1, System.Drawing.Imaging.ImageFormat.Png);
            n.Anh2.Save(Pic2, System.Drawing.Imaging.ImageFormat.Png);
            n.Anh3.Save(Pic3, System.Drawing.Imaging.ImageFormat.Png);
            n.Anh4.Save(Pic4, System.Drawing.Imaging.ImageFormat.Png);
            byte[] Hinh1 = Pic1.ToArray();
            byte[] Hinh2 = Pic2.ToArray();
            byte[] Hinh3 = Pic3.ToArray();
            byte[] Hinh4 = Pic4.ToArray();

            MAT_HANG mh = new MAT_HANG
            {
                TenGiay = n.TenGiay,
                Anh1 = Hinh1,
                Anh2 = Hinh2,
                Anh3 = Hinh3,
                Anh4 = Hinh4,
                Loai = n.Loai,
                SoLuong = n.SoLuong,
                MauSac = n.MauSac,
                Size = n.Size,
                DonGiaBan = n.DonGiaBan
            };
            CHI_TIET_MAT_HANG ctmh = new CHI_TIET_MAT_HANG
            {
                MaGiay = n.MaGiay,
                DonGiaNhap = n.DonGiaNhap,
                ChatLieu = n.ChatLieu,
                BaoHanh = n.BaoHanh,
                DieuKien = n.DieuKien,
                GhiChu = n.GhiChu
            };
            db.MAT_HANGs.InsertOnSubmit(mh);
            db.CHI_TIET_MAT_HANGs.InsertOnSubmit(ctmh);
            db.SubmitChanges();
        }

        public static void XoaMatHang(string MMH)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            MAT_HANG mh = db.MAT_HANGs.SingleOrDefault(p => p.MaGiay.Equals(MMH));
            CHI_TIET_MAT_HANG ctmh = db.CHI_TIET_MAT_HANGs.SingleOrDefault(p => p.MaGiay.Equals(MMH));
            //HOA_DON hd = db.HOA_DONs.SingleOrDefault(p => p.MaGiay.Equals(MMH));
            KY_GUI kg = db.KY_GUIs.SingleOrDefault(p => p.MaGiay.Equals(MMH));
            if (mh != null)
            {
                db.MAT_HANGs.DeleteOnSubmit(mh);
            }
            if (ctmh != null)
            {
                db.CHI_TIET_MAT_HANGs.DeleteOnSubmit(ctmh);
            }
            /*
            if (hd != null)
            {
                db.HOA_DONs.DeleteOnSubmit(hd);
                CHI_TIET_HOA_DON cthd = db.CHI_TIET_HOA_DONs.SingleOrDefault(p => p.MaHoaDon.Equals(hd.MaHoaDon));
                db.CHI_TIET_HOA_DONs.DeleteOnSubmit(cthd);
            }
            */
            if (kg != null)
            {
                db.KY_GUIs.DeleteOnSubmit(kg);
            }
            db.SubmitChanges();
        }

        public static void SuaMatHang(MatHang n)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            MAT_HANG mh = db.MAT_HANGs.SingleOrDefault(p => p.MaGiay.Equals(n.MaGiay));
            MemoryStream Pic1 = new MemoryStream();
            MemoryStream Pic2 = new MemoryStream();
            MemoryStream Pic3 = new MemoryStream();
            MemoryStream Pic4 = new MemoryStream();
            n.Anh1.Save(Pic1, System.Drawing.Imaging.ImageFormat.Png);
            n.Anh2.Save(Pic2, System.Drawing.Imaging.ImageFormat.Png);
            n.Anh3.Save(Pic3, System.Drawing.Imaging.ImageFormat.Png);
            n.Anh4.Save(Pic4, System.Drawing.Imaging.ImageFormat.Png);
            byte[] Hinh1 = Pic1.ToArray();
            byte[] Hinh2 = Pic2.ToArray();
            byte[] Hinh3 = Pic3.ToArray();
            byte[] Hinh4 = Pic4.ToArray();
            if (mh != null)
            {
                mh.TenGiay = n.TenGiay;
                mh.Loai = n.Loai;
                mh.Anh1 = Hinh1;
                mh.Anh2 = Hinh2;
                mh.Anh3 = Hinh3;
                mh.Anh4 = Hinh4;
                mh.SoLuong = n.SoLuong;
                mh.MauSac = n.MauSac;
                mh.Size = n.Size;
                mh.DonGiaBan = n.DonGiaBan;
            }
            CHI_TIET_MAT_HANG ctmh = db.CHI_TIET_MAT_HANGs.SingleOrDefault(p => p.MaGiay.Equals(n.MaGiay));
            if (ctmh != null)
            {
                ctmh.DonGiaNhap = n.DonGiaNhap;
                ctmh.ChatLieu = n.ChatLieu;
                ctmh.BaoHanh = n.BaoHanh;
                ctmh.DieuKien = n.DieuKien;
                ctmh.GhiChu = n.GhiChu;
            }
            db.SubmitChanges();
        }

        public static void GiamSoLuongMatHang(string MMH)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            MAT_HANG mh = db.MAT_HANGs.SingleOrDefault(p => p.MaGiay.Equals(MMH));
            if (mh != null)
            {
                mh.SoLuong--;
                if (mh.SoLuong <= 0)
                {
                    mh.SoLuong = 0;
                }
            }
            db.SubmitChanges();
        }
    }
}
