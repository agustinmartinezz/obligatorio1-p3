using HotelCabañas.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HotelCabañas.Controllers
{
    public class HomeController : Controller
    {
        private const string baseURL = "http://localhost:5256/api";

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginError()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(VMLogin vmLogin)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseURL + "/Usuario/Login");
           
            Task<HttpResponseMessage> postLogin = httpClient.PostAsJsonAsync(httpClient.BaseAddress, vmLogin);
            postLogin.Wait();

            if (postLogin.Result.IsSuccessStatusCode) {
                HttpContent contenido = postLogin.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();

                deseralize.Wait();
                vmLogin = JsonConvert.DeserializeObject<VMLogin>(deseralize.Result);

                if (vmLogin.Token != null)
                {
                    HttpContext.Session.SetString("token", vmLogin.Token);
                }
                return View("~/Views/Home/Index.cshtml");
            } else
            {
                HttpContent contenido = postLogin.Result.Content;
                Task<string> deseralize = contenido.ReadAsStringAsync();

                ViewBag.Error = deseralize.Result;

                return View();
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("token");
            return View("~/Views/Home/Login.cshtml");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}