using System.ComponentModel.DataAnnotations.Schema;

namespace VentasAPI.Entidades
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }

    }
}
