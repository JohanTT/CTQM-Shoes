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
    public class KyGuiDAL
    {
        public static List<string> LayMaKyGui()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<string> ListMKG = new List<string>();
            var thamchieu = (from kg in db.KY_GUIs
                             select kg).ToList();
            var khachhang = thamchieu.ToList();
            foreach (var tt in khachhang)
            {
                ListMKG.Add(tt.MaGiay);
            }
            return ListMKG;
        }

        public static List<KyGui> LayDSKyGui()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<KyGui> kgList = new List<KyGui>();
            var thamchieu = (from kg in db.KY_GUIs
                             from mh in db.MAT_HANGs
                             from ctmh in db.CHI_TIET_MAT_HANGs
                             where kg.MaGiay == ctmh.MaGiay
                             where kg.MaGiay == mh.MaGiay
                             select new
                             {
                                 Mã_Giày = kg.MaGiay,
                                 Mã_Khách_Hàng = kg.MaKhachHang,
                                 Mã_Nhân_Viên = kg.MaNhanVien,
                                 Tên_Giày = mh.TenGiay,
                                 Số_Lượng = mh.SoLuong,
                                 Anh1 = mh.Anh1,
                                 Anh2 = mh.Anh2,
                                 Anh3 = mh.Anh3,
                                 Anh4 = mh.Anh4,
                                 Loai = mh.Loai,
                                 Màu_Sắc = mh.MauSac,
                                 Size = mh.Size,
                                 Đơn_Giá_Bán = mh.DonGiaBan,
                                 Đơn_Giá_Nhập = ctmh.DonGiaNhap,
                                 Chất_Liệu = ctmh.ChatLieu,
                                 Bảo_Hành = ctmh.BaoHanh,
                                 Điều_Kiện = ctmh.DieuKien,
                                 Ghi_Chú = ctmh.GhiChu,
                                 Phí_Ký_Gửi = kg.PhiKyGui,
                                 Thời_Gian_Ký_Gửi = kg.ThoiGianGui,
                                 Ngày_Ký_Gửi = kg.NgayKyGui,
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
                kgList.Add(new KyGui()
                {
                    MaGiay = tt.Mã_Giày,
                    MaKhachHang = tt.Mã_Khách_Hàng,
                    MaNhanVien = tt.Mã_Nhân_Viên,
                    TenGiay = tt.Tên_Giày,
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
                    GhiChu = tt.Ghi_Chú,
                    PhiKyGui = tt.Phí_Ký_Gửi,
                    NgayKyGui = tt.Ngày_Ký_Gửi,
                    ThoiGianKyGui = tt.Thời_Gian_Ký_Gửi    
                });
            }
            return kgList;
        }

        public static List<KyGui> LayDSKyGuiWithMA(string MAKG)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<KyGui> kgList = new List<KyGui>();
            var thamchieu = (from kg in db.KY_GUIs
                             from mh in db.MAT_HANGs
                             from ctmh in db.CHI_TIET_MAT_HANGs
                             where kg.MaGiay == MAKG
                             where kg.MaGiay == ctmh.MaGiay
                             where kg.MaGiay == mh.MaGiay
                             select new
                             {
                                 Mã_Giày = kg.MaGiay,
                                 Mã_Khách_Hàng = kg.MaKhachHang,
                                 Mã_Nhân_Viên = kg.MaNhanVien,
                                 Tên_Giày = mh.TenGiay,
                                 Số_Lượng = mh.SoLuong,
                                 Anh1 = mh.Anh1,
                                 Anh2 = mh.Anh2,
                                 Anh3 = mh.Anh3,
                                 Anh4 = mh.Anh4,
                                 Loai = mh.Loai,
                                 Màu_Sắc = mh.MauSac,
                                 Size = mh.Size,
                                 Đơn_Giá_Bán = mh.DonGiaBan,
                                 Đơn_Giá_Nhập = ctmh.DonGiaNhap,
                                 Chất_Liệu = ctmh.ChatLieu,
                                 Bảo_Hành = ctmh.BaoHanh,
                                 Điều_Kiện = ctmh.DieuKien,
                                 Ghi_Chú = ctmh.GhiChu,
                                 Phí_Ký_Gửi = kg.PhiKyGui,
                                 Thời_Gian_Ký_Gửi = kg.ThoiGianGui,
                                 Ngày_Ký_Gửi = kg.NgayKyGui,
                             }).ToList();
            var kygui = thamchieu.ToList();
            foreach (var tt in kygui)
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
                kgList.Add(new KyGui()
                {
                    MaGiay = tt.Mã_Giày,
                    MaKhachHang = tt.Mã_Khách_Hàng,
                    MaNhanVien = tt.Mã_Nhân_Viên,
                    TenGiay = tt.Tên_Giày,
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
                    GhiChu = tt.Ghi_Chú,
                    PhiKyGui = tt.Phí_Ký_Gửi,
                    NgayKyGui = tt.Ngày_Ký_Gửi,
                    ThoiGianKyGui = tt.Thời_Gian_Ký_Gửi
                });
            }
            return kgList;
        }

        public static List<KyGui> LayDSKyGuiCho()
        {
            Shoes2DataContext db = new Shoes2DataContext();
            List<KyGui> kgList = new List<KyGui>();
            var thamchieu = (from kgc in db.DANH_SACH_KY_GUI_CHOs
                             select kgc).ToList();
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
                kgList.Add(new KyGui()
                {
                    MaKhachHang = tt.MaKhachHang,
                    TenGiay = tt.TenGiay,
                    Anh1 = img1,
                    Anh2 = img2,
                    Anh3 = img3,
                    Anh4 = img4,
                    SoLuong = tt.SoLuong,
                    MauSac = tt.MauSac,
                    Size = tt.Size,
                    DonGiaNhap = tt.DonGiaNhap,
                    ChatLieu = tt.ChatLieu,
                    BaoHanh = tt.BaoHanh,
                    DieuKien = tt.DieuKien,
                    GhiChu = tt.GhiChu,
                    PhiKyGui = tt.PhiKyGui,
                    NgayKyGui = tt.NgayKyGui,
                    ThoiGianKyGui = tt.ThoiGianGui
                });
            }
            return kgList;
        }

        public static List<KyGui> LayDSKyGuiFrom(List<KyGui> listKG, string MKH)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            var thamchieu = (from kg in db.KY_GUIs
                             from mh in db.MAT_HANGs
                             from ctmh in db.CHI_TIET_MAT_HANGs
                             from kh in db.KHACH_HANGs
                             where kg.MaKhachHang == MKH
                             where kh.MaKhachHang == kg.MaKhachHang
                             where mh.MaGiay == kg.MaGiay
                             where ctmh.MaGiay == kg.MaGiay
                             select new
                             {
                                 MaGiay = mh.MaGiay,
                                 MaKhachHang = kh.MaKhachHang,
                                 TenGiay = mh.TenGiay,
                                 TenKhachHang = kh.MaKhachHang,
                                 DonGiaBan = mh.DonGiaBan,
                                 DonGiaNhap = ctmh.DonGiaNhap,
                                 Size = mh.Size,
                                 Anh = mh.Anh1,
                                 SoLuongmh = mh.SoLuong,
                                 ThoiHanGui = kg.ThoiGianGui,
                                 DieuKien = ctmh.DieuKien
                             }).ToList();
            foreach (var tt in thamchieu)
            {
                byte[] Pic1 = tt.Anh.ToArray();
                MemoryStream trPic1 = new MemoryStream(Pic1);
                Image img1 = Image.FromStream(trPic1);
                listKG.Add(new KyGui()
                {
                    MaGiay = tt.MaGiay,
                    TenGiay = tt.TenGiay,
                    DonGiaBan = long.Parse(tt.DonGiaBan.ToString()),
                    DonGiaNhap = tt.DonGiaNhap,
                    Anh1 = img1,
                    ThoiGianKyGui = tt.ThoiHanGui
                });
            }
            return listKG;
        }

        public static List<KyGui> LayDSKyGuiChoFrom(List<KyGui> listKG, string MKH)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            var thamchieu = (from kgc in db.DANH_SACH_KY_GUI_CHOs
                             where kgc.MaKhachHang == MKH
                             select kgc).ToList();
            foreach (var tt in thamchieu)
            {
                byte[] Pic1 = tt.Anh1.ToArray();
                MemoryStream trPic1 = new MemoryStream(Pic1);
                Image img1 = Image.FromStream(trPic1);
                listKG.Add(new KyGui()
                {
                    TenGiay = tt.TenGiay,
                    DonGiaNhap = tt.DonGiaNhap,
                    Anh1 = img1,
                    ThoiGianKyGui = tt.ThoiGianGui
                });
            }
            return listKG;
        }

        public static void ThemKyGui(KyGui n)
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
            KY_GUI kg = new KY_GUI
            {
                MaGiay = n.MaGiay,
                MaKhachHang = n.MaKhachHang,
                MaNhanVien = n.MaNhanVien,
                NgayKyGui = n.NgayKyGui,
                ThoiGianGui = n.ThoiGianKyGui,
                PhiKyGui = n.PhiKyGui,
                DonGiaNhap = n.DonGiaNhap
            };
            MAT_HANG mh = new MAT_HANG
            {
                MaGiay = n.MaGiay,
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

            db.KY_GUIs.InsertOnSubmit(kg);
            db.MAT_HANGs.InsertOnSubmit(mh);
            db.CHI_TIET_MAT_HANGs.InsertOnSubmit(ctmh);
            db.SubmitChanges();
        }

        public static void XoaKyGui(string MKG)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            KY_GUI kg = db.KY_GUIs.SingleOrDefault(p => p.MaGiay.Equals(MKG));
            MAT_HANG mh = db.MAT_HANGs.SingleOrDefault(p => p.MaGiay.Equals(MKG));
            CHI_TIET_MAT_HANG ctmh = db.CHI_TIET_MAT_HANGs.SingleOrDefault(p => p.MaGiay.Equals(MKG));
            //HOA_DON hd = db.HOA_DONs.SingleOrDefault(p => p.MaGiay.Equals(MKG));

            if (kg != null)
            {
                db.KY_GUIs.DeleteOnSubmit(kg);
            }
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
            db.SubmitChanges();
        }

        public static void SuaKyGui(KyGui n)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            KY_GUI kg = db.KY_GUIs.SingleOrDefault(p => p.MaGiay.Equals(n.MaGiay));
            MAT_HANG mh = db.MAT_HANGs.SingleOrDefault(p => p.MaGiay.Equals(n.MaGiay));
            CHI_TIET_MAT_HANG ctmh = db.CHI_TIET_MAT_HANGs.SingleOrDefault(p => p.MaGiay.Equals(n.MaGiay));
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
            if (kg != null)
            {
                kg.NgayKyGui = n.NgayKyGui;
                kg.ThoiGianGui = n.ThoiGianKyGui;
                kg.PhiKyGui = n.PhiKyGui;
                kg.DonGiaNhap = n.DonGiaNhap;
            }
            if (mh != null)
            {
                mh.TenGiay = n.TenGiay;
                mh.Anh1 = Hinh1;
                mh.Anh2 = Hinh2;
                mh.Anh3 = Hinh3;
                mh.Anh4 = Hinh4;
                mh.Loai = n.Loai;
                mh.SoLuong = n.SoLuong;
                mh.MauSac = n.MauSac;
                mh.Size = n.Size;
                mh.DonGiaBan = n.DonGiaBan;
            }
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

        public static void ThemKyGuiCho(KyGui n)
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
            DANH_SACH_KY_GUI_CHO KG = new DANH_SACH_KY_GUI_CHO
            {
                MaKhachHang = n.MaKhachHang,
                TenGiay = n.TenGiay,
                Anh1 = Hinh1,
                Anh2 = Hinh2,
                Anh3 = Hinh3,
                Anh4 = Hinh4,
                SoLuong = n.SoLuong,
                MauSac = n.MauSac,
                Size = n.Size,
                ChatLieu = n.ChatLieu,
                BaoHanh = n.BaoHanh,
                DieuKien = n.DieuKien,
                NgayKyGui = n.NgayKyGui,
                ThoiGianGui = n.ThoiGianKyGui,
                PhiKyGui = n.PhiKyGui,
                DonGiaNhap = n.DonGiaNhap,
                GhiChu = n.GhiChu
            };
            db.DANH_SACH_KY_GUI_CHOs.InsertOnSubmit(KG);
            db.SubmitChanges();
        }

        public static void XoaKyGuiCho(string MKG)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            DANH_SACH_KY_GUI_CHO kgc = db.DANH_SACH_KY_GUI_CHOs.SingleOrDefault(p => p.TenGiay.Equals(MKG));
            if (kgc != null)
            {
                db.DANH_SACH_KY_GUI_CHOs.DeleteOnSubmit(kgc);
            }
            db.SubmitChanges();
        }

        public static void SuaKyGuiCho(KyGui n)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            DANH_SACH_KY_GUI_CHO kgc = db.DANH_SACH_KY_GUI_CHOs.SingleOrDefault(p => p.MaKhachHang.Equals(n.MaKhachHang));
            if (kgc != null)
            {
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
                kgc.MaKhachHang = n.MaKhachHang;
                kgc.TenGiay = n.TenGiay;
                kgc.Anh1 = Hinh1;
                kgc.Anh2 = Hinh2;
                kgc.Anh3 = Hinh3;
                kgc.Anh4 = Hinh4;
                kgc.SoLuong = n.SoLuong;
                kgc.MauSac = n.MauSac;
                kgc.Size = n.Size;
                kgc.ChatLieu = n.ChatLieu;
                kgc.BaoHanh = n.BaoHanh;
                kgc.DieuKien = n.DieuKien;
                kgc.NgayKyGui = n.NgayKyGui;
                kgc.ThoiGianGui = n.ThoiGianKyGui;
                kgc.PhiKyGui = n.PhiKyGui;
                kgc.DonGiaNhap = n.DonGiaNhap;
                kgc.GhiChu = n.GhiChu;
            }
            db.SubmitChanges();
        }
    }
}
