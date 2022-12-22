using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QUẢN_LÝ_THƯ_VIỆN.Models;

namespace QUẢN_LÝ_THƯ_VIỆN.Controllers
{
    public class sachController : Controller
    {
        QLTVEntities db = new QLTVEntities();
        // GET: sach
        public ActionResult Index()
        {
            var ds = from sach in db.SACHes select sach;
            return View(ds);
        }

        public ActionResult Delete(string id)
        {
            SACH sach = db.SACHes.Find(id);
            db.SACHes.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            SACH sach = db.SACHes.Find(id);
            return View(sach);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string masach = f.Get("MASACH");
            SACH sach = db.SACHes.Find(masach);
            sach.TENSACH = f.Get("TENSACH");
            sach.MATHELOAI = f.Get("MATHELOAI");
            sach.TACGIA = f.Get("TACGIA");
            sach.NGXB = DateTime.Parse(f.Get("NGXB"));
            sach.SL = int.Parse(f.Get("SL"));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            SACH sach = db.SACHes.Find(id);
            return View(sach);
        }
        [HttpPost]
        public ActionResult Details(FormCollection f)
        {
            string masach = f.Get("MASACH");
            SACH sach = db.SACHes.Find(masach);
            sach.TENSACH = f.Get("TENSACH");
            sach.MATHELOAI = f.Get("MATHELOAI");
            sach.TACGIA = f.Get("TACGIA");
            sach.NGXB = DateTime.Parse(f.Get("NGXB"));
            sach.SL = int.Parse(f.Get("SL"));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SACH sach)
        {
            db.SACHes.Add(sach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Alert_delete()
        {
            return View();
        }
    }
}