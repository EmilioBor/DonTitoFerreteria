
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using Services.Service;

var builder = WebApplication.CreateBuilder(args);

//-------------------------------------------------------------------
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


//CORS
//El intercambio de recursos de origen cruzado o CORS es un mecanismo que permite que se puedan solicitar recursos restringidos
//en una p�gina web desde un dominio diferente del dominio que sirvi� el primer recurso

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000", "http://localhost:3001/", "http://localhost:3000/", "http://localhost:3000")
                            .AllowAnyHeader()  // Permite todos los encabezados
                            .AllowAnyMethod()  // Permite todos los m�todos HTTP
                            .AllowCredentials(); //se utiliza para configurar el servidor para permitir que las credenciales de autenticaci�n se incluyan en las solicitudes CORS
                        

                      });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TitoContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("Connection")));

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IModeloService, ModeloService>();
builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//agregar
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
