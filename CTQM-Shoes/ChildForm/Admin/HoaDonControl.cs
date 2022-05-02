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

namespace CTQM_Shoes.ChildForm.Admin
{
    public partial class HoaDonControl : UserControl
    {
        public HoaDonControl()
        {
            InitializeComponent();
        }

        bool boolThem = false;
        bool boolXoa = false;
        bool boolSua = false;

        private void ReText()
        {
            foreach (var ctl in groupBox2.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    ((TextBox)ctl).Text = "";
                }
                if (ctl.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)ctl).Text = "";
                }
                if (ctl.GetType() == typeof(DateTimePicker))
                {
                    ((DateTimePicker)ctl).Text = "";
                }
            }
        }

        private void MaHoaDoncbx_Load()
        {
            MaHoaDoncbx.DataSource = HoaDonBUS.LayMaHoaDon();
        }

        private void MaNhanViencbx_Load()
        {
            MaNhanViencbx.DataSource = NhanVienBUS.LayMaNhanVien();
        }

        private void MaKhachHangcbx_Load()
        {
            MaKhachHangcbx.DataSource = KhachHangBUS.LayMaKhachHang();
        }

        private void MaGiaycbx_Load()
        {
            MaGiaycbx.DataSource = MatHangBUS.LayMaMatHang();
        }

        private void Them_Click(object sender, EventArgs e)
        {
            if (boolXoa == true)
            {
                Cancelbtn.Visible = false;
                DoItbtn.Visible = false;
                boolXoa = false;
                Xoa.BackColor = Color.FromArgb(248, 129, 37);
                ReText();
            }
            if (boolSua == true)
            {
                Cancelbtn.Visible = false;
                DoItbtn.Visible = false;
                boolSua = false;
                Sua.BackColor = Color.FromArgb(248, 129, 37);
                ReText();
            }
            if (boolThem == false)
            {
                Cancelbtn.Visible = true;
                DoItbtn.Visible = true;
                boolThem = true;
                Them.BackColor = Color.DarkCyan;
                ReText();
            }
            else if (boolThem == true)
            {
                Cancelbtn.Visible = false;
                DoItbtn.Visible = false;
                boolThem = false;
                Them.BackColor = Color.FromArgb(248, 129, 37);
                ReText();
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            if (boolThem == true)
            {
                Cancelbtn.Visible = false;
                DoItbtn.Visible = false;
                boolThem = false;
                Them.BackColor = Color.FromArgb(248, 129, 37);
                ReText();
            }
            if (boolSua == true)
            {
                Cancelbtn.Visible = false;
                DoItbtn.Visible = false;
                boolSua = false;
                Sua.BackColor = Color.FromArgb(248, 129, 37);
                ReText();
            }
            if (boolXoa == false)
            {
                Cancelbtn.Visible = true;
                DoItbtn.Visible = true;
                boolXoa = true;
                Xoa.BackColor = Color.DarkCyan;
            }
            else if (boolXoa == true)
            {
                Cancelbtn.Visible = false;
                DoItbtn.Visible = false;
                boolXoa = false;
                Xoa.BackColor = Color.FromArgb(248, 129, 37);
                ReText();
            }
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            if (boolXoa == true)
            {
                Cancelbtn.Visible = false;
                DoItbtn.Visible = false;
                boolXoa = false;
                Xoa.BackColor = Color.FromArgb(248, 129, 37);
                ReText();
            }
            if (boolThem == true)
            {
                Cancelbtn.Visible = false;
                DoItbtn.Visible = false;
                boolThem = false;
                Them.BackColor = Color.FromArgb(248, 129, 37);
                ReText();
            }
            if (boolSua == false)
            {
                Cancelbtn.Visible = true;
                DoItbtn.Visible = true;
                boolSua = true;
                Sua.BackColor = Color.DarkCyan;
            }
            else if (boolSua == true)
            {
                Cancelbtn.Visible = false;
                DoItbtn.Visible = false;
                boolSua = false;
                Sua.BackColor = Color.FromArgb(248, 129, 37);
                ReText();
            }
        }

        private void HoaDonControl_Load(object sender, EventArgs e)
        {
            MaHoaDoncbx_Load();
            MaGiaycbx_Load();
            MaKhachHangcbx_Load();
            MaNhanViencbx_Load();
            AdminGrV.DataSource = HoaDonBUS.LayDSHoaDon();
        }

        private void AdminGrV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = AdminGrV.CurrentRow.Index;
            MaHoaDoncbx.Text = AdminGrV.Rows[i].Cells[0].Value.ToString();
            MaGiaycbx.Text = AdminGrV.Rows[i].Cells[1].Value.ToString();
            MaKhachHangcbx.Text = AdminGrV.Rows[i].Cells[2].Value.ToString();
            MaNhanViencbx.Text = AdminGrV.Rows[i].Cells[3].Value.ToString();
            if (AdminGrV.Rows[i].Cells[4].Value != null) MaKhuyenMaicbx.Text = AdminGrV.Rows[i].Cells[4].Value.ToString();
            PTTTcbx.Text = AdminGrV.Rows[i].Cells[5].Value.ToString();
            DonGiaBantxt.Text = AdminGrV.Rows[i].Cells[6].Value.ToString();
            KhuyenMaicbx.Text = AdminGrV.Rows[i].Cells[7].Value.ToString();
            ThanhTientxt.Text = AdminGrV.Rows[i].Cells[8].Value.ToString();
            SoLuongtxt.Text = AdminGrV.Rows[i].Cells[9].Value.ToString();
            Sizecbx.Text = AdminGrV.Rows[i].Cells[10].Value.ToString();
            NgayThanhToanp.Value = DateTime.Parse(AdminGrV.Rows[i].Cells[11].Value.ToString());
            DanhGiatxt.Text = AdminGrV.Rows[i].Cells[12].Value.ToString();
        }

        private void DoItbtn_Click(object sender, EventArgs e)
        {
            if (boolThem == true)
            {
                HoaDon hd = new HoaDon
                {
                    MaHoaDon = MaHoaDoncbx.Text,
                    MaGiay = MaGiaycbx.Text,
                    MaKhachHang = MaKhachHangcbx.Text,
                    MaNhanVien = MaNhanViencbx.Text,
                    MaKhuyenMai = MaKhuyenMaicbx.Text,
                    PhuongThucThanhToan = PTTTcbx.Text,
                    DonGiaBan = double.Parse(DonGiaBantxt.Text),
                    KhuyenMai = KhuyenMaicbx.Text,
                    ThanhTien = double.Parse(ThanhTientxt.Text),
                    SoLuong = double.Parse(SoLuongtxt.Text),
                    Size = Sizecbx.Text,
                    NgayThanhToan = NgayThanhToanp.Value,
                    DanhGia = DanhGiatxt.Text
                };
                HoaDonBUS.ThemHoaDon(hd);
                HoaDonControl_Load(sender, e);
            }
            else if (boolXoa == true)
            {
                HoaDonBUS.XoaHoaDon(MaHoaDoncbx.Text);
                HoaDonControl_Load(sender, e);
            }
            else if (boolSua == true)
            {
                HoaDon hd = new HoaDon
                {
                    MaHoaDon = MaHoaDoncbx.Text,
                    MaGiay = MaGiaycbx.Text,
                    MaKhachHang = MaKhachHangcbx.Text,
                    MaNhanVien = MaNhanViencbx.Text,
                    MaKhuyenMai = MaKhuyenMaicbx.Text,
                    PhuongThucThanhToan = PTTTcbx.Text,
                    DonGiaBan = double.Parse(DonGiaBantxt.Text),
                    KhuyenMai = KhuyenMaicbx.Text,
                    ThanhTien = double.Parse(ThanhTientxt.Text),
                    SoLuong = double.Parse(SoLuongtxt.Text),
                    Size = Sizecbx.Text,
                    NgayThanhToan = NgayThanhToanp.Value,
                    DanhGia = DanhGiatxt.Text
                };
                HoaDonBUS.SuaHoaDon(hd);
                HoaDonControl_Load(sender, e);
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            ReText();
        }
    }
}
