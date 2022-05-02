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
    public partial class FormKyGui : Form
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

        public FormKyGui()
        {
            InitializeComponent();
            LoadTheme();
        }

        Image ByteToImage(byte[] b) // cũng giống như thằng kia để chuyển hình từ bên sql
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }

        public string MaKhachHangKG { get; set; } // lấy mã khách hàng được truyền vào

        private void LayDSKyGui(string mkh)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            KyGuiControl[] listKGC = new KyGuiControl[100];
            List<KyGui> listKG = new List<KyGui>();
            KyGuiBUS.LayDSKyGuiFrom(listKG, mkh);
            if (listKG.Count == 0) OhNolb.Visible = true;
            else
            {
                DSKGfpn.Controls.Clear();
                for (int j = 0; j < listKG.Count; j++)
                {
                    listKGC[j] = new KyGuiControl();
                    listKGC[j].MaGiay = listKG[j].MaGiay;
                    listKGC[j].TenGiay = listKG[j].TenGiay;
                    listKGC[j].DonGia = (long)listKG[j].DonGiaNhap;
                    listKGC[j].Anh1 = listKG[j].Anh1;
                    listKGC[j].ThoiHanGui = listKG[j].ThoiGianKyGui;
                    listKGC[j].Click += new EventHandler(KyGuiThongTin);
                    listKGC[j].XoaKyGui += new EventHandler(FormKiGui_Load);
                    DSKGfpn.Controls.Add(listKGC[j]);
                }
            }
        }

        private void LayDSKyGuiCho(string mkh) // lấy danh sách các sản phẩm của người đó nhưng đang chờ duyệt
        {
            Shoes2DataContext db = new Shoes2DataContext();
            KyGuiControl[] listKGC = new KyGuiControl[100];
            List<KyGui> listKG = new List<KyGui>();
            KyGuiBUS.LayDSKyGuiChoFrom(listKG, mkh);
            if (listKG.Count == 0) OhNolb.Visible = true;
            else
            {
                OhNolb.Visible = false;
                for (int j = 0; j < listKG.Count; j++)
                {
                    listKGC[j] = new KyGuiControl();
                    listKGC[j].TenGiay = listKG[j].TenGiay;
                    listKGC[j].DonGia = (long)listKG[j].DonGiaNhap;
                    listKGC[j].Anh1 = listKG[j].Anh1;
                    listKGC[j].ThoiHanGui = listKG[j].ThoiGianKyGui;
                    listKGC[j].Click += new EventHandler(KyGuiThongTin);
                    listKGC[j].XoaKyGui += new EventHandler(FormKiGui_Load);
                    listKGC[j].BackColor = Color.Gray;
                    DSKGfpn.Controls.Add(listKGC[j]);
                }
            }
        }

        private void KyGuiThongTin(object sender, EventArgs e)
        {
            KyGuiControl tmp = (KyGuiControl)sender;
            TenGiaylb.Text = tmp.TenGiay;
            DonGIalb.Text = tmp.DonGia.ToString();
            IntroPic.Image = tmp.Anh1;
        }

        private void FormKiGui_Load(object sender, EventArgs e)
        {
            LayDSKyGui(MaKhachHangKG);
            LayDSKyGuiCho(MaKhachHangKG);
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = RGBColors.color2;
                }
            }
        }

        private void ThemSPbtn_Click(object sender, EventArgs e)
        {
            FormThemKyGui formThemKyGui = new FormThemKyGui();
            formThemKyGui.MaKhachHangThemKG = MaKhachHangKG;
            formThemKyGui.Quaylaiclick += new EventHandler(ShowDSKyGui);
            formThemKyGui.TopLevel = false;
            KyGuipn.Controls.Add(formThemKyGui);
            formThemKyGui.Dock = DockStyle.Fill;
            formThemKyGui.BringToFront();
            formThemKyGui.Show();
        }

        private void ShowDSKyGui(object sender, EventArgs e)
        {
            ThemKyGuipn.Hide();
            FormKiGui_Load(sender, e);
        }
    }
}
