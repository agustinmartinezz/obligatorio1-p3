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
    public class CUAltaMantenimiento: ICUAltaMantenimiento

    {
    
        public IRepositorioMantenimiento RepoMantenimiento { get; set; }

        public CUAltaMantenimiento(IRepositorioMantenimiento repoMantenimiento)
        {
            RepoMantenimiento = repoMantenimiento;
        }

        public void AltaMantenimiento(Mantenimiento mantenimiento)
        {
            try
            {
                RepoMantenimiento.Add(mantenimiento);
            }
            catch
            {
                throw;
            }
        }
    }
}
