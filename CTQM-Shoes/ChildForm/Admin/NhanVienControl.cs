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
    public partial class NhanVienControl : UserControl
    {
        public NhanVienControl()
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

        private void MaNhanViencbx_Load()
        {
            MaNhanViencbx.DataSource = NhanVienBUS.LayMaNhanVien();
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

        private void NhanVienControl_Load(object sender, EventArgs e)
        {
            MaNhanViencbx_Load();
            AdminGrV.DataSource = NhanVienBUS.LayDSNhanVien();
        }

        private void AdminGrV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = AdminGrV.CurrentRow.Index;
            MaNhanViencbx.Text = AdminGrV.Rows[i].Cells[0].Value.ToString();
            TenNhanVientxt.Text = AdminGrV.Rows[i].Cells[1].Value.ToString();
            SoDienThoaitxt.Text = AdminGrV.Rows[i].Cells[2].Value.ToString();
            DiaChitxt.Text = AdminGrV.Rows[i].Cells[3].Value.ToString();
            NgaySinhp.Value = DateTime.Parse(AdminGrV.Rows[i].Cells[4].Value.ToString());
            GioiTinhcbx.Text = AdminGrV.Rows[i].Cells[5].Value.ToString();
        }

        private void DoItbtn_Click(object sender, EventArgs e)
        {
            if (boolThem == true)
            {
                NhanVien nv = new NhanVien
                {
                    MaNhanVien = MaNhanViencbx.Text,
                    TenNhanVien = TenNhanVientxt.Text,
                    SoDienThoai = SoDienThoaitxt.Text,
                    DiaChi = DiaChitxt.Text,
                    GioiTinh = GioiTinhcbx.Text,
                    NgaySinh = NgaySinhp.Value
                };
                NhanVienBUS.ThemNhanVien(nv);
                NhanVienControl_Load(sender, e);
            }
            else if (boolXoa == true)
            {
                NhanVienBUS.XoaNhanVien(MaNhanViencbx.Text);
                NhanVienControl_Load(sender, e);
            }
            else if (boolSua == true)
            {
                NhanVien nv = new NhanVien
                {
                    MaNhanVien = MaNhanViencbx.Text,
                    TenNhanVien = TenNhanVientxt.Text,
                    SoDienThoai = SoDienThoaitxt.Text,
                    DiaChi = DiaChitxt.Text,
                    GioiTinh = GioiTinhcbx.Text,
                    NgaySinh = NgaySinhp.Value
                };
                NhanVienBUS.SuaNhanVien(nv);
                NhanVienControl_Load(sender, e);
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            ReText();
        }
    }
}
