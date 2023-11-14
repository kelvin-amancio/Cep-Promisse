using CepPromisse.Application.Interfaces;
using CepPromisse.Application.Mappings;
using CepPromisse.Application.Rest;
using CepPromisse.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IApiRest, ApiRest>();
builder.Services.AddTransient<ICepService, CepService>();

builder.Services.AddAutoMapper(typeof(CepMapping).Assembly);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cep}/{action=Index}/{id?}");

app.Run();
