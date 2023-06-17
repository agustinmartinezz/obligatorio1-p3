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
    public class CULoguearUsuario: ICULoguearUsuario
    {
    
        public IRepositorioUsuario RepoUsuario { get; set; }

        public CULoguearUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public void LoguearUsuario(string mail, string contrasenia)
        {
            try
            {
                RepoUsuario.LoguearUsuario(mail, contrasenia);
            }
            catch
            {
                throw;
            }
        }
    }
}
