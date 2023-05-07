using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.Repositorios;
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

            
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarios>();
            builder.Services.AddScoped<IRepositorioTipoCabana, RepositorioTiposCabana>();
            builder.Services.AddScoped<IRepositorioCabana, RepositorioCabana>();

            ConfigurationBuilder miConfiguracion = new ConfigurationBuilder();

            miConfiguracion.AddJsonFile("appsettings.json");

            string cadenaConexion = builder.Configuration.GetConnectionString("HotelCabanas");
            builder.Services.
                AddDbContext<HotelCabanaContext>(options => options.UseSqlServer(cadenaConexion));

            builder.Configuration.AddJsonFile("parametros.json",
                     optional: true,
                     reloadOnChange: true);

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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