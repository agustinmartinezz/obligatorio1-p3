using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class TipoCabana:IValidar
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CostoxHuesped { get; set; }

        public void ValidarDatos()
        {
            throw new NotImplementedException();
        }
    }
}
