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
    public class CUUpdateMantenimiento : ICUUpdateMantenimiento
    {

        public IRepositorioMantenimiento RepoMantenimiento { get; set; }

        public CUUpdateMantenimiento(IRepositorioMantenimiento repoMantenimiento)
        {
            RepoMantenimiento = repoMantenimiento;
        }

        public DTOMantenimiento UpdateMantenimiento(int Id, DTOMantenimiento dtoMantenimiento)
        {
            try
            {
                Mantenimiento mantenimiento = new()
                {
                    Fecha = dtoMantenimiento.Fecha,
                    Descripcion = dtoMantenimiento.Descripcion,
                    Costo = new Costo(dtoMantenimiento.Costo),
                    NombreRealizo = new Nombre(dtoMantenimiento.NombreRealizo),
                    CabaniaId = dtoMantenimiento.CabaniaId
                };
                RepoMantenimiento.Update(Id, mantenimiento);
                dtoMantenimiento.Id = mantenimiento.Id;
            }
            catch
            {
                throw;
            }
            return dtoMantenimiento;
        }
    }
}
