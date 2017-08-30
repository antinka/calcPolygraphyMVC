using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class poligraphContext : DbContext
    {
        public DbSet<Bigovka> Bigovkas { get; set; }
        public DbSet<DensityLamin> DensityLamins { get; set; }
        public DbSet<Faltsovka> Faltsovkas { get; set; }
        public DbSet<Perforation> Perforations { get; set; }
        public DbSet<TypeLamination> TypeLaminations { get; set; }
        public DbSet<RoundAngle> RoundAngles { get; set; }
        public DbSet<TypePaper> TypePapers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<FormatProduct> FormatProducts { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Density> Densities { get; set; }
        public DbSet<CostPaper> CostPapers { get; set; }
        public DbSet<CostPage> CostPages { get; set; }
        public DbSet<PriceToner> PriceToners { get; set; }
        public DbSet<CostLamination> CostLaminations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LinqUserOrder> LinqUserOrders { get; set; }
        public DbSet<StatusOrder> StatusOrders { get; set; }
        public DbSet<CharacterLaminMachine> CharacterLaminMachines { get; set; }
        public DbSet<CharacterPrintMachine> CharacterPrintMachines { get; set; }
        public DbSet<CostOfOwner> CostOfOwners { get; set; }
        public DbSet<PercenTaxProfit> PercenTaxProfits { get; set; }
     public DbSet<HistoryBuyLam> HistoryBuyLams  {get; set; }
     public DbSet<HistoryBuyPage> HistoryBuyPages { get; set; }


      }
}
