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
    public class CUFindAllCabania: ICUFindAllCabania
    {
    
        public IRepositorioCabania RepoCabania { get; set; }

        public CUFindAllCabania(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
        }

        public void FindAllCabania()
        {
            try
            {
                RepoCabania.FindAll();
            }
            catch
            {
                throw;
            }
        }
    }
}
