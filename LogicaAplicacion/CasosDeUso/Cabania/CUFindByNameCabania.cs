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
    public class CUFindByNameCabania:ICUFindByNameCabania
    {
    
        public IRepositorioCabania RepoCabania { get; set; }

        public CUFindByNameCabania(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
        }

        public void FindByNameCabania(string name)
        {
            try
            {
                RepoCabania.FindByName(name);
            }
            catch
            {
                throw;
            }
        }
    }
}
