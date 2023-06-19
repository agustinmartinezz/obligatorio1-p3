using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasoDeUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUDeleteCabania: ICUDeleteCabania
    {
    
        public IRepositorioCabania RepoCabania { get; set; }

        public CUDeleteCabania(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
        }

        public void DeleteCabania(int cabaniaId)
        {
            try
            {
                RepoCabania.Delete(cabaniaId);
              
            }
            catch
            {
                throw;
            }
        }
    }
}
