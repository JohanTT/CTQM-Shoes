using Guna.UI2.WinForms;
using SHOESBUS;
using SHOESDAL;
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
    public partial class ChiTietMatHang : Form
    {
        public ChiTietMatHang()
        {
            InitializeComponent();
        }
        // những thứ này thường xuyên được lấy nên để tạm trên đây
        public event EventHandler Quaylaiclick; // Event để khi người dùng bấm quay lại sẽ show lại dsmh cũ
        private Image[] HinhGiay = new Image[5];
        private string _MaGiay;
        private string _MaKhachHang;
        private string _TenGiay;
        private string _TienGiay;
        private int _SoLuong = 0;
        private string _MauSac;
        private string _ChatLieu;
        private string _SizeG;
        private string _SizeC;
        private string _GhiChu;
        private string _BaoHanh;
        private int _SLMH;
        bool checkChonSize = false; // Kiểm tra người dùng đã có chọn size chưa
        // chỗ để get set
        public Image this[int index]
        {
            get { return HinhGiay[index]; }
            set { HinhGiay[index] = value; }
        }
        public string MaGiay
        {
            get { return _MaGiay; }
            set { _MaGiay = value; }
        }
        public string MaKhachHang
        {
            get { return _MaKhachHang; }
            set { _MaKhachHang = value; }
        }
        public string TenGiay
        {
            get { return _TenGiay; }
            set { _TenGiay = value; }
        }
        public string TienGiay
        {
            get { return _TienGiay; }
            set { _TienGiay = value; }
        }
        public int SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
        public string MauSac
        {
            get { return _MauSac; }
            set { _MauSac = value; }
        }
        public string ChatLieu
        {
            get { return _ChatLieu; }
            set { _ChatLieu = value; }
        }
        public string SizeG
        {
            get { return _SizeG; }
            set { _SizeG = value; }
        }
        public string BaoHanh
        {
            get { return _BaoHanh; }
            set { _BaoHanh = value; }
        }
        public int SLMH
        {
            get { return _SLMH; }
            set { _SLMH = value; }
        }

        private void ChiTietMatHangControl_Load(object sender, EventArgs e) // load các thông tin mặt hàng đã được truyền vào trước đó
        {
            TenGiaylb.Text = _TenGiay;
            Tienlb.Text = _TienGiay;
            MauSaclb.Text = "Màu sắc: " + _MauSac;
            ChatLieulb.Text = "Chất liệu: " + _ChatLieu;
            BaoHanhlb.Text = "Bảo hành: " + _BaoHanh;
            GhiChulb.Text = _GhiChu;
            SoLuongchoice.Value = _SoLuong;
            Pic1.Image = HinhGiay[0];
            Pic2.Image = HinhGiay[1];
            Pic3.Image = HinhGiay[2];
            Pic4.Image = HinhGiay[3];
            Mainpic.Image = HinhGiay[0];
            LaySize(); 
        }

        private void LaySize() // tạo hàm lấy size để có thể hiện các nút dựa trên số lượng size
        {
            if (_SizeG != null)
            {
                string sizeH = "", sizeT = ""; // size đầu và size cuối
                bool check = false; // Kiểm tra có dấu - hay không
                if (_SizeG.Contains('-')) // nếu có - ở giữa có nghĩa là từ 2 size trở lên
                {
                    check = true;
                    sizeH = _SizeG[0].ToString() + _SizeG[1].ToString(); // lấy 2 số đầu
                    sizeT = _SizeG[3].ToString() + _SizeG[4].ToString(); // lấy 2 số cuối
                }
                else sizeH = _SizeG; // không có thì chỉ là 1 size
                int dem, tmp;
                if (check == true) // Nếu có dấu - thì thêm từ đầu tới cuối vào cbx
                {
                    int sodau = int.Parse(sizeH), socuoi = int.Parse(sizeT); // chuyển sang kiểu số
                    for (int i = 1; i <= socuoi - sodau + 1; i++) // có 2 vòng lặp để các nút được xuất hiện đúng theo thứ tự
                    {
                        dem = i;
                        tmp = sodau;
                        foreach (var ctl in panelbtnsize.Controls)
                        {
                            if (tmp <= socuoi && ((Guna2Button)ctl).TabIndex == dem) // dựa trên cái tabindex để sắp xếp
                            {
                                ((Guna2Button)ctl).Visible = true;
                                ((Guna2Button)ctl).Text += " " + (tmp + i - 1).ToString();
                                tmp++;
                            }
                        }
                    }
                }
                else
                {
                    Button1.Visible = true; // Nếu không thì thêm thẳng size vào
                    Button1.Text += " " + sizeH;
                }
            }
        }

        private void ThemVaoGioHangbtn_Click(object sender, EventArgs e)
        {
            // Thêm vào giỏ hàng
            if (checkChonSize == false) // chưa chọn size
            {
                MessageBox.Show("Hãy chọn size giày trước!");
            }
            else if (SoLuongchoice.Value == 0) // chưa chọn số lượng
            {
                MessageBox.Show("Chọn số lượng");
            }
            else
            {
                string soKH = _MaKhachHang[7].ToString() + _MaKhachHang[8].ToString() + _MaKhachHang[9].ToString();
                GioHangDTO n = new GioHangDTO // tạo giỏ hàng mới
                {
                    MaGioHang = "GH" + _MaGiay.Trim() + "_" + soKH.Trim() + _SizeC.Trim() + SoLuongchoice.Value.ToString().Trim(),
                    MaGiay = _MaGiay,
                    MaKhachHang = _MaKhachHang,
                    SoLuongDat = int.Parse(SoLuongchoice.Value.ToString()),
                    SizeDat = _SizeC,
                    SoLuongMatHang = _SLMH,
                    TongSize = _SizeG
                };
                GioHangBUS.ThemVaoGioHang(n); // thêm vào giỏ hàng
            }
        }

        private void Turnback_Click(object sender, EventArgs e) // để thoát ra
        {
            if (this.Quaylaiclick != null)
            {
                this.Quaylaiclick(this, e);
            }
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e) // chọn các btn và biểu hiện bằng chuyển sang màu cam
        {
            foreach (var xbtn in panelbtnsize.Controls)
            {
                if (xbtn.GetType() == typeof(Guna2Button))
                {
                    ((Guna2Button)xbtn).FillColor = Color.FromArgb(251, 155, 81); // load các nút đã chọn lại màu ban đầu
                }
            }
            Guna2Button btn = (Guna2Button)sender; // lấy cái nút được chọn
            string tmp = btn.Text;
            bool check = false; // Kiểm tra đã tới dấu cách chưa để lấy số
            string result = ""; // Lấy kết quả
            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i] == ' ') check = true; // ở dây chỉ là lấy size thôi
                if (check == true)
                {
                    result += tmp[i]; // lấy số size thôi không có gì đâu
                }
            }
            _SizeC = result; // sau khi xử lý chuỗi xong gán nó vào lại cái size chính
            btn.FillColor = Color.OrangeRed; // đổi màu cam
            checkChonSize = true; // check là đã chọn size
        }

        private void SoLuongchoice_ValueChanged(object sender, EventArgs e)
        {
            if (SoLuongchoice.Value > _SLMH) // số lượng chọn vượt quá số lưuọng mặt hàng hiện có
            {
                SoLuongchoice.Value--; // nhiều quá giảm xuống lại
                MessageBox.Show("Bạn đã mua nhiều hơn số lượng hiện có");
            }
        }

        private void Pic1_Click(object sender, EventArgs e)
        {
            PictureBox tmp = (PictureBox)sender; // chọn cái hình được cliick vàooô
            Mainpic.Image = tmp.Image; // xuất cái hình đó lên màn ảnh rộng
        }
        // thêm hiện ứng màu mè hoa lá hẹ

        private void Pic1_MouseEnter(object sender, EventArgs e)
        {
            PictureBox tmp = (PictureBox)sender;
            tmp.BorderStyle = BorderStyle.FixedSingle;
        }

        private void Pic1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox tmp = (PictureBox)sender;
            tmp.BorderStyle = BorderStyle.None;
        }

        private void iconButton1_MouseEnter(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.OrangeRed;
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.FromArgb(248, 129, 37);
        }
    }
}
