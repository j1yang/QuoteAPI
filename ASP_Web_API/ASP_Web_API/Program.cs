using Microsoft.EntityFrameworkCore;

using ASP_Web_API.Models;
using ASP_Web_API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

builder.Services.AddControllersWithViews().AddXmlSerializerFormatters();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication();

// Add CORS support, first by defining a CORS policy by name:
builder.Services.AddCors(options => {
    options.AddPolicy("AllowQuotesClients", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.ConfigureCors();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJwtAuthentication(builder.Configuration);

builder.Services.AddDbContext<QuotesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuotesContext")));

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseHttpsRedirection();

app.UseStaticFiles();

// we use the CORS policy defined above by name:
app.UseCors("AllowQuotesClients");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
