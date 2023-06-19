﻿using LogicaNegocio.EntidadesNegocio;
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
    public class CUFindByTipoCabania : ICUFindByTipoCabania
    {
    
        public IRepositorioCabania RepoCabania { get; set; }

        public CUFindByTipoCabania(IRepositorioCabania repoCabania)
        {
            RepoCabania = repoCabania;
        }

        public IEnumerable<DTOCabania> FindByTipoCabania(int tipoId)
        {
            try
            {   
                IEnumerable<Cabania> cabanias = RepoCabania.FindByTipo(tipoId);

                IEnumerable<DTOCabania> dtoCabanias = cabanias.Select(c => new DTOCabania()
                {
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