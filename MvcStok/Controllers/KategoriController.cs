﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities1 db = new MvcDbStokEntities1(); 
        public ActionResult Index(int sayfa = 1) //kategori listeleme işlemi
        {
            //var degerler = db.TBLKATEGORILER.ToList();    
            var degerler = db.TBLKATEGORILER.ToList().ToPagedList(sayfa, 4); //sayfalama işlemi
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View(); 
        }   


        [HttpPost] 
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }

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

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);  
            return View("KategoriGetir", ktgr);
        }

        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var ktgr = db.TBLKATEGORILER.Find(p1.KATEGORIID);
            ktgr.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}