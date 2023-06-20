using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasoDeUso;
using DTOs;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUAltaCabania : ICUAltaCabania
    {
    
        public IRepositorioCabania RepoCabania { get; set; }

        public CUAltaCabania(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
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
                    NumeroHabitacion = dtoCabania.NumeroHabitacion,
                    MaxPersonas = dtoCabania.MaxPersonas,
                    Foto = dtoCabania.Foto,
                    Fotos = Fotos,
                };

                RepoCabania.Add(cabania);
                dtoCabania.Id = cabania.Id;
            }
            catch
            {
                throw;
            }
            return dtoCabania;
        }
    }
}
