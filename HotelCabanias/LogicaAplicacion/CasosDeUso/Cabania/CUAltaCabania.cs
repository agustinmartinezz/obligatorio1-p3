using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasoDeUso;
using DTOs;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObjects;
using LogicaAccesoDatos.Repositorios;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUAltaCabania : ICUAltaCabania
    {
    
        public IRepositorioCabania RepoCabania { get; set; }
        public IRepositorioTipoCabania RepoTipoCabania { get; set; }


        public CUAltaCabania(IRepositorioCabania repoCabania, IRepositorioTipoCabania repoTipoCabania)
        {
            RepoCabania = repoCabania;
            RepoTipoCabania = repoTipoCabania;

        }

        public DTOCabania AltaCabania(DTOCabania dtoCabania)
        {
            try
            {
                List<string> Fotos = new List<string>();
                //RepoCabania.AddPicture();
                //Fotos.(dtoCabania.Foto);

                Cabania cabania = new()
                {
                    TipoId = dtoCabania.TipoId,
                    Nombre = new Nombre(dtoCabania.Nombre),
                    Descripcion = dtoCabania.Descripcion,
                    TieneJacuzzi = dtoCabania.TieneJacuzzi,
                    HabilitadaReservas = dtoCabania.HabilitadaReservas,
                    //NumeroHabitacion = dtoCabania.NumeroHabitacion,
                    MaxPersonas = dtoCabania.MaxPersonas,
                    Foto = dtoCabania.Foto,
                    Fotos = Fotos,
                };

                cabania.Foto = cabania.GetNombreFoto() + Path.GetExtension(dtoCabania.Foto);
                RepoCabania.Add(cabania);

                dtoCabania.Id = cabania.Id;
                dtoCabania.Foto = cabania.Foto;

                TipoCabania tipoCab = RepoTipoCabania.FindById(cabania.TipoId);
                dtoCabania.TipoCabania = new ()
                {
                    Id = tipoCab.Id,
                    Nombre = tipoCab.Nombre.TextoNombre,
                    Descripcion = tipoCab.Descripcion,
                    CostoxHuesped = tipoCab.CostoxHuesped.ValorCosto
                };
            }
            catch
            {
                throw;
            }
            return dtoCabania;
        }
    }
}
