using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Tic_Oto.Models.AppContext;
using Online_Tic_Oto.Models.Enums;
using Online_Tic_Oto.Models.Sınıflar;


namespace Online_Tic_Oto.Controllers
{
    public class CarilerController : Controller
    {
        // GET: Cariler
        Context db = new Context();


        public ActionResult Index()
        {

            var carilist = db.Carilers.Where(a => a.Durum == true).ToList();
            return View(carilist);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            List<SelectListItem> sehirList = db.Sehirlers
            .Select(k => new SelectListItem
            {
                Value = k.SehirID.ToString(),
                Text = k.SehirADı
            })
            .ToList();

            ViewBag.sehirler = sehirList;
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler c)
        {

            int secilenSehirId = int.Parse(Request.Form["SehirID"]);

            db.Carilers.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult CariSil(int id)
        {
            var carisil = db.Carilers.Find(id);

            carisil.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CariGetir(int id)
        {
            List<SelectListItem> sehirList = db.Sehirlers
            .Select(k => new SelectListItem
            {
                Value = k.SehirID.ToString(),
                Text = k.SehirADı
            })
            .ToList();
            var carigtr = db.Carilers.Find(id);
            ViewBag.sehirler2 = sehirList;


            return View("CariGetir", carigtr);
        }

        public ActionResult CariGüncelle(Cariler c)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> sehirList = db.Sehirlers
              .Select(k => new SelectListItem
              {
                  Value = k.SehirID.ToString(),
                  Text = k.SehirADı
              })
                .ToList();

                ViewBag.sehirler2 = sehirList;

                return View("CariGetir", c);

            }
            int yeniSehirID = int.Parse(Request.Form["SehirID"]);

            var carigncl = db.Carilers.Find(c.CariID);
            carigncl.CariADI = c.CariADI;
            carigncl.CariSoyadı = c.CariSoyadı;
            carigncl.CariMail = c.CariMail;
            carigncl.SehirID = yeniSehirID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSatis(int id)
        {
            var degerlr = db.SatisHarakets.Where(a => a.CariID == id).ToList();
            var caribaslik = db.Carilers.Where(a => a.CariID == id).Select(a => a.CariADI + " " + a.CariSoyadı).FirstOrDefault();
            ViewBag.c_baslk = caribaslik;
            return View(degerlr);
        }
    }
}