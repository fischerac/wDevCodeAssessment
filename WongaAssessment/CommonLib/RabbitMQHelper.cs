using RabbitMQ.Client;

namespace CommonLib
{
    public class RabbitMQHelper
    {
        private static IModel _model;
        private static string _exchangeName;
        const string RoutingKey = "hello";

        public RabbitMQHelper(IModel model, string exchangeName)
        {
            _model = model;
            _exchangeName = exchangeName;
        }


        public void SetupQueue(string queueName)
        {
            _model.QueueDeclare(queueName, false, false, false, null);
        }

        public void PushMessageIntoQueue(byte[] message, string queue)
        {            
            _model.BasicPublish(_exchangeName, RoutingKey, null, message);
        }

        public byte[] ReadMessageFromQueue(string queueName)
        {
            SetupQueue(queueName);
            byte[] message;
            var data = _model.BasicGet(queueName, false);
            message = data.Body;
            _model.BasicAck(data.DeliveryTag, false);
            return message;
        }

    }
}
