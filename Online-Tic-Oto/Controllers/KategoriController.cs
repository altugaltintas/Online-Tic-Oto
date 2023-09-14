using Online_Tic_Oto.Models.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Tic_Oto.Models.Sınıflar;
using Antlr.Runtime.Tree;

namespace Online_Tic_Oto.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

         
        Context db =new Context();

        public ActionResult Index()
        {
            var degerler =  db.Kategoris.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori K)
        {

            
            db.Kategoris.Add(K);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kate= db.Kategoris.Find(id);

            db.Kategoris.Remove(kate);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KategoriGetir(int id)
        {
            var kate = db.Kategoris.Find(id);
            return View("KategoriGetir", kate);
        }

        public ActionResult KategoriGüncelle(Kategori k)
        {
            var kategr = db.Kategoris.Find(k.KategoriID);
            kategr.KategoriADI = k.KategoriADI;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}