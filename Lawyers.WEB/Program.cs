using Data.DAL.Context;
using Lawyers.BLL.Contracts;
using Lawyers.BLL.Services;
using Lawyers.DAL.Interfaces;
using Lawyers.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string? conString = builder.Configuration.GetConnectionString("LawyersContext");
builder.Services.AddDbContext<LawyersContext>(options => options.UseSqlServer(conString!));

// Agregar el servicio de sesión
builder.Services.AddSession();

//Agregar servicios
builder.Services.AddScoped<ICasosRepository, CasosRepository>();
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddScoped<IEstadoCivilRepository, EstadoCivilRepository>();
builder.Services.AddScoped<IEstadosCasosRepository, EstadosCasosRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<ITiposDeCasosRepository, TiposDeCasosRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IAbogadosRepository, AbogadosRepository>();

builder.Services.AddTransient<ICasosService, CasosService>();
builder.Services.AddTransient<IClienteService, ClientesService>();
builder.Services.AddTransient<IEstadoCivilService, EstadoCivilService>();
builder.Services.AddTransient<IEstadosCasosService, EstadosCasosService>();
builder.Services.AddTransient<IRolesService, RolesService>();
builder.Services.AddTransient<ITiposDeCasosService, TiposDeCasosService>();
builder.Services.AddTransient<IUsuariosService, UsuariosService>();
builder.Services.AddTransient<IAbogadoService, AbogadoService>();
builder.Services.AddTransient(typeof(ILoggerService<>), typeof(LoggerService<>));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();  // Agregar el middleware de sesión aquí

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();