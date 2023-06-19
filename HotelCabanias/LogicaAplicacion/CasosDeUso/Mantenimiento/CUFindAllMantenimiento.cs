using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasoDeUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUFindAllMantenimiento : ICUFindAllMantenimiento
    {

        public IRepositorioMantenimiento RepoMantenimiento { get; set; }

        public CUFindAllMantenimiento(IRepositorioMantenimiento repoMantenimiento)
        {
            RepoMantenimiento = repoMantenimiento;
        }

        public IEnumerable<DTOMantenimiento> FindAllMantenimiento()
        {
            try
            {
                IEnumerable<Mantenimiento> mantenimientos = RepoMantenimiento.FindAll();

                IEnumerable<DTOMantenimiento> dtoMantenimientos = mantenimientos.Select(m => new DTOMantenimiento ()
                {
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
