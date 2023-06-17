using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasoDeUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUFindByIdCabania: ICUFindByIdCabania
    {
    
        public IRepositorioCabania RepoCabania { get; set; }

        public CUFindByIdCabania(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
        }

        public DTOCabania FindByIdCabania(int cabaniaId)
        {
            try
            {
                Cabania c = RepoCabania.FindById(cabaniaId);

                return new DTOCabania() {
                    TipoId = c.TipoId,
                    Nombre = c.Nombre.TextoNombre,
                    Descripcion = c.Descripcion,
                    TieneJacuzzi = c.TieneJacuzzi,
                    HabilitadaReservas = c.HabilitadaReservas,
                    NumeroHabitacion = c.NumeroHabitacion,
                    MaxPersonas = c.MaxPersonas,
                    Foto = c.Foto,
                };
            }
            catch
            {
                throw;
            }
        }
    }
}
