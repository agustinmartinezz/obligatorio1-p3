using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    [NotMapped]
    public class DTOMantenimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Costo { get; set; }
        public string NombreRealizo { get; set; }
        public int CabaniaId { get; set; }
    }
}