using System;
using Xunit;
using CommonLib;

namespace WongaXUnitTest
{
    public class Wonga_SendReceive
    {
        [Fact]
        public void IfSend2Q_ThenConsumeReceive()
        {
            
            RabbitMQQueueDestroyer.DeleteQueue("hello", "/");
                        
            var fake = new FakeProcessor();
            var consumer = new Consumer(fake);
                       
            

            var producer = new Publisher();            
            producer.Publish("hello", "test message");

           
            consumer.Consume("hello");


            // ASSERT
            Assert.Equal(1, fake.Messages.Count);
            Assert.Equal("test message", fake.Messages[0]);
        }
    }
}
