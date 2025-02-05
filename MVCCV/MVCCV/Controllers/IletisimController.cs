using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Controllers;
using MVCCV.Repostories;

namespace MVCCV.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        GenericRepository<TBL_COM> repo = new GenericRepository<TBL_COM>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}