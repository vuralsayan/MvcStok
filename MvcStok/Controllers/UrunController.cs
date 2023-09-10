using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity; 

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities1 db = new MvcDbStokEntities1(); 
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();  
            return View(degerler);
        }
        [HttpGet]

        public ActionResult UrunEkle()
        {
            return View();
        }

        [HttpPost]

        public ActionResult UrunEkle(TBLURUNLER p1)
        {
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return View();

        }

    }
}