using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;

namespace MVCCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        CVdbEntities db = new CVdbEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_ABOUT.ToList();
            return View(degerler);
        }
        public PartialViewResult Sosyal()
        {
            var sosyal = db.TBL_SOCIAL.ToList();
            return PartialView(sosyal);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TBL_EXP.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitim()
        {
            var egitim = db.TBL_EDU.ToList();
            return PartialView(egitim);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenek = db.TBL_SKILLS.ToList();
            return PartialView(yetenek);
        }
        public PartialViewResult Hobilerim()
        {
            var hobi = db.TBL_HOBIES.ToList();
            return PartialView(hobi);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertifika = db.TBL_CERT.ToList();
            return PartialView(sertifika);
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {
            var iletisim = db.TBL_COM.ToList();
            return PartialView(iletisim);
        }
        [HttpPost]
        public PartialViewResult Iletisim(TBL_COM t)
        {
            t.Date =DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBL_COM.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}