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
    public partial class DanhSachSanPham : Form
    {
        MainData mainData;
        TrangDangNhap dangNhap;

        int index;
        public DanhSachSanPham()
        {
            InitializeComponent();
        }

        private void DanhSachSanPham_Load(object sender, EventArgs e)
        {
            dangNhap = new TrangDangNhap();
            mainData = new MainData();
            try
            {
                DGVdssp.DataSource = mainData.HienThiTatCaSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool check()
        {
            if(string.IsNullOrWhiteSpace(tbthemmsp.Text))
            {
                return false;
            }    
            if(string.IsNullOrWhiteSpace(tbthemtsp.Text))
            {
                return false;
            }    
            if(string.IsNullOrWhiteSpace(tbthemgiasp.Text))
            {
                return false;
            }
            return true;
        }
        void returnWhiteSpace()
        {
            tbthemmsp.Text = "";
            tbthemgiasp.Text = "";
            tbthemtsp.Text = "";
        }
        private void btnthemspInds_Click(object sender, EventArgs e)
        {
            if (check())
            {
                string mahoadon = tbthemmsp.Text;
                string tensp = tbthemtsp.Text;
                float giasp = float.Parse(tbthemgiasp.Text);
                SanPham sp = new SanPham(mahoadon, tensp, giasp);
                if (mainData.ThemSanPham(sp))
                {
                    DGVdssp.DataSource = mainData.HienThiTatCaSanPham();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công !");
                }
                returnWhiteSpace();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dangNhap.Show();
            this.Close();
        }

        private void DGVdssp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            tbthemmsp.Text = DGVdssp[0, index].Value.ToString();
            tbthemtsp.Text = DGVdssp[1, index].Value.ToString();
            tbthemgiasp.Text = DGVdssp[2, index].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thay đổi ?", "Question:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string masp = tbthemmsp.Text;
                string tensp = tbthemtsp.Text;
                float giasp = float.Parse(tbthemgiasp.Text);
                SanPham sp = new SanPham(masp, tensp, giasp);
                if (mainData.SuaSanPham(sp))
                {

                    DGVdssp.DataSource = mainData.HienThiTatCaSanPham();
                }
                else
                {
                    MessageBox.Show("Them san pham khong thanh cong !");
                }
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Question:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string masp = tbthemmsp.Text;
                if (mainData.XoaSanPham(masp))
                {
                    DGVdssp.DataSource = mainData.HienThiTatCaSanPham();
                }
                else
                {
                    MessageBox.Show("Xoa san pham khong thanh cong !");
                }
            }
        }
    }
}
