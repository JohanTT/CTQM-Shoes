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
    public partial class FormGioHang : Form
    {

        public FormGioHang()
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
        bool _Fixclick = false; // kiểm tra là người dùng có bấm sửa hay không
        public bool Fixclick
        {
            get { return _Fixclick; }
            set { _Fixclick = value; }
        }

        long TongTien1 = new int(); // lấy mấy cái này để tính toán các thứ
        long TongTien2 = new int();
        long TongTien3 = new int();
        int sale = new int(); // có sale nữa nè
        int dem = 0; // cái này để đếm số lượng
        long TienVDTco;
        long TienPayPalco;

        public string MaKhachHangGH { get; set; } // lấy mã khách hàng được truyền vào
        public string MaGiamGiaGH { get; set; }

        private void LayDSGioHang(string mkh) // lấy từ trong tabel giỏ hàng ra giỏ hàng
        {
            GioHangControl[] listGHC = new GioHangControl[100];
            List<GioHangDTO> listGH = new List<GioHangDTO>();
            GioHangBUS.LayDSGioHangFrom(listGH, mkh);
            if (listGH.Count == 0) OhNolb.Visible = true;
            else
            {
                DSSPPanel.Controls.Clear();
                for (int j = 0; j < listGH.Count; j++) 
                { 
                    listGHC[j] = new GioHangControl();
                    listGHC[j].MaGioHangGH = listGH[j].MaGioHang;
                    listGHC[j].MaGiay = listGH[j].MaGiay;
                    listGHC[j].TenGiay = listGH[j].TenGiay;
                    listGHC[j].TienGiay = listGH[j].DonGiaBan.ToString();
                    listGHC[j].HinhGiay = listGH[j].HinhGiay;
                    listGHC[j].SLMH = listGH[j].SoLuongMatHang;
                    listGHC[j].SoLuong = listGH[j].SoLuongDat;
                    listGHC[j].SizeG = listGH[j].TongSize;
                    listGHC[j].SizeC = listGH[j].SizeDat;
                    listGHC[j].Giam = sale;
                    listGHC[j].XoaGioHang += new EventHandler(GioHang_Load); // thêm sự kiện khi xoá hàng sẽ tự load lại
                    listGHC[j].Fixclick = _Fixclick;
                    DSSPPanel.Controls.Add(listGHC[j]);
                }
                dem = listGH.Count;
            }
        }

        private void GioHang_Load(object sender, EventArgs e) // dùng để gọi các hàm load
        {
            LayDSGioHang(MaKhachHangGH);
            LoadTien();
            SoGiaylb.Text = dem.ToString() + " đôi giày"; // cái này để xuất số đôi giày vào cái lb
        }

        public void LoadTien() // hàm load tiền
        {
            TongTien1 = 0;
            TongTien2 = 0;
            TongTien3 = 0;
            foreach(var tt in DSSPPanel.Controls)
            {
                if (tt.GetType() == typeof(GioHangControl))
                {
                    TongTien1 += long.Parse(((GioHangControl)tt).TienGiay) * ((GioHangControl)tt).SoLuong; // lấy tiền từ tổng tiền của các controlform
                }
            }
            TT1.Text = TongTien1.ToString();
            if (sale != 0) TongTien2 = (TongTien1 * sale) / 100; // tiền khuyến mãi
            TT2.Text = TongTien2.ToString();
            TongTien3 = TongTien1 - TongTien2; // tổng tiền sau khi đã trừ thêm khuyến mãi... mà làm gì có khuyến mãi lắm :))
            TT3.Text = TongTien3.ToString();
        }

        private void MoHoaDon()
        {
            DialogResult result = MessageBox.Show("Thanh toán giỏ hàng!?", "Thanh toán", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                FormHoaDon formHoaDon = new FormHoaDon(); // thêm vào giỏ hàng xong sẽ hiện cái form hoá đơn để thanh toán
                formHoaDon.MaKhachHangHD = MaKhachHangGH; // truyền tham số mã khách hàng
                formHoaDon.MaKhuyenMaiHD = KhuyenMaitxt.Text;
                formHoaDon.PhuongThucThanhToan = PTTTcbx.Text;
                formHoaDon.GiamHD = sale;
                formHoaDon.Show(); // Tiến hành thang toán và xuất hoá đơn
            }
        }

        private void ThanhToanbtn_Click(object sender, EventArgs e)
        {
            if (PTTTcbx.SelectedIndex == 1)
            {
                if (TienVDTco < TongTien3)
                {
                    MessageBox.Show("Số dư hiện có trong tài khoản không khả dụng");
                    return;
                }
                FormXacNhan formXacNhan = new FormXacNhan();
                formXacNhan.MaKhachHangKT = MaKhachHangGH;
                formXacNhan.loai = 1;
                formXacNhan.XacNhan += new EventHandler(XacNhanDung);
                formXacNhan.Show();
            }
            else if (PTTTcbx.SelectedIndex == 2)
            {
                if (TienPayPalco < TongTien3)
                {
                    MessageBox.Show("Số dư hiện có trong tài khoản không khả dụng");
                    return;
                }
                FormXacNhan formXacNhan = new FormXacNhan();
                formXacNhan.MaKhachHangKT = MaKhachHangGH;
                formXacNhan.loai = 2;
                formXacNhan.XacNhan += new EventHandler(XacNhanDung);
                formXacNhan.Show();
            }
            else if (PTTTcbx.SelectedIndex == 0)
            {
                MoHoaDon();
            }
        }

        private void XacNhanDung(object sender, EventArgs e)
        {
            MoHoaDon();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = RGBColors.color1;
                }
            }
        }

        private void Fixbtn_Click(object sender, EventArgs e)
        {
            if (_Fixclick == false) // cái này là chọn để sửa
            {
                Fixbtn.FillColor = Color.OrangeRed;
                Fixbtn.Text = "Xong";
                _Fixclick = true;
                GioHang_Load(sender, e); // cái này để load lại dữ liệu sau khi sửa
            } 
            else if (_Fixclick == true) // cái này là để chốt khi sửa xong
            {
                Fixbtn.FillColor = Color.FromArgb(251, 155, 81);
                Fixbtn.Text = "Sửa";
                _Fixclick = false;
                GioHang_Load(sender, e); // cái này cũng vậy
            }
        }

        private void ApDungMKMbtn_Click(object sender, EventArgs e)
        {
            if (KhuyenMaitxt.Text == MaGiamGiaGH)
            {
                MessageBox.Show("Năm mới vui vẻ cùng CTQM nhé!");
                string KM = MaGiamGiaGH[2].ToString() + MaGiamGiaGH[3].ToString();
                sale = int.Parse(KM);
                GioHang_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Mã giảm giá sai rồi!!");
                sale = 0;
                GioHang_Load(sender, e);
            }
        }

        private void PTTTcbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PTTTcbx.SelectedIndex == 1)
            {
                PTTTlb.Text = "Ví điện tử của bạn: ";
                TienVDTco = KhachHangBUS.LayTienVDT(MaKhachHangGH);
                PTTTlb.Text += TienVDTco.ToString();
                PTTTlb.Visible = true;
            }
            else if (PTTTcbx.SelectedIndex == 2)
            {
                PTTTlb.Text = "Paypal của bạn: ";
                TienPayPalco = KhachHangBUS.LayTienPayPal(MaKhachHangGH);
                PTTTlb.Text += TienPayPalco.ToString();
                PTTTlb.Visible = true;
            }
            else PTTTlb.Visible = false;
        }
    }
}
