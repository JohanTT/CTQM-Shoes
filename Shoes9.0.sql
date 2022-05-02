Create Database SHOESSS
GO

USE SHOESSS
GO

CREATE TABLE KHACH_HANG (
    MaKhachHang  CHAR		(20) CONSTRAINT KH_MAKH_PK PRIMARY KEY ,
    TenKhachHang NVARCHAR	(50) CONSTRAINT KH_TENKH_U NOT NULL,
    SoDienThoai  CHAR		(10) CONSTRAINT KH_SDT_N NULL,
    DiaChi       NVARCHAR	(50) CONSTRAINT KH_DC_N NULL,
	NgaySinh	 DATE		     CONSTRAINT KH_NS_N NULL,
	GioiTinh     Nchar		(4)  CONSTRAINT KH_P_C CHECK (GioiTinh IN (N'NAM', N'NỮ')),
	TaiKhoan	 VARCHAR	(50) CONSTRAINT KH_TK_NN NOT NULL,
	MatKhau		 VARCHAR	(50) CONSTRAINT KH_MK_NN NOT NULL,
	GhiChu		 Nchar		(5)   CONSTRAINT KH_GC_C CHECK (GhiChu IN ('TRUE','FALSE')),
	TienVDT		 FLOAT		(53) CONSTRAINT KH_TVDT_N NOT NULL,
	MaBaoMat	 CHAR		(5)  CONSTRAINT KH_MVDT_N NOT NULL
)
GO

CREATE TABLE MAT_HANG (
    MaGiay     CHAR			(20)	CONSTRAINT MH_MAG_PK PRIMARY KEY,
    TenGiay    NVARCHAR		(50)	CONSTRAINT MH_TENG_NN NOT NULL,
    Anh1       VARBINARY	(MAX)	CONSTRAINT MH_A_NN NOT NULL,
	Anh2       VARBINARY	(MAX)	CONSTRAINT MH_A_NN NOT NULL,
	Anh3       VARBINARY	(MAX)	CONSTRAINT MH_A_NN NOT NULL,
	Anh4       VARBINARY	(MAX)	CONSTRAINT MH_A_NN NOT NULL,
	Loai	   Nchar	    (3)		CONSTRAINT MH_L_C CHECK (Loai IN ('OLD', 'NEW')),
    SoLuong    FLOAT		(53)    CONSTRAINT MH_SL_NN NOT NULL,
    MauSac     NVARCHAR		(50)	CONSTRAINT MH_MS_NN NOT NULL,
    Size       CHAR			(53)    CONSTRAINT MH_SIZE_NN NOT NULL,
	DonGiaBan  FLOAT		(53)    CONSTRAINT MH_DONGB_NN NOT NULL,
)
GO

CREATE TABLE NHAN_VIEN (
	MaNhanVien		CHAR		(20) CONSTRAINT NV_MNV_PK PRIMARY KEY,
	TenNhanVien		NVARCHAR	(50) CONSTRAINT NV_TNV_NN NOT NULL,
	SoDienThoai		CHAR		(10) CONSTRAINT NV_SDT_NN NOT NULL,
	DiaChi			NVARCHAR	(100)CONSTRAINT NV_DC_NN NOT NULL,
	NgaySinh		DATE			 CONSTRAINT NV_NS_NN NOT NULL,
	GioiTinh		Nchar		(4)	 CONSTRAINT NV_P_C CHECK (GioiTinh IN (N'NAM', N'NỮ'))
)
GO

CREATE TABLE HOA_DON (
	MaHoaDon          CHAR		(50)  CONSTRAINT HD_MHD_PK PRIMARY KEY,
    MaGiay			  CHAR		(20)  CONSTRAINT HD_MG_FK FOREIGN KEY  (MaGiay) REFERENCES MAT_HANG (MaGiay), 
	MaKhuyenMai		  CHAR		(20)  CONSTRAINT HD_MKM_N NULL,
	PhuongThucThanhToan		NCHAR	(20)  CONSTRAINT HD_PPTT_C CHECK (PhuongThucThanhToan IN (N'Tiền mặt', N'Ví điện tử', N'Paypal')),
    DonGiaBan         FLOAT		(53)  CONSTRAINT HD_DGB_NN  NOT NULL,   
    KhuyenMai         CHAR		(53)  CONSTRAINT HD_KM_NN  NOT NULL,
    ThanhTien         FLOAT		(53)  CONSTRAINT HD_TT_NN  NOT NULL,
)
GO 

