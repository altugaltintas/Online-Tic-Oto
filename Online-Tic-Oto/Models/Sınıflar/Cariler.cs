using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Tic_Oto.Models.Sınıflar
{
    public class Cariler
    {

        public Cariler()
        {
            Durum = true;
        }

        [Key]
        public int CariID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsin")]
        [Required(ErrorMessage = "Bu Alanı Boş geçemezsiniz")]
        public string CariADI { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsin")]
        [Required(ErrorMessage ="Bu Alanı Boş geçemezsiniz")]
        public string CariSoyadı { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }

        public bool Durum { get; set; }


        public int SehirID { get; set; }

        public virtual Sehirler Sehirler { get; set; }

        public ICollection<SatisHaraket> SatisHarakets { get; set; }
    }
}