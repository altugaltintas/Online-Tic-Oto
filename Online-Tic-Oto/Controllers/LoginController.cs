using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Tic_Oto.Models.AppContext;
using Online_Tic_Oto.Models.Sınıflar;

namespace Online_Tic_Oto.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            List<SelectListItem> sehirList = db.Sehirlers
           .Select(k => new SelectListItem
           {
               Value = k.SehirPlaka.ToString(),
               Text = k.SehirADı
           })
           .ToList();


            ViewBag.sehirler= sehirList;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Cariler c)
        {
            int secilenSehirId = int.Parse(Request.Form["SehirID"]);


            db.Carilers.Add(c);
            db.SaveChanges();
            return PartialView();
        }





        public PartialViewResult Partial2()
        {

            return PartialView();
        }

        public PartialViewResult Partial3()
        {

            return PartialView();
        }
    }
}