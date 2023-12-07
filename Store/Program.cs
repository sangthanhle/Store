using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess.Infrastructure;
using OnlineStore.Domain.Data;
using OnlineStore.DataAccess.Repositories;
using OnlineStore.BusinessLogic.Implement;
using OnlineStore.BusinessLogic.Service;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                      });
});
builder.Services.AddDbContext<OnlineStore.DataAccess.DataContext.StoreContext>(options => {options.UseSqlServer(builder.Configuration.GetConnectionString("Store"));});
// Đăng ký IRepository và các Repository tương ứng

builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// đăng kí service
builder.Services.AddScoped<IProductService, ProductService>();
// ConfigureServices  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
