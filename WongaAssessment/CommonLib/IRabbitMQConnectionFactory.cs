using RabbitMQ.Client;

namespace CommonLib
{
    public interface IRabbitMQConnectionFactory
    {
        IConnection CreateConnection();
    }
}
