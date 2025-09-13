using Microsoft.EntityFrameworkCore;

namespace IntelligentDevicesApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Devices> Devices { get; set; }
        public DbSet<Marcas> Marcas { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }

}
