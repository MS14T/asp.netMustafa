using mustafa24.Models;
using mustafa24.Models.DateContext;
using mustafa24.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace mustafa24.Controllers
{
    public class AdminController : Controller
    {
        mustafa24Context db= new mustafa24Context();
        // GET: Admin
        [Route("yonetimpaneli")]
        public ActionResult Index()
        {
            ViewBag.BlogSay = db.Blog.Count();
            ViewBag.KategoriSay=db.Kategori.Count();
            ViewBag.HizmetSay=db.Hizmet.Count();
            ViewBag.YorumSay=db.Yorum.Count();
            ViewBag.YorumOnay=db.Yorum.Where(x=>x.Onay==false).Count();
            var sorgu = db.Kategori.ToList();
            return View(sorgu);
        }
        [Route("yonetimpaneli/giris")]
        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var login=db.Admin.Where(x=>x.Eposta==admin.Eposta).SingleOrDefault();
            if (login.Eposta==admin.Eposta && login.Sifre==admin.Sifre)
            {
                Session["adminid"] = login.AdminId;
                Session["eposta"] = login.Eposta;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Uyari = "Kullanıcı adı ya da şifre yanlış";
            return View(admin);

        }
        public ActionResult Logout()
        {
            Session["adminid"] = null;
            Session["eposta"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");

        }
    }
}