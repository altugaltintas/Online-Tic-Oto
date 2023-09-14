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



        // GET: Satış/YeniSatış
        public ActionResult Create()
        {
            return View();
        }

        // Satış bilgilerini kaydeder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Satis sales)
        {
            if (ModelState.IsValid)
            {
                db.Satis.Add(sales);
                db.SaveChanges();
                return RedirectToAction("CreateDetay", "SatisDene", new { SatisID = sales.ID });
            }
            return View(sales);


        }




        public ActionResult CreateDetay(int SatisID)
        {
            List<SelectListItem> urunlist = db.SatisDetays.Where(a => a.SatisID == SatisID)
            .Select(k => new SelectListItem
            {
                Value = k.ID.ToString(),
                Text = k.UrunAD
            })
            .ToList();

            ViewBag.urunlist2 = urunlist;





            ViewBag.SalesId = SatisID;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDetay(SatisDetay salesDetail)
        {


            if (ModelState.IsValid)
            {
                db.SatisDetays.Add(salesDetail);
                db.SaveChanges();
                return RedirectToAction("CreateDetay", new { SatisID = salesDetail.SatisID });
            }
            ViewBag.SalesId = salesDetail.SatisID;
            return View(salesDetail);
            //    if (ModelState.IsValid)
            //    {
            //        db.SatisDetays.Add(salesDetail);
            //        db.SaveChanges();
            //        return RedirectToAction("CreateDetay", new { salesId = salesDetail.SatisID });
            //    }
            //    ViewBag.SalesId = salesDetail.SatisID;
            //    return View(salesDetail);
            //}
        }
    }
}