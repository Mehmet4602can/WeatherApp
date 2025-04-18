using WeatherApp.Business;
using WeatherApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // MVC kullanýyorsak

// Business Katmanýný ekliyoruz
builder.Services.AddScoped<SucukAIService>();

// Data Katmanýný ekliyoruz
builder.Services.AddHttpClient<WeatherDataService>();

// Uygulama oluþturuluyor
var app = builder.Build();

// Uygulama için pipeline ayarlarý
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();