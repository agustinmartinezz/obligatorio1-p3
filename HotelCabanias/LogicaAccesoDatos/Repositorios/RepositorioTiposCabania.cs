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
    public class RepositorioTiposCabania : IRepositorioTipoCabania
    {
        public HotelCabaniaContext Contexto { get; set; }

        public RepositorioTiposCabania(HotelCabaniaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(TipoCabania tipoCabania)
        {
            try
            {
                tipoCabania.ValidarDatos();

                Contexto.TipoCabanias.Add(tipoCabania);
                Contexto.SaveChanges();
            } catch
            {
                throw;
            }           
        }

        public TipoCabania FindById(int id)
        {
            return Contexto.TipoCabanias.Find(id);
        }

        public void Delete(int id)
        {
            try
            {
                TipoCabania tipo = this.FindById(id);

                Cabania? cab = Contexto.Cabanias.FirstOrDefault(c => c.TipoId == id);

                if (cab != null)
                    throw new Exception("Existen cabañas de ese tipo.");
                
                Contexto.TipoCabanias.Remove(tipo);
                Contexto.SaveChanges();
            } catch
            {
                throw;
            }
            
        }

        public void Update(int id, TipoCabania tipoCabania)
        {
            try
            {
                tipoCabania.ValidarDatos();

                Contexto.TipoCabanias.Update(tipoCabania);
                Contexto.SaveChanges();
            } catch
            {
                throw;
            }
        }

        public IEnumerable<TipoCabania> FindAll()
        {
            try
            {
                return Contexto.TipoCabanias.ToList();
            } catch
            {
                throw;
            }
        }

        public IEnumerable<TipoCabania> FindByName(string nombre)
        {
            try
            {
                return Contexto.TipoCabanias
                    .Where(t => t.Nombre.TextoNombre.Contains(nombre)).ToList();
            } catch
            {
                throw;
            }
        }
    }
}
