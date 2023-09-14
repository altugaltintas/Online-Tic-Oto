using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Tic_Oto.Models.Sınıflar
{
    public class UrunDty2
    {


        [Key]
        public int DetayID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAdı { get; set; }



        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string UrunBilgileri { get; set; }
        


    }
}