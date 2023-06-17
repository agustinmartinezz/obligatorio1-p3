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
    public class CUFindByIdMantenimiento : ICUFindByIdMantenimiento
    {

        public IRepositorioMantenimiento RepoMantenimiento { get; set; }

        public CUFindByIdMantenimiento(IRepositorioMantenimiento repoMantenimiento)
        {
            RepoMantenimiento = repoMantenimiento;
        }

        public void FindByIdMantenimiento(int mantenimientoId)
        {
            try
            {
                RepoMantenimiento.FindById(mantenimientoId);
            }
            catch
            {
                throw;
            }
        }
    }
}
