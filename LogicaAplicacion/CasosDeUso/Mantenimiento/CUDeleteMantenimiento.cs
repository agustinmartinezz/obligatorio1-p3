using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasoDeUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUDeleteMantenimiento : ICUDeleteMantenimiento
    {

        public IRepositorioMantenimiento RepoMantenimiento { get; set; }

        public CUDeleteMantenimiento(IRepositorioMantenimiento repoMantenimiento)
        {
            RepoMantenimiento = repoMantenimiento;
        }

        public void DeleteMantenimiento(int mantenimientoId)
        {
            try
            {
                RepoMantenimiento.Delete(mantenimientoId);
            }
            catch
            {
                throw;
            }
        }
    }
}
