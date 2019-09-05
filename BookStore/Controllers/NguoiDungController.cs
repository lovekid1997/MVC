using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class NguoiDungController : Controller
    {
        QLBanSachEntities5 db = new QLBanSachEntities5();

        // GET: NguoiDung
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHang kh)
        {
            
            if (ModelState.IsValid)
            {
                //KHTT khtt = new KHTT();
                //khtt.MaKHTT = kh.MaKH;
                //insert du lieu
                db.KhachHangs.Add(kh);
                //db.KHTTs.Add(khtt);
                db.SaveChanges();
                return RedirectToAction("DangKyThanhCong");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
      
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
           
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if(sTaiKhoan == "admin"&& sMatKhau == "admin")
            {
                Session["TaiKhoan"] = kh;
                Session["admin"] = kh;
                return RedirectToAction("Index", "QuanLySanPham");
            }
            
            if(kh != null )
            {
                
                if (Session["GioHang"] is null)
                {
                    ViewBag.ThongBao = "Chúc mừng bạn đã đăng nhập thành công !";
                    Session.Add("TaiKhoan", kh);
                    //Session["TaiKhoan"] = kh;
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session.Add("TaiKhoan", kh);
                    //Session["TaiKhoan"] = kh;
                    return RedirectToAction("GioHang", "GioHang");
                }
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng !";
            return View();
        }

        public ActionResult DangKyThanhCong()
        {
            return View();
        }
        public ActionResult DangNhapThanhCong()
        {
           
            return View();
        }
        public ActionResult DangNhap1()
        {

            if (Session["TaiKhoan"] != null)
            {
                KhachHang kh = (KhachHang)Session["TaiKhoan"];
                ViewBag.ThongBao = kh.HoTen;
                return PartialView();
            }

            ViewBag.ThongBao = "Đăng Nhập";
            return PartialView();
        }
        [HttpGet]
        public ActionResult ThongTinKhachHang(int maKH)
        {
            KhachHang kh1 = db.KhachHangs.SingleOrDefault(n => n.MaKH == maKH);
            return View(kh1);
        }
        public ActionResult Thoat()
        {
            if (Session["TaiKhoan"] != null)
            {
                Session.Remove("TaiKhoan");
                Session.Remove("admin");
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public ActionResult SuaThongTin(int maKH)
        {
            KhachHang khachhang = db.KhachHangs.Single(n => n.MaKH == maKH);
            return View(khachhang);
        }
        [HttpPost]
                [ValidateInput(true)]
        public ActionResult SuaThongTin(KhachHang khachhang, FormCollection f)
        {

            if (ModelState.IsValid)
            {
                //Thực hiện cập nhật trong model
                db.Entry(khachhang).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            //db.KhachHangs.Single(n => n.MaKH == kh.MaKH).MatKhau = f["password"].ToString();
            //kh1.MatKhau = f["password"].ToString();
            //db.SaveChanges();

            return RedirectToAction("ThongTinKhachHang", new { @maKH = khachhang.MaKH } );
        }
        [HttpGet]
        public ActionResult LichSuMuaHang(int maKH)
        {
            List<DonHang> dh = db.DonHangs.Where(o => o.MaKH == maKH).ToList();
            
            List<ChiTietDonHang> ctdh = new List<ChiTietDonHang>();
            foreach(var item in dh)
            {
                List<ChiTietDonHang> ex = db.ChiTietDonHangs.Where(n => n.MaDonHang == item.MaDonHang).ToList();
                foreach(var item1 in ex)
                {
                    ctdh.Add(item1);
                }
            }
            
            //ChiTietDonHang ctdh = db.ChiTietDonHangs.Where(n => n.MaDonHang == dh.MaDonHang).ToList();
            return View(ctdh.ToList());
        }
    }
}