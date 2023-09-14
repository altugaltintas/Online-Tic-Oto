using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Tic_Oto.Models.Sınıflar
{
    public class Faturalar
    {

        [Key]
        public int FaturaID { get; set; }



        [Column(TypeName = "Varchar")]
        [StringLength(3)]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string FaturaSıraNo { get; set; }
        public DateTime Tarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string VeriDariesi { get; set; }


        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Saat { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }


        public decimal ToplamTutar { get; set; }



        public ICollection<FaturaKalem> FaturaKalems { get; set; }

        [NotMapped]   
        public string FaturaSeriSiraBirlesik
        {
            get { return $"{FaturaSeriNo.ToUpper()} - {FaturaSıraNo.ToUpper()}"; }
        }
        // public string FaturaSeriSiraBirlesik => $"{FaturaSeriNo} {FaturaSıraNo}";



    }
}