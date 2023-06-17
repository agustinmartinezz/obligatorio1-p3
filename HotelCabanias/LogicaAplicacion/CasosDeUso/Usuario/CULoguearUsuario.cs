using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public class CULoguearUsuario: ICULoguearUsuario
    {
    
        public IRepositorioUsuario RepoUsuario { get; set; }

        public CULoguearUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public DTOUsuario LoguearUsuario(string mail, string contrasenia)
        {
            try
            {
                Usuario usuario = RepoUsuario.LoguearUsuario(mail, contrasenia);

                DTOUsuario dtoUsuario = new() { 
                    Nombre = usuario.Nombre.TextoNombre,
                    Mail = usuario.Mail.TextoMail,
                    Contrasenia = usuario.Contrasenia.TextoContrasenia
                };
                return dtoUsuario;
            }
            catch
            {
                throw;
            }
        }
    }
}
