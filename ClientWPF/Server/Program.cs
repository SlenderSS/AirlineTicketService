using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "Server";
            using (var server = new ServiceHost(typeof(AirlinesTicketService)))
            {
                try
                {
                    server.Open();
                    Console.WriteLine("Server strated...");
                }
                catch (Exception e)
                { 
                    Console.WriteLine(e.Message);
                }

                
                Console.ReadLine();
            }
        }
    }
}
