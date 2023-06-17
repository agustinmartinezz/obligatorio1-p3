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
    public class CUAddPictureCabania : ICUAddPictureCabania
    {
    
        public IRepositorioCabania RepoCabania { get; set; }

        public CUAddPictureCabania(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
        }

        public void AddPicture(int cabaniaId, string name)
        {
            try
            {
                RepoCabania.AddPicture(cabaniaId, name);
            }
            catch
            {
                throw;
            }
        }
    }
}
