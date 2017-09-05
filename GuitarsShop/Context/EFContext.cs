using GuitarsShop.Models;
using System.Data.Entity;

namespace GuitarsShop.Context
{
    public class EFContext : DbContext
    {

        public DbSet<Guitar> Guitars { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public EFContext()
            : base("Asp_Net_MVC_CS")
        {

        }
    }
}