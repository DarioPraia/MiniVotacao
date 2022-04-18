using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using VotacaoConsumer.Persistence;

var factory = new ConnectionFactory()
{
    Uri = new Uri("amqp://admin:admin@localhost:5672")
};

using (var connection = factory.CreateConnection())

using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare(exchange: "votacao", type: ExchangeType.Fanout); 

    var queueName = channel.QueueDeclare().QueueName;

    channel.QueueBind(
        queue: queueName,
        exchange: "votacao",
        routingKey: ""
    );

    var consumer = new EventingBasicConsumer(channel);

    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();

        var message =  Encoding.UTF8.GetString(body);

        Vota vota = JsonSerializer.Deserialize<Vota>(message);

        using (var unitOfWork = new UnitOfWork(new VotacaoContext()))
        {
            var participante = unitOfWork.Participantes.Get(vota.Id);

            unitOfWork.Votacoes.Votar(participante, vota.data);

            unitOfWork.Complete();
        }

        Console.WriteLine($"[x] Received {message}");
    };

    channel.BasicConsume(
        queue: queueName, 
        autoAck: true, 
        consumer: consumer
    );

    Console.ReadLine();
}

public record Vota(int Id, DateTime data);