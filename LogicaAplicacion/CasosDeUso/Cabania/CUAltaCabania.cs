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
    public class CUAltaCabania : ICUAltaCabania
    {
    
        public IRepositorioCabania RepoCabania { get; set; }

        public CUAltaCabania(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
        }

        public void AltaCabania(Cabania cabania)
        {
            try
            {
                RepoCabania.Add(cabania);
            }
            catch
            {
                throw;
            }
        }
    }
}
