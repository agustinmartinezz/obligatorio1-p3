using DTOs;

namespace LogicaAplicacion.InterfacesCasoDeUso
{
    public interface ICUFindByIdCabania
    {
        public DTOCabania FindByIdCabania(int cabaniaId);
    }
}
