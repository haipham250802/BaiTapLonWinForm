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
    public partial class MainForm : Form
    {
        TrangThanhToan trangThanhtoan;
        TrangLichSuGiaoDich trangLichSuGiaoDich;
        DanhSachSanPham danhSachSanPham;
        TrangDangNhap trangDangNhap;
        TrangThongKe trangThongKe;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            trangThanhtoan = new TrangThanhToan();
            trangThanhtoan.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trangDangNhap = new TrangDangNhap();
            trangDangNhap.Show();
           // this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trangLichSuGiaoDich = new TrangLichSuGiaoDich();
            trangLichSuGiaoDich.Show();
           // this.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            trangThongKe = new TrangThongKe();
            trangThongKe.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
           
        }

       
    }
}
