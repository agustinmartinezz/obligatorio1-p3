using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public interface ICUFindAllUsuario
    {
        public IEnumerable<DTOUsuario> FindAllUsuario();
    }
}
