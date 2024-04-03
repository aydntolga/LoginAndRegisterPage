using AuthLogin.Data;
using AuthLogin.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddDbContext<UserContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString")));
builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<JwtService>();



/*
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{



    //app.UseSwagger();
    //app.UseSwaggerUI();
}
app.UseCors(options => options
    .WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    );

app.UseAuthorization();

app.MapControllers();

app.Run();
