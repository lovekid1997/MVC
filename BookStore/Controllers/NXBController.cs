using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class NXBController : Controller
    {
        QLBanSachEntities5 db = new QLBanSachEntities5();
        // GET: NXB
        public PartialViewResult NXBPartial()
        {
            return PartialView(db.NhaXuatBans.Take(8).OrderBy(n => n.TenNXB).ToList());
        }
        //Hienthisachtheonhaxuatban
        public ViewResult hienThiTacCaNXB(int maNXB =0)
        {
            NhaXuatBan NXB = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == maNXB);
            ViewBag.lstNXB = db.NhaXuatBans.ToList();
            if (NXB == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Truy xuất danh sách theo NXB
            List<SAch> lstSach = db.SAches.Where(n => n.MaNXB == maNXB).OrderBy(n => n.GiaBan).ToList();
            if (lstSach.Count == 0)
            {
                ViewBag.Sach = "Không có sách nào thuộc nhà xuất bản này.";
            }
            ViewBag.TenNXB = db.NhaXuatBans.Single(n => n.MaNXB == maNXB).TenNXB;
            return View(lstSach);
        }

        public ViewResult hienThiDanhMucNXB()
        {
            return View(db.NhaXuatBans.ToList());
        }
    }
}