using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib
{
    public class RabbitMQQueueDestroyer
    {
        public static void DeleteQueue(string queueName, string virtualHost)
        {
            var connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = "localhost";
            connectionFactory.UserName = "guest";
            connectionFactory.Password = "guest";
            connectionFactory.VirtualHost = virtualHost;

            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDelete(queueName);
            connection.Close();
        }
    }
}
