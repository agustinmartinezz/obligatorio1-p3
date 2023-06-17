using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public interface ICUFindByIdMantenimiento
    {

        public DTOMantenimiento FindByIdMantenimiento(int mantenimientoId);
    }
}
