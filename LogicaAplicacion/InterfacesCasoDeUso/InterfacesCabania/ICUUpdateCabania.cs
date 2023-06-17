using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasoDeUso
{
    public interface ICUUpdateCabania
    {
        public void UpdateCabania(int Id, Cabania cabania);
    }
}
