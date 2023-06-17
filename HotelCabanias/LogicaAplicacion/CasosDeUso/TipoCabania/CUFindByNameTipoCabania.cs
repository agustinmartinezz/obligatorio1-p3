using DTOs;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUFindByNameTipoCabania:ICUFindByNameTipoCabania
    {
    
        public IRepositorioTipoCabania RepoTipoCabania { get; set; }

        public CUFindByNameTipoCabania(IRepositorioTipoCabania repoTipoCabania)
        {
            RepoTipoCabania = repoTipoCabania;
        }

        public IEnumerable<DTOTipoCabania> FindByNameTipoCabania(string name)
        {
            try
            {
                IEnumerable<TipoCabania> tipoCabanias = RepoTipoCabania.FindByName(name);

                IEnumerable<DTOTipoCabania> dtoTipoCabanias = tipoCabanias.Select(t => new DTOTipoCabania()
                {
                    Nombre = t.Nombre.TextoNombre,
                    Descripcion = t.Descripcion,
                    CostoxHuesped = t.CostoxHuesped.ValorCosto,
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
