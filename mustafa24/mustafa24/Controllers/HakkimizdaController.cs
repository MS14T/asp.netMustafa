using mustafa24.Models.DateContext;
using mustafa24.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace mustafa24.Controllers
{
    public class HakkimizdaController : Controller
    {
        mustafa24Context db = new mustafa24Context();
        // GET: Hakkimizda
        public ActionResult Index()
        {
            var h = db.Hakkimizda.ToList();
            return View(h);
        }
        public ActionResult Edit(int id)
        {
            var h = db.Hakkimizda.Where(x => x.HakkimizdaId == id).FirstOrDefault();
            return View(h);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Hakkimizda h)
        {
            if (ModelState.IsValid)
            {
                var hakkimizda = db.Hakkimizda.Where(x => x.HakkimizdaId == id).FirstOrDefault();

                hakkimizda.Aciklama= h.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(h);
        }
    }
}