using SHOESBUS;
using SHOESDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTQM_Shoes.ChildForm
{
    public partial class FormChinhTaiKhoan : Form
    {
        public FormChinhTaiKhoan()
        {
            InitializeComponent();
        }
        public string MaKhachHangCtk { get; set; }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            KhachHang n = new KhachHang
            {
                MaKhachHang = MaKhachHangCtk,
                TenKhachHang = TenKHtxt.Text,
                SoDienThoai = Sdttxt.Text,
                DiaChi = Diachitxt.Text,
                NgaySinh = DateTime.Parse(NgaySinhdtp.Text),
                GioiTinh = GioiTinhcbx.Text
            };
            KhachHangBUS.SuaKhachHang(n);
            MessageBox.Show("Sửa thông tin thành công");
        }

        private void DoiMkbtn_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau formDoiMatKhau = new FormDoiMatKhau();
            formDoiMatKhau.MaKhachHangDMK = MaKhachHangCtk;
            formDoiMatKhau.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_MouseEnter(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.LimeGreen;
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.FromArgb(248, 129, 37);
        }

        private void FormChinhTaiKhoan_Load(object sender, EventArgs e)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            KHACH_HANG kh = db.KHACH_HANGs.SingleOrDefault(p => p.MaKhachHang.Equals(MaKhachHangCtk));
            if (kh != null)
            {
                TenKHtxt.Text = kh.TenKhachHang;
                if (kh.SoDienThoai != null) Sdttxt.Text = kh.SoDienThoai.ToString();
                if (kh.DiaChi != null) Diachitxt.Text = kh.DiaChi;
                if (kh.NgaySinh != null) NgaySinhdtp.Value = DateTime.Parse(kh.NgaySinh.ToString());
                if (kh.GioiTinh != null) GioiTinhcbx.Text = kh.GioiTinh;
            }
        }

        private void DoiMaBaoMatbtn_Click(object sender, EventArgs e)
        {
            FormDoiMaBaoMat formDoiBaoMat = new FormDoiMaBaoMat();
            formDoiBaoMat.MaKhachHangDMBM = MaKhachHangCtk;
            formDoiBaoMat.Show();
        }
    }
}
