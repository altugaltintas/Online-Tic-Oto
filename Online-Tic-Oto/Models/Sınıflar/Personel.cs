using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Tic_Oto.Models.Sınıflar
{
    public class Personel
    {

        [Key]
        public int PesonelID { get; set; }       


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAD { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }


        public ICollection<SatisHaraket> SatisHarakets { get; set; }

        public int DepartmanID { get; set; }
        public virtual Departman Departman { get; set; }

    }
}