using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Tic_Oto.Models.AppContext;
using Online_Tic_Oto.Models.Sınıflar;

namespace Online_Tic_Oto.Models.Sınıflar
{
    public class GrupSinif2
    {
        Context db = new Context();




        public int Departman { get; set; }
        public int Sayi { get; set; }
        public string DepartmanAdi { get; set; }
    }
}