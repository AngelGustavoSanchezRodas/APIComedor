using System.ComponentModel.DataAnnotations.Schema;

namespace APIComedor.model
{
    [Table("MenuComedor_13449")]
    public class MenuComedor_13449
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }

    }
}
