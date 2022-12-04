using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces;
using PROYECTO_APP_BusCar.DOMAIN.infrastructure.Mapping;
using PROYECTO_APP_BusCar.DOMAIN.infrastructure.Repositories;
using PROYECTO_APP_BusCar.DOMAIN.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connection String

var connectionString = builder
    .Configuration
    .GetConnectionString("DevConnection");
builder
    .Services
    .AddDbContext<DB_BUSContext>
    (Options => Options.UseSqlServer(connectionString));

builder.Services.AddTransient<IProgramacionRepository, ProgramacionRepository>();
builder.Services.AddTransient<IReservaRepository, ReservaRepository>();
builder.Services.AddTransient<ITripulacionRepository, TripulacionRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IDocumentoRepository, DocumentoRepository>();
builder.Services.AddTransient<IMarcaRepository, MarcaRepository>();
builder.Services.AddTransient<IModeloRepository, ModeloRepository>();
builder.Services.AddTransient<INivelRepository, NivelRepository>();
builder.Services.AddTransient<IOrigenRepository, OrigenRepository>();
builder.Services.AddTransient<IPagos_PaypalRepository, Pagos_PaypalRepository>();
builder.Services.AddTransient<IPersonalRepository, PersonalRepository>();
builder.Services.AddTransient<IPrecioRepository, PrecioRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IComprobanteRepository, ComprobanteRepository>();
builder.Services.AddTransient<IDestinoRepository, DestinoRepository>();
builder.Services.AddTransient<IDetalleReservaRepository, DetalleReservaRepository>();
builder.Services.AddTransient<IAsientoRepository, AsientoRepository>();
builder.Services.AddTransient<IAsientoProgramacionRepository, AsientoProgramacionRepository>();
builder.Services.AddTransient<IBusRepository, BusRepository>();


builder.Services.AddCors(policyBuilder => policyBuilder.AddDefaultPolicy(policy => policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader()));



var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutomapperProfile());
});

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
