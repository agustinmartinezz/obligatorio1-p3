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
    public class CUFindByTipoCabania : ICUFindByTipoCabania
    {
    
        public IRepositorioCabania RepoCabania { get; set; }

        public CUFindByTipoCabania(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
        }

        public void FindByTipoCabania(int tipoId)
        {
            try
            {
                RepoCabania.FindByTipo(tipoId);
            }
            catch
            {
                throw;
            }
        }
    }
}
