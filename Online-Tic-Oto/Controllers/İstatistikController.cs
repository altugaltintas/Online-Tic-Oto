using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Tic_Oto.Models.AppContext;
using Online_Tic_Oto.Models.Sınıflar;


namespace Online_Tic_Oto.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik


        Context db = new Context();
        public ActionResult Index()
        {

            var deger1 = db.Carilers.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = db.Uruns.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = db.Personels.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = db.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;



            var deger5 = db.Uruns.Sum(a => a.Stok).ToString();
            ViewBag.d5 = deger5;

            var deger6 = (from x in db.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;

            var deger7 = db.Uruns.Count(a => a.Stok <= 20).ToString();
            ViewBag.d7 = deger7;

            var deger8 = (from x in db.Uruns orderby x.SatisFiyat descending select x.UrunAD).FirstOrDefault();
            ViewBag.d8 = deger8;



            var deger9 = (from x in db.Uruns orderby x.SatisFiyat ascending select x.UrunAD).FirstOrDefault();
            ViewBag.d9 = deger9;

            var deger10 = db.Uruns.Where(a => a.UrunAD.Contains("Buzdolabı")).ToList();
            ViewBag.d10 = deger10.Count();

            var deger11 = db.Uruns.Where(a => a.UrunAD.Contains("laptop")).ToList();
            ViewBag.d11 = deger11.Count();

            var deger12 = db.Uruns.GroupBy(a=> a.Marka).OrderByDescending(a=>a.Count()).Select(a=> a.Key).FirstOrDefault();
            ViewBag.d12 = deger12;





            var deger13 = db.Uruns.Where(b=> b.UrunID==(db.SatisHarakets.GroupBy(a=> a.UrunID).OrderByDescending(a=> a.Count()).Select(a=>a.Key).FirstOrDefault())).Select(k=> k.UrunAD).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = db.SatisHarakets.Sum(a => a.ToplamTutar).ToString();
            ViewBag.d14 = deger14;


            DateTime buguntarih = DateTime.Today;

            var deger15 = db.SatisHarakets.Count(a=>a.Tarih == buguntarih).ToString();
            ViewBag.d15 = deger15;

            var deger16 = db.SatisHarakets.Where(a => a.Tarih == buguntarih).Sum(a => a.ToplamTutar).ToString();
            ViewBag.d16 = deger16;



            return View();



        }


        public ActionResult KolayTablolar()
        {



            return View();
        }
    }
}