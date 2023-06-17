using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasoDeUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUUpdateCabania:ICUUpdateCabania
    {
    
        public IRepositorioCabania RepoCabania { get; set; }

        public CUUpdateCabania(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
        }

        public void UpdateCabania(int Id, DTOCabania dtoCabania)
        {
            try
            {
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
                };

                RepoCabania.Update(Id, cabania);
            }
            catch
            {
                throw;
            }
        }
    }
}
