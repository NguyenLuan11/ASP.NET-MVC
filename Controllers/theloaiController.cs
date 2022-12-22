using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QUẢN_LÝ_THƯ_VIỆN.Models;

namespace QUẢN_LÝ_THƯ_VIỆN.Controllers
{
    public class theloaiController : Controller
    {
        QLTVEntities db = new QLTVEntities();
        // GET: theloai
        public ActionResult Index()
        {
            var ds = from theloai in db.THELOAIs select theloai;
            return View(ds);
        }

        public ActionResult Delete(string id)
        {
            THELOAI theloai = db.THELOAIs.Find(id);
            db.THELOAIs.Remove(theloai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            THELOAI theloai = db.THELOAIs.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string mtl = f.Get("MATHELOAI");
            THELOAI theloai = db.THELOAIs.Find(mtl);
            theloai.TENTHELOAI = f.Get("TENTHELOAI");
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            THELOAI theloai = db.THELOAIs.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public ActionResult Details(FormCollection f)
        {
            string mtl = f.Get("MATHELOAI");
            THELOAI theloai = db.THELOAIs.Find(mtl);
            theloai.TENTHELOAI = f.Get("TENTHELOAI");
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(THELOAI theloai)
        {
            db.THELOAIs.Add(theloai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}