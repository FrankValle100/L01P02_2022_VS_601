using Microsoft.EntityFrameworkCore;

namespace Vistas_y_Variables_de_Sesión.Models
{
    public class equiposDbContext : DbContext
    {
        public equiposDbContext(DbContextOptions options) : base(options)
        {
        }


    }
}

