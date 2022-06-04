using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
namespace BTL
{
    public partial class TrangThanhToan : Form
    {
        MainData mainData;
        Ma ma;
        MaKhachHang mkHang;
        TrangThanhtoan TTT;
        TrangHoadon THD;

        LichSuGiaoDich LSGD;
        TrangHoaDon trangHoaDon;
        MainForm mainForm;

        DataTable dataTableGia;
        List<MaKhachHang> listmakhachhang = new List<MaKhachHang>();
        List<LichSuGiaoDich> ListLSGD = new List<LichSuGiaoDich>();
        List<TrangThanhtoan> ListTTT = new List<TrangThanhtoan>();
        List<TrangHoadon> ListTHD = new List<TrangHoadon>();
        List<Ma> ListMa = new List<Ma>();

        int demMHD = 1020;
        int demMKH = 1020;
        int index;
        float gia;
        float tonggia;
        float ThanhTien = 0;
        int dem = 0;



        public TrangThanhToan()
        {
            InitializeComponent();
        }
        private void TrangThanhToan_Load(object sender, EventArgs e)
        {
            tbmahoadon.Text = "MHD" + demMHD;
            tbMakhachhang.Text = "MKH" + demMKH;
            DataTable dataTableSP = new DataTable();

            mainData = new MainData();
            mainForm = new MainForm();
            dataTableSP = mainData.HienThiTatCaSanPham();

            cbbtensp.DataSource = dataTableSP;
            cbbtensp.DisplayMember = "TenSanPham";

            string tensanpham = cbbtensp.Text;
            dataTableGia = new DataTable();
            dataTableGia = mainData.HienThiGiaSanPham(tensanpham);
            tbgia.DataSource = dataTableGia;
            tbgia.DisplayMember = "GiaSanPham";

            tbMaSanPham.DataSource = dataTableGia;
            tbMaSanPham.DisplayMember = "MaSanPham";

            cbbtensp.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbbtensp.AutoCompleteSource = AutoCompleteSource.ListItems;


            if (System.IO.File.Exists("LichSuGiaoDich.json"))
            {
                System.IO.StreamReader readLSGD = new System.IO.StreamReader("LichSuGiaoDich.json");
                string strLSGD = readLSGD.ReadToEnd();
                readLSGD.Close();
                List<LichSuGiaoDich> dsLSGD = JsonConvert.DeserializeObject<List<LichSuGiaoDich>>(strLSGD);
                ListLSGD = dsLSGD;
            }
            if (System.IO.File.Exists("Ma.json"))
            {
                System.IO.StreamReader readMa = new System.IO.StreamReader("Ma.json");
                string strMa = readMa.ReadToEnd();
                readMa.Close();
                List<Ma> dsMa = JsonConvert.DeserializeObject<List<Ma>>(strMa);
                ListMa = dsMa;
            }
            for (int i = 0; i < ListMa.ToArray().Length; i++)
            {
                if (tbMakhachhang.Text == ListMa[i].makhachhang)
                {
                    demMKH++;
                    tbMakhachhang.Text = "MKH" + demMKH;
                }
            }

            for (int i = 0; i < ListMa.ToArray().Length; i++)
            {
                if (tbmahoadon.Text == ListMa[i].mahoadon)
                {
                    demMHD++;
                    tbmahoadon.Text = "MHD" + demMHD;
                }
            }
            dem = ListLSGD.ToArray().Length - 1;
        }
        private bool Check()
        {
            if (string.IsNullOrWhiteSpace(tbKhachHang.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbSoLuong.Text))
            {
                return false;
            }
            return true;
        }
        private void ReturnWhiteSpace()
        {
            tbKhachHang.Text = "";
            tbSoLuong.Text = "";
        }
        private void btnthemsp_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                string makhachhang = "MKH" + demMKH;
                string mahoadon = tbmahoadon.Text;
                string masanpham = tbMaSanPham.Text;
                string tenkhachhang = tbKhachHang.Text;
                string ngaymua = dtpNgayMua.Text;
                string tensanpham = cbbtensp.Text;
                int soluong = int.Parse(tbSoLuong.Text);
                float gia = float.Parse(tbgia.Text);
                float tonggia = soluong * gia;
                ThanhTien += tonggia;
                TTT = new TrangThanhtoan(makhachhang, masanpham, mahoadon, tensanpham, tenkhachhang, ngaymua, soluong, gia, tonggia);
                LSGD = new LichSuGiaoDich(masanpham, mahoadon, tensanpham, tenkhachhang, ngaymua, soluong, gia, tonggia);
                mkHang = new MaKhachHang(makhachhang);
                ma = new Ma(makhachhang, mahoadon);
                THD = new TrangHoadon(tensanpham, soluong, ngaymua, gia, tonggia);

                ListTTT.Add(TTT);
                ListLSGD.Add(LSGD);
                ListMa.Add(ma);
                listmakhachhang.Add(mkHang);
                ListTHD.Add(THD);

                DGVTrangthanhtoan.DataSource = null;
                DGVTrangthanhtoan.DataSource = ListTTT;

