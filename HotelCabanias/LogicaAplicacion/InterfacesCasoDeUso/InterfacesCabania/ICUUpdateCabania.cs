using DTOs;

namespace LogicaAplicacion.InterfacesCasoDeUso
{
    public interface ICUUpdateCabania
    {
        public DTOCabania UpdateCabania(int Id, DTOCabania cabania);
    }
}