CREATE TABLE CHI_TIET_HOA_DON (
	MaHoaDon          CHAR		(50)  CONSTRAINT CTHD_MHD_PK FOREIGN KEY (MaHoaDon) REFERENCES HOA_DON (MaHoaDon),
	MaKhachHang       CHAR		(20)  CONSTRAINT CTHD_MKH_FK FOREIGN KEY (MaKhachHang) REFERENCES KHACH_HANG (MaKhachHang),
    MaNhanVien		  CHAR		(20)  CONSTRAINT CTHD_MNV_FK FOREIGN KEY (MaNhanVien) REFERENCES NHAN_VIEN (MaNhanVien) ,
	SoLuong			  FLOAT		(53)  CONSTRAINT CTHD_SL_NN  NOT NULL,
	Size			  CHAR		(53)  CONSTRAINT MH_SIZE_NN NOT NULL,
    NgayThanhToan	  DATE		      CONSTRAINT CTHD_NTT_NN    NOT NULL,
	DanhGia           NVARCHAR	(2000) CONSTRAINT CTHD_DG_N NULL
	PRIMARY KEY (MaHoaDon)
)
GO

create table CHI_TIET_MAT_HANG (
	MaGiay		CHAR		(20)  CONSTRAINT CTMH_MG_FK FOREIGN KEY  (MaGiay) REFERENCES MAT_HANG (MaGiay), 
	DonGiaNhap	FLOAT	    (53)  CONSTRAINT CTMH_DGN_NN NOT NULL,
	ChatLieu	NVARCHAR	(1000)  CONSTRAINT CTMH_CL_NN NOT NULL,
	BaoHanh		NVARCHAR	(50)  CONSTRAINT CTMH_BH_NN NOT NULL,
	DieuKien    CHAR		(4)   CONSTRAINT CTMH_DK_NN NOT NULL,
    GhiChu      NVARCHAR	(2000) CONSTRAINT CTMH_GC_N NULL
	PRIMARY KEY(MaGiay)
)
GO

create table KY_GUI (
	MaGiay			CHAR		(20)  CONSTRAINT KG_MG_FK FOREIGN KEY  (MaGiay) REFERENCES MAT_HANG (MaGiay),
	MaKhachHang		CHAR		(20)  CONSTRAINT KG_MKH_FK FOREIGN KEY (MaKhachHang) REFERENCES KHACH_HANG (MaKhachHang),
	MaNhanVien		CHAR		(20)  CONSTRAINT KG_MNV_FK FOREIGN KEY (MaNhanVien) REFERENCES NHAN_VIEN (MaNhanVien),
	NgayKyGui		DATE			  CONSTRAINT KG_NKG_NN NOT NULL,	
	ThoiGianGui		NVARCHAR	(20)  CONSTRAINT KG_TGG_NN NOT NULL,
	PhiKyGui		FLOAT		(53)  CONSTRAINT KG_PKG_NN  NOT NULL,
	DonGiaNhap		FLOAT		(53)  CONSTRAINT KG_DONGN_NN NOT NULL,
	PRIMARY KEY(MaGiay, MaKhachHang, MaNhanVien)
)
GO 

