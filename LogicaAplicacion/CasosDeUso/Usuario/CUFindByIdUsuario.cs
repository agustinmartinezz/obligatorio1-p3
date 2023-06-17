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
    public class CUFindByIdUsuario : ICUFindByIdUsuario
    {

        public IRepositorioUsuario RepoUsuario { get; set; }

        public CUFindByIdUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public DTOUsuario FindByIdUsuario(int usuarioId)
        {
            try
            {
                Usuario u = RepoUsuario.FindById(usuarioId);

                if (u != null)
                {
                    DTOUsuario dtoUsuario =
                    new DTOUsuario()
                    {
                        Id = u.Id,
                        Nombre = u.Nombre.TextoNombre,
                        Mail = u.Mail.TextoMail,
                        Contrasenia = u.Contrasenia.TextoContrasenia,

                    };
                    return dtoUsuario;
                }
                else
                {
                    throw new Exception("El id no es correcto");
                }
            }
            catch
            {
                throw;
            }
        }


    }
}
