using Trizen.Application;
using Trizen.DataLayer;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Middleware;
using Trizen.Presentation;
using Trizen.Recommendation;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Registerations
builder.Services.RegisterInfrastructure();
builder.Services.RegisterDataLayer();
builder.Services.RegisterPresentation();
builder.Services.RegisterApplication();
builder.Services.RegisterPresentation(builder.Configuration, builder.Logging);
#endregion

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    _ = app.UseExceptionHandler("/Error/InternalServerError");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
