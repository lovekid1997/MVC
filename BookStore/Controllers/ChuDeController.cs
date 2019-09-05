using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class ChuDeController : Controller
    {

        QLBanSachEntities5 db = new QLBanSachEntities5();
        
        
        // GET: ChuDe
        public ActionResult ChuDePartial()
        {

            return PartialView(db.ChuDes.Take(5).ToList());
        }
        
        //Tìm sách theo chủ đề
        public ViewResult timSachTheoChuDe(int maChuDe = 0)
        {
            //Kiểm tra chủ đề tồn tại   
            ChuDe chude = db.ChuDes.SingleOrDefault(n => n.MaChuDe == maChuDe);

            ViewBag.lstChuDe = db.ChuDes.ToList();
            
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
                //Truy xuất danh sách theo chủ đề
                List<SAch> lstSach = db.SAches.Where(n => n.MaChuDe == maChuDe).OrderBy(n => n.GiaBan).ToList();
                if (lstSach.Count == 0)
                {
                    ViewBag.Sach = "Không có sách nào thuộc chủ đề này.";
                }

            ViewBag.TenChuDe = db.ChuDes.Single(n => n.MaChuDe == maChuDe).TenChuDe;

            return View(lstSach);
        }
        public ViewResult hienThiTatCaChuDe()
        {
            return View(db.ChuDes.ToList());
        }

    }
}