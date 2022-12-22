using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QUẢN_LÝ_THƯ_VIỆN.Models;

namespace QUẢN_LÝ_THƯ_VIỆN.Controllers
{
    public class giahanController : Controller
    {
        QLTVEntities db = new QLTVEntities();
        // GET: giahan
        public ActionResult Index()
        {
            var ds = from giahan in db.GIAHANs select giahan;
            return View(ds);
        }

        public ActionResult Delete(string id, string masach)
        {
            var ds = from giahans in db.GIAHANs where (giahans.MADG == id) && (giahans.MASACH == masach) select giahans;
            GIAHAN giahan = ds.First();
            db.GIAHANs.Remove(giahan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id, string masach)
        {
            var ds = from giahans in db.GIAHANs where (giahans.MADG == id) && (giahans.MASACH == masach) select giahans;
            GIAHAN giahan = ds.First();
            return View(giahan);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string madg = f.Get("MADG");
            string masach = f.Get("MASACH");
            GIAHAN giahan = db.GIAHANs.Where(s => s.MADG.Equals(madg) && s.MASACH.Equals(masach)).FirstOrDefault();
            giahan.TUNGAY = DateTime.Parse(f.Get("TUNGAY"));
            giahan.DENNGAY = DateTime.Parse(f.Get("DENNGAY"));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(string id, string masach)
        {
            var ds = from giahans in db.GIAHANs where (giahans.MADG == id) && (giahans.MASACH == masach) select giahans;
            GIAHAN giahan = ds.First();
            return View(giahan);
        }
        [HttpPost]
        public ActionResult Details(FormCollection f)
        {
            string madg = f.Get("MADG");
            string masach = f.Get("MASACH");
            GIAHAN giahan = db.GIAHANs.Where(s => s.MADG.Equals(madg) && s.MASACH.Equals(masach)).FirstOrDefault();
            giahan.TUNGAY = DateTime.Parse(f.Get("TUNGAY"));
            giahan.DENNGAY = DateTime.Parse(f.Get("DENNGAY"));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DOCGIA docgia, SACH sach, GIAHAN giahan)
        {
            db.DOCGIAs.Add(docgia);
            db.SACHes.Add(sach);
            db.GIAHANs.Add(giahan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}