create table GIO_HANG (
	MaGioHang		CHAR		(50)  CONSTRAINT GH_MGH_PK PRIMARY KEY,
	MaGiay			CHAR		(20)  CONSTRAINT GH_MG_FK FOREIGN KEY  (MaGiay) REFERENCES MAT_HANG (MaGiay),
	MaKhachHang		CHAR		(20)  CONSTRAINT GH_MKH_FK FOREIGN KEY (MaKhachHang) REFERENCES KHACH_HANG (MaKhachHang),
	SoLuongDat		FLOAT		(53)  CONSTRAINT GH_SLD_NN  NOT NULL,
	SizeDat			CHAR		(53)    CONSTRAINT GH_SIZE_NN NOT NULL,
	SoLuongMatHang	FLOAT		(53)	CONSTRAINT	GH_SLMH_NN NOT NULL,
	SizeMatHang		CHAR		(53)    CONSTRAINT GH_SMH_NN NOT NULL
)
GO

create table DANH_SACH_KY_GUI_CHO (
	MaKhachHang		CHAR		(20)  CONSTRAINT DSKGC_MKH_FK FOREIGN KEY (MaKhachHang) REFERENCES KHACH_HANG (MaKhachHang),
	TenGiay    NVARCHAR		(50)	CONSTRAINT DSKGC_TENG_NN NOT NULL,
    Anh1       VARBINARY	(MAX)	CONSTRAINT DSKGC_A_NN NOT NULL,
	Anh2       VARBINARY	(MAX)	CONSTRAINT DSKGC_A_NN NOT NULL,
	Anh3       VARBINARY	(MAX)	CONSTRAINT DSKGC_A_NN NOT NULL,
	Anh4       VARBINARY	(MAX)	CONSTRAINT DSKGC_A_NN NOT NULL,
	SoLuong    FLOAT		(53)    CONSTRAINT DSKGC_SL_NN NOT NULL,
    MauSac     NVARCHAR		(50)	CONSTRAINT DSKGC_MS_NN NOT NULL,
    Size       CHAR			(53)    CONSTRAINT DSKGC_SIZE_NN NOT NULL,
	ChatLieu   NVARCHAR	(1000)  CONSTRAINT DSKGC_CL_NN NOT NULL,
	BaoHanh		NVARCHAR	(50)  CONSTRAINT DSKGC_BH_NN NOT NULL,
	DieuKien    CHAR		(4)   CONSTRAINT DSKGC_DK_NN NOT NULL,
    GhiChu      NVARCHAR	(2000) CONSTRAINT DSKGC_GC_N NULL,
	NgayKyGui		DATE			  CONSTRAINT DSKGC_NKG_NN NOT NULL,	
	ThoiGianGui		NVARCHAR	(20)  CONSTRAINT DSKGC_TGG_NN NOT NULL,
	PhiKyGui		FLOAT		(53)  CONSTRAINT DSKGC_PKG_NN  NOT NULL,
	DonGiaNhap FLOAT		(53)    CONSTRAINT DSKGC_DONGB_NN NOT NULL,
	PRIMARY KEY(MaKhachHang)
)
GO

create table DANH_SACH_HOA_DON_CHO (
	MaHoaDon          CHAR		(50)  CONSTRAINT DSHDC_MHD_PK PRIMARY KEY,
	MaKhachHang       CHAR		(20)  CONSTRAINT DSHDC_MKH_FK FOREIGN KEY (MaKhachHang) REFERENCES KHACH_HANG (MaKhachHang),
	MaGiay			  CHAR		(20)  CONSTRAINT DSHDC_MG_FK  FOREIGN KEY  (MaGiay) REFERENCES MAT_HANG (MaGiay),
	MaKhuyenMai		  CHAR		(20)  CONSTRAINT DSHDC_MKM_N  NULL,
	PhuongThucThanhToan		NCHAR	(20)  CONSTRAINT DSHDC_PPTT_C CHECK (PhuongThucThanhToan IN (N'Tiền mặt', N'Ví điện tử', N'Paypal')),
    DonGiaBan         FLOAT		(53)  CONSTRAINT DSHDC_DGB_NN NOT NULL,   
    KhuyenMai         CHAR		(53)  CONSTRAINT DSHDC_KM_NN  NOT NULL,
    ThanhTien         FLOAT		(53)  CONSTRAINT DSHDC_TT_NN  NOT NULL,
	SoLuong			  FLOAT		(53)  CONSTRAINT DSHDC_SL_NN  NOT NULL,
	Size			  CHAR		(53)  CONSTRAINT DSHDC_SIZE_NN NOT NULL,
    NgayThanhToan	  DATE		      CONSTRAINT DSHDC_NTT_NN  NOT NULL
)
GO

