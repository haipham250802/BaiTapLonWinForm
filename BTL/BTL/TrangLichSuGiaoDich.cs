using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace BTL
{
    public partial class TrangLichSuGiaoDich : Form
    {
        MainForm mainForm;
        List<LichSuGiaoDich> listLSGD = new List<LichSuGiaoDich>();
        DataTable dt;
        DataView dv;
        public TrangLichSuGiaoDich()
        {
            InitializeComponent();

        }
        private void fillDataTable(List<LichSuGiaoDich> LSGD)
        {
            foreach (var lsgd in LSGD)
            {
                dt.Rows.Add(lsgd.MaSanPham, lsgd.MaHoaDon, lsgd.TenSanPham, lsgd.TenKhachHang, lsgd.NgayMua, lsgd.SoLuong, lsgd.GiaSanPham, lsgd.TongGia);
            }
        }
        private void TrangLichSuGiaoDich_Load(object sender, EventArgs e)
        {
            mainForm = new MainForm();

            System.IO.StreamReader readLSGD = new System.IO.StreamReader("LichSuGiaoDich.json");
            string strLSGD = readLSGD.ReadToEnd();
            readLSGD.Close();

            List<LichSuGiaoDich> dsLSGD = JsonConvert.DeserializeObject<List<LichSuGiaoDich>>(strLSGD);
            listLSGD = dsLSGD;

            dt = new DataTable();
            dt.Columns.Add("MaSanPham");
            dt.Columns.Add("MaHoaDon");
            dt.Columns.Add("TenSanPham");
            dt.Columns.Add("TenKhachHang");
            dt.Columns.Add("NgayMua");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("GiaSanPham");
            dt.Columns.Add("TongGia");
            

            fillDataTable(listLSGD);
            dv = new DataView(dt);

            DGVlichsugiaodich.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVlichsugiaodich.DataSource = dv;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }

        private void tbtimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbtimkiem.Text))
                {
                    MessageBox.Show("Vui lòng nhập vào mã hóa đơn !");
                }
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dv.RowFilter = string.Format("MaHoaDon Like '%{0}%'", tbtimkiem.Text);
            DGVlichsugiaodich.DataSource = dv;
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            listLSGD.Clear();
            DGVlichsugiaodich.DataSource = null;
            DGVlichsugiaodich.DataSource = listLSGD;

            string LSGD = JsonConvert.SerializeObject(listLSGD);
            System.IO.File.WriteAllText("LichSuGiaoDich.json", LSGD);
        }
    }
}
