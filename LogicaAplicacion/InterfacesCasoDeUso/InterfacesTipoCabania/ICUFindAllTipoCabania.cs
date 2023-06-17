using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public interface ICUFindAllTipoCabania
    {
        public IEnumerable<DTOTipoCabania> FindAllTipoCabania();
    }
}
