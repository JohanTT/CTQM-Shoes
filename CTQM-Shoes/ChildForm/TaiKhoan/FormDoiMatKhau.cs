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
    public partial class FormDoiMatKhau : Form
    {
        public FormDoiMatKhau()
        {
            InitializeComponent();
            MatKhau1txt.UseSystemPasswordChar = true;
            MatKhau2txt.UseSystemPasswordChar = true;
            MatKhau3txt.UseSystemPasswordChar = true;
        }
        bool showpass = false; // hiện và ẩn mật khẩu

        public string MaKhachHangDMK { get; set; }

        private void Check1btn_Click(object sender, EventArgs e)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            KHACH_HANG kh = db.KHACH_HANGs.SingleOrDefault(p => p.MaKhachHang.Equals(MaKhachHangDMK));
            if (kh != null)
            {
                if (kh.MatKhau == MatKhau1txt.Text)
                {
                    Errorlb.Visible = false;
                    Check1btn.Visible = false;
                    Cancelbtn.Visible = false;
                    PnMKD.Visible = true;
                }
                else
                {
                    Errorlb.Visible = true;
                }
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Check2btn_Click(object sender, EventArgs e)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            KHACH_HANG kh = db.KHACH_HANGs.SingleOrDefault(p => p.MaKhachHang.Equals(MaKhachHangDMK));
            if (kh != null)
            {
                if (MatKhau2txt.Text == MatKhau3txt.Text)
                {
                    kh.MatKhau = MatKhau3txt.Text;
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    db.SubmitChanges();
                    this.Close();
                }
                else
                {
                    Error2lb.Visible = true;
                }
            }
        }

        private void Showpassbtn3_Click(object sender, EventArgs e)
        {
            if (showpass == false)
            {
                Showpassbtn.IconChar = FontAwesome.Sharp.IconChar.Eye;
                Showpassbtn2.IconChar = FontAwesome.Sharp.IconChar.Eye;
                Showpassbtn3.IconChar = FontAwesome.Sharp.IconChar.Eye;
                MatKhau1txt.UseSystemPasswordChar = false;
                MatKhau2txt.UseSystemPasswordChar = false;
                MatKhau3txt.UseSystemPasswordChar = false;
                showpass = true;
            }
            else if (showpass == true)
            {
                Showpassbtn.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                Showpassbtn2.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                Showpassbtn3.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                MatKhau1txt.UseSystemPasswordChar = true;
                MatKhau2txt.UseSystemPasswordChar = true;
                MatKhau3txt.UseSystemPasswordChar = true;
                showpass = false;
            }
        }
    }
}
