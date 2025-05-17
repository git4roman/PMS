using CloudinaryDotNet;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using PMS.Core;
using PMS.Core.CategoryFeatures;
using PMS.Core.ProductFeatures;
using PMS.Core.Utility;
using PMS.DataAccess.Data;
using PMS.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);
DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.AddScoped<IUow, Uow>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<IProductRepo,ProductRepo>();

builder.Services.AddSingleton<Cloudinary>(new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL")));
builder.Services.AddScoped<CloudinaryService>();

builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowAll");
 


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PMS API V1");
    c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
