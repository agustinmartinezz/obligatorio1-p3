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
    public class CUUpdateUsuario : ICUUpdateUsuario
    {

        public IRepositorioUsuario RepoUsuario { get; set; }

        public CUUpdateUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public void UpdateUsuario(int Id,Usuario usuario)
        {
            try
            {
                RepoUsuario.Update(Id,usuario);
            }
            catch
            {
                throw;
            }
        }
    }
}
