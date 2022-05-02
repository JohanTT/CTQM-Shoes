using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTQM_Shoes.ChildForm.GioHang
{
    public partial class FormXacNhan : Form
    {
        public FormXacNhan()
        {
            InitializeComponent();
        }

        public event EventHandler XacNhan;
        public int loai { get; set; } // 1 thanh toán bằng ví điện tử, 2 thanh toán bằng paypal
        public string MaKhachHangKT { get; set; }

        private void XacNhanMa_Load(object sender, EventArgs e)
        {
            if (loai == 1)
            {
                PTTTlb.Text = "Ví điện tử";
            }
            else if (loai == 2)
            {
                PTTTlb.Text = "PayPal";
            }
        }

        private void Check1btn_Click(object sender, EventArgs e)
        {
            Shoes2DataContext db = new Shoes2DataContext();
            if (loai == 1)
            {
                var thamchieu = (from kh in db.KHACH_HANGs
                                 where kh.MaKhachHang == MaKhachHangKT
                                 where kh.MaBaoMat == MaBaoMattxt.Text
                                 select kh).ToList();
                if (thamchieu.Count != 0)
                {
                    if (this.XacNhan != null)
                    {
                        this.XacNhan(this, e);
                    }
                    LInfor.Visible = false;
                    this.Close();
                }
                else
                {
                    LInfor.Visible = true;
                    MaBaoMattxt.Text = "";
                }
            }
            else if (loai == 2)
            {
                var thamchieu = (from kh in db.PAYPALs
                                 where kh.MaKhachHang == MaKhachHangKT
                                 where kh.MaBaoMat == MaBaoMattxt.Text
                                 select kh).ToList();
                if (thamchieu.Count != 0)
                {
                    if (this.XacNhan != null)
                    {
                        this.XacNhan(this, e);
                    }
                    LInfor.Visible = false;
                    this.Close();
                }
                else
                {
                    LInfor.Visible = true;
                    MaBaoMattxt.Text = "";
                }
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
