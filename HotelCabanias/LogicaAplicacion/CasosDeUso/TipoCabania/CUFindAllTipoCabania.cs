using DTOs;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUFindAllTipoCabania: ICUFindAllTipoCabania
    {
    
        public IRepositorioTipoCabania RepoTipoCabania { get; set; }

        public CUFindAllTipoCabania(IRepositorioTipoCabania repoTipoCabania)
        {
            RepoTipoCabania = repoTipoCabania;
        }

        public IEnumerable<DTOTipoCabania> FindAllTipoCabania()
        {
            try
            {
                IEnumerable<TipoCabania> tipoCabanias = RepoTipoCabania.FindAll();

                IEnumerable<DTOTipoCabania> dtoTipoCabanias = tipoCabanias.Select(t => new DTOTipoCabania()
                {
                    Id = t.Id,
                    Nombre = t.Nombre.TextoNombre,
                    Descripcion = t.Descripcion,
                    CostoxHuesped = t.CostoxHuesped.ValorCosto
                });
                return dtoTipoCabanias;
            }
            catch
            {
                throw;
            }
        }
    }
}
