using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUDeleteTipoCabania: ICUDeleteTipoCabania
    {
    
        public IRepositorioTipoCabania RepoTipoCabania { get; set; }

        public CUDeleteTipoCabania(IRepositorioTipoCabania repoTipoCabania)
        {
            RepoTipoCabania = repoTipoCabania;
        }

        public void DeleteTipoCabania(int tipoCabaniaId)
        {
            try
            {
                RepoTipoCabania.Delete(tipoCabaniaId);
            }
            catch
            {
                throw;
            }
        }
    }
}
