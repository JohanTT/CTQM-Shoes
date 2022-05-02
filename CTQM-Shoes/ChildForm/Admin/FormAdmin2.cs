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
    public partial class FormAdmin2 : Form
    {
        public FormAdmin2()
        {
            InitializeComponent();
        }

        private void KhachHangbtn_Click(object sender, EventArgs e)
        {
            Controlpn.Controls.Clear();
            KhachHangControl KhachHang = new KhachHangControl();
            Controlpn.Controls.Add(KhachHang);
        }

        private void NhanVienbtn_Click(object sender, EventArgs e)
        {
            Controlpn.Controls.Clear();
            NhanVienControl NhanVien = new NhanVienControl();
            Controlpn.Controls.Add(NhanVien);
        }

        private void MatHangbtn_Click(object sender, EventArgs e)
        {
            Controlpn.Controls.Clear();
            MatHangControl MatHang = new MatHangControl();
            Controlpn.Controls.Add(MatHang);
        }

        private void KyGuibtn_Click(object sender, EventArgs e)
        {
            Controlpn.Controls.Clear();
            KyGuiform KyGui = new KyGuiform();
            Controlpn.Controls.Add(KyGui);
        }

        private void KGCbtn_Click(object sender, EventArgs e)
        {
            Controlpn.Controls.Clear();
            KyGuiChoControl KyGuiCho = new KyGuiChoControl();
            Controlpn.Controls.Add(KyGuiCho);
        }

        private void HoaDonbtn_Click(object sender, EventArgs e)
        {
            Controlpn.Controls.Clear();
            HoaDonControl HoaDon = new HoaDonControl();
            Controlpn.Controls.Add(HoaDon);
        }

        private void HDCbtn_Click(object sender, EventArgs e)
        {
            Controlpn.Controls.Clear();
            HoaDonChoControl HoaDonCho = new HoaDonChoControl();
            Controlpn.Controls.Add(HoaDonCho);
        }
    }
}
