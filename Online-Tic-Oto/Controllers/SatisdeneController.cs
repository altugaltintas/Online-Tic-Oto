using Online_Tic_Oto.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Tic_Oto.Models.AppContext;
using System.Security.Cryptography.X509Certificates;

namespace Online_Tic_Oto.Controllers
{
    public class SatisdeneController : Controller
    {
        Context db = new Context();


        private List<Satis> _satışlar = new List<Satis>();
        private int _sonSatışID = 1;

        // Satışlar listesini görüntüleme
        public ActionResult Index()
        {
            return View(_satışlar);
        }

        // Firma bilgisi giriş için PartialView
        public ActionResult FirmaPartial()
        {
            return PartialView();
        }

        // Ürün bilgisi giriş için PartialView
        public ActionResult ÜrünPartial()
        {
            return PartialView();
        }

        // Firma bilgisini kaydetme
        [HttpPost]
        public ActionResult FirmaPartial(Satis satış)
        {
            satış.ID = _sonSatışID++;
            _satışlar.Add(satış);
            return RedirectToAction("ÜrünPartial", new { id = satış.ID });
        }

        // Ürün bilgisini kaydetme
        [HttpPost]
        public ActionResult ÜrünPartial(SatisDetay satışDetay)
        {
            var satış = _satışlar.Find(s => s.ID == satışDetay.SatisID);
            if (satış != null)
            {
                satış.satisDetays.Add(satışDetay);
            }
            return RedirectToAction("Index");
        }
    }
}
