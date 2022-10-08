using UsuariosContatoService;
using UsuariosDatabaseSettings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<UsuariosContatoDatabaseSettings>
    (builder.Configuration.GetSection("DevNetStoreDatabase"));

builder.Services.AddSingleton<UsuariosContatosServices>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
