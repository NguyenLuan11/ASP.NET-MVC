using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QUẢN_LÝ_THƯ_VIỆN.Models;

namespace QUẢN_LÝ_THƯ_VIỆN.Controllers
{
    public class docgiaController : Controller
    {
        QLTVEntities db = new QLTVEntities();
        // GET: docgia
        public ActionResult Index()
        {
            var ds = from docgia in db.DOCGIAs select docgia;
            return View(ds);
        }

        public ActionResult Delete(string id)
        {
            DOCGIA docgia = db.DOCGIAs.Find(id);
            db.DOCGIAs.Remove(docgia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            DOCGIA docgia = db.DOCGIAs.Find(id);
            return View(docgia);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string madg = f.Get("MADG");
            DOCGIA docgia = db.DOCGIAs.Find(madg);
            docgia.HOTEN = f.Get("HOTEN");
            docgia.DCHI = f.Get("DCHI");
            docgia.NGSINH = DateTime.Parse(f.Get("NGSINH"));
            docgia.SODT = f.Get("SODT");
            docgia.NGDK = DateTime.Parse(f.Get("NGDK"));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            DOCGIA docgia = db.DOCGIAs.Find(id);
            return View(docgia);
        }
        [HttpPost]
        public ActionResult Details(FormCollection f)
        {
            string madg = f.Get("MADG");
            DOCGIA docgia = db.DOCGIAs.Find(madg);
            docgia.HOTEN = f.Get("HOTEN");
            docgia.DCHI = f.Get("DCHI");
            docgia.NGSINH = DateTime.Parse(f.Get("NGSINH"));
            docgia.SODT = f.Get("SODT");
            docgia.NGDK = DateTime.Parse(f.Get("NGDK"));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DOCGIA docgia)
        {
            db.DOCGIAs.Add(docgia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Alert_delete()
        {
            return View();
        }
    }
}