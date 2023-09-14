using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Tic_Oto.Models.Sınıflar
{
    public class FaturaKalem
    {
        [Key]
        public int FatureKalemID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string FaturaAciklama { get; set; }
        public int Miktar { get; set; }
        public int BirimFiyat { get; set; }
        public int Tutar { get; set; }

       
        public int FaturaID { get; set; }   

        public virtual Faturalar Faturalar { get; set; }
    }
}