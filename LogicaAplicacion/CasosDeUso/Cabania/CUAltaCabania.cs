﻿using LogicaNegocio.InterfacesRepositorios;
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

        public void AltaCabania(DTOCabania dtoCabania)
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

                RepoCabania.Add(cabania);
            }
            catch
            {
                throw;
            }
        }
    }
}
