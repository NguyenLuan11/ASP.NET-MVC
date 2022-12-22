using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using QUẢN_LÝ_THƯ_VIỆN.Models;

namespace QUẢN_LÝ_THƯ_VIỆN.Controllers
{
    public class muon_traController : Controller
    {
        QLTVEntities db = new QLTVEntities();
        // GET: muon_tra
        public ActionResult Index()
        {
            var ds = from muontra in db.MUON_TRA select muontra;
            return View(ds);
        }

        public ActionResult Delete(string id, string masach)
        {
            var ds = from muontras in db.MUON_TRA where (muontras.MADG == id) && (muontras.MASACH == masach) select muontras;
            MUON_TRA muontra = ds.First();
            db.MUON_TRA.Remove(muontra);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id, string masach)
        {
            var ds = from muontras in db.MUON_TRA where (muontras.MADG == id) && (muontras.MASACH == masach) select muontras;
            MUON_TRA muontra = ds.First();
            return View(muontra);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string madg = f.Get("MADG");
            string masach = f.Get("MASACH");
            MUON_TRA muontra = db.MUON_TRA.Where(s => s.MADG.Equals(madg) && s.MASACH.Equals(masach)).FirstOrDefault();
            muontra.SL = int.Parse(f.Get("SL"));
            muontra.NGMUON = DateTime.Parse(f.Get("NGMUON"));
            muontra.NGQDTRA = DateTime.Parse(f.Get("NGQDTRA"));
            muontra.NGTRA = DateTime.Parse(f.Get("NGTRA"));
            muontra.PHATQH = Decimal.Parse(f.Get("PHATQH"));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(string id, string masach)
        {
            var ds = from muontras in db.MUON_TRA where (muontras.MADG == id) && (muontras.MASACH == masach) select muontras;
            MUON_TRA muontra = ds.First();
            return View(muontra);
        }
        [HttpPost]
        public ActionResult Details(FormCollection f)
        {
            string madg = f.Get("MADG");
            string masach = f.Get("MASACH");
            MUON_TRA muontra = db.MUON_TRA.Where(s => s.MADG.Equals(madg) && s.MASACH.Equals(masach)).FirstOrDefault();
            muontra.SL = int.Parse(f.Get("SL"));
            muontra.NGMUON = DateTime.Parse(f.Get("NGMUON"));
            muontra.NGQDTRA = DateTime.Parse(f.Get("NGQDTRA"));
            muontra.NGTRA = DateTime.Parse(f.Get("NGTRA"));
            muontra.PHATQH = Decimal.Parse(f.Get("PHATQH"));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DOCGIA docgia, SACH sach, MUON_TRA muontra)
        {
            db.DOCGIAs.Add(docgia);
            db.SACHes.Add(sach);
            db.MUON_TRA.Add(muontra);
            return RedirectToAction("Index");
        }
    }
}