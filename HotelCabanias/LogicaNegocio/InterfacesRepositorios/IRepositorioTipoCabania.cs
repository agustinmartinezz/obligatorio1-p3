using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioTipoCabania : IRepositorio<TipoCabania>
    {
        public IEnumerable<TipoCabania> FindByName(string nombre);
    }
}
