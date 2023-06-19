using LogicaNegocio.InterfacesRepositorios;
using DTOs;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUAltaMantenimiento: ICUAltaMantenimiento

    {
    
        public IRepositorioMantenimiento RepoMantenimiento { get; set; }

        public CUAltaMantenimiento(IRepositorioMantenimiento repoMantenimiento)
        {
            RepoMantenimiento = repoMantenimiento;
        }

        public DTOMantenimiento AltaMantenimiento(DTOMantenimiento dtoMantenimiento)
        {
            try
            {
                Mantenimiento mantenimiento = new() {
                    Fecha = dtoMantenimiento.Fecha,
                    Descripcion = dtoMantenimiento.Descripcion,
                    Costo = new Costo(dtoMantenimiento.Costo),
                    NombreRealizo = dtoMantenimiento.NombreRealizo,
                    CabaniaId = dtoMantenimiento.CabaniaId
                };

                RepoMantenimiento.Add(mantenimiento);
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
