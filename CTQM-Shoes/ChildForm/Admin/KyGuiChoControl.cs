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
    public partial class KyGuiChoControl : UserControl
    {
        public KyGuiChoControl()
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

        private void MaKhachHangcbx_Load()
        {
            MaKhachHangcbx.DataSource = KhachHangBUS.LayMaKhachHangKGC();
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

        private void AdminGrV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = AdminGrV.CurrentRow.Index;
            MaKhachHangcbx.Text = AdminGrV.Rows[i].Cells[1].Value.ToString();
            TenGiaytxt.Text = AdminGrV.Rows[i].Cells[3].Value.ToString();
            Pic1.Image = (Image)AdminGrV.Rows[i].Cells[4].Value;
            Pic2.Image = (Image)AdminGrV.Rows[i].Cells[5].Value;
            Pic3.Image = (Image)AdminGrV.Rows[i].Cells[6].Value;
            Pic4.Image = (Image)AdminGrV.Rows[i].Cells[7].Value;
            SoLuongtxt.Text = AdminGrV.Rows[i].Cells[9].Value.ToString();
            MauSactxt.Text = AdminGrV.Rows[i].Cells[10].Value.ToString();
            Sizecbx.Text = AdminGrV.Rows[i].Cells[11].Value.ToString();
            DonGiaNhaptxt.Text = AdminGrV.Rows[i].Cells[13].Value.ToString();
            ChatLieucbx.Text = AdminGrV.Rows[i].Cells[14].Value.ToString();
            BaoHanhcbx.Text = AdminGrV.Rows[i].Cells[15].Value.ToString();
            DieuKiencbx.Text = AdminGrV.Rows[i].Cells[16].Value.ToString();
            GhiChutxt.Text = AdminGrV.Rows[i].Cells[17].Value.ToString();
            PhiKyGuitxt.Text = AdminGrV.Rows[i].Cells[18].Value.ToString();
            NgayKyGuip.Value = (DateTime)AdminGrV.Rows[i].Cells[19].Value;
            ThoiGianGuicbx.Text = AdminGrV.Rows[i].Cells[20].Value.ToString();
        }

        private void DoItbtn_Click(object sender, EventArgs e)
        {
            if (boolThem == true)
            {
                KyGui kg = new KyGui
                {
                    MaGiay = MaGiaycbx.Text,
                    MaKhachHang = MaKhachHangcbx.Text,
                    MaNhanVien = MaNhanViencbx.Text,
                    TenGiay = TenGiaytxt.Text,
                    Anh1 = Pic1.Image,
                    Anh2 = Pic2.Image,
                    Anh3 = Pic3.Image,
                    Anh4 = Pic4.Image,
                    Loai = "OLD",
                    SoLuong = double.Parse(SoLuongtxt.Text),
                    MauSac = MauSactxt.Text,
                    Size = Sizecbx.Text,
                    DonGiaBan = double.Parse(DonGiaBantxt.Text),
                    DonGiaNhap = double.Parse(DonGiaNhaptxt.Text),
                    ChatLieu = ChatLieucbx.Text,
                    BaoHanh = BaoHanhcbx.Text,
                    DieuKien = DieuKiencbx.Text,
                    GhiChu = GhiChutxt.Text,
                    NgayKyGui = NgayKyGuip.Value,
                    ThoiGianKyGui = ThoiGianGuicbx.Text,
                    PhiKyGui = double.Parse(PhiKyGuitxt.Text)
                };
                if (KyGuiBUS.ThemKyGui(kg)) KyGuiBUS.XoaKyGuiCho(kg.TenGiay);
                KyGuiChoControl_Load(sender, e);
            }
            else if (boolXoa == true)
            {
                KyGuiBUS.XoaKyGuiCho(TenGiaytxt.Text);
                KyGuiChoControl_Load(sender, e);
            }
            else if (boolSua == true)
            {
                KyGui kg = new KyGui
                {
                    MaKhachHang = MaKhachHangcbx.Text,
                    TenGiay = TenGiaytxt.Text,
                    Anh1 = Pic1.Image,
                    Anh2 = Pic2.Image,
                    Anh3 = Pic3.Image,
                    Anh4 = Pic4.Image,
                    SoLuong = double.Parse(SoLuongtxt.Text),
                    MauSac = MauSactxt.Text,
                    Size = Sizecbx.Text,
                    DonGiaNhap = double.Parse(DonGiaNhaptxt.Text),
                    ChatLieu = ChatLieucbx.Text,
                    BaoHanh = BaoHanhcbx.Text,
                    DieuKien = DieuKiencbx.Text,
                    GhiChu = GhiChutxt.Text,
                    NgayKyGui = NgayKyGuip.Value,
                    ThoiGianKyGui = ThoiGianGuicbx.Text,
                    PhiKyGui = double.Parse(PhiKyGuitxt.Text)
                };
                KyGuiBUS.SuaKyGuiCho(kg);
                KyGuiChoControl_Load(sender, e);
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            ReText();
        }

        private void KyGuiChoControl_Load(object sender, EventArgs e)
        {
            MaGiaycbx_Load();
            MaNhanViencbx_Load();
            MaKhachHangcbx_Load();
            AdminGrV.DataSource = KyGuiBUS.LayDSKyGuiCho();
        }

        private void ThoiGianGuicbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tmp = "";
            string tmp2 = ThoiGianGuicbx.SelectedItem as string;
            int tong = 0;
            for (int i = 0; i < tmp2.Length; i++)
            {
                if (tmp2[i] == ' ') break;
                tmp = tmp + tmp2[i];
            }
            tong = int.Parse(tmp) * 30000;
            PhiKyGuitxt.Text = tong.ToString();
        }
    }
}
