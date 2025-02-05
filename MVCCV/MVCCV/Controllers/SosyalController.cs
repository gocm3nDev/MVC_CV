using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repostories;

namespace MVCCV.Controllers
{
    public class SosyalController : Controller
    {
        // GET: Sosyal
        GenericRepository<TBL_SOCIAL> repo = new GenericRepository<TBL_SOCIAL>();
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult SosyalEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SosyalEkle(TBL_SOCIAL p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SosyalDuzenle(int id)
        {
            var sosyal = repo.Find(x => x.ID == id);
            return View(sosyal);
        }
        [HttpPost]
        public ActionResult SosyalDuzenle(TBL_SOCIAL p)
        {
            var s = repo.Find(x => x.ID == p.ID);
            s.Ad = p.Ad;
            s.Link = p.Link;
            s.Icon = p.Icon;
            repo.TUpdate(s);
            return RedirectToAction("Index");
        }
        public ActionResult SosyalSil(int id)
        {
            var s = repo.Find(x => x.ID == id);
            repo.TDelete(s);
            return RedirectToAction("Index");
        }
    }
}