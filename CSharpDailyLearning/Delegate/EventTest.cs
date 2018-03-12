using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegate
{

    public class EventTest000
    {
        public delegate void SendMessageHandler(object sender, MessageArgs e);

        public static event SendMessageHandler SendMessage;

        public void Test()
        {
            var s1 = new Subscriber("S1");
            var s2 = new Subscriber("S2");
            var s3 = new Subscriber("S3");

            SendMessage += s1.ReceiveMessage;
            SendMessage += s2.ReceiveMessage;
            SendMessage += s3.ReceiveMessage;
            
            Console.WriteLine("Simulate initializing...");
            Thread.Sleep(1000);

            var data = new MessageArgs {Message = "Class begin!"};

            SendMessage?.Invoke(null, data);

            SendMessage -= s1.ReceiveMessage;
            Thread.Sleep(1000);
            data.Message = "Calling from main function";
            SendMessage?.Invoke(null, data);

            Console.WriteLine("Class is over!");
            Console.ReadKey();
        }
    }

    public class Subscriber
    {
        public string Name { get; set; }

        public Subscriber(string name)
        {
            Name = name;
        }

        public void ReceiveMessage(object sender, MessageArgs s)
        {
            Console.WriteLine($"I know i my name {Name} and message {s.Message}  ");
        }
    }

    public class MessageArgs : EventArgs
    {
        public string Message { get; set; }
    }



}
