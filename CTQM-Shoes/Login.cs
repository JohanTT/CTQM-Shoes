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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            MatKhautxt.UseSystemPasswordChar = true;
        }
        int dem = 0; // Đếm số tài khoản đã được lưu
        string[,] TK = new string [2,100]; // Lưu người dùng khi chọn lưu tài khoản 0 là tài khoản 1 là mật khẩu
        string _MaKhachHang;
        bool showpass = false; // Cho phép người dùng hiển thị và ẩn pass

        private void LoadTKMK()
        {
            TaiKhoancbx.Items.Clear(); // clear để cho dữ liệu nó không bị trùng lên
            dem = 0;
            KhachHangBUS.LayTaiKhoanMatKhau(TK, ref dem);
            for (int i = 0; i < dem; i++)
            {
                TaiKhoancbx.Items.Add(TK[0, i]);
            }
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Shoes2DataContext db = new Shoes2DataContext();
                if (Listcheck.Checked == false) // nếu sử dụng cách nhập thông thường
                {
                    if (TaiKhoantxt.Text == null)  // Tài khoản trống
                    {
                        LInfor.Text = "Hãy nhập tài khoản";
                        LInfor.Visible = true;
                        return;
                    }
                    else if (MatKhautxt.Text == null)  // Mật khẩu trống
                    {
                        LInfor.Text = "Hãy nhập mật khẩu";
                        LInfor.Visible = true;
                        return;
                    }
                    KHACH_HANG tk = db.KHACH_HANGs.SingleOrDefault(p => p.TaiKhoan.Equals(TaiKhoantxt.Text)); // nếu không có gì trống thì tiến hành truy vấn dựa trên tài khoản
                    KHACH_HANG mk = db.KHACH_HANGs.SingleOrDefault(p => p.MatKhau.Equals(MatKhautxt.Text));
                    if (tk == null)  // Tài khoản không tồn tại
                    {
                        LInfor.Text = "Tài khoản không tồn tại";
                        LInfor.Visible = true;
                        return;
                    }
                    else if (mk == null)  // Mật khẩu trống
                    {
                        LInfor.Text = "Sai tên đăng nhập hoặc mật khẩu";
                        LInfor.Visible = true;
                        return;
                    }
                    if (tk != null && mk != null && tk.TaiKhoan == mk.TaiKhoan && tk.MatKhau == mk.MatKhau)  // Đăng nhập đúng
                    {
                        if (LuuTKcheck.Checked == true)  // nếu có check để lưu thì sẽ lưu thôi :3
                        {
                            KhachHangBUS.ChuyenGhiChu(TaiKhoantxt.Text); // chuyển ghi chú thành TRUE
                        }
                        TaiKhoantxt.Text = "";
                        MatKhautxt.Text = "";
                        this.Hide();
                        _MaKhachHang = tk.MaKhachHang; // lấy cái mã khách hàng của người đó để vào trong làm việc
                        FormMainMenu formMainMenu = new FormMainMenu(); // tạo form chính
                        formMainMenu.MaKhachHang = _MaKhachHang; // chuyển mã khách hàng vào mainform
                        if (formMainMenu.MaKhachHang != null) formMainMenu.ShowDialog(); // mở form chính lên
                        Listcheck.Checked = false;
                        this.Show();
                        return;
                    }
                    else  // Mật khẩu sai
                    {
                        LInfor.Text = "Sai tên đăng nhập hoặc mật khẩu";
                        LInfor.Visible = true;
                        return;
                    }
                }
                else // dùng cách chọn cbx để đăng nhập
                {
                    KHACH_HANG tk = db.KHACH_HANGs.SingleOrDefault(p => p.TaiKhoan.Equals(TaiKhoancbx.Text));  // lấy tài khoản và mật khẩu
                    KHACH_HANG mk = db.KHACH_HANGs.SingleOrDefault(p => p.MatKhau.Equals(MatKhautxt.Text));
                    
                    if (tk == null)  // Tài khoản không tồn tại
                    {
                        LInfor.Text = "Tài khoản không tồn tại";
                        LInfor.Visible = true;
                        return;
                    }
                    else if (mk == null)  // Mật khẩu sai
                    {
                        LInfor.Text = "Sai tên đăng nhập hoặc mật khẩu";
                        LInfor.Visible = true;
                        return;
                    }
                    if (tk != null && mk != null && tk.TaiKhoan == mk.TaiKhoan && tk.MatKhau == mk.MatKhau)  // Đăng nhập đúng
                    {
                        _MaKhachHang = tk.MaKhachHang;
                        TaiKhoantxt.Text = "";
                        MatKhautxt.Text = "";
                        this.Hide();
                        FormMainMenu formMainMenu = new FormMainMenu(); // tạo form mới
                        formMainMenu.MaKhachHang = _MaKhachHang; // truyền dữ liệu khách hàng vào để dùng
                        formMainMenu.ShowDialog(); // mở form chính
                        Listcheck.Checked = false;
                        this.Show();
                        return;
                    }
                    else  // Mật khẩu sai
                    {
                        LInfor.Text = "Sai tên đăng nhập hoặc mật khẩu";
                        LInfor.Visible = true;
                        return;
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void TaiKhoancbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            MatKhautxt.Text = TK[1, TaiKhoancbx.SelectedIndex].ToString(); // lấy mật khẩu dựa trên tài khoảng đã chọn
        }

        private void Listcheck_CheckedChanged(object sender, EventArgs e)
        {
            LoadTKMK(); // lấy tkmk để ứng phó với đăng nhập
            if (Listcheck.Checked == true) // đăng nhập bằng cbx
            {
                TaiKhoancbx.Visible = true;
                TaiKhoantxt.Visible = false;
            }
            else // đăng nhập bằng cách thông thường
            {
                TaiKhoantxt.Visible = true;
                TaiKhoancbx.Visible = false;
            }
            TaiKhoantxt.Text = "";
            MatKhautxt.Text = "";
        }

        private void Signupbtn_Click(object sender, EventArgs e)
        {
            TaiKhoantxt.Text = "";
            MatKhautxt.Text = "";
            this.Hide(); // ẩn cái này đi để hiện cái đăng ký
            Register rg = new Register(); // tạo form đăng ký
            rg.ShowDialog(); // mở cái đăng ký
            this.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này chưa được hoàn thiện hehe");
        }

        private void Showpassbtn_Click(object sender, EventArgs e)
        {
            if (showpass == false)
            {
                Showpassbtn.IconChar = FontAwesome.Sharp.IconChar.Eye;
                MatKhautxt.UseSystemPasswordChar = false;
                showpass = true;
            }
            else if (showpass == true)
            {
                Showpassbtn.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                MatKhautxt.UseSystemPasswordChar = true;
                showpass = false;
            }
        }
    }
}
