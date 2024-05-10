using Backend.Models;
using Microsoft.EntityFrameworkCore;


namespace Backend.Data
{
    public class EdunovaContext : DbContext
    {
        public EdunovaContext(DbContextOptions<EdunovaContext> options) 
            : base(options) 
        { 

        }

        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<Predstava> Predstave { get; set; }
        public DbSet<Kupovina> Kupovine { get; set; }

  



    }
}
