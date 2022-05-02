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
    public partial class KhachHangControl : UserControl
    {
        public KhachHangControl()
        {
            InitializeComponent();
        }

        bool boolThem = false;
        bool boolXoa = false;
        bool boolSua = false;

        private void MaKhachHangcbx_Load()
        {
            MaKhachHangcbx.DataSource = KhachHangBUS.LayMaKhachHang();
        }

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

        private void KhachHangControl_Load(object sender, EventArgs e)
        {
            MaKhachHangcbx_Load();
            AdminGrV.DataSource = KhachHangBUS.LayDSKhachHang();
        }

        private void AdminGrV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = AdminGrV.CurrentRow.Index;
            MaKhachHangcbx.Text = AdminGrV.Rows[i].Cells[0].Value.ToString();
            TenKhachHangtxt.Text = AdminGrV.Rows[i].Cells[1].Value.ToString();
            SoDienThoaitxt.Text = AdminGrV.Rows[i].Cells[2].Value.ToString();
            DiaChitxt.Text = AdminGrV.Rows[i].Cells[3].Value.ToString();
            NgaySinhp.Value = DateTime.Parse(AdminGrV.Rows[i].Cells[4].Value.ToString());
            GioiTinhcbx.Text = AdminGrV.Rows[i].Cells[5].Value.ToString();
            TaiKhoantxt.Text = AdminGrV.Rows[i].Cells[6].Value.ToString();
            MatKhautxt.Text = AdminGrV.Rows[i].Cells[7].Value.ToString();
            TienVDTtxt.Text = AdminGrV.Rows[i].Cells[8].Value.ToString();
            MaBMtxt.Text = AdminGrV.Rows[i].Cells[9].Value.ToString();
        }

        private void DoItbtn_Click(object sender, EventArgs e)
        {
            if (boolThem == true)
            {
                KhachHang kh = new KhachHang
                {
                    MaKhachHang = MaKhachHangcbx.Text,
                    TenKhachHang = TenKhachHangtxt.Text,
                    SoDienThoai = SoDienThoaitxt.Text,
                    DiaChi = DiaChitxt.Text,
                    NgaySinh = NgaySinhp.Value,
                    GioiTinh = GioiTinhcbx.Text,
                    TaiKhoan = TaiKhoantxt.Text,
                    MatKhau = MatKhautxt.Text,
                    TienVDT = long.Parse(TienVDTtxt.Text),
                    MaBaoMat = MaBMtxt.Text
                };
                KhachHangBUS.ThemKhachHang(kh);
                KhachHangControl_Load(sender, e);
            }
            else if (boolXoa == true)
            {
                KhachHangBUS.XoaKhachHang(MaKhachHangcbx.Text);
                KhachHangControl_Load(sender, e);
            }
            else if (boolSua == true)
            {
                KhachHang kh = new KhachHang
                {
                    MaKhachHang = MaKhachHangcbx.Text,
                    TenKhachHang = TenKhachHangtxt.Text,
                    SoDienThoai = SoDienThoaitxt.Text,
                    DiaChi = DiaChitxt.Text,
                    NgaySinh = NgaySinhp.Value,
                    GioiTinh = GioiTinhcbx.Text,
                    TaiKhoan = TaiKhoantxt.Text,
                    MatKhau = MatKhautxt.Text
                };
                KhachHangBUS.SuaKhachHang(kh);
                KhachHangControl_Load(sender, e);
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            ReText();
        }
    }
}
