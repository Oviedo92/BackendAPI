using Microsoft.EntityFrameworkCore;
using WebAppApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var DefaultConnection = "Server=SHERNANCH;Database=DBPersona;User Id=user_persona;Password=Sectriadm4*; Trusted_Connection=True;TrustServerCertificate=True";

// Leer cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ContextBD>(options => options.UseSqlServer(connectionString));

builder.Services.AddCors(option => option.AddPolicy("PoliticaReact", policy =>
{
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(permitir => permitir.WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .SetIsOriginAllowed((host) => true)
    .WithExposedHeaders("Content-Disposition"));    
app.UseCors("PoliticaReact");

app.UseAuthorization();

app.MapControllers();

app.Run();
