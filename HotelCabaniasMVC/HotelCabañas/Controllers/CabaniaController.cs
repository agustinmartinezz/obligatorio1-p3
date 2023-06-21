
using Microsoft.AspNetCore.Mvc;
using HotelCabañas.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using HotelCabañas.Filters;
using System.Net.Http.Headers;

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

            HttpClient httpClientCabania = new HttpClient();

            httpClientCabania.BaseAddress = new Uri(baseURL + "/Cabania" );
            Task<HttpResponseMessage> getCabanias = httpClientCabania.GetAsync(httpClientCabania.BaseAddress);
            getCabanias.Wait();          

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


            HttpClient httpClientTipoCabania = new HttpClient();


            httpClientTipoCabania.BaseAddress = new Uri(baseURL + "/TipoCabania");
            Task<HttpResponseMessage> getTiposCabania = httpClientTipoCabania.GetAsync(httpClientTipoCabania.BaseAddress);
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

            vmIndexCabania.Busqueda.SearchOption = 1;

            return View(vmIndexCabania);
        }

        [Logueado]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(VMIndexCabania VMIndexCabania)
        {
            HttpClient httpClientCabania = new HttpClient();
            HttpClient httpClientTipoCabania = new HttpClient();

            httpClientTipoCabania.BaseAddress = new Uri(baseURL + "/TipoCabania");
            httpClientTipoCabania.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            Task<HttpResponseMessage> getTiposCabania = httpClientTipoCabania.GetAsync(httpClientTipoCabania.BaseAddress);
            
            getTiposCabania.Wait();

            try
            {
                switch (VMIndexCabania.Busqueda.SearchOption)
                {
                    case 1:
                        if (string.IsNullOrWhiteSpace(VMIndexCabania.Busqueda.SearchText))
                        {
                            httpClientCabania.BaseAddress = new Uri(baseURL + "/Cabania");
                            //VMIndexCabania.Cabanias = repositorioCabania.FindAll();
                        } else
                        {
                            httpClientCabania.BaseAddress = new Uri(baseURL + "/Cabania/Name/" + VMIndexCabania.Busqueda.SearchText);
                            //VMIndexCabania.Cabanias = repositorioCabania.FindByName(vmCabania.SearchText);
                        }
                        break;
                    case 2:
                        //int intSearch = Int32.Parse(searchText);
                        //VMIndexCabania.Cabanias = repositorioCabania.FindByTipo(vmCabania.SearchType);
                        httpClientCabania.BaseAddress = new Uri(baseURL + "/Cabania/Type/" + VMIndexCabania.Busqueda.SearchType);

                        break;
                    case 3:
                        //int intSearch2 = Int32.Parse(searchText);
                        // VMIndexCabania.Cabanias = repositorioCabania.FindByMaxPeople(vmCabania.SearchNumber);
                        httpClientCabania.BaseAddress = new Uri(baseURL + "/Cabania/Cupos/" + VMIndexCabania.Busqueda.SearchNumber);

                        break;
                    case 4:
                        //VMIndexCabania.Cabanias = repositorioCabania.FindHabilitadas();
                        httpClientCabania.BaseAddress = new Uri(baseURL + "/Cabania/Habilitadas");

                        break;

                }

             
            } catch (Exception e)
            {
                ViewBag.Error = e.Message;
                //Cabanias
                httpClientCabania.BaseAddress = new Uri(baseURL + "/Cabania");
                
            }

            httpClientCabania.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            Task<HttpResponseMessage> getCabanias = httpClientCabania.GetAsync(httpClientCabania.BaseAddress);
            getCabanias.Wait();

            if (getCabanias.Result.IsSuccessStatusCode)
            {
                HttpContent contenido = getCabanias.Result.Content;
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

            if (!VMIndexCabania.Cabanias.Any())
            {
                ViewBag.Error = "No existen cabañas ingresadas según el criterio utilizado.";
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
            VMIndexCabania vmIndexCabania = new ();
            HttpClient httpClient = new HttpClient();


            httpClient.BaseAddress = new Uri(baseURL + "/TipoCabania");

            httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
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
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseURL + "/Cabania");

                httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                Task<HttpResponseMessage> postCabania = httpClient.PostAsJsonAsync(httpClient.BaseAddress, vmIndexCabania.Cabania);
                
                postCabania.Wait();

                if (postCabania.Result.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Cabaña ingresada con exito.";

                   // vmIndexCabania = new VMIndexCabania();
                    return RedirectToAction("Index", vmIndexCabania);
                }
                else
                {
                    HttpContent contenido = postCabania.Result.Content;
                    Task<string> tarea2 = contenido.ReadAsStringAsync();
                    tarea2.Wait();

                    ViewBag.Error = tarea2.Result.ToString();

                    HttpClient httpClientTipo = new HttpClient();

                    httpClientTipo.BaseAddress = new Uri(baseURL + "/TipoCabania");

                    httpClientTipo.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                    Task<HttpResponseMessage> getTiposCabania = httpClientTipo.GetAsync(httpClientTipo.BaseAddress);
                    
                    getTiposCabania.Wait();

                    if (getTiposCabania.Result.IsSuccessStatusCode)
                    {
                        HttpContent contenido2 = getTiposCabania.Result.Content;
                        Task<string> deseralize = contenido2.ReadAsStringAsync();

                        deseralize.Wait();

                        vmIndexCabania.TiposCabania = JsonConvert.DeserializeObject<IEnumerable<VMTipoCabania>>(deseralize.Result);
                    }
                    else
                    {
                        HttpContent contenido2 = getTiposCabania.Result.Content;
                        Task<string> deseralize = contenido2.ReadAsStringAsync();
                        ViewBag.Mensaje = deseralize.Result;
                    }
                }

                        return View(vmIndexCabania);


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
            }

            catch (Exception e)
            {
                //ViewBag.Error = e.Message;
                //vmCabania.Tipos = repositorioTipoCabania.FindAll();
                //return View(vmCabania);
                return View(vmIndexCabania);

            }




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

                httpClient.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
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