CREATE TABLE PAYPAL (
	MaTaiKhoan		CHAR		(10)  CONSTRAINT PP_MTK_PK PRIMARY KEY,
	MaKhachHang		CHAR		(20)  CONSTRAINT PP_MKH_FK FOREIGN KEY (MaKhachHang) REFERENCES KHACH_HANG (MaKhachHang),
	Tien			FLOAT		(53)  CONSTRAINT PP_T_NN NOT NULL,
	MaBaoMat		CHAR		(5)	  CONSTRAINT PP_MBM_NN NOT NULL
)
GO


INSERT INTO KHACH_HANG (MaKhachHang, TenKhachHang, SoDienThoai, DiaChi, NgaySinh, GioiTinh, TaiKhoan, MatKhau,GhiChu,TienVDT,MaBaoMat) values
('4601104001', N'Phạm Vương Nghĩa', '0394199177', N'97 Ngô Thì Nhậm', '2002/10/25', 'NAM', 'vuongnghia118', 'nghia624','FALSE','1000000','6762'),
('4601104002', N'Cao Việt Thắng', '0909161872', N'64 Tân Hiệp', '2002/09/05', 'NAM', 'vthang59', 'thejohan39','FALSE','0','0000'),
('4601104003', N'Lê Anh Trí', '0982644024', N'11 Cù Chính Lan', '2002/08/25', 'NAM', 'handsomeboy1', 'trinothandsome1','FALSE','3000000','3733'),
('4601104004', N'Nguyễn Thị Thuỳ Linh', '0359391742', N'Đồng Nai', '2002/10/20', N'NỮ', 'thuylinh093', 'linh373','FALSE','0','0000'),
('4601104005', N'Nguyễn Ngọc Trâm', '0395768799', N'Tân Sơn Nhì', '2002/12/18', N'NỮ', 'ngoctram188', 'tramqq66','FALSE','7500000','1883'),
('4601104006',N'Phan Minh Nhật','0987663521','TP.HCM','1997/11/12','Nam', 'minhnhat014', 'nhatxautrai22','FALSE','8700000','2196'),
('4601104007',N'Trần Minh Đức','0785623130',N'Ninh Bình','1999/10/24','Nam', 'minhduc315', 'ducminh5463','FALSE','0','0000'),
('4601104008',N'Nguyễn Thị Thùy Trang','0565637753',N'Bình Dương','2001/09/08',N'Nữ', 'thuytrang714', 'trangs837','FALSE','5000000','1002'),
('4601104009',N'Trần Thị Tuyết Nhi','0797341681', 'TP.HCM','2003/06/16',N'Nữ', 'tuyetnhi892', 'nhidd934','FALSE','9000000','9863'),
('4601104010',N'Vũ Thị Quỳnh Anh','0986432412',N'Biên Hòa','2000/11/11',N'Nữ', 'quynhanh431', 'quynha764','FALSE','0','0000'),
('4601104000', N'Nguyễn Admin', '0000000000', N'TP.HCM', '01/01/2002', 'NAM', 'adminCTQM', '123456', 'FALSE','0','0000')
GO

INSERT INTO NHAN_VIEN (MaNhanVien,TenNhanVien, SoDienThoai, DiaChi, NgaySinh, GioiTinh) VALUES
('NV104195',N'Lê Anh Trí', '0374882766', N'27 Tân Sân Nhì,Quận Tân Phú, TP.HCM', '2003/03/03', 'Nam'),
('NV104165',N'Vịt Thén','0978365261', N'16 Lê Liễu, Quận 5, TP.HCM', '2002/09/09', 'Nam'),
('NV104188',N'Senpai Phạm', '0782354262', N'117 Lãng Binh Thăng, Quận 11, TP.HCM', '2001/02/02', 'Nam'),
('NV104181',N'Nguyễn Ngọc Minh', '0359731542', N'14 Tân Sân Nhì, Quận Tân Phú, TP.HCM','2002/01/01', N'Nữ'),
('NV104093',N'Nguyễn Thị Thùy Lynh', '0783762651', N'271 Lạc Long Quân, Quận 11,TP.HCM', '2000/05/03', N'Nữ')
GO

