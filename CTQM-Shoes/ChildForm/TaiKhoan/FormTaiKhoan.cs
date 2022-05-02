using CTQM_Shoes.ChildForm.GioHang;
using SHOESBUS;
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
    public partial class FormTaiKhoan : Form
    {
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color colorHome = Color.FromArgb(89, 131, 252);
            public static Color colorBase = Color.FromArgb(41, 53, 86);
        }

        public FormTaiKhoan()
        {
            InitializeComponent();
            LoadTheme();
        }
        long TienVDTco;
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = RGBColors.color4;
                }
            }
        }

        public string MaKhachHangTK { get; set; }

        private void LayDSSPDaMua(string mkh) // lấy từ trong tabel giỏ hàng ra giỏ hàng
        {
            Shoes2DataContext db = new Shoes2DataContext();
            SanPhamDaMuaControl[] listGH = new SanPhamDaMuaControl[100]; // tận dụng của giỏ hàng 
            List<HoaDon> listHD = HoaDonBUS.LayDSGiayTuBill(mkh);
            if (listHD.Count == 0) OhNolb.Visible = true;
            else
            {
                Accountfpn.Controls.Clear();
                for (int j = 0; j < listHD.Count; j++) 
                {
                    listGH[j] = new SanPhamDaMuaControl();
                    listGH[j].MaGiay = listHD[j].MaGiay;
                    listGH[j].TienGiay = listHD[j].DonGiaBan.ToString();
                    listGH[j].PTTT = listHD[j].PhuongThucThanhToan;
                    listGH[j].SoLuong = (int)listHD[j].SoLuong;
                    listGH[j].SizeC = listHD[j].Size;
                    listGH[j].Giam = int.Parse(listHD[j].KhuyenMai);
                    Accountfpn.Controls.Add(listGH[j]);
                }
            }
        }

        private void LayDSSPDaMuaDangCho(string mkh)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            SanPhamDaMuaControl[] listGHC = new SanPhamDaMuaControl[100]; // tận dụng của giỏ hàng 
            List<HoaDon> listHD = HoaDonBUS.LayDSGiayTuBillCho(mkh);
            if (listHD.Count == 0) OhNolb.Visible = true;
            else
            {
                OhNolb.Visible = false;
                for (int j = 0; j < listHD.Count; j++)
                {
                    listGHC[j] = new SanPhamDaMuaControl();
                    listGHC[j].MaGiay = listHD[j].MaGiay;
                    listGHC[j].TienGiay = listHD[j].DonGiaBan.ToString();
                    listGHC[j].PTTT = listHD[j].PhuongThucThanhToan;
                    listGHC[j].SoLuong = (int)listHD[j].SoLuong;
                    listGHC[j].SizeC = listHD[j].Size;
                    listGHC[j].Giam = int.Parse(listHD[j].KhuyenMai);
                    listGHC[j].Enabled = false;
                    listGHC[j].BackColor = Color.Gray;
                    Accountfpn.Controls.Add(listGHC[j]);
                }
            }
        }

        private void FormTaiKhoan_Load(object sender, EventArgs e)
        {
            Accountfpn.Controls.Clear();
            PTTTlb.Text = "Ví điện tử: ";
            TienVDTco = KhachHangBUS.LayTienVDT(MaKhachHangTK);
            PTTTlb.Text += TienVDTco.ToString();
            LayDSSPDaMua(MaKhachHangTK);
            LayDSSPDaMuaDangCho(MaKhachHangTK);
        }

        private void TaiKhoanbtn_Click(object sender, EventArgs e) // Mở form để người dùng chỉnh tài khoản
        {
            FormChinhTaiKhoan formChinhTaiKhoan = new FormChinhTaiKhoan();
            formChinhTaiKhoan.MaKhachHangCtk = MaKhachHangTK;
            formChinhTaiKhoan.Show(); 
        }

        private void NapTienbtn_Click(object sender, EventArgs e)
        {
            FormXacNhan formXacNhan = new FormXacNhan();
            formXacNhan.MaKhachHangKT = MaKhachHangTK;
            formXacNhan.loai = 1; // lấy mã bảo mật của ví điện t
            formXacNhan.XacNhan += new EventHandler(XacNhanDung);
            formXacNhan.Show();
        }

        private void XacNhanDung(object sender, EventArgs e)
        {
            FormNapTienVDT formNapTienVDT = new FormNapTienVDT();
            formNapTienVDT.MaKhachHangNT = MaKhachHangTK;
            formNapTienVDT.Xong += new EventHandler(FormTaiKhoan_Load);
            formNapTienVDT.Show();
        }
    }
}
