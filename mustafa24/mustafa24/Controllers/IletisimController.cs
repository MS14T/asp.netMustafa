﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mustafa24.Models.DateContext;
using mustafa24.Models.Model;

namespace mustafa24.Controllers
{
    public class IletisimController : Controller
    {
        private mustafa24Context db = new mustafa24Context();

        // GET: Iletisim
        public ActionResult Index()
        {
            return View(db.Iletisim.ToList());
        }

        // GET: Iletisim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iletisim iletisim = db.Iletisim.Find(id);
            if (iletisim == null)
            {
                return HttpNotFound();
            }
            return View(iletisim);
        }

        // GET: Iletisim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Iletisim/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IletisimId,Adres,Telefon,Fax,Whatsapp,Facebook,Twitter,Instagram")] Iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                db.Iletisim.Add(iletisim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iletisim);
        }

        // GET: Iletisim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iletisim iletisim = db.Iletisim.Find(id);
            if (iletisim == null)
            {
                return HttpNotFound();
            }
            return View(iletisim);
        }

        // POST: Iletisim/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IletisimId,Adres,Telefon,Fax,Whatsapp,Facebook,Twitter,Instagram")] Iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iletisim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iletisim);
        }

        // GET: Iletisim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Iletisim iletisim = db.Iletisim.Find(id);
            if (iletisim == null)
            {
                return HttpNotFound();
            }
            return View(iletisim);
        }

        // POST: Iletisim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Iletisim iletisim = db.Iletisim.Find(id);
            db.Iletisim.Remove(iletisim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}