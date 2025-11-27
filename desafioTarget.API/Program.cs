using desafioTarget.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using desafioTarget.Domain.Interfaces.Repositories;
using desafioTarget.Infra.Repositories;
using desafioTarget.Domain.Services;
using desafioTarget.Application.Services;

var builder = WebApplication.CreateBuilder(args);

 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


//builder.Services.AddDbContext<DesafioContext>(options =>
//    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<DesafioContext>(options =>
    options.UseSqlServer(connectionString, sqlServerOptions =>
    {
        sqlServerOptions.EnableRetryOnFailure(
            maxRetryCount: 2,        // Tenta 2 vezes
            maxRetryDelay: TimeSpan.FromSeconds(3), // Espera até 3s entre tentativas
            errorNumbersToAdd: null);
    }));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins(
                        "http://localhost:4200", // Permite o acesso do Front
                        "http://localhost")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


builder.Services.AddScoped<CalculadoraJurosService>();
builder.Services.AddScoped<CalculadoraComissaoService>();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();


builder.Services.AddScoped<VendaAppService>();
builder.Services.AddScoped<ProdutoAppService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();