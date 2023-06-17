using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public interface ICUFindByNameTipoCabania
    {
        public IEnumerable<DTOTipoCabania> FindByNameTipoCabania(string name);
    }
}