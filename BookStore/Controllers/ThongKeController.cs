using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class ThongKeController : Controller
    {
        QLBanSachEntities5 db = new QLBanSachEntities5();
        
        // GET: ThongKe
        public ActionResult Index()
        {
            List<SAch> lstSAch = db.SAches.ToList();
            List<SAch> SortedList = lstSAch.OrderByDescending(o => o.LuotXem).ToList();
            List<SAch> ThongKe = new List<SAch>();
            int luotxemconlai = 0;
            for (int i = 0; i < 8; i++)
            {
                ThongKe.Add(SortedList[0]);
                SortedList.RemoveAt(0);
            }
            foreach(var item in SortedList)
            {
                luotxemconlai = luotxemconlai +Convert.ToInt32( item.LuotXem);
            }
            Session["conlai"] = luotxemconlai;
            Session.Timeout = 10;
            return View(ThongKe.OrderByDescending(n=>n.LuotXem).ToList());
        }
        //public ActionResult ThongKe1()
        //{

        //}
        public ActionResult ThongKe2()
        {
            List<KhachHang> lstSAch = db.KhachHangs.ToList();
            List<KhachHang> SortedList = lstSAch.OrderByDescending(o => o.LuotXem).ToList();
            List<KhachHang> ThongKe = new List<KhachHang>();
            int luotxemconlai = 0;
            for (int i = 0; i < 8; i++)
            {
                ThongKe.Add(SortedList[0]);
                SortedList.RemoveAt(0);
            }
            foreach (var item in SortedList)
            {
                luotxemconlai = luotxemconlai + Convert.ToInt32(item.LuotXem);
            }
            Session["conlai"] = luotxemconlai;
            Session.Timeout = 10;
            return View(ThongKe.OrderByDescending(n => n.LuotXem).ToList());
        }


    }
}