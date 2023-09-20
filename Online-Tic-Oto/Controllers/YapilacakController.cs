using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Tic_Oto.Models.AppContext;
using Online_Tic_Oto.Models.Sınıflar;

namespace Online_Tic_Oto.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak


        Context db = new Context();
        public ActionResult Index()
        {
            var deger1 = db.Carilers.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = db.Uruns.Where(a => a.Durum == true && a.Stok > 0).Count().ToString();
            ViewBag.d2 = deger2;


            var deger3 = db.Kategoris.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = (from a in db.Carilers select a.Sehirler.SehirADı).Distinct().Count().ToString();
            ViewBag.d4 = deger4;



            var yapilacaklar = db.Yapılacaklars.Where(a => a.YapDurum == false).ToList();


            DateTime suAnkiTarih = DateTime.Now;

            // Liste içerisindeki her bir yapılacak görevin bitiş tarihini güncelle
            foreach (var yapilacak in yapilacaklar)
            {
                if (yapilacak.bitisTarih != null) // Bitiş tarihi null değilse işlem yap
                {
                    // Bitiş tarihini al
                    DateTime bitisTarihi = yapilacak.bitisTarih;

                    // Şu anki tarihten çıkararak kalan süreyi hesapla
                    TimeSpan kalanSure = bitisTarihi - suAnkiTarih;
                    int süre;

                    string süre2;
                    if (kalanSure.TotalDays >= 1)
                    {


                        // Kalan süre 1 günden fazla ise, gün cinsinden göster
                        süre = (int)kalanSure.TotalDays;
                        string saat = "Gün";
                         süre2 = süre.ToString() +" "+ saat;
                    }
                    else
                    {
                        // Kalan süre 1 günden az ise, saat cinsinden göster
                        süre = (int)kalanSure.TotalHours;

                        string saat = "Saat";
                        süre2 = süre.ToString()+" "+ saat;
                    }

                    string saatli =

                    // Yapılacak görevin kalan süresini KalanSure özelliğine ata
                    yapilacak.KalanSure = süre2;

                }
            }



            return View(yapilacaklar);



        }

        [HttpPost]
        public ActionResult Kapat(List<Yapılacaklar> model)
        {
            if (model != null)
            {
                // model içindeki YapID ve YapDurum bilgilerini kullanarak veritabanını güncelleyin
                foreach (var yap in model)
                {
                    // YapID'yi kullanarak veritabanındaki ilgili kaydı bulun ve YapDurum'u güncelleyin
                    // Örnek: Veritabanı işlemleri


                    var deger = db.Yapılacaklars.Find(yap.YapID);

                    deger.YapDurum = true;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            // İşlem tamamlandıktan sonra başka bir sayfaya yönlendirme yapabilirsiniz
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GorevEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult GorevEkle(Yapılacaklar yap)
        {

            if (yap.BaslangicTarih==null)
            {
                yap.BaslangicTarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            }

            

            db.Yapılacaklars.Add(yap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}