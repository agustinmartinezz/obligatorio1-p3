using LogicaNegocio.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs
{
    [NotMapped]
    public class DTOTipoCabania
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CostoxHuesped { get; set; }

    }
}