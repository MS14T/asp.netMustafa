using mustafa24.Models.DateContext;
using mustafa24.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace mustafa24.Controllers
{
    public class HizmetController : Controller
    {
        private mustafa24Context db=new mustafa24Context();
        // GET: Hizmet
        public ActionResult Index()
        {
            return View(db.Hizmet.ToList());
        }
        public ActionResult Create() 
        {
            return  View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Hizmet hizmet, HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);       // logo isminin atanması boyutunun belirlenmesi.
                    string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/hizmet/" + logoname);

                    hizmet.ResimURL = "/Uploads/hizmet/" + logoname;
                }
                db.Hizmet.Add(hizmet);
                db.SaveChanges();
                return RedirectToAction("Index"); // eklemeden sonra indexe dön.
            }
            return View(hizmet);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek Hizmet Bulunamadı.";
            }
            var hizmet=db.Hizmet.Find(id);
            if (hizmet == null)
            {
                return HttpNotFound();
            }
            return View(hizmet) ;
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int? id, Hizmet hizmet, HttpPostedFileBase ResimUrl) 
        {
            if(ModelState.IsValid) 
            {
                var h = db.Hizmet.Where(x => x.HizmetId == id).SingleOrDefault();
                if (ResimUrl!= null) 
                {
                    if (System.IO.File.Exists(Server.MapPath(h.ResimURL))) //daha önce kayıtlı dosya var mı kontrol ediyoruz.
                    {
                        System.IO.File.Delete(Server.MapPath(h.ResimURL)); //varsa sil o dosyayı.
                    }
                    WebImage img = new WebImage(ResimUrl.InputStream);
                    FileInfo imginfo = new FileInfo(ResimUrl.FileName);

                    // logo isminin atanması boyutunun belirlenmesi.
                    string hizmetname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/hizmet/" + hizmetname);

                    h.ResimURL = "/Uploads/hizmet/" + hizmetname;
                }
                h.Baslik = hizmet.Baslik;
                h.Aciklama = hizmet.Aciklama;//editlerin veri tabanına aktarılması.
                db.SaveChanges() ;
                return  RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int? id)          // silme işlemi.
        {
            if (id == null) 
            {
                return HttpNotFound();
            }
            var h = db.Hizmet.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            db.Hizmet.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}