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
        public void Add(Cabania c)
        {
            try
            {
                c.ValidarDatos();
                Cabanias.Add(c);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(int id)
        {

            Cabania Cabania = FindById(id);
            if (Cabania != null)
            {
                Cabanias.Remove(Cabania);
            }

        }

        public Cabania FindById(int id)
        {
            Cabania Cabania = null;
            int i = 0;
            while (i < Cabanias.Count && Cabanias == null)
            {
                if (Cabanias[i].Id == id)
                {
                    Cabania = Cabanias[i];
                }
                i++;
            }
            return Cabania;

        }

        public IEnumerable<Cabania> FindAll()
        {
            // throw new NotImplementedException();
            return Cabanias;
        }

        public void Update(int id, Cabania Cabania)
        {

            Cabania CabaniaBuscado = FindById(id);
            if (CabaniaBuscado != null)
            {
                //corregir lo que corresponda
            }


        }

        public IEnumerable<Cabania> FindByName(string nombre)
        {
            return Contexto.Cabanias
                .Where(c => c.Nombre.ToLower().Contains(nombre.ToLower()))
                .ToList();
        }

        public IEnumerable<Cabania> FindByTypo(int tipoId)
        {
            return Contexto.Cabanias
                .Where(c => c.TipoId==tipoId)
                .ToList();
        }

        public IEnumerable<Cabania> FindByMaxPeople(int maxPeople)
        {
            return Contexto.Cabanias
              .Where(c => c.MaxPersonas >= maxPeople)
              .ToList();
        }

        public IEnumerable<Cabania> FindHabilitadas()
        {
            return Contexto.Cabanias
             .Where(c => c.HabilitadaReservas)
             .ToList();
        }
    } 
    
}
