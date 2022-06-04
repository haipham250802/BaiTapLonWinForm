using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    
    public partial class TrangHoaDon : Form
    {
        TrangThanhToan thanhToan;
        public TrangHoaDon()
        {
            InitializeComponent();
        }

        private void TrangHoaDon_Load(object sender, EventArgs e)
        {
            thanhToan = new TrangThanhToan();
           // lbhoten.Text = thanhToan.tenkhachhang;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            thanhToan.Show();
            this.Hide();
        }
    }
}
