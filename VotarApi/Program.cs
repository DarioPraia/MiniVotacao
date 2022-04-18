using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapPost("/vota", (Participante participante) => {
    int result = AddInQueue(participante.Id);

    if (result > 0) {
        return "Inserido";
    } 
    else
    {
        return "Não inserido";    
    }
});

app.Run(); 

int AddInQueue(int id) {
    int result = 0;

    var factory = new ConnectionFactory() {
        Uri = new Uri("amqp://admin:admin@localhost:5672") 
    };

    using (var connection = factory.CreateConnection())

    using (var channel = connection.CreateModel())
    {
        channel.ExchangeDeclare(exchange: "votacao", type: ExchangeType.Fanout); 

        var message = new { Id = id, Data = DateTime.Now };

        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

        channel.BasicPublish(
            exchange: "votacao",
            routingKey: "",
            basicProperties: null,
            body: body
        );

        Console.WriteLine($"Sent {message}");

        result =  1;
    }

    return result;
}

class Participante
{
    public int Id { get; set; }
}