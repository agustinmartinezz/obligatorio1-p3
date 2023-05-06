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
    public class RepositorioCabana:IRepositorioCabana
    {
        public HotelCabanaContext Contexto { get; set; }

        public RepositorioCabana(HotelCabanaContext contexto)
        {
            Contexto = contexto;
        }

        private static List<Cabana> cabanas = new List<Cabana>();
        public void Add(Cabana c)
        {
            try
            {
                c.ValidarDatos();
                cabanas.Add(c);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(int id)
        {

            Cabana cabana = FindById(id);
            if (cabana != null)
            {
                cabanas.Remove(cabana);
            }

        }

        public Cabana FindById(int id)
        {
            Cabana cabana = null;
            int i = 0;
            while (i < cabanas.Count && cabanas == null)
            {
                if (cabanas[i].Id == id)
                {
                    cabana = cabanas[i];
                }
                i++;
            }
            return cabana;

        }

        public IEnumerable<Cabana> FindAll()
        {
            // throw new NotImplementedException();
            return cabanas;
        }

        public void Update(int id, Cabana cabana)
        {

            Cabana cabanaBuscado = FindById(id);
            if (cabanaBuscado != null)
            {
                //corregir lo que corresponda
            }


        }

        public IEnumerable<Cabana> FindByName(string nombre)
        {
            return Contexto.Cabanas
                .Where(c => c.Nombre.ToLower().Contains(nombre.ToLower()))
                .ToList();
        }

        public IEnumerable<Cabana> FindByTypo(int tipoId)
        {
            return Contexto.Cabanas
                .Where(c => c.TipoId==tipoId)
                .ToList();
        }

        public IEnumerable<Cabana> FindByMaxPeople(int maxPeople)
        {
            return Contexto.Cabanas
              .Where(c => c.MaxPersonas >= maxPeople)
              .ToList();
        }

        public IEnumerable<Cabana> FindHabilitadas()
        {
            return Contexto.Cabanas
             .Where(c => c.HabilitadaReservas)
             .ToList();
        }
    } 
    
}
