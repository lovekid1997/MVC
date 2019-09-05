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
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        QLBanSachEntities5 db = new QLBanSachEntities5();
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f,int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            decimal idOrPrice = 0;
            bool check = decimal.TryParse(f["txtTimKiem"], out idOrPrice);
            if(check && idOrPrice > 0)
            {
                List<SAch> lstKQTK1 = db.SAches.Where(o => o.MaSach == idOrPrice).ToList();
                if(lstKQTK1.Count == 1)
                {
                    ViewBag.ThongBao = "Tìm theo mã sách = " + idOrPrice;
                    return View(lstKQTK1.ToPagedList(pageNumber, pageSize));
                }
                    pageSize = 12;
                    lstKQTK1 = db.SAches.Where(o => o.GiaBan == idOrPrice).ToList();
                    ViewBag.ThongBao = "Tìm theo giá bán = " + string.Format("{0:0,0 } VNĐ", idOrPrice ) ;
                    return View(lstKQTK1.ToPagedList(pageNumber,pageSize));
            }
            
            
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<SAch> lstKQTK = db.SAches.Where(n => n.TenSach.Contains(sTuKhoa)).ToList();
    
            if (lstKQTK.Count == 0 )
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào!";
                return View(db.SAches.OrderBy(n => n.GiaBan).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));

        }
        [HttpGet]
        public ActionResult KetQuaTimKiem(string sTuKhoa, int? page)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<SAch> lstKQTK = db.SAches.Where(n => n.TenSach.Contains(sTuKhoa)).ToList();
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào!";
                return View(db.SAches.OrderBy(n => n.GiaBan).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));

        }






        [HttpGet]
        public ActionResult KetQuaTimKiemCD(string sTuKhoa, int? page)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<ChuDe> lstCD = db.ChuDes.Where(n => n.TenChuDe.Contains(sTuKhoa)).ToList();
            int pageSize = 8;
            int pageNumber = page ?? 1;
            if(lstCD.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy kết quả tương ứng!";
                return View(db.ChuDes.OrderBy(n=>n.TenChuDe).ToPagedList(pageNumber,pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy" + lstCD.Count() + " kết quả.";
            return View(lstCD.OrderBy(n => n.TenChuDe).ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult KetQuaTimKiemCD(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<ChuDe> lstCD = db.ChuDes.Where(n => n.TenChuDe.Contains(sTuKhoa)).ToList();
            int pageSize = 8;
            int pageNumber = page ?? 1;
            if (lstCD.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy kết quả nào tương ứng !";
                return View(db.ChuDes.OrderBy(n => n.TenChuDe).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstCD.Count() + " kết quả.";
            return View(lstCD.OrderBy(n => n.TenChuDe).ToPagedList(pageNumber, pageSize));
        }


        [HttpGet]
        public ActionResult KetQuaTimKiemQL(string sTuKhoa, int? page)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<SAch> lstKQTK = db.SAches.Where(n => n.TenSach.Contains(sTuKhoa)).ToList();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào tương ứng !";
                return View(db.SAches.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count() + " kết quả.";
            return View(lstKQTK.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult KetQuaTimKiemQL(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<SAch> lstKQTK = db.SAches.Where(n => n.TenSach.Contains(sTuKhoa)).ToList();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào tương ứng !";
                return View(db.SAches.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count() + " kết quả.";
            return View(lstKQTK.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
        }

        
          [HttpGet]
        public ActionResult KetQuaTimKiemNXB(string sTuKhoa, int? page)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<NhaXuatBan> lstNXB = db.NhaXuatBans.Where(n => n.TenNXB.Contains(sTuKhoa)).ToList();
            int pageSize = 8;
            int pageNumber = page ?? 1;
            if (lstNXB.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào tương ứng !";
                return View(db.NhaXuatBans.OrderBy(n => n.TenNXB).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstNXB.Count() + " kết quả.";
            return View(lstNXB.OrderBy(n => n.TenNXB).ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult KetQuaTimKiemNXB(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
       
            List<NhaXuatBan> lstNXB = db.NhaXuatBans.Where(n => n.TenNXB.Contains(sTuKhoa)).ToList();
            int pageSize = 8;
            int pageNumber = page ?? 1;
            if (lstNXB.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào tương ứng !";
                return View(db.NhaXuatBans.OrderBy(n => n.TenNXB).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstNXB.Count() + " kết quả.";
            return View(lstNXB.OrderBy(n => n.TenNXB).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult KetQuaTimKiemKH(string sTuKhoa, int? page)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<KhachHang> lstKH = db.KhachHangs.Where(n => n.HoTen.Contains(sTuKhoa)).ToList();
            
            if (lstKH.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy khách hàng nào tương ứng !";
                return View(db.KhachHangs.OrderBy(n => n.HoTen));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKH.Count() + " kết quả.";
            return View(lstKH.OrderBy(n => n.HoTen));
        }
        [HttpPost]
        public ActionResult KetQuaTimKiemKH(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;

            List<KhachHang> lstKH = db.KhachHangs.Where(n => n.HoTen.Contains(sTuKhoa)).ToList();

            if (lstKH.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào tương ứng !";
                return View(db.KhachHangs.OrderBy(n => n.HoTen));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKH.Count() + " kết quả.";
            return View(lstKH.OrderBy(n => n.HoTen));
        }


    }
}

