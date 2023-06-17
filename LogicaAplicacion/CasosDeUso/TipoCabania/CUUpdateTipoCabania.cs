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
    public class CUUpdateTipoCabania:ICUUpdateTipoCabania
    {
    
        public IRepositorioTipoCabania RepoTipoCabania { get; set; }

        public CUUpdateTipoCabania(IRepositorioTipoCabania repoTipoCabania)
        {
            RepoTipoCabania = repoTipoCabania;
        }

        public void UpdateTipoCabania(int Id,TipoCabania tipoCabania)
        {
            try
            {
                RepoTipoCabania.Update(Id,tipoCabania);
            }
            catch
            {
                throw;
            }
        }
    }
}
