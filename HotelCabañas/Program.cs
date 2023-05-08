using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelCabañas
{
public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioTipoCabania, RepositorioTiposCabania>();
            builder.Services.AddScoped<IRepositorioCabania, RepositorioCabania>();

            ConfigurationBuilder miConfiguracion = new();
            miConfiguracion.AddJsonFile("appsettings.json");

            string cadenaConexion = builder.Configuration.GetConnectionString("HotelCabanias");
            builder.Services.
                AddDbContext<HotelCabaniaContext>(options => options.UseSqlServer(cadenaConexion));

            builder.Configuration.AddJsonFile("parametros.json",
                     optional: true,
                     reloadOnChange: true);

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            /*--------- PARAMETROS JSON ---------*/
            Parametros.MinDescTipoCabania = builder.Configuration.GetValue<int>("MinDescTipoCabania");
            Parametros.MaxDescTipoCabania = builder.Configuration.GetValue<int>("MaxDescTipoCabania");
            Parametros.MinDescCabania = builder.Configuration.GetValue<int>("MinDescCabania");
            Parametros.MaxDescCabania = builder.Configuration.GetValue<int>("MaxDescCabania");
            Parametros.MinDescMantenimiento = builder.Configuration.GetValue<int>("MinDescMantenimiento");
            Parametros.MaxDescMantenimiento = builder.Configuration.GetValue<int>("MaxDescMantenimiento");
            /*-----------------------------------*/

            var app = builder.Build();

            app.UseSession();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
            app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Login}/{id?}");

            app.Run();
        }
    }
}