using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Tic_Oto.Models.Sınıflar
{
    public class Sehirler
    {
        [Key]
        public int SehirID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string SehirADı { get; set; }       

        public int SehirPlaka { get; set; }      

       
    }
}