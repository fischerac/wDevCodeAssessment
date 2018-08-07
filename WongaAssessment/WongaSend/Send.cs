using CommonLib;
using System;

namespace WongaSend
{
    class Send
    {
        

       

        static void Main(string[] args)
        {

            string sName;

            Console.WriteLine("Enter your name :");

            sName = Console.ReadLine();
            

            if (sName != null)
            {

                string message = string.Format("Hello my name is, {0}", sName);

                var producer = new Publisher();
                producer.Publish("hello", message);
                Console.WriteLine(" [x] Sent {0}", message);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
                
            }
            Console.WriteLine("      " + sName);
            
        }

       
    }
}