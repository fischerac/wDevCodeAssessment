using CommonLib;
using System;

namespace WongaReceive
{
    class Receive
    {
        static void Main(string[] args)
        {            

            var fake = new FakeProcessor();
            var consumer = new Consumer(fake);

            consumer.Consume("hello");

            var ReceivedName = fake.Messages[0];
            string sReceivedName = IsValid(ReceivedName);

            Console.WriteLine(string.Format("Hello{0}, I am your father!", sReceivedName));
            
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        static string IsValid(object obj)
        {
            string str = obj as string;
            if (!string.IsNullOrEmpty(str))
                if (!string.IsNullOrWhiteSpace(str))
                {                                    
                    return str.Substring(17, str.Length - 17);
                }                    

            return string.Empty;
        }
    }
}