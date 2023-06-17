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
    public class CUFindAllUsuario : ICUFindAllUsuario
    {

        public IRepositorioUsuario RepoUsuario { get; set; }

        public CUFindAllUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public void FindAllUsuario()
        {
            try
            {
                RepoUsuario.FindAll();
            }
            catch
            {
                throw;
            }
        }
    }
}
