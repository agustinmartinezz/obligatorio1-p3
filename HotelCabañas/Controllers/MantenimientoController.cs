using HotelCabañas.Models;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.EntidadesNegocio;
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
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            VMMantenimiento vmMantenimiento = new();

            vmMantenimiento.IdCabania = idCabania;
            vmMantenimiento.Cabania = repositorioCabania.FindById(idCabania);
            
            return View(vmMantenimiento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(VMMantenimiento vmMantenimiento)
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

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
        public ActionResult Create(int idCabania)
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            VMAltaMantenimiento vmAltaMan = new VMAltaMantenimiento();
            vmAltaMan.CabaniaId = idCabania;

            return View(vmAltaMan);
        }

        // POST: MantenimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMAltaMantenimiento vmAltaMan)
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            try
            {
                vmAltaMan.Mantenimiento.CabaniaId = vmAltaMan.CabaniaId;
                vmAltaMan.Mantenimiento.Cabania = repositorioCabania.FindById(vmAltaMan.CabaniaId);
                
                repositorioMantenimiento.Add(vmAltaMan.Mantenimiento);

                VMCabania vmCabania = new VMCabania();
                vmCabania.Cabanias = repositorioCabania.FindAll();

                TempData["Message"] = "Mantenimiento ingresado con exito.";
                return RedirectToAction("Index", "Cabania");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(vmAltaMan);
            }
        }
    }
}
