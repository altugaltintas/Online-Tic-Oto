using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Tic_Oto.Models.Sınıflar
{
    public class SatisHaraket
    {
        [Key]
        public int SatisID { get; set; }

        //ürün        
        //Cari
        //Personel

        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public int Fiyat { get; set; }
        public int ToplamTutar { get; set; }

        public int UrunID { get; set; }
        public int CariID { get; set; }
        public int PesonelID { get; set; }

        public virtual Urun Urun { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }

    }
}