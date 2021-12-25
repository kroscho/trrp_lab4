using System;
using Grpc.Core;
using Server;
using System.Threading.Tasks;
using System.Configuration;

namespace ServergRPC
{

   

    class Program
    {
        private static int Port = int.Parse(ConfigurationManager.AppSettings.Get("Port"));
        static string address = ConfigurationManager.AppSettings.Get("Adress");
        static void Main(string[] args)
        {

            //Grpc.Core.Server server = new Grpc.Core.Server
            //{
            //    //Services = { WriteNotes.BindService(new WriteNotesImpl()) },
            //    Ports = { new ServerPort(address, Port, ServerCredentials.Insecure) }
            //};
            //server.Start();

            //Console.WriteLine("ServerGRPC listening on port " + Port);
            //Console.WriteLine("Press any key to stop the server...");
            //Console.ReadKey();

            //server.ShutdownAsync().Wait();
        }
    }
}
