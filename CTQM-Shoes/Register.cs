using SHOESBUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTQM_Shoes
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            MatKhautxt.UseSystemPasswordChar = true;
            ConMatKhautxt.UseSystemPasswordChar = true;
        }
        bool showpass = false; // hiện và ẩn mật khẩu

        private void Registerbtn_Click(object sender, EventArgs e)
        {
            if (MatKhautxt.Text != ConMatKhautxt.Text) // mật khẩu không khớp
            {
                Error.Visible = true;
            }
            else
            {
                Error.Visible = true;
                Error.ForeColor = Color.Green;
                Error.Text = "Đăng ký tài khoản thành công";
                KhachHangBUS.ThemTaiKhoan(HoTentxt.Text, TaiKhoantxt.Text, MatKhautxt.Text); // thêm tài khoản mới tạo vào csdl
                HoTentxt.Text = "";
                TaiKhoantxt.Text = "";
                MatKhautxt.Text = "";
                ConMatKhautxt.Text = "";
            }

        }

        private void TurnBack_Click(object sender, EventArgs e)
        {
            HoTentxt.Text = "";
            TaiKhoantxt.Text = "";
            MatKhautxt.Text = "";
            ConMatKhautxt.Text = "";
            this.Close(); // đóng form này
        }

        private void Showpassbtn_Click(object sender, EventArgs e)
        {
            if (showpass == false)
            {
                Showpassbtn.IconChar = FontAwesome.Sharp.IconChar.Eye;
                Showpassbtn2.IconChar = FontAwesome.Sharp.IconChar.Eye;
                MatKhautxt.UseSystemPasswordChar = false;
                ConMatKhautxt.UseSystemPasswordChar = false;
                showpass = true;
            }
            else if (showpass == true)
            {
                Showpassbtn.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                Showpassbtn2.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                MatKhautxt.UseSystemPasswordChar = true;
                ConMatKhautxt.UseSystemPasswordChar = true;
                showpass = false;
            }
        }
    }
}
