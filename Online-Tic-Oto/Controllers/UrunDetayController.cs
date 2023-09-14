using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Tic_Oto.Models.AppContext;
using Online_Tic_Oto.Models.Sınıflar;

namespace Online_Tic_Oto.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay

        Context db = new Context();
        public ActionResult Index()
        {
            UrunDty3 urunDty3 = new UrunDty3();

            urunDty3.deger1 = db.Uruns.Where(a => a.UrunID == 18).ToList();
            urunDty3.deger2 = db.urunDty2s.Where(a => a.DetayID == 1).ToList();   

            //urun ekranındaki detay butonu basıcna burası açılsın oradaki ID bilgisi ile vs yapılabilir




            //var degerler = db.Uruns.Where(a => a.UrunID == 18).ToList();

            return View(urunDty3);
        }
    }
}