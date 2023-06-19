using DTOs;

namespace LogicaAplicacion.InterfacesCasoDeUso
{
    public interface ICUFindByTipoCabania
    {
        public IEnumerable<DTOCabania> FindByTipoCabania(int tipoId);
    }
}
