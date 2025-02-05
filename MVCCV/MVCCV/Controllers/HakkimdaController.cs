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
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<TBL_ABOUT> repo = new GenericRepository<TBL_ABOUT>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(TBL_ABOUT p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Name = p.Name;
            t.Surname = p.Surname;
            t.Address = p.Address;
            t.Mail = p.Mail;
            t.Identification = p.Identification;
            t.Image = p.Image;
            t.Phone = p.Phone;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}