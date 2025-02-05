using MVCCV.Models.Entity;
using MVCCV.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCV.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TBL_EDU> repo = new GenericRepository<TBL_EDU>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TBL_EDU p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            TBL_EDU t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            TBL_EDU e = repo.Find(x => x.ID == id);
            return View(e);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(TBL_EDU t)
        {
            var e = repo.Find(x => x.ID == t.ID);
            e.Header = t.Header;
            e.LowerHeader = t.LowerHeader;
            e.Role = t.Role;
            e.GPA = t.GPA;
            e.Date = t.Date;
            repo.TUpdate(e);
            return RedirectToAction("Index");
        }
    }
}