using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Tic_Oto.Models.Sınıflar
{
    public class Departman
    {



        public Departman()
        {
            Durum = true;
        }
        [Key]
        public int DepartmanID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmanADI { get; set; }

        public bool Durum { get; set; } = true;


        public ICollection<Personel> Personels { get; set; }
    }
}