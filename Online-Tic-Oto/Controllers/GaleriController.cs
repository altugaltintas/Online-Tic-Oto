using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Tic_Oto.Models.AppContext;
using Online_Tic_Oto.Models.Sınıflar;

namespace Online_Tic_Oto.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri

        Context db = new Context();

        public ActionResult Index()
        {
            var urunler = db.Uruns.Where(a => a.Durum == true  ).ToList();
            return View(urunler);

            
        }


       
    }
}