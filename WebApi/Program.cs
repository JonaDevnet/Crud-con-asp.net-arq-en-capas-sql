using Bussisnes;
using Data; // Referencia a nuestro proyecto data 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Lee la sección "ConnectionStrings" y la enlaza con la clase ConnectionStrings
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));

// Registro de la capa de datos
builder.Services.AddSingleton<EmpleadoData>(); // AddSingleton: Instancia única para inyección de dependencias

// Registro de la capa de negocio
builder.Services.AddScoped<EmpleadoBSSN>(); // AddScoped: Registra una instancia por cada solicitud HTTP

// Protección contra CORS
builder.Services.AddCors(policyBuilder => policyBuilder.AddDefaultPolicy(policy => policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
