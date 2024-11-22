using AdminDemoFront.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<ApiService>();

builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("http://18.224.112.120:5003/Demo_AdminService.asmx/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "empleado",
    pattern: "{controller=Empleado}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "entidades",
    pattern: "{controller=Entidad}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "usuarios",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");

app.Run();
