using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Tic_Oto.Models.AppContext;
using Online_Tic_Oto.Models.Enums;
using Online_Tic_Oto.Models.Sınıflar;

namespace Online_Tic_Oto.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun


        Context db = new Context();
        public ActionResult Index()
        {
            var urunler = db.Uruns.Where(a => a.Durum == true && a.Stok > 0).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> kategoriListesi = db.Kategoris
             .Select(k => new SelectListItem
             {
                 Value = k.KategoriID.ToString(),
                 Text = k.KategoriADI
             })
             .ToList();

            ViewBag.Kategoriler = kategoriListesi;
            return View();
        }


        [HttpPost]
        public ActionResult UrunEkle(Urun K)
        {

            int secilenKategoriID = int.Parse(Request.Form["KategoriID"]);

            db.Uruns.Add(K);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = db.Uruns.Find(id);

            deger.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> kategoriListesi = db.Kategoris
             .Select(k => new SelectListItem
             {
                 Value = k.KategoriID.ToString(),
                 Text = k.KategoriADI
             })
             .ToList();

            ViewBag.Kategoriler = kategoriListesi;
            var urundeger = db.Uruns.Find(id);

            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(Urun k)
        {

            int secilenKategoriID = int.Parse(Request.Form["KategoriID"]);
            var urungtr = db.Uruns.Find(k.UrunID);

            urungtr.UrunAD = k.UrunAD;
            urungtr.Marka = k.Marka;
            urungtr.Stok = k.Stok;
            urungtr.AlisFiyat = k.AlisFiyat;
            urungtr.SatisFiyat = k.SatisFiyat;
            urungtr.UrunGorsel = k.UrunGorsel;

            urungtr.KategoriID = secilenKategoriID;




            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult UrunListesi()
        {
            var degerler = db.Uruns.ToList();
            return View(degerler);
        }

    }
}