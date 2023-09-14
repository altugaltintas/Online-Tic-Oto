using Online_Tic_Oto.Models.AppContext;
using Online_Tic_Oto.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Tic_Oto.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel

        Context db = new Context();
        public ActionResult Index()
        {
            var persList = db.Personels.ToList();
            return View(persList);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> departmList = db.Departmen
             .Select(k => new SelectListItem
             {
                 Value = k.DepartmanID.ToString(),
                 Text = k.DepartmanADI
             })
             .ToList();

            ViewBag.deplist = departmList;
            return View();

        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {

            int selineDepartmanID = int.Parse(Request.Form["DepartmanID"]);

            db.Personels.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> departmList = db.Departmen
             .Select(k => new SelectListItem
             {
                 Value = k.DepartmanID.ToString(),
                 Text = k.DepartmanADI
             })
             .ToList();
            ViewBag.deplist2 = departmList;

            var persgtr = db.Personels.Find(id);
            
            return View("PersonelGetir", persgtr);
        }
        public ActionResult PersonelGüncelle(Personel p)
        {
            int yeniDepartmanID = int.Parse(Request.Form["DepartmanID"]);
           

            var personeller = db.Personels.Find(p.PesonelID);
            personeller.PersonelAD = p.PersonelAD;
            personeller.PersonelSoyad = p.PersonelSoyad;
            personeller.PersonelGorsel = p.PersonelGorsel;
            personeller.DepartmanID = yeniDepartmanID;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}