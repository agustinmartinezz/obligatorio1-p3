using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasoDeUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUFindByIdMantenimiento : ICUFindByIdMantenimiento
    {

        public IRepositorioMantenimiento RepoMantenimiento { get; set; }

        public CUFindByIdMantenimiento(IRepositorioMantenimiento repoMantenimiento)
        {
            RepoMantenimiento = repoMantenimiento;
        }

        public DTOMantenimiento FindByIdMantenimiento(int mantenimientoId)
        {
            try
            {
                Mantenimiento m = RepoMantenimiento.FindById(mantenimientoId);

                DTOMantenimiento dtoMantenimiento = new()
                {
                    Id = m.Id,
                    Fecha = m.Fecha,
                    Descripcion = m.Descripcion,
                    Costo = m.Costo.ValorCosto,
                    NombreRealizo = m.NombreRealizo,
                    CabaniaId = m.CabaniaId
                };
                return dtoMantenimiento;
            }
            catch
            {
                throw;
            }
        }
    }
}
