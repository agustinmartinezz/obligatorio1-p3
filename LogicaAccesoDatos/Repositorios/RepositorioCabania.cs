using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAccesoDatos.BaseDatos;
using LogicaNegocio;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioCabania:IRepositorioCabania
    {
        public HotelCabaniaContext Contexto { get; set; }

        public RepositorioCabania(HotelCabaniaContext contexto)
        {
            Contexto = contexto;
        }

        private static List<Cabania> Cabanias = new List<Cabania>();
        public void Add(Cabania cabania)
        {
            try
            {
                cabania.ValidarDatos();
                Contexto.Cabanias.Add(cabania);
                Contexto.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Cabania FindById(int id)
        {
            return Contexto.Cabanias.Find(id);
        }

        public void Delete(int id)
        {
            try
            {
                Cabania cabania = this.FindById(id);

                IEnumerable<Mantenimiento>? m = Contexto.Mantenimientos
                    .Where(m => m.CabaniaId == cabania.Id)
                    .ToList();

                foreach (Mantenimiento man in m)
                {
                    Contexto.Mantenimientos.Remove(man);
                }

                Contexto.Cabanias.Remove(cabania);
                Contexto.SaveChanges();
            }
            catch
            {
                throw;
            }

        }

        public IEnumerable<Cabania> FindAll()
        {
            try
            {
                return Contexto.Cabanias
                    .Include(c => c.Tipo)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public void Update(int id, Cabania cabania)
        {
            try
            {
                Contexto.Cabanias.Update(cabania);
                Contexto.SaveChanges();
            }
            catch
            {
                throw;
            }
        }


        public IEnumerable<Cabania> FindByName(string nombre)
        {
            try
            {
                return Contexto.Cabanias
                    .Where(c => c.Nombre.ToLower().Contains(nombre.ToLower()))
                    .Include(c => c.Tipo)
                    .ToList();
            } catch
            {
                throw;
            }
            
        }

        public IEnumerable<Cabania> FindByTypo(int tipoId)
        {
            try
            {
                return Contexto.Cabanias
                .Where(c => c.TipoId == tipoId)
                .Include(c => c.Tipo)
                .ToList();
            } catch
            {
                throw;
            }
        }

        public IEnumerable<Cabania> FindByMaxPeople(int maxPeople)
        {
            try
            {
                return Contexto.Cabanias
                  .Where(c => c.MaxPersonas >= maxPeople)
                  .Include(c => c.Tipo)
                  .ToList();
            } catch
            {
                throw;
            }
        }

        public IEnumerable<Cabania> FindHabilitadas()
        {
            try
            {
                return Contexto.Cabanias
                    .Where(c => c.HabilitadaReservas)
                    .Include(c => c.Tipo)
                    .ToList();
            } catch
            {
                throw;
            }
        }
    } 
    
}






