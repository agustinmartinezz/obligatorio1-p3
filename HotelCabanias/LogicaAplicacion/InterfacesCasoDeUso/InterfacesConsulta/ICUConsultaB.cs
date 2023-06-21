using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasoDeUso
{
    public interface ICUConsultaB
    {
        public IEnumerable<object> ConsultaB(int desde, int hasta);
    }
}
