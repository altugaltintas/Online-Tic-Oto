using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Tic_Oto.Models.Sınıflar
{
    public class SatisDetay
    {


        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAD { get; set; }



        public int SatisID { get; set; }

        public virtual Satis Satis { get; set; }
    }
}