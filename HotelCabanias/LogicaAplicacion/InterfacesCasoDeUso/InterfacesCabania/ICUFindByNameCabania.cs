using DTOs;

namespace LogicaAplicacion.InterfacesCasoDeUso
{
    public interface ICUFindByNameCabania
    {
        public IEnumerable<DTOCabania> FindByNameCabania(string name);
    }
}
