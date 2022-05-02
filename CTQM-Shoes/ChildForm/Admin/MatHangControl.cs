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
    public partial class MatHangControl : UserControl
    {
        public MatHangControl()
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

        private void MatHangControl_Load(object sender, EventArgs e)
        {
            MaGiaycbx_Load();
            AdminGrV.DataSource = MatHangBUS.LayDSMatHang();
        }

        private void AdminGrV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = AdminGrV.CurrentRow.Index;
            MaGiaycbx.Text = AdminGrV.Rows[i].Cells[0].Value.ToString();
            TenGiaytxt.Text = AdminGrV.Rows[i].Cells[1].Value.ToString();
            Pic1.Image = (Image)AdminGrV.Rows[i].Cells[2].Value;
            Pic2.Image = (Image)AdminGrV.Rows[i].Cells[3].Value;
            Pic3.Image = (Image)AdminGrV.Rows[i].Cells[4].Value;
            Pic4.Image = (Image)AdminGrV.Rows[i].Cells[5].Value;
            Loaicbx.Text = AdminGrV.Rows[i].Cells[6].Value.ToString();
            SoLuongtxt.Text = AdminGrV.Rows[i].Cells[7].Value.ToString();
            MauSactxt.Text = AdminGrV.Rows[i].Cells[8].Value.ToString();
            Sizecbx.Text = AdminGrV.Rows[i].Cells[9].Value.ToString();
            DonGiaBantxt.Text = AdminGrV.Rows[i].Cells[10].Value.ToString();
            DonGiaNhaptxt.Text = AdminGrV.Rows[i].Cells[11].Value.ToString();
            ChatLieucbx.Text = AdminGrV.Rows[i].Cells[12].Value.ToString();
            BaoHanhcbx.Text = AdminGrV.Rows[i].Cells[13].Value.ToString();
            DieuKiencbx.Text = AdminGrV.Rows[i].Cells[14].Value.ToString();
            GhiChutxt.Text = AdminGrV.Rows[i].Cells[15].Value.ToString();            
        }

        private void DoItbtn_Click(object sender, EventArgs e)
        {
            if (boolThem == true)
            {
                MatHang mh = new MatHang
                {
                    MaGiay = MaGiaycbx.Text,
                    TenGiay = TenGiaytxt.Text,
                    Anh1 = Pic1.Image,
                    Anh2 = Pic2.Image,
                    Anh3 = Pic3.Image,
                    Anh4 = Pic4.Image,
                    Loai = Loaicbx.Text,
                    SoLuong = double.Parse(SoLuongtxt.Text),
                    MauSac = MauSactxt.Text,
                    Size = Sizecbx.Text,
                    DonGiaBan = double.Parse(DonGiaBantxt.Text),
                    DonGiaNhap = double.Parse(DonGiaNhaptxt.Text),
                    ChatLieu = ChatLieucbx.Text,
                    BaoHanh = BaoHanhcbx.Text,
                    DieuKien = DieuKiencbx.Text,
                    GhiChu = GhiChutxt.Text
                };
                MatHangBUS.ThemMatHang(mh);
                MatHangControl_Load(sender, e);
            }
            else if (boolXoa == true)
            {
                MatHangBUS.XoaMatHang(MaGiaycbx.Text);
                MatHangControl_Load(sender, e);
            }
            else if (boolSua == true)
            {
                MatHang mh = new MatHang
                {
                    MaGiay = MaGiaycbx.Text,
                    TenGiay = TenGiaytxt.Text,
                    Anh1 = Pic1.Image,
                    Anh2 = Pic2.Image,
                    Anh3 = Pic3.Image,
                    Anh4 = Pic4.Image,
                    Loai = Loaicbx.Text,
                    SoLuong = double.Parse(SoLuongtxt.Text),
                    MauSac = MauSactxt.Text,
                    Size = Sizecbx.Text,
                    DonGiaBan = double.Parse(DonGiaBantxt.Text),
                    DonGiaNhap = double.Parse(DonGiaNhaptxt.Text),
                    ChatLieu = ChatLieucbx.Text,
                    BaoHanh = BaoHanhcbx.Text,
                    DieuKien = DieuKiencbx.Text,
                    GhiChu = GhiChutxt.Text
                };
                MatHangBUS.SuaMatHang(mh);
                MatHangControl_Load(sender, e);
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            ReText();
        }

        private void Pic1_Click(object sender, EventArgs e)
        {
            OpenFileDialog layhinh = new OpenFileDialog();
            PictureBox p = sender as PictureBox;
            if (p != null)
            {
                layhinh.Filter = "(*.jpg;*.jpeg;*.bmp;*.png)| *.jpg; *.jpeg; *.bmp; *.png";
                if (layhinh.ShowDialog() == DialogResult.OK)
                {
                    p.Image = Image.FromFile(layhinh.FileName);
                }
            }
        }
    }
}
