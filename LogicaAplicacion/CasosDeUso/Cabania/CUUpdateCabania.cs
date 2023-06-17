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
    public class CUUpdateCabania:ICUUpdateCabania
    {
    
        public IRepositorioCabania RepoCabania { get; set; }

        public CUUpdateCabania(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
        }

        public void UpdateCabania(int Id,Cabania cabania)
        {
            try
            {
                RepoCabania.Update(Id,cabania);
            }
            catch
            {
                throw;
            }
        }
    }
}
