using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Tic_Oto.Models.Sınıflar
{
    public class Satis
    {

        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FirmaAD { get; set; }


      

    }
}