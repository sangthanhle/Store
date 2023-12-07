using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using OnlineStore.BusinessLogic.Implement;
using OnlineStore.BusinessLogic.Service;
using OnlineStore.DataAccess.DataContext;
using OnlineStore.DataAccess.Infrastructure;
using OnlineStore.DataAccess.Repositories;
using OnlineStore.Domain.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// 
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Store")));

//Đăng ký dịch vụ và repository trong Startup.cs:
//builder.Services.AddScoped<BaseRepository<Categorie>, CategoriesRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<Categorie>, CategoriesRepository>();
builder.Services.AddScoped<IRepository<User>, UsersRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// đăng kí service
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoriesService,CategoriesService>();
builder.Services.AddScoped<IUserService, UserService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
