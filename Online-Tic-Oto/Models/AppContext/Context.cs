using Online_Tic_Oto.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Tic_Oto.Models.AppContext
{


   
    public class Context : DbContext
    {


        

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cariler> Carilers { get; set; }
        public DbSet<Departman> Departmen { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Faturalar> Faturalars { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<SatisHaraket> SatisHarakets { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Sehirler> Sehirlers { get; set; }
        public DbSet<UrunDty2> urunDty2s { get; set; }
        public DbSet<Yapılacaklar> Yapılacaklars { get; set; }

        public DbSet<Satis> Satis { get; set; }
        public DbSet<SatisDetay> SatisDetays { get; set; }

    }
}