using CTQM_Shoes.ChildForm.GioHang;
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
    public partial class FormNapTienVDT : Form
    {
        public FormNapTienVDT()
        {
            InitializeComponent();
        }

        public event EventHandler Xong;

        long TienPayPalco;
        long TienNap;
        public string MaKhachHangNT { get; set; }
        private void Check1btn_Click(object sender, EventArgs e)
        {
            TienNap = long.Parse(Tientxt.Text);
            if (TienNap < 50000)
            {
                Tientxt.Text = "";
                MessageBox.Show("Không được nạp vào số tiền dưới 50.000 nhé!");
            }
            else
            {
                FormXacNhan formXacNhan = new FormXacNhan();
                formXacNhan.MaKhachHangKT = MaKhachHangNT;
                formXacNhan.loai = 2; // lấy mã bảo mật của paypal
                formXacNhan.XacNhan += new EventHandler(XacNhanDung);
                formXacNhan.Show();
            }
        }

        private void XacNhanDung(object sender, EventArgs e)
        {
            try
            {
                TienNap = long.Parse(Tientxt.Text);
                if (TienNap > TienPayPalco)
                {
                    MessageBox.Show("Số dư của bạn không đủ để nạp!");
                }
                else if (TienPayPalco - TienNap > 0)
                {
                    KhachHangBUS.NapTienVDT(MaKhachHangNT, TienNap); // nạp tiền vào ví điện tử
                    KhachHangBUS.GiamTienPayPal(MaKhachHangNT, TienNap); // giảm số tiền tương ứng đã nạp
                    MessageBox.Show("Nạp tiền vào ví điện tử thành công!");
                }
            }
            catch
            {
                MessageBox.Show("Bạn đã nhập sai số tiền!");
                Tientxt.Text = "";
                return;
            }
        }

        private void FormNapTienVDT_Load(object sender, EventArgs e)
        {
            TienPayPalco = KhachHangBUS.LayTienPayPal(MaKhachHangNT);
            Tienlb.Text = TienPayPalco.ToString();
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            if (this.Xong != null)
            {
                this.Xong(this, e);
            }
            this.Close();
        }
    }
}
