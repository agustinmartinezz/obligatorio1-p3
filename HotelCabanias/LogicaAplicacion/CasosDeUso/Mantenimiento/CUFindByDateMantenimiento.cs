using DTOs;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUFindByDateMantenimiento : ICUFindByDateMantenimiento
    {
        public IRepositorioMantenimiento RepoMantenimiento { get; set; }

        public CUFindByDateMantenimiento(IRepositorioMantenimiento repoMantenimiento)
        {
            RepoMantenimiento = repoMantenimiento;
        }

        public IEnumerable<DTOMantenimiento> FindByDates(int CabaniaId, DateTime date1, DateTime date2)
        {
            try
            {
                IEnumerable<Mantenimiento> m = RepoMantenimiento.FindByDates(CabaniaId, date1, date2);

                IEnumerable<DTOMantenimiento> dtoMantenimientos = m.Select(m => new DTOMantenimiento() {
                    Id = m.Id,
                    Fecha = m.Fecha,
                    Descripcion = m.Descripcion,
                    Costo = m.Costo.ValorCosto,
                    NombreRealizo = m.NombreRealizo,
                    CabaniaId = m.CabaniaId
                });

                return dtoMantenimientos;
            }
            catch
            {
                throw;
            }
        }
    }
}
