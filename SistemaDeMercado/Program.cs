using Aplication.ItemServiceHttpClient;
using Microsoft.OpenApi.Models;
using Refit;
using ServiceBus;
using SistemaDeMercado.DependencesInjections;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var dependencias = DependenceInjection.InjectionDependence(builder.Services, builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiProdutos", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);  
});

builder.Services.AddRefitClient<IEstoqueService>().
                                                    ConfigureHttpClient(c =>
                                                    {
                                                        c.BaseAddress = new Uri(builder.Configuration["Uris:Api_Estoque"]);
                                                        c.Timeout = TimeSpan.FromSeconds(int.Parse(builder.Configuration["Resilience:Timeout:Api"]));
                                                    });

var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // Lê as configurações de RabbitMQ do appsettings.json
                services.Configure<PublisherConfiguration>(context.Configuration.GetSection("RabbitConnection"));

                // Registra o RabbitMQManager como um serviço
                services.AddTransient<RabbitMensagemRepository>();
            })
            .Build();

// Inicia a aplicação
using (var scope = host.Services.CreateScope())
{
    var rabbitMQManager = scope.ServiceProvider.GetRequiredService<RabbitMensagemRepository>();
    rabbitMQManager.SendMessage(queueName: "minha_fila_dinamica", message: "Mensagem dinâmica!");
}
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
