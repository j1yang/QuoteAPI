using Microsoft.EntityFrameworkCore;

using ASP_Web_API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

builder.Services.AddControllersWithViews().AddXmlSerializerFormatters();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add CORS support, first by defining a CORS policy by name:
builder.Services.AddCors(options => {
    options.AddPolicy("AllowQuotesClients", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddDbContext<QuotesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuotesContext")));



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

// we use the CORS policy defined above by name:
app.UseCors("AllowQuotesClients");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
