using Antlr.Runtime;
using Online_Tic_Oto.Models.AppContext;
using Online_Tic_Oto.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Tic_Oto.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura

        Context db = new Context();
        public ActionResult Index()
        {
            var fatlist = db.Faturalars.ToList();

            return View(fatlist);
        }


        [HttpGet]


        public ActionResult FaturaEkle()
        {
            return View();
        }


        [HttpPost]


        public ActionResult FaturaEkle(Faturalar f)
        {
            db.Faturalars.Add(f);

            db.SaveChanges();
            return RedirectToAction("FaturaKalemEkle");
        }


        public ActionResult FaturaGetir(int id)
        {

            var fatgetr = db.Faturalars.Find(id);

            return View("FaturaGetir", fatgetr);
        }

        public ActionResult FaturaGüncelle(Faturalar f)
        {

            var fatgetr = db.Faturalars.Find(f.FaturaID);

            fatgetr.VeriDariesi = f.VeriDariesi;
            fatgetr.Tarih = f.Tarih;
            fatgetr.Saat = f.Saat;
            fatgetr.TeslimEden = f.TeslimEden;
            fatgetr.TeslimAlan = f.TeslimAlan;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult FaturaDetay(int id)
        {
            var fatdty = db.FaturaKalems.Where(a => a.FaturaID == id).ToList();






            var fatdytbaslk = db.Faturalars.Where(a => a.FaturaID == id).Select(a => a.FaturaSeriNo).FirstOrDefault();
            var fatdytbaslk2 = db.Faturalars.Where(a => a.FaturaID == id).Select(b => b.FaturaSıraNo).FirstOrDefault();

            var baslk1 = fatdytbaslk.ToUpper();

            ViewBag.dft = baslk1 + "  " + fatdytbaslk2;


            return View(fatdty);

        }


        [HttpGet]

        public ActionResult FaturaKalemEkle()

        {
            return View();

        }

        //public ActionResult FaturaKalemEkle(int id)

        //{
        //    FaturaKalem faturaKalem = db.FaturaKalems.FirstOrDefault(a => a.FatureKalemID == id);

        //    var fatura = db.Faturalars.FirstOrDefault(b => b.FaturaID == faturaKalem.FaturaID);

        //    var baslik1 = fatura.FaturaSeriNo.ToUpper();
        //    var baslik2 = fatura.FaturaSıraNo;

        //    //var det2 = db.FaturaKalems.Where(a => a.FatureKalemID == id).Select(a => a.FaturaID).FirstOrDefault();

        //    //var det3 = db.Faturalars.Where(a => a.FaturaID == fat).Select(a => a.FaturaSeriNo).FirstOrDefault();
        //    //var det4 = db.Faturalars.Where(a => a.FaturaID == fat).Select(a => a.FaturaSıraNo).FirstOrDefault();

        //    //var baslik1 = det3.ToUpper();
        //    //var baslik2 = det4;

        //    ViewBag.dft2 = baslik1 + "  " + baslik2;

        //    return View("FaturaKalemEkle");


        //}


        public ActionResult FaturaKalemEkle(FaturaKalem ft)

        {
            db.FaturaKalems.Add(ft);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}