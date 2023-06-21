using LogicaAccesoDatos.BaseDatos;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioConsulta : IRepositorioConsulta
    {
        public HotelCabaniaContext Contexto { get; set; }

        public RepositorioConsulta(HotelCabaniaContext contexto)
        {
            Contexto = contexto;
        }

        IEnumerable<object> IRepositorioConsulta.ConsultaA(int idTipo, int monto)
        {
            IEnumerable<object> lista =
            Contexto.Cabanias
                .Where(c => c.TipoId == idTipo)
                .Where(c => c.Tipo.CostoxHuesped.ValorCosto < monto)
                .Where(c => c.TieneJacuzzi == true)
                .Where(c => c.HabilitadaReservas == true)
                .Select(c => new { c.Nombre.TextoNombre, c.MaxPersonas })
                .ToList();

            return lista;
        }

        IEnumerable<object> IRepositorioConsulta.ConsultaB(int desde, int hasta)
        {
            IEnumerable<int> cabanias = Contexto.Cabanias
                .Where(c => c.MaxPersonas >= desde)
                .Where(c => c.MaxPersonas <= hasta)
                .Select(c => c.Id).ToList();

            IEnumerable<object> lista = Contexto.Mantenimientos
                .Where(m => cabanias.Contains(m.Cabania.Id))
                .Select(m => new { 
                    m.NombreRealizo, 
                    CantidadMantenimientos = Contexto.Mantenimientos
                            .Where(man => man.NombreRealizo.Equals(m.NombreRealizo))
                            .Where(man => cabanias.Contains(man.CabaniaId))
                            .Count() 
                }).Distinct().ToList();

            return lista;
        }
    }
}
