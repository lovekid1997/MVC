using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Models;
namespace BookStore.Models
{
    public class GioHang
    {
        //private int imaSP;

        //public int ImaSP { get => imaSP; set => imaSP = value; }
        public int imaSach { get; set; }
        public string stenSach { get; set; }
        public  string sHinhAnh { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double  dThanhTien
        {
            get
            {
                return iSoLuong * dDonGia;
            }
        }
        QLBanSachEntities5 db = new QLBanSachEntities5();
        public GioHang(int MaSach)
        {
            imaSach = MaSach;
            SAch sach = db.SAches.Single(n => n.MaSach == imaSach);
            stenSach = sach.TenSach;
            sHinhAnh = sach.AnhBia;
            dDonGia = double.Parse( sach.GiaBan.ToString());
            iSoLuong = 1;
        }

    }
}