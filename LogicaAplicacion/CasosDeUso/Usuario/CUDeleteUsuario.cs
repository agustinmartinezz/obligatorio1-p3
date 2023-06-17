using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUDeleteUsuario : ICUDeleteUsuario
    {

        public IRepositorioUsuario RepoUsuario { get; set; }

        public CUDeleteUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public void DeleteUsuario(int usuarioId)
        {

            try
            {
                RepoUsuario.Delete(usuarioId);
            }
            catch
            {
                throw;
            }
         
        }
    }
}
