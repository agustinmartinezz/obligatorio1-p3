using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using HotelCabañas.Models;

namespace HotelCabañas.Controllers
{
    public class CabaniaController : Controller
    {
        public IRepositorioCabania repositorioCabania { get; set; }
        public IRepositorioTipoCabania repositorioTipoCabania { get; set; }

        private readonly IWebHostEnvironment _env;
        public CabaniaController(IRepositorioCabania repoCabania,IRepositorioTipoCabania repoTipoCabania, IWebHostEnvironment env)
        {
            repositorioCabania = repoCabania;
            repositorioTipoCabania = repoTipoCabania;
            _env = env;
        }

        // GET: CabaniaController

        [HttpGet]
        public ActionResult Index()
        {
            VMCabania vmCabania = new VMCabania();
            vmCabania.Cabanias = repositorioCabania.FindAll();
            return View(vmCabania);
        }

        [HttpPost]
        public ActionResult Index(VMCabania vmCabania)
        {
            string? searchText = vmCabania.strSearchCabania;
            int intSearch = Int32.Parse(searchText);

            switch (vmCabania.searchTypeCabania)
            {
                case 1:
                    vmCabania.Cabanias = repositorioCabania.FindByName(searchText);
                    break;
                case 2:
                    vmCabania.Cabanias = repositorioCabania.FindByTypo(intSearch);
                    break;
                case 3:
                    vmCabania.Cabanias = repositorioCabania.FindByMaxPeople(intSearch);
                    break;
                case 4:
                    vmCabania.Cabanias = repositorioCabania.FindHabilitadas();
                    break;

            }

            return View(vmCabania.Cabanias);
        }

        // GET: CabaniaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CabaniaController/Create
        [HttpGet]
        public ActionResult Create()
        {
            VMCabania vmCabania = new VMCabania();
            vmCabania.Tipos = repositorioTipoCabania.FindAll();
            return View(vmCabania);
        }

        // POST: CabaniaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMCabania vmCabania)
        {
            try
            {
                Cabania c = vmCabania.Cabania;
                if(vmCabania.TieneJacuzzi=="0") c.TieneJacuzzi=false; else c.TieneJacuzzi = true;
                if(vmCabania.HabilitadaReservas=="0") c.HabilitadaReservas = false; else c.HabilitadaReservas = true;


                if (vmCabania.Foto != null)
                {
                    var fileName = Path.GetFileName(vmCabania.Foto.FileName);
                    //()
                    var path = Path.Combine(_env.WebRootPath, "~/Imagenes/Cabanias/", fileName);
                    //vmCabania.Foto.SaveAs(path);

                    // Guarda la ruta de la imagen en la base de datos
                    //c.Foto = "/Imagenes/Cabanias/" + fileName;
                }
               // repositorioCabania.Add(c); 
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Mensaje = e.Message;
                vmCabania.Tipos = repositorioTipoCabania.FindAll();
                return View(vmCabania);
            }
        }

        // GET: CabaniaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CabaniaController/Edit/5
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

        // GET: CabaniaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CabaniaController/Delete/5
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
