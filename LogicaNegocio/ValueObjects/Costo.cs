using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    

    public class Costo : IValidar
    {
        public int ValorCosto { get; }
        
        public Costo(int valorCosto) {
            this.ValorCosto = valorCosto;
            //ValidarDatos();
        }

        public void ValidarDatos()
        {
            if (ValorCosto <= 0)
            {
                throw new CostoException("El costo debe ser mayor que 0.");
            }
        }
    }
}
