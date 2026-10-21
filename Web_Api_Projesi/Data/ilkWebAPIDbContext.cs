
using Microsoft.EntityFrameworkCore;

namespace Web_Api_Projesi.Data
{
    public class ilkWebAPIDbContext : DbContext
    {
      public ilkWebAPIDbContext(DbContextOptions<ilkWebAPIDbContext> options) : base(options)
        {

        }
        public DbSet<Web_Api_Projesi.Models.Kullanicilar> Kullanicilars { get; set; }
        public DbSet<Web_Api_Projesi.Models.Kategoriler> Kategorilers { get; set; }

    }
}
