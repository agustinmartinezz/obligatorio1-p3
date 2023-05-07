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
    internal class RepositorioTiposCabana : IRepositorioTipoCabana
    {
        public HotelCabanaContext Contexto { get; set; }

        public RepositorioTiposCabana(HotelCabanaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(TipoCabana tipoCabana)
        {
            try
            {
                tipoCabana.ValidarDatos();

                Contexto.TipoCabanas.Add(tipoCabana);
                Contexto.SaveChanges();
            } catch
            {
                throw;
            }           
        }

        public TipoCabana FindById(int id)
        {
            return Contexto.TipoCabanas.Find(id);
        }

        public void Delete(int id)
        {
            try
            {
                TipoCabana tipo = this.FindById(id);

                Contexto.TipoCabanas.Remove(tipo);
                Contexto.SaveChanges();
            } catch
            {
                throw;
            }
            
        }

        public void Update(int id, TipoCabana cabana)
        {
            try
            {
                Contexto.TipoCabanas.Update(cabana);
                Contexto.SaveChanges();
            } catch
            {
                throw;
            }
        }

        public IEnumerable<TipoCabana> FindAll()
        {
            try
            {
                return Contexto.TipoCabanas.ToList();
            } catch
            {
                throw;
            }
        }

        public IEnumerable<TipoCabana> FindByName(string nombre)
        {
            try
            {
                return Contexto.TipoCabanas
                    .Where(t => t.Nombre.Contains(nombre)).ToList();
            } catch
            {
                throw;
            }
        }
    }
}
