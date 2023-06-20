using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public interface ICUFindByDateMantenimiento
    {
        public IEnumerable<DTOMantenimiento> FindByDates(int CabaniaId, DateTime date1, DateTime date2);
    }
}
