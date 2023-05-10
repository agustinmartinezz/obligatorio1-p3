using HotelCabañas.Models;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelCabañas.Controllers
{
    public class MantenimientoController : Controller

    {
        public IRepositorioCabania repositorioCabania { get; set; }
        public IRepositorioMantenimiento repositorioMantenimiento { get; set; }

        public MantenimientoController(IRepositorioCabania repoCabania, IRepositorioMantenimiento repoMantenimiento)
        {
            repositorioCabania = repoCabania;
            repositorioMantenimiento = repoMantenimiento;
        }


        // GET: MantenimientoController
        public ActionResult Index(int idCabania)
        
        {
            VMMantenimiento vmMantenimiento = new();

            vmMantenimiento.IdCabania = idCabania;
            vmMantenimiento.Cabania = repositorioCabania.FindById(idCabania);
            
            return View(vmMantenimiento);
        }

        [HttpPost]
        public ActionResult Index(VMMantenimiento vmMantenimiento)
        {
            try
            {
                int idCabania = vmMantenimiento.IdCabania;
                vmMantenimiento.Cabania = repositorioCabania.FindById(idCabania);

                if (vmMantenimiento.Fecha1 <= vmMantenimiento.Fecha2)
                {
                    vmMantenimiento.Mantenimientos = repositorioMantenimiento.FindByDates(vmMantenimiento.Cabania.Id, vmMantenimiento.Fecha1, vmMantenimiento.Fecha2);
                    
                    if (!vmMantenimiento.Mantenimientos.Any())
                    {
                        ViewBag.Error = "No se encontraron mantenimientos para las fechas dadas.";
                    }
                }
                else
                {
                    ViewBag.Error = "La fecha desde debe ser menor o igual a la fecha hasta";
                }
            } catch (Exception e)
            {
                ViewBag.Error = e;
            }

            return View(vmMantenimiento);
        }

        // GET: MantenimientoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MantenimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