                string strma = JsonConvert.SerializeObject(ListMa);
                System.IO.File.WriteAllText("Ma.json", strma);
                tbMakhachhang.Text = "MKH" + demMKH;
                dem++;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập vào thông tin !");
            }
        }
        private void cbbtensp_TextChanged(object sender, EventArgs e)
        {
            string tensanpham = cbbtensp.Text;
            dataTableGia = mainData.HienThiGiaSanPham(tensanpham);
            tbgia.DataSource = dataTableGia;
            tbgia.DisplayMember = "GiaSanPham";


            tbMaSanPham.DataSource = dataTableGia;
            tbMaSanPham.DisplayMember = "MaSanPham";

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
          
                if (MessageBox.Show("Bạn đã chắc chắn nhập đủ số mặt hàng rồi chứ ?", "Question:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    demMKH++;
                    demMHD++;
                    tbmahoadon.Text = "MHD" + demMHD;
                    trangHoaDon = new TrangHoaDon();
                    trangHoaDon.Show();

                    string Tenkhachhang = tbKhachHang.Text;
                    trangHoaDon.label4.Text += Tenkhachhang;

                    trangHoaDon.dataGridView1.AutoGenerateColumns = true;
                    trangHoaDon.dataGridView1.DataSource = ListTHD;

                    trangHoaDon.textBox1.Text = ThanhTien.ToString();

                    string LSGD = JsonConvert.SerializeObject(ListLSGD);
                    System.IO.File.WriteAllText("LichSuGiaoDich.json", LSGD);

                    ReturnWhiteSpace();
                    ListTTT.Clear();

                    DGVTrangthanhtoan.DataSource = null;
                    DGVTrangthanhtoan.DataSource = ListTTT;

                
            }
            else
            {
                MessageBox.Show("Vui lòng nhập vào thông tin !");
            }

        }

        private void DGVTrangthanhtoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                tbMaSanPham.Text = DGVTrangthanhtoan[1, index].Value.ToString();
                tbMakhachhang.Text = DGVTrangthanhtoan[0, index].Value.ToString();
                tbmahoadon.Text = DGVTrangthanhtoan[2, index].Value.ToString();
                cbbtensp.Text = DGVTrangthanhtoan[3, index].Value.ToString();
                tbKhachHang.Text = DGVTrangthanhtoan[4, index].Value.ToString();
                dtpNgayMua.Text = DGVTrangthanhtoan[5, index].Value.ToString();
                tbSoLuong.Text = DGVTrangthanhtoan[6, index].Value.ToString();
            }
        }
        int k;
        private void btbThayDoi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thay đổi ?", "Question:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gia = float.Parse(tbgia.Text);
                float tienthaydoi = ListTTT[index].TongGia;
                tonggia = float.Parse(tbSoLuong.Text) * gia;
                ThanhTien = ThanhTien - tienthaydoi + tonggia;

                ListTTT[index].MaKhachHang = tbMakhachhang.Text;
                ListTTT[index].MaSanPham = tbMaSanPham.Text;
                ListTTT[index].MaHoaDon = tbmahoadon.Text;
                ListTTT[index].TenSanPham = cbbtensp.Text;
                ListTTT[index].TenKhachHang = tbKhachHang.Text;
                ListTTT[index].NgayMua = dtpNgayMua.Text;
                ListTTT[index].GiaSanPham = float.Parse(tbgia.Text);
                ListTTT[index].SoLuong = int.Parse(tbSoLuong.Text);
                ListTTT[index].TongGia = tonggia;

                int k = index + dem - 1;
                ListLSGD[k].MaSanPham = tbMaSanPham.Text;
                ListLSGD[k].TenSanPham = cbbtensp.Text;
                ListLSGD[k].GiaSanPham = float.Parse(tbgia.Text);
                ListLSGD[k].TongGia = tonggia;
                ListLSGD[k].SoLuong = int.Parse(tbSoLuong.Text);
                ListLSGD[k].NgayMua = dtpNgayMua.Text;

                ListTHD[index].TenSanPham = cbbtensp.Text;
                ListTHD[index].SoLuong = Convert.ToInt32(tbSoLuong.Text);
                ListTHD[index].NgayMua = dtpNgayMua.Text;
                ListTHD[index].TongGia = tonggia;
                ListTHD[index].GiaSanPham = Convert.ToInt32(tbgia.Text);

                DGVTrangthanhtoan.DataSource = null;
                DGVTrangthanhtoan.DataSource = ListTTT;

                string LSGD = JsonConvert.SerializeObject(ListLSGD);
                System.IO.File.WriteAllText("LichSuGiaoDich.json", LSGD);
            }
        }

        private void tbKhachHang_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbKhachHang.Text))
                {
                    MessageBox.Show("Vui lòng nhập vào tên khách hàng !");
                    tbKhachHang.Focus();
                }
            }
            catch (Exception) { }
        }

        private void tbSoLuong_Leave(object sender, EventArgs e)
        {
            try
            {
                int sl = Convert.ToInt32(tbSoLuong.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Số lượng nhập vào phải là chữ số ,xin vui lòng nhập !");
                tbSoLuong.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Question:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                float tienthaydoi = ListTTT[index].TongGia;
                ListTTT.Remove(ListTTT[index]);
                ListLSGD.Remove(ListLSGD[k]);

                ThanhTien = ThanhTien - tienthaydoi;

                DGVTrangthanhtoan.DataSource = null;
                DGVTrangthanhtoan.DataSource = ListTTT;

                tbSoLuong.Text = "";
            }
        }
        private void tbMaSanPham_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbmahoadon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}