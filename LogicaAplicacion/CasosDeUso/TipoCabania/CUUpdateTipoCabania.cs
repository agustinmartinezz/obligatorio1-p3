using DTOs;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUUpdateTipoCabania:ICUUpdateTipoCabania
    {
    
        public IRepositorioTipoCabania RepoTipoCabania { get; set; }

        public CUUpdateTipoCabania(IRepositorioTipoCabania repoTipoCabania)
        {
            RepoTipoCabania = repoTipoCabania;
        }

        public void UpdateTipoCabania(int Id,DTOTipoCabania dtoTipoCabania)
        {
            try
            {
                TipoCabania tipoCabania = new()
                {
                    Nombre = new NombreTipoCabania(dtoTipoCabania.Nombre),
                    Descripcion = dtoTipoCabania.Descripcion,
                    CostoxHuesped = new Costo(dtoTipoCabania.CostoxHuesped)
                };
                RepoTipoCabania.Update(Id, tipoCabania);
            }
            catch
            {
                throw;
            }
        }
    }
}
