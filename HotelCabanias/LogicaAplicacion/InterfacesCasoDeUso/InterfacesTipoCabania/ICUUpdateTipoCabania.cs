using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public interface ICUUpdateTipoCabania
    {

        public DTOTipoCabania UpdateTipoCabania(int Id, DTOTipoCabania tipoCabania);
    }
}
