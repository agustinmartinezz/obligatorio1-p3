using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public interface ICUUpdateUsuario
    {
        public DTOUsuario UpdateUsuario(int Id, DTOUsuario usuario);
    }
}
