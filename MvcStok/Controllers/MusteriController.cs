using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;    

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities1 db = new MvcDbStokEntities1();
        public ActionResult Index() //Müşterileri listeleme işlemi
        {
            var degerler = db.TBLMUSTERILER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1) //Müşteri ekleme işlemi
        {
            db.TBLMUSTERILER.Add(p1);   
            db.SaveChanges();
            return View();  
        }

        public ActionResult SIL (int id) //Müşteri silme işlemi
        {
            var musterı = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musterı);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}