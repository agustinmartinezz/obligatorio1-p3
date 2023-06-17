using DTOs;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUAltaTipoCabania : ICUAltaTipoCabania
    {
    
        public IRepositorioTipoCabania RepoTipoCabania { get; set; }

        public CUAltaTipoCabania(IRepositorioTipoCabania repoTipoCabania)
        {
            RepoTipoCabania = repoTipoCabania;
        }

        public void AltaTipoCabania(DTOTipoCabania dtoTipoCabania)
        {
            try
            {
                TipoCabania tipoCabania = new()
                {
                    Nombre = new NombreTipoCabania(dtoTipoCabania.Nombre),
                    Descripcion = dtoTipoCabania.Descripcion,
                    CostoxHuesped = new Costo(dtoTipoCabania.CostoxHuesped)
                };

                RepoTipoCabania.Add(tipoCabania);
            }
            catch
            {
                throw;
            }
        }
    }
}
