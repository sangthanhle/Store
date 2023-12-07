using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OnlineStore.Domain.Data;  
using OnlineStore.DataAccess.DataContext;
using OnlineStore.DataAccess.Repositories;
using OnlineStore.BusinessLogic.Implement;
using OnlineStore.BusinessLogic.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddDbContext<OnlineStore.DataAccess.DataContext.StoreContext>(options => {options.UseSqlServer(builder.Configuration.GetConnectionString("Store"));});
// Đăng ký IRepository và các Repository tương ứng
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// đăng kí service
builder.Services.AddScoped<IProductService, ProductService>();
// ConfigureServices  
// Định cấu hình xác thực JWT Authorization
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "yourIssuer", // Thay đổi thành Issuer của bạn
            ValidAudience = "yourAudience", // Thay đổi thành Audience của bạn
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourSecretKey")) // Thay đổi thành Secret Key của bạn
        };
    });

// Phân quyền
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Clerk", policy => policy.RequireRole("Clerk"));
    options.AddPolicy("Customer", policy => policy.RequireRole("Customer"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
