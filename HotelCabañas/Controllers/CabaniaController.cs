using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using HotelCabañas.Models;
using Microsoft.AspNetCore;

namespace HotelCabañas.Controllers
{
    public class CabaniaController : Controller
    {
        public IRepositorioCabania repositorioCabania { get; set; }
        public IRepositorioTipoCabania repositorioTipoCabania { get; set; }

        private IWebHostEnvironment WebHost { get; set; }
        public CabaniaController(IRepositorioCabania repoCabania,IRepositorioTipoCabania repoTipoCabania, IWebHostEnvironment webHost)
        {
            repositorioCabania = repoCabania;
            repositorioTipoCabania = repoTipoCabania;
            WebHost = webHost;
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
            

            switch (vmCabania.searchTypeCabania)
            {
                case 1:
                    vmCabania.Cabanias = repositorioCabania.FindByName(searchText);
                    break;
                case 2:
                    int intSearch = Int32.Parse(searchText);
                    vmCabania.Cabanias = repositorioCabania.FindByTypo(intSearch);
                    break;
                case 3:
                    int intSearch2 = Int32.Parse(searchText);
                    vmCabania.Cabanias = repositorioCabania.FindByMaxPeople(intSearch2);
                    break;
                case 4:
                    vmCabania.Cabanias = repositorioCabania.FindHabilitadas();
                    break;

            }

            return View(vmCabania);
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
                string nombreImagen = vmCabania.Foto.FileName;
                string ruta = Path.Combine(WebHost.WebRootPath, "Imagenes");
                string rutaArchivo = Path.Combine(ruta, nombreImagen);
                //string rutaArchivo = Path.Combine(ruta, "Imagenes");

                FileStream foto = new FileStream(rutaArchivo, FileMode.Create);
                vmCabania.Foto.CopyTo(foto);
                c.Tipo = repositorioTipoCabania.FindById(c.TipoId);
                c.Foto = nombreImagen;
                repositorioCabania.Add(c);
                return RedirectToAction(nameof(Index));
            }

            catch (Exception e)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                repositorioCabania.Delete(id);

                TempData["Mensaje"] = "Tipo de cabaña eliminado correctamente.";

                VMCabania vmCabania = new VMCabania();
                return RedirectToAction("Index", vmCabania);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }
    }
}
