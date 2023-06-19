using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUFindAllUsuario : ICUFindAllUsuario
    {

        public IRepositorioUsuario RepoUsuario { get; set; }

        public CUFindAllUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public IEnumerable<DTOUsuario> FindAllUsuario()
        {
            try
            {
                IEnumerable<Usuario> usuarios = RepoUsuario.FindAll();
                
                IEnumerable<DTOUsuario> dtoUsuarios = usuarios.Select(u => new DTOUsuario()
                {
                    Id = u.Id,
                    Nombre = u.Nombre.TextoNombre,
                    Mail = u.Mail.TextoMail,
                    Contrasenia = u.Contrasenia.TextoContrasenia,
                });
                return dtoUsuarios;
            }
            catch
            {
                throw;
            }
        }
    }
}
