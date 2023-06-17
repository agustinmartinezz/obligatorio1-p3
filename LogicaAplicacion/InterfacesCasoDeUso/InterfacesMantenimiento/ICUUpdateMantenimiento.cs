using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public interface ICUUpdateMantenimiento
    {

        public void UpdateMantenimiento(int Id, DTOMantenimiento mantenimiento);
    }
}
