using meuapp.Data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;

Console.Clear();

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços de controle
builder.Services.AddControllers();

// Configura o contexto de banco de dados
builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddScoped<DataContext, DataContext>();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Redireciona todas as requisições para o Google
app.Use(async (context, next) =>
{
    // Se a URL solicitada for a raiz ("/"), redireciona para o /swagger/index.html
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("http://localhost:5157/swagger/index.html");
        return;
    }
    await next();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Mapeia os controladores
app.MapControllers();

app.Run();
