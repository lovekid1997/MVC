using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        QLBanSachEntities5 db = new QLBanSachEntities5();
        public ActionResult Index(int? page)
        {
            //tao bien so san pham tren trang
            int pageSize = 6;
            //tao bien so trang
            int pageNumber = (page ?? 1);
            return View(db.SAches.ToList().OrderBy(n=>n.GiaBan).ToPagedList(pageNumber, pageSize));

        }


       
    }
}