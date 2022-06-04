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
    public partial class TrangThongKe : Form
    {
        MainForm mainForm;
        List<LichSuGiaoDich> listLSGD = new List<LichSuGiaoDich>();
        TrangLichSuGiaoDich TLSGD;
        DataTable dt;
        DataTable dt2;
        MainData mainData;
       
        public TrangThongKe()
        {
            InitializeComponent();
        }

       
        private void TrangThongKe_Load(object sender, EventArgs e)
        {
            DataTable dataTableSP = new DataTable();
            mainForm = new MainForm();

            mainData = new MainData();
            dataTableSP = mainData.HienThiTatCaSanPham();
           
            comboBox1.DataSource = dataTableSP;
            comboBox1.DisplayMember = "TenSanPham";
           

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

            dt2 = new DataTable();
            dt2.Columns.Add("MaSP");
            dt2.Columns.Add("MaHD");
            dt2.Columns.Add("TSP");
            dt2.Columns.Add("TKH");
            dt2.Columns.Add("NM");
            dt2.Columns.Add("SL");
            dt2.Columns.Add("Gia");
            dt2.Columns.Add("Tonggia");

          //  DGVtrangthongke.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e) // tab2
        {
            dt2.Clear();
            dgvthongke2.Refresh();
            int n = listLSGD.ToArray().Length;
            string tensp = comboBox1.Text;
            float tongg = 0;
            for (int i = 0; i < n; i++)
            {
                if (listLSGD[i].TenSanPham == tensp)
                {
                    dt2.Rows.Add(listLSGD[i].MaSanPham, listLSGD[i].MaHoaDon, listLSGD[i].TenSanPham, listLSGD[i].TenKhachHang, listLSGD[i].NgayMua, listLSGD[i].SoLuong, listLSGD[i].GiaSanPham, listLSGD[i].TongGia);
                    tongg += listLSGD[i].TongGia;
                }
            }
            tbdoanhthu.Text = tongg.ToString();

           
            dgvthongke2.DataSource = dt2;
        }
        void addTenSP()
        {
            for(int i=0;i<listLSGD.ToArray().Length;i++)
            {
                
            }    
        }    
        private void button1_Click_1(object sender, EventArgs e) // btn tab1
        {
            TLSGD = new TrangLichSuGiaoDich();
            tbsongay.Text = "";
            tbtongdoanhthu.Text = "";
            tbdoanhthutb.Text = "";

            DateTime inTime = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime outTime = Convert.ToDateTime(dateTimePicker2.Text);
            if (outTime >= inTime)
            {
                tbsongay.Text = outTime.Subtract(inTime).Days.ToString();
            }
            int songay = outTime.Subtract(inTime).Days;
            if (songay == 0)
            {
                songay = 1;
                tbsongay.Text = "1";
            }

            int n = listLSGD.ToArray().Length;
            int tong = 0;
            float TB;
            for (int i = 0; i < n; i++)
            {
                DateTime datetime = Convert.ToDateTime(listLSGD[i].NgayMua);
                if (datetime >= inTime && datetime <= outTime)
                {
                    dt.Rows.Add(listLSGD[i].MaSanPham, listLSGD[i].MaHoaDon, listLSGD[i].TenSanPham, listLSGD[i].TenKhachHang, listLSGD[i].NgayMua, listLSGD[i].SoLuong, listLSGD[i].GiaSanPham, listLSGD[i].TongGia);
                    int gia = Convert.ToInt32(listLSGD[i].TongGia);
                    tong += gia;
                }
            }

            TB = tong / songay;
            tbtongdoanhthu.Text = tong.ToString();
            tbdoanhthutb.Text = TB.ToString();

            // **************
            var s = (from i in listLSGD
                     group i by i.TenSanPham into grp
                     orderby grp.Count() descending
                     select grp.Key).First();
            textBox1.Text = s; // hien thi san pham nhieu nhat

            DGVtrangthongke.DataSource = null;
            DGVtrangthongke.DataSource = dt;
        }
    }
}
