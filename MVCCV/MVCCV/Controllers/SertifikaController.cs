using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repostories;

namespace MVCCV.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TBL_CERT> repo = new GenericRepository<TBL_CERT>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGuncelle(int id)
        {
            TBL_CERT t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SertifikaGuncelle(TBL_CERT t)
        {
            var s = repo.Find(x => x.ID == t.ID);
            s.Sertifika = t.Sertifika;
            s.Date = t.Date;
            repo.TUpdate(s);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YeniSertifika(TBL_CERT p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var s = repo.Find(x => x.ID == id);
            repo.TDelete(s);
            return RedirectToAction("Index");
        }
    }
}