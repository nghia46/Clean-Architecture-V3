using CleanArchitecture.Domain.Constants;

namespace CleanArchitecture.Domain.Interfaces.AMQP;

public interface IMessagePublisher
{
    Task PublishAsync<T>(T message, QueueName queueName, CancellationToken cancellationToken);
}