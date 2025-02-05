using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repostories;

namespace MVCCV.Controllers
{
    [Authorize]
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepostory repo = new DeneyimRepostory();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TBL_EXP p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            TBL_EXP t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TBL_EXP t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TBL_EXP p)
        {
            TBL_EXP t = repo.Find(x => x.ID == p.ID);
            t.Header = p.Header;
            t.LowerHeader = p.LowerHeader;
            t.Identification = p.Identification;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}