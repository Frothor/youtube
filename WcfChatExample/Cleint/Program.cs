using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Cleint
{
    public class MyCallback : Proxy.IChatServiceCallback
    {
        public void RecieveMessage(string user, string message)
        {
            Console.WriteLine("{0}:{1}",user,message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            InstanceContext context = new InstanceContext(new MyCallback());
            Proxy.ChatServiceClient server = new Proxy.ChatServiceClient(context);

            Console.WriteLine("Enter UserName");
            var username = Console.ReadLine();
            server.Join(username);

            Console.WriteLine();
            Console.WriteLine("Enter Message");
            Console.WriteLine("Press Q to Exit");

            var message = Console.ReadLine();

            while (message!="Q")
                
            {
                if (!string.IsNullOrEmpty(message))
                    server.SendMessage(message);

                message = Console.ReadLine();
            }


        }
    }
}
