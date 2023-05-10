using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAccesoDatos.BaseDatos;
using LogicaNegocio;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioMantenimiento:IRepositorioMantenimiento
    {
        public HotelCabaniaContext Contexto { get; set; }

        public RepositorioMantenimiento(HotelCabaniaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Mantenimiento m)
        {
            try
            {
                m.ValidarDatos();
                Contexto.Mantenimientos.Add(m);
                Contexto.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Mantenimiento m = FindById(id);

                Contexto.Mantenimientos.Remove(m);
                Contexto.SaveChanges();
            } catch {
                throw;
            }
        }

        public Mantenimiento FindById(int id)
        {
            return Contexto.Mantenimientos.Find(id);
        }

        public IEnumerable<Mantenimiento> FindByDates(int CabaniaId,DateTime fecha1, DateTime fecha2)
        {
           return Contexto.Mantenimientos
                .Where(m => m.Fecha.Date >= fecha1.Date)
                .Where(m => m.Fecha.Date <= fecha2.Date)
                .Where(m => m.CabaniaId >= CabaniaId)
                .OrderByDescending(m => m.Costo)
                .ToList();

        }

        public void Update(int id, Mantenimiento m)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mantenimiento> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
