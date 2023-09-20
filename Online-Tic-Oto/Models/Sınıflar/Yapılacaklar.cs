using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Tic_Oto.Models.Sınıflar
{
    public class Yapılacaklar
    {

        [Key]
        public int YapID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string YapBaslik { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(200)]
        public string YapDetay { get; set; }


        [Column(TypeName = "Bit")]        
        public bool YapDurum { get; set; }


        public DateTime BaslangicTarih
        {
            get { return DateTime.Now; }
            set {  }
        }
        public DateTime bitisTarih { get; set; }


       
        public string KalanSure { get; set; }

    }
}