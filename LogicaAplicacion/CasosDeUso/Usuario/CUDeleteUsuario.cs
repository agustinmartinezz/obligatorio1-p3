using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasoDeUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUDeleteUsuario : ICUDeleteUsuario
    {

        public IRepositorioUsuario RepoUsuario { get; set; }

        public CUDeleteUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public DTOUsuario DeleteUsuario(int usuarioId)
        {

            try
            {
                Usuario u = new Usuario(dtoUsuario.Nombre, dtoUsuario.Mail, dtoUsuario.Contrasenia);
                RepoUsuario.Add(u);
                dtoUsuario.Id = u.Id;
                return dtoUsuario;
                RepoUsuario.Delete(usuarioId);
            }
            catch
            {
                throw;
            }
         
        }
    }
}
