using CTQM_Shoes.ChildForm;
using CTQM_Shoes.ChildForm.Admin;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTQM_Shoes
{
    public partial class FormMainMenu : Form
    {
        //Khai báo
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private int DemHinh = 1; // đếm số lần hình chạy trên picturebox
        //Khởi tạo
        public FormMainMenu()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            //loại bỏ title bar mặc định
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;//giới hạn kích thước cửa sổ để không chèn vào task bar của desktop
        }

        private void LoadHinhTiepTheo()
        {
            timer1.Start();
            if (DemHinh == 1) panelDesktop.BackgroundImage = Properties.Resources._1;
            if (DemHinh == 2) panelDesktop.BackgroundImage = Properties.Resources._2;
            if (DemHinh == 3) panelDesktop.BackgroundImage = Properties.Resources._3;
            if (DemHinh == 4) panelDesktop.BackgroundImage = Properties.Resources._4;
            LoadChecked();
            DemHinh++;
            if (DemHinh > 4)
            {
                DemHinh = 1;
            }
        }

        private void LoadChecked()
        {
            if (DemHinh == 1) { Rbtn1.Checked = true; }
            else if (DemHinh == 2) { Rbtn2.Checked = true; }
            else if (DemHinh == 3) { Rbtn3.Checked = true; }
            else if (DemHinh == 4) { Rbtn4.Checked = true; }
        }

        //Màu
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(251, 155, 81);
            public static Color color2 = Color.FromArgb(248, 129, 37);
            //public static Color color3 = Color.FromArgb(253, 138, 114);
            //public static Color color4 = Color.FromArgb(95, 77, 221);
            //public static Color color5 = Color.FromArgb(249, 88, 155);
            //public static Color color6 = Color.Aquamarine;
            public static Color colorHome = Color.FromArgb(17, 34, 78);
            public static Color colorBase = Color.FromArgb(26, 59, 112);
        }

        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string MaGiamGia { get; set; }

        //Phương thức
        private void ActiveButton(object senderBtn, Color color) //Button khi nhấp chuột
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button hiện tại
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(44, 89, 157);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Button bên trái
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Icon của Child Form
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void HoverButton(object senderBtn, Color color) //Button khi di chuyển chuột vào vùng button
        {
            if (senderBtn != null)
            {
                //Button hiện tại
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(251, 155, 81);
                currentBtn.ForeColor = color;
                currentBtn.IconColor = color;
                currentBtn.ImageAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void DisableButton() //Bỏ highlight button khi thoát khỏi vùng button
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(17, 34, 78);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = RGBColors.color1;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                //chỉ mở form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        private void iconGiohang_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            FormGioHang gh = new FormGioHang();
            gh.MaKhachHangGH = MaKhachHang;
            MaGiamGia = "KM30_0101"; // Mã khuyến mãi chào mừng năm mới
            gh.MaGiamGiaGH = MaGiamGia;
            OpenChildForm(gh);
            timer1.Stop();
            //btnHome.BackColor = RGBColors.color1;
            //guna2Panel1.BackColor = RGBColors.color1;
        }

        private void iconKigui_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            FormKyGui kg = new FormKyGui();
            kg.MaKhachHangKG = MaKhachHang;
            OpenChildForm(kg);
            timer1.Stop();
            //btnHome.BackColor = RGBColors.color1;
            //guna2Panel1.BackColor = RGBColors.color1;
        }

        private void iconSanpham_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            FormSanPham sp = new FormSanPham();
            sp.MaKhachHangSP = MaKhachHang;
            OpenChildForm(sp);
            timer1.Stop();
            //btnHome.BackColor = RGBColors.color2;
            //guna2Panel1.BackColor = RGBColors.color2;
        }

        private void iconTaikhoan_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color2);
            FormTaiKhoan formtaikhoan = new FormTaiKhoan();
            formtaikhoan.MaKhachHangTK = MaKhachHang;
            OpenChildForm(formtaikhoan);
            timer1.Stop();
            //btnHome.BackColor = RGBColors.color2;
            //guna2Panel1.BackColor = RGBColors.color2;
        }

        private void iconCaidat_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            OpenChildForm(new FormAdmin2());
            timer1.Stop();
            //btnHome.BackColor = RGBColors.color1;
            //guna2Panel1.BackColor = RGBColors.color1;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null) currentChildForm.Close();
            timer1.Start();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = RGBColors.color2;
            lblTitleChildForm.Text = "Trang chủ";
            btnHome.BackColor = Color.FromArgb(248, 129, 37);
            guna2Panel1.BackColor = Color.FromArgb(248, 129, 37);
            //this.Size = new Size(1176, 638);
            //panelTitleBar.BackColor = Color.FromArgb(41, 53, 86);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTatCuaSo_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnTatCuaSo_MouseHover(object sender, EventArgs e)
        {
            btnTatCuaSo.BackColor = Color.FromArgb(251, 155, 81);
            btnTatCuaSo.ForeColor = RGBColors.colorHome;
            btnTatCuaSo.IconColor = RGBColors.colorHome;
            btnTatCuaSo.ImageAlign = ContentAlignment.MiddleCenter;
        }

        private void btnTatCuaSo_MouseLeave(object sender, EventArgs e)
        {
            if (currentBtn != null)
            {
                btnTatCuaSo.BackColor = Color.FromArgb(17, 34, 78);
                btnTatCuaSo.IconColor = Color.Gainsboro;
                btnTatCuaSo.ImageAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void btnThoat_MouseHover(object sender, EventArgs e)
        {
            btnThoat.BackColor = Color.FromArgb(251, 155, 81);
            btnThoat.ForeColor = RGBColors.colorHome;
            btnThoat.IconColor = RGBColors.colorHome;
            btnThoat.ImageAlign = ContentAlignment.MiddleCenter;
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
        {
            if (currentBtn != null)
            {
                btnThoat.BackColor = Color.FromArgb(17, 34, 78);
                btnThoat.IconColor = Color.Gainsboro;
                btnThoat.ImageAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            KHACH_HANG tk = db.KHACH_HANGs.SingleOrDefault(p => p.MaKhachHang.Equals(MaKhachHang));
            label1.Text = tk.TenKhachHang;
            panelDesktop.BackgroundImage = Properties.Resources._1;
            Rbtn1.Checked = true;
            if (MaKhachHang.Trim() == "4601104000") iconCaidat.Visible = true;
        }

        private void Logoutbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadHinhTiepTheo();
        }

        private void Rbtn1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Start();
            if (Rbtn1.Checked == true) { panelDesktop.BackgroundImage = Properties.Resources._1; }
            else if (Rbtn2.Checked == true) { panelDesktop.BackgroundImage = Properties.Resources._2; }
            else if (Rbtn3.Checked == true) { panelDesktop.BackgroundImage = Properties.Resources._3; }
            else if (Rbtn4.Checked == true) { panelDesktop.BackgroundImage = Properties.Resources._4; }
        }

        private void panelDesktop_MouseClick(object sender, MouseEventArgs e)
        {
            ActiveButton(iconSanpham, RGBColors.color1);
            FormSanPham sp = new FormSanPham();
            sp.MaKhachHangSP = MaKhachHang;
            OpenChildForm(sp);
        }
    }
}
