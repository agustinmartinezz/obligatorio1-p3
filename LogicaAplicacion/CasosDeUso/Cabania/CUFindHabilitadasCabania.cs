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
    public class CUFindHabilitadasCabania:ICUFindHabilitadasCabania
    {
    
        public IRepositorioCabania RepoCabania { get; set; }

        public CUFindHabilitadasCabania(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
        }

        public void FindHabilitadasCabania()
        {
            try
            {
                RepoCabania.FindHabilitadas();
            }
            catch
            {
                throw;
            }
        }
    }
}
