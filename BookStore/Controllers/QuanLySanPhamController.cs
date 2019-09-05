using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using PagedList;
using PagedList.Mvc;
namespace BookStore.Controllers
{
    public class QuanLySanPhamController : Controller   
    {

        // GET: QuanLySanPham
        QLBanSachEntities5 db = new QLBanSachEntities5();
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page??1);
            return View(db.SAches.ToList().OrderByDescending(n=>n.MaSach).ToPagedList(pageNumber,pageSize));
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {

            ViewBag.MaChuDe = new SelectList(  db.ChuDes.ToList().OrderBy(n=>n.TenChuDe),"MaChuDe","TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n=>n.TenNXB), "MaNXB", "TenNXB");

            return View();
        }
        [HttpPost]
        [ValidateInput( false)]
        public ActionResult ThemMoi(SAch sach,HttpPostedFileBase fileUpload)
        {
            
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Chọn hình ảnh";
                return View();
            }
            //them vao csdl
            if(ModelState.IsValid )
            {
                //Luu ten file
                var fileName = Path.GetFileName(fileUpload.FileName);
                //luu duong dan
                var path = Path.Combine(Server.MapPath("~/imgSP"), fileName);
                //kiem tra hinh anh da ton tai chua
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại!";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                sach.AnhBia = fileUpload.FileName;
                db.SAches.Add(sach);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        //chinhsua
        [HttpGet]
        public ActionResult ChinhSua(int MaSach)
        {
            
            // lay sach theo ma sach
            SAch sach = db.SAches.SingleOrDefault(n => n.MaSach == MaSach);
            if(sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", sach.MaNXB);
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe", sach.MaChuDe);
        
            return View(sach);
        }
        [HttpPost]
        [ValidateInput(false)]
  
        public ActionResult ChinhSua(SAch sach,FormCollection  f )
        {

            //them vao csdl
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhật trong model
                db.Entry(sach).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", sach.MaNXB);
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe", sach.MaChuDe);
           

            return RedirectToAction("Index");
        }
        public ActionResult HienThi(int MaSach)
        {
            SAch sach = db.SAches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
        [HttpGet]
        public ActionResult Xoa( int MaSach)
        {
            SAch sach = db.SAches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
        [HttpPost,ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaSach)
        {
            SAch sach = db.SAches.SingleOrDefault(n => n.MaSach == MaSach);
            if(sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.SAches.Remove(sach);
            db.SaveChanges();
 
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult ThemChuDe()
        {
            return View();
        }
        [HttpPost]

        public ActionResult ThemChuDe(ChuDe cd)
        {
            if (ModelState.IsValid)
            {
                db.ChuDes.Add(cd);
                db.SaveChanges();

            }

            return RedirectToAction("XemChuDe");
        }

        [HttpGet]
        public ActionResult ThemNXB()
        {
            return View();
        }
        [HttpPost]

        public ActionResult ThemNXB(NhaXuatBan nxb)
        {
            if (ModelState.IsValid)
            {
                db.NhaXuatBans.Add(nxb);
                db.SaveChanges();

            }

            return RedirectToAction("XemNXB");
        }

        public ActionResult XemChuDe()
        {

            return View(db.ChuDes.OrderByDescending(n=>n.MaChuDe).ToList());
        }
       
        [HttpGet]
        public ActionResult ChinhSuaCD(int MaCD)
        {
            // lay sach theo ma sach
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaCD);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(cd);
        }
        [HttpPost]

        public ActionResult ChinhSuaCD(ChuDe cd)
        {
            //them vao csdl
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhật trong model
                db.Entry(cd).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("XemChuDe");
        }
        public ActionResult XemNXB()
        {

            return View(db.NhaXuatBans.OrderByDescending(n=>n.MaNXB).ToList());
        }

        [HttpGet]
        public ActionResult ChinhSuaNXB(int MaNXB)
        {
            // lay sach theo ma sach
            NhaXuatBan nxb = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nxb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nxb);
        }
        [HttpPost]

        public ActionResult ChinhSuaNXB(NhaXuatBan nxb)
        {
            //them vao csdl
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhật trong model
                db.Entry(nxb).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("XemNXB");
        }
 
        public ActionResult XemThongTinKhachHang()
        {

            return View(db.KhachHangs.ToList());
        }
        [HttpGet]
        public ActionResult SuaThongTin(int maKH)
        {
            KhachHang kh = db.KhachHangs.Single(n => n.MaKH == maKH);
            return View(kh);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaThongTin(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhật trong model
                db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("XemThongTinKhachHang");
        }
        public ActionResult HienThiThongTin(int maKH)
        {
            KhachHang kh = db.KhachHangs.Single(n => n.MaKH == maKH);

            return View(kh);
        }


        public ActionResult XemDonHang()
        {
            return View(db.DonHangs.ToList());
        }
        public ActionResult HienThiDonHang(int maDH)
        {
            List<ChiTietDonHang> lstCTDH = db.ChiTietDonHangs.Where(n => n.MaDonHang == maDH).ToList();
            return View(lstCTDH.ToList());
        }
        //[HttpGet]
        //public ActionResult ChinhSua(int maDH)
        //{

        //}
    }


}