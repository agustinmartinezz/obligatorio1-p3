using LogicaNegocio.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs
{
    [NotMapped]
    public class DTOUsuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public string Mail { get; set; }

        public string Contrasenia { get; set; }
    }
}