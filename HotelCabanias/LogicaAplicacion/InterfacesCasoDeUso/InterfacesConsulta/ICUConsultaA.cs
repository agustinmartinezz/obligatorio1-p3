using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasoDeUso
{
    public interface ICUConsultaA
    {
        public IEnumerable<object> ConsultaA(int idTipo, int monto);
    }
}
