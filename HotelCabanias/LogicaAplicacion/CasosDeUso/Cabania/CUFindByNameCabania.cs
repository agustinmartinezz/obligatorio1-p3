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
    public class CUFindByNameCabania:ICUFindByNameCabania
    {
    
        public IRepositorioCabania RepoCabania { get; set; }

        public CUFindByNameCabania(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
        }

        public IEnumerable<DTOCabania> FindByNameCabania(string name)
        {
            try
            {
                IEnumerable<Cabania> cabanias = RepoCabania.FindByName(name);

                IEnumerable<DTOCabania> dtoCabanias = cabanias.Select(c => new DTOCabania()
                {
                    Id = c.Id,
                    TipoId = c.TipoId,
                    Nombre = c.Nombre.TextoNombre,
                    Descripcion = c.Descripcion,
                    TieneJacuzzi = c.TieneJacuzzi,
                    HabilitadaReservas = c.HabilitadaReservas,
                    NumeroHabitacion = c.NumeroHabitacion,
                    MaxPersonas = c.MaxPersonas,
                    Foto = c.Foto,
                });
                return dtoCabanias;
            }
            catch
            {
                throw;
            }
        }
    }
}
