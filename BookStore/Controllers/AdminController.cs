using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BookStore.Models;
namespace BookStore.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        public ActionResult Admin()
        {
            if (Session["admin"] != null)
            {
                string sTaiKhoan = Request.Form["userName"];
                string sMatKhau = Request.Form["password"];
                if (sTaiKhoan == "admin" && sMatKhau == "admin")
                {
                    ViewBag.ThongBao = "Đăng nhập thành công!";
                    return RedirectToAction("Index", "QuanLySanPham");
                }
            }
            return View();
        }
    }
}