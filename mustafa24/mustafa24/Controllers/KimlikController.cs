using mustafa24.Models.DateContext;
using mustafa24.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace mustafa24.Controllers
{
    public class KimlikController : Controller
    {
        mustafa24Context db= new mustafa24Context();
        // GET: Kimlik
        public ActionResult Index()
        {
            return View(db.Kimlik.ToList());
        }


        // GET: Kimlik/Edit/5
        public ActionResult Edit(int id)
        {
            var kimlik=db.Kimlik.Where(x=>x.KimlikId==id).SingleOrDefault();
            return View(kimlik);
        }

        // POST: Kimlik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Kimlik kimlik, HttpPostedFileBase LogoURL)
        {
            if(ModelState.IsValid)
            {
                var k = db.Kimlik.Where(x=>x.KimlikId == id).SingleOrDefault();

                if(LogoURL!=null)
                {
                    if(System.IO.File.Exists(Server.MapPath(k.LogoURL))) //daha önce kayıtlı dosya var mı kontrol ediyoruz.
                    {  
                        System.IO.File.Delete(Server.MapPath(k.LogoURL)); //varsa sil o dosyayı.
                    }
                    WebImage img= new WebImage(LogoURL.InputStream);
                    FileInfo imginfo = new FileInfo(LogoURL.FileName);
                                                                         // logo isminin atanması boyutunun belirlenmesi.
                    string logoname = LogoURL.FileName+imginfo.Extension;
                    img.Resize(300,200);
                    img.Save("~/Uploads/kimlik/" + logoname);

                    k.LogoURL = "/Uploads/kimlik/" + logoname;
                }
                k.Title = kimlik.Title;
                k.Keywords = kimlik.Keywords;
                k.Description = kimlik.Description;
                k.Unvan=kimlik.Unvan;
                db.SaveChanges();                     //databasede değişikleri kaydediyoruz.
                return RedirectToAction("Index");   //yaptıklarımız değişiklikleri indexe gönderiyoruz.
            }
            return View(kimlik);
        }

    }
}
