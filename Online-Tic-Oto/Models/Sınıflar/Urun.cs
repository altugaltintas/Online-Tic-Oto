using Online_Tic_Oto.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_Tic_Oto.Models.Sınıflar
{
    public class Urun
    {

        public Urun()
        {
            Durum = true;
        }


        [Key]
        public int UrunID { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string UrunAD { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal  AlisFiyat { get; set; }
        public decimal  SatisFiyat { get; set; }

        public bool Durum { get; set; } = true;

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
            


        public int KategoriID { get; set; }

        public virtual Kategori Ketegori { get; set; }
        public ICollection<SatisHaraket> SatisHarakets { get; set; }

    }
}