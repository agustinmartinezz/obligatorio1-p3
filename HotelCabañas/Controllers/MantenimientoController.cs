using HotelCabañas.Models;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelCabañas.Controllers
{
    public class MantenimientoController : Controller

    {

        public IRepositorioCabana repositorioCabana { get; set; }
        public IRepositorioMantenimiento repositorioMantenimiento { get; set; }


        public MantenimientoController(IRepositorioCabana repoCabana, IRepositorioMantenimiento repoMantenimiento)
        {
            repositorioCabana = repoCabana;
            repositorioMantenimiento = repoMantenimiento;
        }


        // GET: MantenimientoController
        public ActionResult Index(VMMantenimiento vmMantenimiento)
        {
            vmMantenimiento.Mantenimientos = repositorioMantenimiento.FindByDates(vmMantenimiento.Cabana.Id,vmMantenimiento.date1, vmMantenimiento.date2);

            return View(vmMantenimiento.Mantenimiento);
        }

        // GET: MantenimientoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

        // GET: MantenimientoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MantenimientoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: MantenimientoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MantenimientoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
