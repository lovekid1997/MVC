using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using PagedList;
using PagedList.Mvc;
namespace BookStore.Controllers
{
    public class SachController : Controller
    {
        QLBanSachEntities5 db = new QLBanSachEntities5();
        // GET: Sach


        public PartialViewResult SachMoiPartial()
        {
            var listSachMoi = db.SAches.Take(3).ToList();
            return PartialView(listSachMoi);
        }
        public ViewResult xemChiTiet(int maSach =0)
        {
            SAch sach = db.SAches.SingleOrDefault(n=>n.MaSach == maSach);
            if (sach == null)
            {
                //Tra ve trang bao loi
                Response.StatusCode = 404;
                return null;
            }
            if(Session["TaiKhoan"] != null)
            {
                KhachHang kh = (KhachHang) Session["TaiKhoan"];
                KhachHang kh1 = db.KhachHangs.Single(n => n.MaKH == kh.MaKH);
                if (kh1.LuotXem == null)
                    kh1.LuotXem = 1;
                else
                    kh1.LuotXem += 1;
                db.SaveChanges();
            }
            if(sach.LuotXem == null)
                sach.LuotXem = 1;
            else
                sach.LuotXem += 1;

            db.SaveChanges();

            ViewBag.TenChuDe = db.ChuDes.Single(n => n.MaChuDe == sach.MaChuDe).TenChuDe;
            ViewBag.NhaXuatBan = db.NhaXuatBans.Single(n => n.MaNXB == sach.MaNXB).TenNXB;
            return View(sach);
        }

        public ViewResult hienThiSachMoi(int? page)
        {   
            int pageSize = 6;
            //tao bien so trang
            int pageNumber = (page ?? 1);
            return View(db.SAches.Where(n => n.Moi == 1).ToList().OrderBy(n => n.GiaBan).ToPagedList(pageNumber, pageSize));
        }
    }
}