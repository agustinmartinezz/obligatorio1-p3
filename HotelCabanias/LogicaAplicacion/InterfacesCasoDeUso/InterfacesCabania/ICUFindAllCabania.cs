using DTOs;

namespace LogicaAplicacion.InterfacesCasoDeUso
{
    public interface ICUFindAllCabania
    {
        public IEnumerable<DTOCabania> FindAllCabania();
    }
}
