using CleanArchitecture.Domain.Constants;
using CleanArchitecture.Domain.Interfaces;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Persistence;

public class MessagePublisher(IConfiguration configuration, ISendEndpointProvider provider) : IMessagePublisher
{
    public async Task PublishAsync<T>(T message, QueueName queueName, CancellationToken cancellationToken)
    {
        var endpoint = await provider.GetSendEndpoint(new Uri($"queue:{queueName}"));
        if (message != null) await endpoint.Send(message, cancellationToken);
    }
    
}