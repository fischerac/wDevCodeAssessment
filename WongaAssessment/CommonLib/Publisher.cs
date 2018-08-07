using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib
{
    public class Publisher
    {
        public void Publish(string queueName, string message)
        {
            var factory = new RabbitMQConnection(
                               new RabbitMQConnectionDetail() { HostName = "localhost", UserName = "guest", Password = "guest" }
                   );

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var rabbitMQHelper = new RabbitMQHelper(channel, "");
                rabbitMQHelper.SetupQueue(queueName);
                rabbitMQHelper.PushMessageIntoQueue(Encoding.UTF8.GetBytes(message), queueName);                
            }
        }
    }
}
