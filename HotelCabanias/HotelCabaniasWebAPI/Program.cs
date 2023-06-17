using Microsoft.EntityFrameworkCore;
using LogicaNegocio;
using LogicaNegocio.InterfacesRepositorios;

using LogicaAccesoDatos.Repositorios;
using LogicaAccesoDatos.BaseDatos;

using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCasoDeUso;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioTipoCabania, RepositorioTiposCabania>();
builder.Services.AddScoped<IRepositorioCabania, RepositorioCabania>();
builder.Services.AddScoped<IRepositorioMantenimiento, RepositorioMantenimiento>();

ConfigurationBuilder miConfiguracion = new();
miConfiguracion.AddJsonFile("appsettings.json");

string cadenaConexion = builder.Configuration.GetConnectionString("HotelCabanias");
builder.Services.
    AddDbContext<HotelCabaniaContext>(options => options.UseSqlServer(cadenaConexion));

builder.Services.AddScoped<ICUAltaCabania, CUAltaCabania>();



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
