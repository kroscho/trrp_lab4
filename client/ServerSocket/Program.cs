using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace ServerSocket
{
    class Program
    {
        private static int port = 8005;

        static void Main(string[] args)
        {

           
            var RSA = new RSACryptoServiceProvider(2048);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            // связываем сокет с локальной точкой, по которой будем принимать данные
            listenSocket.Bind(ipPoint);

            // начинаем пsрослушивание
            listenSocket.Listen(10);
            Console.WriteLine("Сервер запущен. Ожидание подключений...");

            while (true)
            {
                var handler = listenSocket.Accept();
                try
                {
                    //Асинхронный ключ шифрования
                    handler.Send(Encoding.UTF8.GetBytes(RSA.ToXmlString(false)));
                    Console.WriteLine("Открытй ключ RSA отправлен");

                    //Синхронный ключ шифрования
                    var byteAES = RSA.Decrypt(WorkClass.RecieveMes(handler), true);
                    var myAES = WorkClass.ByteArrayToObject(byteAES) as MyAES;
                    var AES = new AesCryptoServiceProvider()
                    {
                        Key = myAES.key,
                        IV = myAES.IV
                    };

                    var mas = WorkClass.ByteArrayTotakenotes(WorkClass.RecieveMes(handler), AES);
                    mas.ForEach(notes => notes.WriteToNormalizedDb());

                    // отправляем ответ
                    string message = "Ваше сообщение доставлено";
                    byte[] info = Encoding.Unicode.GetBytes(message);
                    handler.Send(info);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // отправляем ответ
                    string message = "Ваше сообщение было доставлено с ошибкой";
                    byte[] info = Encoding.Unicode.GetBytes(message);
                    handler.Send(info);
                }
                finally
                {
                    // закрываем сокет
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
        }

        
    }
}
