using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class GioHangController : Controller
    {
        QLBanSachEntities5 db = new QLBanSachEntities5();
        // GET: GioHang
        //Lay gio hang
        #region
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //neu gio hang chua ton tai, khoi tao list gio hang
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //them gio hang 
        public ActionResult ThemGioHang(int iMaSach, string strUrl)
        {
            SAch sach = db.SAches.SingleOrDefault(n => n.MaSach == iMaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            //kiemtra sach nay da ton tai trong ssesion chua
            GioHang sanpham = lstGioHang.Find(n => n.imaSach == iMaSach);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMaSach);
                lstGioHang.Add(sanpham);
                return Redirect(strUrl);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strUrl);
            }

        }
        //cap nhat gio hang
        public ActionResult CapNhatGioHang(int iMaSP, FormCollection f)
        {
            //kiem tra ma sp
            SAch sach = db.SAches.SingleOrDefault(n => n.MaSach == iMaSP);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.imaSach == iMaSP);
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("GioHang");
        }
        //xoa gio hang
        public ActionResult XoaGioHang(int iMaSP)
        {
            SAch sach = db.SAches.SingleOrDefault(n => n.MaSach == iMaSP);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.imaSach == iMaSP);
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.imaSach == iMaSP);

            }
            if(lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult GioHang()
        {

            if(Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            
            return View(lstGioHang);
        }
        //tinh tong so luong va tong tien
        public double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.dThanhTien);

            }
            return dTongTien;
        }
        public double TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);

            }
            return iTongSoLuong;
        }

        public ActionResult GioHangPartial()
        {
            if(TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }

        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();

            return View(lstGioHang);
        }
        #endregion

        #region
        [HttpPost]
        public ActionResult DatHang()
        {
            //Kiem tra dang nhap
            if(Session["TaiKhoan"] == null )
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            //kiem tra gio hang
            if(Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //them don hang
            DonHang ddh = new DonHang();
            KhachHang kh = (KhachHang) Session["TaiKhoan"];
            List<GioHang> gh = LayGioHang();
            ddh.MaKH = kh.MaKH;
            ddh.NgayDat = DateTime.Now;
            db.DonHangs.Add(ddh);
            db.SaveChanges();
            //them chi tiet don hang
            foreach(var item in gh)
            {
                ChiTietDonHang ctDH = new ChiTietDonHang();
                ctDH.MaDonHang = ddh.MaDonHang;
                ctDH.MaSach = item.imaSach;
                ctDH.SoLuong = item.iSoLuong;
                ctDH.DonGia = item.dDonGia;
                db.ChiTietDonHangs.Add(ctDH);
                
            }
            db.SaveChanges();
            Session.Remove("GioHang");
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}