
using Microsoft.AspNetCore.Mvc;
using HotelCabañas.Models;
using Newtonsoft.Json;
using System.Net.Http;
using HotelCabañas.Filters;

namespace HotelCabañas.Controllers
{
    public class CabaniaController : Controller
    {
        private const string baseURL = "http://localhost:5256/api";
        private IWebHostEnvironment WebHost { get; set; }
        public CabaniaController(IWebHostEnvironment webHost)
        {
            WebHost = webHost;
        }

        // GET: CabaniaController
        [Logueado]
        [HttpGet]
        public ActionResult Index()
        {
            VMIndexCabania vmIndexCabania = new VMIndexCabania();

            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(baseURL + "/Cabania" );
            Task<HttpResponseMessage> getCabanias = httpClient.GetAsync(httpClient.BaseAddress);
            getCabanias.Wait();

            httpClient.BaseAddress = new Uri(baseURL + "/TipoCabania");
            Task<HttpResponseMessage> getTiposCabania = httpClient.GetAsync(httpClient.BaseAddress);
            getTiposCabania.Wait();


            if (getCabanias.Result.IsSuccessStatusCode)
            {
                HttpContent contenido = getCabanias.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();

                deseralize.Wait();

                vmIndexCabania.Cabanias = JsonConvert.DeserializeObject<IEnumerable<VMCabania>>(deseralize.Result);
            }
            else
            {
                HttpContent contenido = getCabanias.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();
                ViewBag.Mensaje = deseralize.Result;
            }

            if (getTiposCabania.Result.IsSuccessStatusCode)
            {
                HttpContent contenido = getTiposCabania.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();

                deseralize.Wait();

                vmIndexCabania.TiposCabania = JsonConvert.DeserializeObject<IEnumerable<VMTipoCabania>>(deseralize.Result);
            }
            else
            {
                HttpContent contenido = getTiposCabania.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();
                ViewBag.Mensaje = deseralize.Result;
            }

            vmIndexCabania.Busqueda.SearchNumber = 1;

            return View(vmIndexCabania);
        }

        [Logueado]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(VMIndexCabania VMIndexCabania)
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            HttpClient httpClient = new HttpClient();

            
            httpClient.BaseAddress = new Uri(baseURL + "/TipoCabania");
            Task<HttpResponseMessage> getTiposCabania = httpClient.GetAsync(httpClient.BaseAddress);
            getTiposCabania.Wait();

            try
            {
                switch (VMIndexCabania.Busqueda.SearchOption)
                {
                    case 1:
                        if (string.IsNullOrWhiteSpace(VMIndexCabania.Busqueda.SearchText))
                        {
                            httpClient.BaseAddress = new Uri(baseURL + "/Cabania");
                            //VMIndexCabania.Cabanias = repositorioCabania.FindAll();
                        } else
                        {
                            httpClient.BaseAddress = new Uri(baseURL + "/Cabania/Name/" + VMIndexCabania.Busqueda.SearchText);
                            //VMIndexCabania.Cabanias = repositorioCabania.FindByName(vmCabania.SearchText);
                        }
                        break;
                    case 2:
                        //int intSearch = Int32.Parse(searchText);
                        //VMIndexCabania.Cabanias = repositorioCabania.FindByTipo(vmCabania.SearchType);
                        httpClient.BaseAddress = new Uri(baseURL + "/Cabania/Tipo/" + VMIndexCabania.Busqueda.SearchType);

                        break;
                    case 3:
                        //int intSearch2 = Int32.Parse(searchText);
                        // VMIndexCabania.Cabanias = repositorioCabania.FindByMaxPeople(vmCabania.SearchNumber);
                        httpClient.BaseAddress = new Uri(baseURL + "/Cabania/MaxCupos/" + VMIndexCabania.Busqueda.SearchNumber);

                        break;
                    case 4:
                        //VMIndexCabania.Cabanias = repositorioCabania.FindHabilitadas();
                        httpClient.BaseAddress = new Uri(baseURL + "/Cabania/Habilitadas");

                        break;

                }

                if (!VMIndexCabania.Cabanias.Any())
                {
                    ViewBag.Error = "No existen cabañas ingresadas según el criterio utilizado.";
                }
            } catch (Exception e)
            {
                ViewBag.Error = e.Message;
                //Cabanias
                httpClient.BaseAddress = new Uri(baseURL + "/Cabania");

                //Tipos Cabania
                Task<HttpResponseMessage> getTiposCabanias = httpClient.GetAsync(httpClient.BaseAddress);
                getTiposCabanias.Wait();

                if (getTiposCabania.Result.IsSuccessStatusCode)
                {
                    HttpContent contenido = getTiposCabania.Result.Content;
                    Task<string> deseralize = contenido.ReadAsStringAsync();

                    deseralize.Wait();

                    VMIndexCabania.TiposCabania = JsonConvert.DeserializeObject<IEnumerable<VMTipoCabania>>(deseralize.Result);
                }
                else
                {
                    HttpContent contenido = getTiposCabania.Result.Content;
                    Task<string> deseralize = contenido.ReadAsStringAsync();
                    ViewBag.Mensaje = deseralize.Result;
                }
            }

