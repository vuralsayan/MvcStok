using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities1 db = new MvcDbStokEntities1(); 
        public ActionResult Index() //kategori listeleme işlemi
        {
            var degerler = db.TBLKATEGORILER.ToList();    
            return View(degerler);
        }
        [HttpGet] //sayfa yüklendiğinde çalışacak olan action
        public ActionResult YeniKategori()
        {
            return View(); 
        }   


        [HttpPost] //sayfada bir butona tıkladığımızda çalışacak olan action
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult SIL(int id) //id parametresi ile gelen değeri sil
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}