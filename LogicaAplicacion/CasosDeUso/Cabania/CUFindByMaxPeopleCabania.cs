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
    public class CUFindByMaxPeopleCabania: ICUFindByMaxPeopleCabania
    {
    
        public IRepositorioCabania RepoCabania { get; set; }

        public CUFindByMaxPeopleCabania(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
        }

        public void FindByMaxPeopleCabania(int max)
        {
            try
            {
                RepoCabania.FindByMaxPeople(max);
            }
            catch
            {
                throw;
            }
        }
    }
}
