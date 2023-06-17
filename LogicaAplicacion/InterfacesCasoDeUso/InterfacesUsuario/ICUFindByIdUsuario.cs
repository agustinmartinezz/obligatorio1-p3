using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public interface ICUFindByIdUsuario
    {
        public DTOUsuario FindByIdUsuario(int usuarioId);
    }
}
