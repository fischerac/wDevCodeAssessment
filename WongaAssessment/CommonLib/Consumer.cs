using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib
{
    public class Consumer
    {
        private IMessageProcessor _messageProcessor;


        public Consumer(IMessageProcessor messageProcessor)
        {
            _messageProcessor = messageProcessor;
        }
       
        public void Consume(string queueName)
        {
            var factory = new RabbitMQConnection(
                               new RabbitMQConnectionDetail() { HostName = "localhost", UserName = "guest", Password = "guest" }
                   );

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var rabbitMQHelper = new RabbitMQHelper(channel, "");

                var readMsg = rabbitMQHelper.ReadMessageFromQueue(queueName);

                string resultString = System.Text.Encoding.UTF8.GetString(readMsg, 0, readMsg.Length);
                _messageProcessor.ProcessMessage(resultString);
            }

        }
      

    }
}
