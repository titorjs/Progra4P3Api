using Microsoft.EntityFrameworkCore;
using PruebaP3.Model;

namespace PruebaP3.Data
{
    public class TareaDbContext :DbContext
    {
        public TareaDbContext()
        {

        }

        public TareaDbContext(DbContextOptions<TareaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tarea> Tareas {  get; set; }

    }
}
