using System.ComponentModel.DataAnnotations;

namespace PruebaP3.Model
{
    public class Tarea
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
    }
}
