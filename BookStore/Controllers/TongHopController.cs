using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class TongHopController : Controller
    {
        // GET: TongHop
        public ActionResult HuongDan()
        {
            return View();
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
    }
}