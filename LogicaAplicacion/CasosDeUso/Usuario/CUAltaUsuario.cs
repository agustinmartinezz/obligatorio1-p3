using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using DTOs;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUAltaUsuario: ICUAltaUsuario
    {
    
        public IRepositorioUsuario RepoUsuario { get; set; }

        public CUAltaUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public DTOUsuario AltaUsuario(DTOUsuario dtoUsuario)
        {

            try
            {
                Usuario usuario = new ()
                {
                    Nombre = new Nombre(dtoUsuario.Nombre),
                    Mail = new Mail(dtoUsuario.Mail),
                    Contrasenia = new Contrasenia(dtoUsuario.Contrasenia)
                };

                RepoUsuario.Add(usuario);
                dtoUsuario.Id = usuario.Id; //revisar si funciona.

                return dtoUsuario;
            }
            catch
            {
                throw;
            }
            
        }
    }
}
