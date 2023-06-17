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
    public class CUFindByIdCabania: ICUFindByIdCabania
    {
    
        public IRepositorioCabania RepoCabania { get; set; }

        public CUFindByIdCabania(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
        }

        public void FindByIdCabania(int cabaniaId)
        {
            try
            {
                RepoCabania.FindById(cabaniaId);
            }
            catch
            {
                throw;
            }
        }
    }
}
