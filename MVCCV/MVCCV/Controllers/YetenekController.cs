using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MVCCV.Models.Entity;
using MVCCV.Repostories;

namespace MVCCV.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        GenericRepository<TBL_SKILLS> repo = new GenericRepository<TBL_SKILLS>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TBL_SKILLS p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            TBL_SKILLS t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            TBL_SKILLS t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult YetenekDuzenle(TBL_SKILLS t)
        {
            var y = repo.Find(x => x.ID == t.ID);   
            y.Skills = t.Skills;
            y.Ratio = t.Ratio;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}