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
    public class CUDeleteTipoCabania: ICUDeleteTipoCabania
    {
    
        public IRepositorioTipoCabania RepoTipoCabania { get; set; }

        public CUDeleteTipoCabania(IRepositorioTipoCabania repoTipoCabania)
        {
            RepoTipoCabania = repoTipoCabania;
        }

        public void DeleteTipoCabania(int tipoCabaniaId)
        {
            try
            {
                RepoTipoCabania.Delete(tipoCabaniaId);
            }
            catch
            {
                throw;
            }
        }
    }
}
