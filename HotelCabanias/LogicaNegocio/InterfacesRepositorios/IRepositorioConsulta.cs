using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioConsulta
    {
        IEnumerable<object> ConsultaA(int idTipo, int monto);
        IEnumerable<object> ConsultaB(int desde, int hasta);
    }
}
