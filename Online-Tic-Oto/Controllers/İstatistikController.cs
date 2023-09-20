using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            var deger12 = db.Uruns.GroupBy(a => a.Marka).OrderByDescending(a => a.Count()).Select(a => a.Key).FirstOrDefault();
            ViewBag.d12 = deger12;





            var deger13 = db.Uruns.Where(b => b.UrunID == (db.SatisHarakets.GroupBy(a => a.UrunID).OrderByDescending(a => a.Count()).Select(a => a.Key).FirstOrDefault())).Select(k => k.UrunAD).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = db.SatisHarakets.Sum(a => a.ToplamTutar).ToString();
            ViewBag.d14 = deger14;


            DateTime buguntarih = DateTime.Today;

            var deger15 = db.SatisHarakets.Count(a => a.Tarih == buguntarih).ToString();
            ViewBag.d15 = deger15;

            //var deger16 = db.SatisHarakets.Where(a => a.Tarih == buguntarih).Sum(a => a.ToplamTutar).ToString();
            var deger16 = db.SatisHarakets.Where(a => a.Tarih == buguntarih).Sum(a => (decimal?)a.ToplamTutar) ?? 0M;

            
                ViewBag.d16 = deger16;


            return View();
        }


        public ActionResult KolayTablolar()
        {

            var sorgu = from c in db.Carilers
                        join s in db.Sehirlers on c.SehirID equals s.SehirID
                        group c by s.SehirADı into g
                        select new GrupSinif
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };

            return View(sorgu.ToList());
        }

        public PartialViewResult Partial1()
        {
            var sorgu2 = from a in db.Personels
                         join d in db.Departmen on a.DepartmanID equals d.DepartmanID
                         group new { a, d } by a.DepartmanID into g
                         select new GrupSinif2
                         {
                             Departman = g.Key,
                             DepartmanAdi = g.FirstOrDefault().d.DepartmanADI, // Departman adını buradan alıyoruz
                             Sayi = g.Count()
                         };

            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {

            var sorgu2 = db.Carilers.ToList();
            return PartialView(sorgu2);
        }

        public PartialViewResult Partial3()
        {

            var sorgu3 = db.Uruns.ToList();
            return PartialView(sorgu3);
        }
        public PartialViewResult Partial4()
        {
            var sorgu4 = from a in db.Uruns                         
                         group a by a.Marka into g
                         select new GrupSinif3
                         {
                             Marka = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu4);
        }
    }
}