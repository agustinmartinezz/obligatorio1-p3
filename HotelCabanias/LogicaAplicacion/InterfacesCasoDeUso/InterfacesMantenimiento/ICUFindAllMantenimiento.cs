using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public interface ICUFindAllMantenimiento
    {
        public IEnumerable<DTOMantenimiento> FindAllMantenimiento();
    }
}
