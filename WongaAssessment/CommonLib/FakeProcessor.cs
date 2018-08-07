using System.Collections.Generic;

namespace CommonLib
{
    public class FakeProcessor : IMessageProcessor
    {
        public List<string> Messages { get; set; }

        public FakeProcessor()
        {
            Messages = new List<string>();
        }

        public void ProcessMessage(string message)
        {
            Messages.Add(message);
        }
    }
}
