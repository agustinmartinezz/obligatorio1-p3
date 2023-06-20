using Microsoft.EntityFrameworkCore;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;

using LogicaAccesoDatos.Repositorios;
using LogicaAccesoDatos.BaseDatos;

using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCasoDeUso;


var builder = WebApplication.CreateBuilder(args);
ConfigurationBuilder miConfiguracion = new();
miConfiguracion.AddJsonFile("appsettings.json");

string cadenaConexion = builder.Configuration.GetConnectionString("HotelCabanias");

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

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICUUpdateUsuario, CUUpdateUsuario>();
builder.Services.AddScoped<ICULoguearUsuario, CULoguearUsuario>();
builder.Services.AddScoped<ICUFindByIdUsuario, CUFindByIdUsuario>();
builder.Services.AddScoped<ICUFindAllUsuario, CUFindAllUsuario>();
builder.Services.AddScoped<ICUDeleteUsuario, CUDeleteUsuario>();
builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();

builder.Services.AddScoped<ICUUpdateCabania, CUUpdateCabania>();
builder.Services.AddScoped<ICUFindByIdCabania, CUFindByIdCabania>();
builder.Services.AddScoped<ICUFindAllCabania, CUFindAllCabania>();
builder.Services.AddScoped<ICUDeleteCabania, CUDeleteCabania>();
builder.Services.AddScoped<ICUAltaCabania, CUAltaCabania>();
builder.Services.AddScoped<ICUAddPictureCabania, CUAddPictureCabania>();
builder.Services.AddScoped<ICUFindByMaxPeopleCabania, CUFindByMaxPeopleCabania>();
builder.Services.AddScoped<ICUFindByNameCabania, CUFindByNameCabania>();
builder.Services.AddScoped<ICUFindByTipoCabania, CUFindByTipoCabania>();
builder.Services.AddScoped<ICUFindHabilitadasCabania, CUFindHabilitadasCabania>();

builder.Services.AddScoped<ICUUpdateTipoCabania, CUUpdateTipoCabania>();
builder.Services.AddScoped<ICUFindByIdTipoCabania, CUFindByIdTipoCabania>();
builder.Services.AddScoped<ICUFindByNameTipoCabania, CUFindByNameTipoCabania>();
builder.Services.AddScoped<ICUFindAllTipoCabania, CUFindAllTipoCabania>();
builder.Services.AddScoped<ICUDeleteTipoCabania, CUDeleteTipoCabania>();
builder.Services.AddScoped<ICUAltaTipoCabania, CUAltaTipoCabania>();

builder.Services.AddScoped<ICUUpdateMantenimiento, CUUpdateMantenimiento>();
builder.Services.AddScoped<ICUFindByIdMantenimiento, CUFindByIdMantenimiento>();
builder.Services.AddScoped<ICUFindByDateMantenimiento, CUFindByDateMantenimiento>();
builder.Services.AddScoped<ICUFindAllMantenimiento, CUFindAllMantenimiento>();
builder.Services.AddScoped<ICUDeleteMantenimiento, CUDeleteMantenimiento>();
builder.Services.AddScoped<ICUAltaMantenimiento, CUAltaMantenimiento>();

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioTipoCabania, RepositorioTiposCabania>();
builder.Services.AddScoped<IRepositorioCabania, RepositorioCabania>();
builder.Services.AddScoped<IRepositorioMantenimiento, RepositorioMantenimiento>();


builder.Services.
    AddDbContext<HotelCabaniaContext>(options => options.UseSqlServer(cadenaConexion));



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
