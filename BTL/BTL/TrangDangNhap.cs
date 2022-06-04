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

    public partial class TrangDangNhap : Form
    {
        DanhSachSanPham danhSachSanPham;
        MainForm mainForm;
        public TrangDangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbdangnhap.Text == "admin2002" && tbmatkhau.Text == "2002")
            {
                danhSachSanPham.Show();
                //  this.Close();
            }
            else
            {
                MessageBox.Show("Sai Tên Đăng Nhập Hoặc Mật Khẩu , Vui Lòng Nhập Lại !");
            }

        }

        private void TrangDangNhap_Load(object sender, EventArgs e)
        {
            danhSachSanPham = new DanhSachSanPham();
            mainForm = new MainForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            //this.Close();
        }

        private void tbdangnhap_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbdangnhap.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập");
                    tbdangnhap.Focus();
                }
            }
            catch (Exception) { }
        }

        private void tbmatkhau_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(tbmatkhau.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu");
                    tbmatkhau.Focus();
                }
            }
            catch (Exception) { }
        }

        private void TrangDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
