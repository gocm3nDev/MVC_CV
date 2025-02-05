using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repostories;

namespace MVCCV.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TBL_HOBIES> repo = new GenericRepository<TBL_HOBIES>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
        public ActionResult Index(TBL_HOBIES p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Description1 = p.Description1;
            t.Description2 = p.Description2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}