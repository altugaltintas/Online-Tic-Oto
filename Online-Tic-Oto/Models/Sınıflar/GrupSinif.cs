using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Tic_Oto.Models.AppContext;
using Online_Tic_Oto.Models.Sınıflar;

namespace Online_Tic_Oto.Models.Sınıflar
{
    public class GrupSinif
    {
        Context db = new Context();


        public string Sehir { get; set; }

        public int Sayi { get; set; }
    }
}