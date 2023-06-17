using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public interface ICULoguearUsuario
    {
        public DTOUsuario LoguearUsuario(string mail, string contrasenia);
    }
}
