using Microsoft.FeatureManagement;
using webapp.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionStringAppConfig = "Endpoint=https://vcwebappconfig.azconfig.io;Id=lkiu;Secret=pBKX7eG+LwHdL1o+Jj/u6mjG2TO5XgOxdsmmh9YEgG4=";

builder.Host.ConfigureAppConfiguration(builder =>
{
    builder.AddAzureAppConfiguration(options => 
    options.Connect(connectionStringAppConfig).UseFeatureFlags());
});


builder.Services.AddTransient<IProductService, ProductService>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddFeatureManagement();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
