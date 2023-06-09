﻿namespace HotelCabañas.Models
{
    public class VMIndexCabania
    {
        public IEnumerable<VMCabania> Cabanias { get; set; }
        public IEnumerable<VMTipoCabania> TiposCabania { get; set; }

        public VMBusqueda Busqueda { get; set; }
        public VMCabania Cabania { get; set; }

        public IFormFile Foto { get; set; }


        public VMIndexCabania()
        {
            Cabanias = new List<VMCabania>();
            TiposCabania = new List<VMTipoCabania>();
            Cabania = new VMCabania();
            Busqueda = new VMBusqueda();

        }
    }


}
