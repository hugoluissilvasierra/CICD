using System.ComponentModel.DataAnnotations.Schema;

namespace VentasAPI.Entidades
{
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
