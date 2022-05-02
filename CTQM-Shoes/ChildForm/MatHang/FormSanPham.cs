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
    public partial class FormSanPham : Form
    {
        public FormSanPham()
        {
            InitializeComponent();
            LoadTheme();
        }

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

        private string _MaKhachHang; // tạo mã khách hàng đễ làm việc khi người dùng mua hàng
        public string MaKhachHangSP
        {
            get { return _MaKhachHang; }
            set { _MaKhachHang = value; }
        }
        
        private void LayDSMatHang() // lấy danh sách mặt hàng từ sql
        {
            Shoes2DataContext db = new Shoes2DataContext();
            DSMatHangfl.Controls.Clear();
            MatHangControl[] listMHC = new MatHangControl[100]; // tạo controlform để dễ dàng ứng phó với nhiều sp
            List<MatHang> listMH = MatHangBUS.LayDSMatHangForm();
            for (int j = 0; j < listMH.Count; j++)
            {
                listMHC[j] = new MatHangControl();
                listMHC[j].MaGiay = listMH[j].MaGiay;
                listMHC[j].TenGiay = listMH[j].TenGiay;
                listMHC[j].TienGiay = listMH[j].DonGiaBan.ToString();
                listMHC[j].ChatLieu = listMH[j].ChatLieu;
                listMHC[j].BaoHanh = listMH[j].BaoHanh;
                listMHC[j].HinhGiay = listMH[j].Anh1;
                listMHC[j].Loai = listMH[j].Loai;
                listMHC[j].XemGiay += new EventHandler(this.LoadMatHangChiTiet); // thêm event để khi nhấp vào mở chi tiết của mặt hàng đó
                DSMatHangfl.Controls.Add(listMHC[j]);
            }
        }

        private void LoadMatHangChiTiet(object sender, EventArgs e)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            ChiTietMatHang ctmh = new ChiTietMatHang(); // tạo form chi tiết mặt hàng
            MatHangControl tmp = (MatHangControl)sender; // lấy thông tin từ thằng MatHangControl vừa mới tương tác
            MatHang MH = MatHangBUS.LayDSMatHangChiTietForm(tmp.MaGiay);
            // Truyền giá trị
            ctmh.MaGiay = MH.MaGiay;
            ctmh.MaKhachHang = MaKhachHangSP;
            ctmh.TenGiay = MH.TenGiay;
            ctmh.TienGiay = MH.DonGiaBan.ToString();
            ctmh.SizeG = MH.Size;
            ctmh.MauSac = MH.MauSac;
            ctmh.GhiChu = MH.GhiChu;
            ctmh.ChatLieu = MH.ChatLieu;
            ctmh.BaoHanh = MH.BaoHanh;
            ctmh.SLMH = (int)MH.SoLuong;
            ctmh[0] = MH.Anh1;
            ctmh[1] = MH.Anh2;
            ctmh[2] = MH.Anh3;
            ctmh[3] = MH.Anh4;
            ctmh.Quaylaiclick += new EventHandler(ShowDSMatHang);
            // Mở form
            DSMatHangfl.Hide();
            ChiTietMatHangpn.Show();
            ctmh.TopLevel = false;
            ChiTietMatHangpn.Controls.Add(ctmh);
            ctmh.Dock = DockStyle.Fill;
            ctmh.BringToFront();
            ctmh.Show();
        }

        private void ShowDSMatHang(object sender, EventArgs e)
        {
            ChiTietMatHangpn.Hide();
            DSMatHangfl.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LayDSMatHang();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = RGBColors.color3;
                }
            }
        }
    }
}
