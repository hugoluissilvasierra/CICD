using Microsoft.EntityFrameworkCore;
using VentasAPI.Entidades;

namespace VentasAPI.Repositorios
{
    public class VentasDbContext : DbContext
    {
        public VentasDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

    }
}
