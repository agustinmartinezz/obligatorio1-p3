using HotelCabañas.Filters;
using HotelCabañas.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace HotelCabañas.Controllers
{
    public class ConsultaController : Controller
    {
        private const string baseURL = "http://localhost:5256/api";

        [Logueado]
        [HttpGet]
        public IActionResult ConsultaA()
        {
            VMConsulta vmConsulta = new()
            {
                Param1 = 0,
                Param2 = 0,
            };

            return View(vmConsulta);
        }

        [Logueado]
        [HttpPost]
        public IActionResult ConsultaA(VMConsulta vmConsulta)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseURL + "/Consulta/A");

                string URLParams = "?tipoId=" + vmConsulta.Param1.ToString() + "&monto=" + vmConsulta.Param2.ToString();

                httpClient.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                Task<HttpResponseMessage> postConsultaA = httpClient.PostAsync(httpClient.BaseAddress + URLParams, new StringContent(""));

                postConsultaA.Wait();

                if (postConsultaA.Result.IsSuccessStatusCode)
                {
                    HttpContent contenido = postConsultaA.Result.Content;
                    Task<string> deseralize = contenido.ReadAsStringAsync();

                    deseralize.Wait();

                    vmConsulta.Resultado = JsonConvert.DeserializeObject<IEnumerable<VMConsultaA>>(deseralize.Result);

                    if (vmConsulta.Resultado == null)
                        ViewBag.Error = "Los datos ingresados no devolvieron resultados.";
                }
                else
                {
                    HttpContent contenido = postConsultaA.Result.Content;
                    Task<string> deseralize = contenido.ReadAsStringAsync();
                    ViewBag.Error = deseralize.Result;
                }
            } catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }

            return View(vmConsulta);
        }

        [Logueado]
        [HttpGet]
        public IActionResult ConsultaB()
        {
            VMConsulta vmConsulta = new () {
                Param1 = 0,
                Param2 = 0,
            };

            return View(vmConsulta);
        }

        [Logueado]
        [HttpPost]
        public IActionResult ConsultaB(VMConsulta vmConsulta)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseURL + "/Consulta/B");

                string URLParams = "?desde=" + vmConsulta.Param1.ToString() + "&hasta=" + vmConsulta.Param2.ToString();

                httpClient.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                Task<HttpResponseMessage> postConsultaB = httpClient.PostAsync(httpClient.BaseAddress + URLParams, new StringContent(""));

                postConsultaB.Wait();

                if (postConsultaB.Result.IsSuccessStatusCode)
                {
                    HttpContent contenido = postConsultaB.Result.Content;
                    Task<string> deseralize = contenido.ReadAsStringAsync();

                    deseralize.Wait();

                    vmConsulta.Resultado = JsonConvert.DeserializeObject<IEnumerable<VMConsultaB>>(deseralize.Result);

                    if (vmConsulta.Resultado == null)
                        ViewBag.Error = "Los datos ingresados no devolvieron resultados.";
                }
                else
                {
                    HttpContent contenido = postConsultaB.Result.Content;
                    Task<string> deseralize = contenido.ReadAsStringAsync();
                    ViewBag.Error = deseralize.Result;
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }

            return View(vmConsulta);
        }
    }
}
