using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public interface ICUUpdateMantenimiento
    {

        public DTOMantenimiento UpdateMantenimiento(int Id, DTOMantenimiento mantenimiento);
    }
}
