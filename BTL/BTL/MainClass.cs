using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL
{
    internal class SanPham
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public float GiaSanPham { get; set; }

        public SanPham(string msp, string tsp, float gsp)
        {
            this.MaSanPham = msp;
            this.TenSanPham = tsp;
            this.GiaSanPham = gsp;
        }
    }

    internal class KhachHang
    {
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
    }

    internal class HoaDon
    {

    }


    // ******************************************************************

    internal class TrangThanhtoan
    {
        public string MaKhachHang { get; set; }
        public string MaSanPham { get; set; }
        public string MaHoaDon { get; set; }
        public string TenSanPham { get; set; }
        public string TenKhachHang { get; set; }
        public string NgayMua { get; set; }
        public int SoLuong { get; set; }
        public float GiaSanPham { get; set; }
        public float TongGia { get; set; }
        public TrangThanhtoan() { }
        public TrangThanhtoan(string mkh, string msp, string mhd, string tsp, string tkh, string nm, int sl, float giasp, float tg)
        {
            this.MaHoaDon = mhd;
            this.TenSanPham = tsp;
            this.TenKhachHang = tkh;
            this.NgayMua = nm;
            this.SoLuong = sl;
            this.GiaSanPham = giasp;
            this.MaSanPham = msp;
            this.MaKhachHang = mkh;
            this.TongGia = tg;
        }

    }

    internal class LichSuGiaoDich
    {

        public string MaSanPham { get; set; }
        public string MaHoaDon { get; set; }
        public string TenSanPham { get; set; }
        public string TenKhachHang { get; set; }
        public string NgayMua { get; set; }
        public int SoLuong { get; set; }
        public float GiaSanPham { get; set; }
        public float TongGia { get; set; }
        public LichSuGiaoDich() { }
        public LichSuGiaoDich(string msp, string mhd, string tsp, string tkh, string nm, int sl, float giasp, float tg)
        {
            this.MaHoaDon = mhd;
            this.TenSanPham = tsp;
            this.TenKhachHang = tkh;
            this.NgayMua = nm;
            this.SoLuong = sl;
            this.GiaSanPham = giasp;
            this.MaSanPham = msp;
            this.TongGia = tg;
        }
    }
    internal class TrangHoadon
    {

        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public string NgayMua { get; set; }
        public float GiaSanPham { get; set; }
        public float TongGia { get; set; }
        public TrangHoadon() { }
        public TrangHoadon(string tsp, int sl, string nm, float g, float tg)
        {
            this.TenSanPham = tsp;
            this.SoLuong = sl;
            this.NgayMua = nm;
            this.GiaSanPham = g;
            this.TongGia = tg;
        }
    }
    //*****************************************
    internal class MaKhachHang
    {
        public string makhachhang;
        public MaKhachHang() { }
        public MaKhachHang(string mkh)
        {
            this.makhachhang = mkh;
        }
    }
    internal class MaHoaDon
    {
        public string makhachhang;
        public MaHoaDon() { }
        public MaHoaDon(string mkh)
        {
            this.makhachhang = mkh;
        }
    }
    internal class Ma
    {
        public string makhachhang;
        public string mahoadon;
        public Ma() { }
        public Ma(string mkh, string mhd)
        {
            this.makhachhang = mkh;
            this.mahoadon = mhd;
        }
    }
}
