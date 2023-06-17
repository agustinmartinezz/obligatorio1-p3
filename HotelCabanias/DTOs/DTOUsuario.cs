using LogicaNegocio.ValueObjects;

namespace DTOs
{
    public class DTOUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Mail { get; set; }

        public string Contrasenia { get; set; }

        
    }
}