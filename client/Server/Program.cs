using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Configuration;

namespace Server
{
    class Program
    {
        public static int port = int.Parse(ConfigurationManager.AppSettings.Get("Port"));
        public static string Address = ConfigurationManager.AppSettings.Get("Address");

        static void Main(string[] args)
        {

            //адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(Address), port);
            // создание сокета
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);

                // начинаем прослушивание
                listenSocket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while(true)
                {
                    Socket handler = listenSocket.Accept();
                    Console.WriteLine("Соединение с клиентом установлено");
                    //получаем сообщение
                    var builder = new List<byte>();
                    int bytes = 0;
                    byte[] data = new byte[256];

                    do
                    {
                        bytes = handler.Receive(data);
                        for (int i = 0; i < bytes; i++)
                            builder.Add(data[i]);
                    }
                    while
                    (handler.Available > 0);
                    Console.WriteLine("Сообщение получено");
                    //десеарилизация
                    string serializeMes = Encoding.UTF8.GetString(builder.ToArray());
                    var messag = JsonConvert.DeserializeObject<List<takenotes>>(serializeMes);
                    messag.ForEach(notes => notes.WriteToNormalizedDb());
                    Console.WriteLine("Записи записаны в БД");

                    //отправляем ответ
                    string message = "Ваше сообщение доставлено";
                    data = Encoding.Unicode.GetBytes(message);
                    handler.Send(data);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


    }
}
