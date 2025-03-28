using Microsoft.EntityFrameworkCore;

namespace Formularios_con_Razor_y_HTML.Models
{
    public class equiposDbContext : DbContext
    {
        public equiposDbContext(DbContextOptions options) : base(options)
        {
           _eqiposDbContext = equiposDbContext;
        }
        public DbSet<marcas> marcas { get; set; }

        public DbSet<equipos> equipos { get; set; } 
    }
}