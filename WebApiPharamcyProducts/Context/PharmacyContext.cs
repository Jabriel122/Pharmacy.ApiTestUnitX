using Microsoft.EntityFrameworkCore;
using WebApiPharamcyProducts.Domains;

namespace WebApiPharamcyProducts.Context
{
    public class PharmacyContext : DbContext
    {
        public DbSet<ProductsDomain> ProductsDomain { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE14-SALA19; Database=Pharmacy-DataBase; User Id = sa; Pwd = Senai@134; TrustServerCertificate= True;");
            base.OnConfiguring(optionsBuilder);

        }
    }
}
