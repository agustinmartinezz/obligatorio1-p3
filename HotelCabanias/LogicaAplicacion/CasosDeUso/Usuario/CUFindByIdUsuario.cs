using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
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
                    DTOUsuario dtoUsuario = new()
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