            Task<HttpResponseMessage> getCabanias = httpClient.GetAsync(httpClient.BaseAddress);
            getCabanias.Wait();

            if (getCabanias.Result.IsSuccessStatusCode)
            {
                HttpContent contenido = getTiposCabania.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();

                deseralize.Wait();

                VMIndexCabania.Cabanias = JsonConvert.DeserializeObject<IEnumerable<VMCabania>>(deseralize.Result);
            }
            else
            {
                HttpContent contenido = getCabanias.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();
                ViewBag.Mensaje = deseralize.Result;
            }


            return View(VMIndexCabania);



        }

        // GET: CabaniaController/Details/5
        [Logueado]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CabaniaController/Create
        [HttpGet]
        [Logueado]
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            VMIndexCabania vmIndexCabania = new ();
            HttpClient httpClient = new HttpClient();


            httpClient.BaseAddress = new Uri(baseURL + "/TipoCabania");
            Task<HttpResponseMessage> getTiposCabania = httpClient.GetAsync(httpClient.BaseAddress);
            getTiposCabania.Wait();

            if (getTiposCabania.Result.IsSuccessStatusCode)
            {
                HttpContent contenido = getTiposCabania.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();

                deseralize.Wait();

                vmIndexCabania.TiposCabania = JsonConvert.DeserializeObject<IEnumerable<VMTipoCabania>>(deseralize.Result);
            }
            else
            {
                HttpContent contenido = getTiposCabania.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();
                ViewBag.Mensaje = deseralize.Result;
            }


            //vmCabania.Tipos = repositorioTipoCabania.FindAll();
            return View(vmIndexCabania);
        }

        // POST: CabaniaController/Create
        [Logueado]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMIndexCabania vmIndexCabania)
        {
            if (HttpContext.Session.GetString("EMAIL") == null)
            {
                return View("~/Views/Shared/LoginError.cshtml");
            }

            try
            {
                //Primero me aseguro que la cabania existe, luego subo la foto, si algo falla no subo al pedo la foto
                //verificar que pase eso
                //VMCabania cab = vmIndexCabania.Cabania;

                //string nombreImagen = cab.GetNombreFoto() + Path.GetExtension(vmCabania.Foto.FileName);

                //string ruta = Path.Combine(WebHost.WebRootPath, "Imagenes");
                //string rutaArchivo = Path.Combine(ruta, nombreImagen);

                //FileStream foto = new FileStream(rutaArchivo, FileMode.Create);

                ////nombreImagen = "Imagenes/" + nombreImagen;

                //cab.Tipo = repositorioTipoCabania.FindById(cab.TipoId);
                ////cab.Foto = nombreImagen;

                //repositorioCabania.Add(cab, nombreImagen);

                //vmCabania.Foto.CopyTo(foto);

                //ViewData["Message"] = "Cabaña ingresada correctamente.";
               // return RedirectToAction(nameof(Index));
            }

            catch (Exception e)
            {
                //ViewBag.Error = e.Message;
                //vmCabania.Tipos = repositorioTipoCabania.FindAll();
                //return View(vmCabania);
            }
                return RedirectToAction(nameof(Index));


        }

        // GET: CabaniaController/Edit/5
        [Logueado]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CabaniaController/Edit/5
        [Logueado]
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

        [Logueado]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri(baseURL + "/Cabania/Delete" + id);
                Task<HttpResponseMessage> borrarCabania = httpClient.GetAsync(httpClient.BaseAddress);
                borrarCabania.Wait();


                TempData["Mensaje"] = "Tipo de cabaña eliminado correctamente.";

                VMIndexCabania vmIndexCabania = new();
                return RedirectToAction("Index", vmIndexCabania);

            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }
    }
}
