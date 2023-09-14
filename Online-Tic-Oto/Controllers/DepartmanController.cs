using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Tic_Oto.Models.AppContext;
using Online_Tic_Oto.Models.Sınıflar;

namespace Online_Tic_Oto.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context db = new Context();
        public ActionResult Index()
        {
            var degerler = db.Departmen.Where(a => a.Durum == true).ToList();

            return View(degerler);

        }


        [HttpGet]

        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            db.Departmen.Add(d);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult DepartmanSil(int id)
        {
            var deger = db.Departmen.Find(id);

            deger.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DepartmanGetir(int id)
        {
            List<SelectListItem> departmanList = db.Departmen
             .Select(k => new SelectListItem
             {
                 Value = k.DepartmanID.ToString(),
                 Text = k.DepartmanADI
             })
             .ToList();

            ViewBag.Departmanlar = departmanList;
            var departmanDeger = db.Departmen.Find(id);

            return View("DepartmanGetir",departmanDeger);
        }
        public ActionResult DepartmanGuncelle(Departman k)
        {
            var depgtr = db.Departmen.Find(k.DepartmanID);
            depgtr.DepartmanADI = k.DepartmanADI;         
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DepartmanDetay(int id)

        {
            var depDty = db.Personels.Where(a=> a.DepartmanID == id).ToList();

            var departBaslk = db.Departmen.Where(a => a.DepartmanID == id).Select(a => a.DepartmanADI).FirstOrDefault();
            ViewBag.d=departBaslk;


            return View(depDty);
           // return RedirectToAction("/Index");
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {

            var degerlr=db.SatisHarakets.Where(a=> a.PesonelID== id).ToList();
             
             var persBaslk=db.Personels.Where(a=> a.PesonelID==id).Select(a=> a.PersonelAD +" "+ a.PersonelSoyad).FirstOrDefault();
            ViewBag.d_pers=persBaslk;
            return View(degerlr);
        }
    }
}