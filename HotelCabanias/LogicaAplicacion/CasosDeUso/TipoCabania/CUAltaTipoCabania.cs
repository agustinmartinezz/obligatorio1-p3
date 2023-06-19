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

        public DTOTipoCabania AltaTipoCabania(DTOTipoCabania dtoTipoCabania)
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
                dtoTipoCabania.Id = tipoCabania.Id;
            }
            catch
            {
                throw;
            }
            return dtoTipoCabania;
        }
    }
}
