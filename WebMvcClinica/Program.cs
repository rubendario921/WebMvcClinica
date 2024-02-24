using Microsoft.EntityFrameworkCore;
using WebMvcClinica.Models;
using WebMvcClinica.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Inicio app web instacia 
builder.Services.AddDbContext<BDClinicaContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("Clinica")));

//Agregar Servicio
builder.Services.AddScoped<IServiceSpeciality, ServiceSpeciality>();
builder.Services.AddScoped<IServiceRol, ServiceRol>();
builder.Services.AddScoped<IServiceUser, ServiceUser>();

var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
