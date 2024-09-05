using CleanArchitecture.Application.Interfaces.AMQP;
using CleanArchitecture.Domain.Constants;
using MassTransit;

namespace CleanArchitecture.Persistence.AMQP;

public class MessagePublisher(ISendEndpointProvider provider) : IMessagePublisher
{
    public async Task PublishAsync<T>(T message, QueueName queueName, CancellationToken cancellationToken)
    {
        var endpoint = await provider.GetSendEndpoint(new Uri($"queue:{queueName}"));
        if (message != null) await endpoint.Send(message, cancellationToken);
    }
}