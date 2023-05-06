using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    internal class RepositorioUsuarios : IRepositorio<Usuario>
    {
        void IRepositorio<Usuario>.Add(Usuario t)
        {
            throw new NotImplementedException();
        }

        void IRepositorio<Usuario>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Usuario> IRepositorio<Usuario>.FindAll()
        {
            throw new NotImplementedException();
        }

        Usuario IRepositorio<Usuario>.FindById(int id)
        {
            throw new NotImplementedException();
        }

        void IRepositorio<Usuario>.Update(int id, Usuario t)
        {
            throw new NotImplementedException();
        }
    }
}
