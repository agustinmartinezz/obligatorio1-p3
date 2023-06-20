using HotelCabañas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelCabañas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(VMLogin vmLogin)
        {
            string email = vmLogin.Email;
            string contrasenia = vmLogin.Contrasenia;

            HttpContext.Session.SetString("EMAIL", "Pruebasinlogin");
            return View("~/Views/Home/Index.cshtml");
            //Usuario usuario = repositorioUsuarios.LoguearUsuario(email, contrasenia);

            //if (usuario != null)
            //{
            //HttpContext.Session.SetString("EMAIL", usuario.Mail.TextoMail);
            //return View("~/Views/Home/Index.cshtml");
            //}
            //else
            //{
            //    ViewBag.Error = "Usuario o contraseña incorrecto.";
            //    return View();
            //}

        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("EMAIL");
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