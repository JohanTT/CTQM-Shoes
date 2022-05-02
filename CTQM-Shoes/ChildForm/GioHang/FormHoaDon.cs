using SHOESBUS;
using SHOESDAL;
using SHOESDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTQM_Shoes.ChildForm
{
    public partial class FormHoaDon : Form
    {
        public FormHoaDon()
        {
            InitializeComponent();
        }
        long TongTien1 = new int(); // tính tiền thôi :3
        long TongTien2 = new int();
        long TongTien3 = new int();
        string _MaHoaDon = "";

        public string MaKhachHangHD { get; set; }
        public string MaKhuyenMaiHD { get; set; }
        public int GiamHD { get; set; }
        public string PhuongThucThanhToan { get; set; }

        private void TrongGioHang(string mkh) // cũng là lấy danh sách từ giỏ hàng nhưng mà khác tên
        {
            string soKH = MaKhachHangHD[7].ToString() + MaKhachHangHD[8].ToString() + MaKhachHangHD[9].ToString();
            Shoes2DataContext db = new Shoes2DataContext();
            DSGHpn.Controls.Clear();
            HoaDonControl[] listHD = new HoaDonControl[100]; // và khác cái control
            List<GioHangDTO> listGH = new List<GioHangDTO>();
            GioHangBUS.LayDSThanhToanFrom(listGH, mkh);
            for (int j = 0; j < listGH.Count; j++) { 
                listHD[j] = new HoaDonControl();
                listHD[j].MaHoaDon = "HD" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + soKH.Trim() + 
                    "_" + listGH[j].MaGiay.Trim() + "_" + listGH[j].SizeDat.Trim() + "_" + listGH[j].SoLuongDat.ToString().Trim();
                listHD[j].MaGioHang = listGH[j].MaGioHang;
                listHD[j].MaGiay = listGH[j].MaGiay;
                listHD[j].TenGiay = listGH[j].TenGiay;
                listHD[j].DonGiaMua = listGH[j].DonGiaBan;
                listHD[j].SoLuongMua = listGH[j].SoLuongDat;
                listHD[j].SizeMua = listGH[j].SizeDat;
                listHD[j].KhuyenMai = GiamHD;
                TongTien1 += listGH[j].DonGiaBan * listGH[j].SoLuongDat;
                TenKHlb.Text = listGH[j].TenKhachHang;
                SDTlb.Text = listGH[j].SoDienThoai;
                DiaChilb.Text = listGH[j].DiaChi;
                DSGHpn.Controls.Add(listHD[j]);
            }
        }

        private void FormHoaDon_Load(object sender, EventArgs e) // cũng là load dữ liệu lên form nưhng mà nó dài hơn và nhiều
        {
            TrongGioHang(MaKhachHangHD);
            TT1.Text = TongTien1.ToString();
            if (GiamHD != 0) TongTien2 = (TongTien1 * GiamHD) / 100;
            TT2.Text = TongTien2.ToString();
            TongTien3 = TongTien1 - TongTien2;
            TT3.Text = TongTien3.ToString();
            NgayThanhToan.Text = DateTime.Now.ToString();
            TTbtn.Text += " - " + TongTien3.ToString();
            string soKH = MaKhachHangHD[7].ToString() + MaKhachHangHD[8].ToString() + MaKhachHangHD[9].ToString();
            _MaHoaDon = "HD" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + soKH;
            MaHoaDonlb.Text = _MaHoaDon;
            PTTTpn.Text = PhuongThucThanhToan;
            if (MaKhuyenMaiHD != null)
            {
                MaKM.Text = MaKhuyenMaiHD;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e) // đóng form
        {
            this.Close();
        }

        private void TTbtn_Click(object sender, EventArgs e)
        {
            string Hoadontxt = 
               "----------CTQM STORE BILL----------\r\n" +
               "|Mã hoá đơn: " + _MaHoaDon + "     Ngày thanh toán: " + NgayThanhToan.Text + "\r\n" +
               "|Tên khách hàng: " + TenKHlb.Text + "\r\n" +
               "|Số điện thoại: " + SDTlb.Text + "\r\n" +
               "|Địa chỉ: " + DiaChilb.Text + "\r\n" +
               "|Mã khuyến mãi: " + MaKhuyenMaiHD + "\r\n" +
               "-----------------------------------\r\n" +
               "Số lượng \t Tên giày \t Đơn giá \t Giảm giá \t Tổng tiền \r\n";
            foreach (var tt in DSGHpn.Controls)
            {
                int dem = 1;
                if (tt.GetType() == typeof(HoaDonControl))
                {
                    Hoadontxt += "Sản phẩm " + dem.ToString() + ": \r\n";
                    Hoadontxt += "Mã sản phẩm mua: " + ((HoaDonControl)tt).MaHoaDon + "\r\n";
                    Hoadontxt += ((HoaDonControl)tt).SoLuongMua.ToString() + "\t" +
                        ((HoaDonControl)tt).TenGiay + "\t" +
                        ((HoaDonControl)tt).DonGiaMua.ToString() + "\t\t" +
                        GiamHD.ToString() + "\t" +
                        ((HoaDonControl)tt).TongMua.ToString() + "\r\n";
                    GioHangBUS.XoaKhoiGioHang(((HoaDonControl)tt).MaGioHang); // Xoá sản phẩm đó khỏi giỏ hàng
                    MatHangBUS.GiamSoLuongMatHang(((HoaDonControl)tt).MaGiay); // giảm số lượng của sản phẩm đã mua
                    HoaDon hd = new HoaDon
                    {
                        MaHoaDon = ((HoaDonControl)tt).MaHoaDon,
                        MaKhachHang = MaKhachHangHD,
                        MaGiay = ((HoaDonControl)tt).MaGiay,
                        MaKhuyenMai = MaKhuyenMaiHD,
                        DonGiaBan = ((HoaDonControl)tt).DonGiaMua,
                        KhuyenMai = GiamHD.ToString(),
                        ThanhTien = ((HoaDonControl)tt).TongMua,
                        SoLuong = ((HoaDonControl)tt).SoLuongMua,
                        Size = ((HoaDonControl)tt).SizeMua,
                        NgayThanhToan = DateTime.Now,
                        PhuongThucThanhToan = PhuongThucThanhToan
                    };
                    HoaDonBUS.ThemVaoHoaDonCho(hd);
                    dem++;
                }
            }

            Hoadontxt +=
                "-----------------------------------\r\n" +
                "Tổng tiền giày: " + TT1.Text + "\r\n" +
                "Tổng tiền khuyến mãi: " + TT2.Text + "\r\n" +
                "Cần thanh toán: " + TT3.Text + "\r\n" +
                "Phương thức thanh toán: " + PhuongThucThanhToan + "\r\n";
            string HDtexttmp = _MaHoaDon + ".txt";
            if (!File.Exists(HDtexttmp))
            {
                StreamWriter HDtext = new StreamWriter(HDtexttmp);
                HDtext.Write(Hoadontxt);
                HDtext.Close();
            }
            // giảm tiền sau khi thanh toán
            if (PhuongThucThanhToan.Trim() == "Ví điện tử")
            {
                KhachHangBUS.GiamTienVDT(MaKhachHangHD, TongTien3);
            }
            else if (PhuongThucThanhToan.Trim() == "Paypal")
            {
                KhachHangBUS.GiamTienPayPal(MaKhachHangHD, TongTien3);
            }
            this.Close();
        }
    }
}
