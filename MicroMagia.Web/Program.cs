using MicroMagia.Web.Career.Interfaces;
using MicroMagia.Web.Career.Service;
using MicroMagia.Web.Course.Interfaces;
using MicroMagia.Web.Course.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("MicroMagia", x =>
    x.BaseAddress = new Uri(builder.Configuration["ClientsHttp:BaseUrl"]!));
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IServiceCareer,ServiceCareer>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
