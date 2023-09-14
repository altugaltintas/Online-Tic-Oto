using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Tic_Oto.Models.AppContext;
using Online_Tic_Oto.Models.Sınıflar;

namespace Online_Tic_Oto.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis


        Context db = new Context();
        public ActionResult Index()
        {
            var satslist = db.SatisHarakets.ToList();

            return View(satslist);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> urunlist = db.Uruns
                              .Select(k => new SelectListItem
                              {
                                  Value = k.UrunID.ToString(),
                                  Text = k.Marka + " : " + k.UrunAD + " (Stok: " + k.Stok + ")",


                              })
            .ToList();



            List<SelectListItem> carilist = db.Carilers
                        .Select(k => new SelectListItem
                        {
                            Value = k.CariID.ToString(),
                            Text = k.CariADI + " " + k.CariSoyadı
                        })
                        .ToList();

            List<SelectListItem> persList = db.Personels
                        .Select(k => new SelectListItem
                        {
                            Value = k.PesonelID.ToString(),
                            Text = k.PersonelAD + " " + k.PersonelSoyad
                        })
                        .ToList();

            ViewBag.persList = persList;
            ViewBag.carilist = carilist;
            ViewBag.urunlist = urunlist;



            return View();
        }



        [HttpPost]
        public ActionResult YeniSatis(SatisHaraket s)
        {

            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

            db.SatisHarakets.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult SatisGetir(int id)

        {

            List<SelectListItem> urunlist = db.Uruns
                             .Select(k => new SelectListItem
                             {
                                 Value = k.UrunID.ToString(),
                                 Text = k.Marka + " : " + k.UrunAD + " (Stok: " + k.Stok + ")",


                             })
                          .ToList();



            List<SelectListItem> carilist = db.Carilers
                        .Select(k => new SelectListItem
                        {
                            Value = k.CariID.ToString(),
                            Text = k.CariADI + " " + k.CariSoyadı
                        })
                        .ToList();

            List<SelectListItem> persList = db.Personels
                        .Select(k => new SelectListItem
                        {
                            Value = k.PesonelID.ToString(),
                            Text = k.PersonelAD + " " + k.PersonelSoyad
                        })
                        .ToList();

            ViewBag.persList = persList;
            ViewBag.carilist = carilist;
            ViewBag.urunlist = urunlist;

            var satDegr = db.SatisHarakets.Find(id);
            return View("SatisGetir", satDegr);
        }


        public ActionResult SatisGuncelle(SatisHaraket s)
        {
            var satDegr2 = db.SatisHarakets.Find(s.SatisID);

            satDegr2.CariID = s.CariID;
            satDegr2.Adet = s.Adet;
            satDegr2.Fiyat = s.Fiyat;
            satDegr2.PesonelID = s.PesonelID;
            satDegr2.Tarih = s.Tarih;
            satDegr2.ToplamTutar = s.ToplamTutar;
            satDegr2.UrunID = s.UrunID;
            db.SaveChanges();



            return RedirectToAction("Index");
        }


        public ActionResult SatisDetay(int id)
        {


            var degerlr = db.SatisHarakets.Where(a => a.SatisID == id).ToList();

            //var persBaslk = db.SatisHarakets.Where(a => a.SatisID == id).Select(a => a.CariID + " " + a.UrunID).FirstOrDefault();
            //ViewBag.s_dety = persBaslk;
            return View(degerlr);
        }
    }
}