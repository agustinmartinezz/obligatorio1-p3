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
    public class CUUpdateMantenimiento : ICUUpdateMantenimiento
    {

        public IRepositorioMantenimiento RepoMantenimiento { get; set; }

        public CUUpdateMantenimiento(IRepositorioMantenimiento repoMantenimiento)
        {
            RepoMantenimiento = repoMantenimiento;
        }

        public void UpdateMantenimiento(int Id,Mantenimiento mantenimiento)
        {
            try
            {
                RepoMantenimiento.Update(Id,mantenimiento);
            }
            catch
            {
                throw;
            }
        }
    }
}