INSERT INTO MAT_HANG(MaGiay,TenGiay,Anh1,Anh2,Anh3,Anh4,Loai, SoLuong,MauSac,Size,DonGiaBan) VALUES 
('JD_RHOHR_G/W_O_1','AIR JORDAN 1 RETRO HIGH OG HYPER ROYAL',(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\AIR JORDAN 1 RETRO HIGH OG HYPER ROYAL\1.PNG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\AIR JORDAN 1 RETRO HIGH OG HYPER ROYAL\2.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\AIR JORDAN 1 RETRO HIGH OG HYPER ROYAL\3.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\AIR JORDAN 1 RETRO HIGH OG HYPER ROYAL\4.JPG', SINGLE_BLOB) AS T1),'OLD','1','Hyper Royal/Light Smoke Grey/White','41','7000000'),
('VANS_CLASSIC_B_O_1','Vans Classic SK8-HI Black',(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Vans Classic SK8-HI Black\1.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Vans Classic SK8-HI Black\2.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Vans Classic SK8-HI Black\3.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Vans Classic SK8-HI Black\4.JPG', SINGLE_BLOB) AS T1),'OLD','1','Black','39','1200000'),
('JD_RHOT_B_O_1','Wmns Air Jordan 1 Retro High OG ',(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Wmns Air Jordan 1 Retro High OG Twist\1.PNG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Wmns Air Jordan 1 Retro High OG Twist\2.JPEG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Wmns Air Jordan 1 Retro High OG Twist\3.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Wmns Air Jordan 1 Retro High OG Twist\4.JPG', SINGLE_BLOB) AS T1),'OLD','1','BLACK','42','8000000'),
('AYB_V2LFL_O_O_1','Adidas Yeezy Boost 350 V2 Linen FY5158 /Linen ',(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Adidas Yeezy Boost 350 V2 Linen FY5158\1.PNG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Adidas Yeezy Boost 350 V2 Linen FY5158\2.PNG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Adidas Yeezy Boost 350 V2 Linen FY5158\3.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Adidas Yeezy Boost 350 V2 Linen FY5158\4.JPG', SINGLE_BLOB) AS T1),'OLD','1','ORANGE','40','3000000'),
('NIKE_AF1_W_O_1','Nike Air Force 1 07',(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Nike Air Force 1 07\1.PNG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Nike Air Force 1 07\2.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Nike Air Force 1 07\3.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Nike Air Force 1 07\5.JPG', SINGLE_BLOB) AS T1),'OLD','1','WHITE','39','3000000'),
('NIKE_AJ1SB_WBPG_N_2','Nike Air Jordan 1 Mid “South Beach”',(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Nike Air Jordan 1 Mid “South Beach”\1.PNG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Nike Air Jordan 1 Mid “South Beach”\2.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Nike Air Jordan 1 Mid “South Beach”\4.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Nike Air Jordan 1 Mid “South Beach”\5.JPG', SINGLE_BLOB) AS T1),'NEW','50','WHITE/BLACK-PINK-GREEN','34-44','5000000'),
('JD_1MSE_W/LSG/PG_N_3','Air Jordan 1 Mid SE',(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Air Jordan 1 Mid SE\1.JPG' ,SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Air Jordan 1 Mid SE\2.JPG' ,SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Air Jordan 1 Mid SE\3.JPG' ,SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Air Jordan 1 Mid SE\4.JPG' ,SINGLE_BLOB) AS T1),'NEW','50','White/Light Smoke Grey/Pine Green','34-44','4000000'),
('VANS_OSRS_G_N_3','VANS OLD SKOOL RETRO SPORT SEASPRAY GREEN',(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\VANS OLD SKOOL RETRO SPORT SEASPRAY GREEN\1.PNG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\VANS OLD SKOOL RETRO SPORT SEASPRAY GREEN\2.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\VANS OLD SKOOL RETRO SPORT SEASPRAY GREEN\3.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\VANS OLD SKOOL RETRO SPORT SEASPRAY GREEN\4.JPEG', SINGLE_BLOB) AS T1),'NEW','50','GREEN','35-44','1700000'),
('AD_4DR_CW_N_5','Adidas 4D Run 1.0 "Cloud White"',(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Adidas 4d Run 1.0 Cloud White\1.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Adidas 4d Run 1.0 Cloud White\2.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Adidas 4d Run 1.0 Cloud White\3.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\Adidas 4d Run 1.0 Cloud White\4.PNG', SINGLE_BLOB) AS T1),'NEW','50','Cloud-White','40-44','7500000'),
('JD_4R_CG/W_N_4','KAWS X AIR JORDAN 4 RETRO COOL GREY',(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\KAWS X AIR JORDAN 4 RETRO COOL GREY\1.PNG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\KAWS X AIR JORDAN 4 RETRO COOL GREY\2.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\KAWS X AIR JORDAN 4 RETRO COOL GREY\3.JPG', SINGLE_BLOB) AS T1),(SELECT * FROM OPENROWSET (BULK N'D:\anh\ảnh\KAWS X AIR JORDAN 4 RETRO COOL GREY\4.JPG', SINGLE_BLOB) AS T1),'NEW','2','COOL GREY/WHITE','38-44','67912355')
GO

INSERT INTO HOA_DON(MaHoaDon,MaGiay,MaKhuyenMai, PhuongThucThanhToan, DonGiaBan,KhuyenMai,ThanhTien) VALUES
('HD0609007_JD_1MSE_W/LSG/PG_N_3_43_1','JD_1MSE_W/LSG/PG_N_3','KM10_2011', N'Tiền mặt','4000000','10%','3600000'),
('HD3012006_AD_4DR_CW_N_5_40_1','AD_4DR_CW_N_5', null, N'Ví điện tử','7500000','0%','7500000'),
('HD1411008_AD_4DR_CW_N_5_39_1','AD_4DR_CW_N_5','KM30_0509', N'Tiền mặt','7500000','30%','5250000'),
('HD1602009_VANS_OSRS_G_N_3_37_1','VANS_OSRS_G_N_3','KM10_0101', N'Paypal','1700000','10%','1530000'),
('HD1811010_JD_4R_CG/W_N_4_45_1','JD_4R_CG/W_N_4',null, N'Ví điện tử','67912355','0%','67912355')
GO

INSERT INTO CHI_TIET_HOA_DON (MaHoaDon,MaKhachHang,MaNhanVien,SoLuong,Size,NgayThanhToan,DanhGia) VALUES
('HD0609007_JD_1MSE_W/LSG/PG_N_3_43_1','4601104007','NV104181','1','43','2020/09/06','GOOD'),
('HD3012006_AD_4DR_CW_N_5_40_1','4601104006','NV104188','1','40','2020/12/30','GOOD'),
('HD1411008_AD_4DR_CW_N_5_39_1','4601104008','NV104093','1','39','2021/11/14','BAD'),
('HD1602009_VANS_OSRS_G_N_3_37_1','4601104009','NV104165','1','37','2020/02/16','GOOD'),
('HD1811010_JD_4R_CG/W_N_4_45_1','4601104010','NV104165','1','45','2021/11/18','GOOD')
GO

INSERT INTO CHI_TIET_MAT_HANG (MaGiay, DonGiaNhap, ChatLieu, BaoHanh, DieuKien, GhiChu) VALUES
('JD_RHOHR_G/W_O_1', '4000000', N'Da cao cấp', N'12 tháng', '99%', N'Air Jordan 1 Retro High OG ‘Hyper Royal’ mang tính thẩm mỹ thời tiết, nổi bật bởi phần trên bằng da trắng với lớp phủ da lộn màu xanh nhạt. Các điểm nhấn màu xám trung tính tương phản đổ bộ vào Swoosh và cổ áo đệm, bổ sung vào bảng màu tinh tế của giày thể thao.'),
('VANS_CLASSIC_B_O_1', '900000', N'Da cao cấp', N'12 tháng', '99%', N'Giày Thể Thao Vans Classic Sk8-Hi Black màu sắc trắng dễ dàng kết hợp với nhiều trang phục khác nhau theo sở thích bản thân tạo nên 1 set đồ đẹp khi đi chơi, đi học hay dạo phố.'),
('JD_RHOT_B_O_1', '5000000', N'Da cao cấp', N'12 tháng', '99%', N'Wmns Air Jordan 1 Retro High OG là một biểu tượng hiện đại của biểu tượng năm 1985 với các yếu tố được cải tiến và chức năng cổ điển. Ra mắt vào tháng 5 năm 2019, phiên bản dành cho nữ "Twist" này có tính thẩm mỹ sang trọng với các tấm lông ngựa tổng hợp và các chi tiết của Swooshes với chi tiết bằng da lộn phía trên.'),
('AYB_V2LFL_O_O_1', '3000000', N'Vải cao dấp', N'12 tháng', '99%', N'Yeezy Boost 350 V2 “Desert Sage” là một phối màu siêu đeo khác của hình bóng đặc trưng phổ biến của Kanye West. Vừa hỗ trợ vừa thoáng khí, phần trên Primeknit có sọc phản chiếu từ gót chân đến ngón chân, tỏa sáng khi tiếp xúc với ánh sáng.'),
('NIKE_AF1_W_O_1', '1500000', N'Da cao dấp', N'12 tháng', '99%', N'Sự rạng rỡ còn tồn tại trong Nike Air Force 1 "07, quả bóng b-ball OG mang đến sự thay đổi mới mẻ về những gì bạn biết rõ nhất: các lớp phủ được khấu đẹp, kết thúc sạch sẽ và lượng đèn flash hoàn hảo để khiến bạn tỏa sáng.'),
('JD_1MSE_W/LSG/PG_N_3','3200000', N'Da lộn cao cấp', N'12 tháng', '100%', N'Air Jordan 1 Mid SE South Beach là phối màu AJ1 mới nhất được Nike và Jordan Brand ra mắt với thiết kế ngay lập tức gây ấn tượng từ cái nhìn đầu tiên. Lối phối màu vẫn được giữ nguyên vẹn với Black Toe, logo Swoosh màu đỏ nổi bật cùng với Jumpman quen thuộc. Chất liệu da Tumble leather có độ mềm cao hơn, được phủ bóng bằng lớp chống bụi bẩn và chống nước nên việc vệ sinh cũng tương đối dễ dàng. Hệ thống đế đệm Air cũng được nâng cấp mềm mại hơn so với phiên bản gốc.'),
('NIKE_AJ1SB_WBPG_N_2', '2400000', N'Da thật cao cấp', N'12 tháng', '100%', N'Tiếp tục phong cách của bạn trong Chuyến bay với Air Jordan 1 Mid, đôi giày thể thao của những khả năng vô tận. Mới mẻ hơn bao giờ hết, phiên bản đặc biệt này của đôi giày đế giữa nổi tiếng mang đến sự thoải mái không ngừng cho bất kỳ ai không thể cảm nhận đủ phong cách cổ điển của di sản.'),
('VANS_OSRS_G_N_3', '1300000', N'Da lộn cao cấp', N'12 tháng', '100%', N'VANS OLD SKOOL STYLE 36 Là trong 1 trong 2 thiết kế được VANS lựa chọn trong BST lần này, OLD SKOOL được khoác lên mình 1 vẻ ngoài hết sức bắt mắt. Logo OFF THE WALL được thể hiện độc đáo với phong cách all over print thời thường cùng với phối màu tím hết sức ấn tượng. Được biết logo này là thông điệp mà VANS luôn muốn truyền tải đến những bạn trẻ với tinh thần dám nghĩ dám làm, luôn sáng tạo và bức phá. Các chi tiết trên đôi gìay được chăm chút, sử dụng cùng màu mới tông màu chủ đạo khiến cho đôi giày trở nên hoàn thiện hơn như : dây giày, khoen xỏ dây, đường chỉ cao su chạy quanh đế giày,.. Đôi giày vẫn được sử dụng những chất liệu giống như những phối màu OLD SKOOL trước đây như da lộn, da bóng cũng như là vải canvas, sự phối hợp đa chất liệu này đem lại sự cao cấp, nâng cao sự bền bỉ thêm cho đôi giày.'),
('AD_4DR_CW_N_5', '6000000', N'Nhựa cao cấp', N'12 tháng', '100%', N'Giày Sneaker Nam Adidas 4D Run 1.0 "Cloud White". Hàng nghìn vận động viên. Nhiều năm trời thu thập dữ liệu. adidas 4D chính là công nghệ cho tương lai. Đế giữa in kỹ thuật số không chỉ mang vẻ ngoài tân tiến, từng mảng lưới làm bằng nhựa lỏng cho cảm giác độc đáo dưới chân. Phom giày được chế tác bằng ánh sáng và hoàn thiện bằng nhiệt. Tất cả tạo nên một đôi giày chạy bộ với thiết kế riêng thúc đẩy bạn tiến lên phía trước. Kết hợp hài hòa giữa cũ và mới, đôi giày này cùng bạn xuống phố với tinh thần hướng tới tương lai.'),
('JD_4R_CG/W_N_4', '60500000', N'Da lộn cao cấp', N'12 tháng', '100%', N'KAWSx Air Jordan 4 Retro là sự hợp tác giữa nghệ sĩ đường phố Brooklyn KAWS, hay còn gọi là Brian Donnelly, và Jordan Brand. Thiết kế loại bỏ các điểm nhấn bằng nhựa truyền thống của hình bóng và trang phục bằng da lộn màu xám cao cấp trên toàn bộ upper và midsole. Đôi giày thể thao này cũng có nhãn hiệu KAWS "XX" trên tab gót. Đôi giày được phát hành vào tháng 3 năm 2017 cùng với một bộ sưu tập nhỏ bao gồm áo khoác, áo hoodie, áo thun và mũ. Sự cường điệu cho bản phát hành này dữ dội đến mức cảnh sát đọc được cảnh bạo động tại quầy xổ số trong cửa hàng ở Patta ở London và các sneakerhead đã đột nhập vào trang web của Donnelly để có cơ hội.')
go

INSERT INTO KY_GUI (MaGiay,MaKhachHang,MaNhanVien,NgayKyGui,ThoiGianGui,PhiKyGui,DonGiaNhap) VALUES
('JD_RHOHR_G/W_O_1','4601104004','NV104181','2021-10-30',N'3 Tháng','90000','4000000'),
('JD_RHOT_B_O_1','4601104005','NV104195','2021-09-21',N'4 tháng','120000','5000000'),
('AYB_V2LFL_O_O_1','4601104002','NV104195','2021-11-01',N'3 tháng','90000','3000000'),
('VANS_CLASSIC_B_O_1','4601104007','NV104165','2021-11-11',N'1 tháng','30000','900000'),
('NIKE_AF1_W_O_1','4601104010','NV104188','2021-07-03',N'2 tháng','60000','1500000')
go

INSERT INTO PAYPAL (MaTaiKhoan,MaKhachHang,Tien,MaBaoMat) VALUES
('9430376001','4601104001','15000000','4546'),
('9419363112','4601104002','25000000','6362'),
('9472410348','4601104003','30000000','3224'),
('9431358400','4601104004','40000000','4421'),
('9401158317','4601104005','35000000','8832'),
('9400924165','4601104006','90000000','7529'),
('9410234815','4601104007','48000000','9232'),
('9404733484','4601104008','55000000','9273'),
('9494620056','4601104009','86000000','1436'),
('9402138671','4601104010','87000000','9726')
GO