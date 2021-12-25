using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;
using System.Xml.Serialization;

namespace ServerSocket
{
    public static class WorkClass
    {
        #region Шифрование
        public static byte[] takenotesToByteArray(List<takenotes> obj, Aes AES)
        {
            using (var encryptor = AES.CreateEncryptor())
            {
                var temp = ObjectToByteArray(obj);
                return encryptor.TransformFinalBlock(temp, 0, temp.Length);
            }
        }

        public static List<takenotes> ByteArrayTotakenotes(byte[] arrBytes, Aes AES)
        {
            using (var decryptor = AES.CreateDecryptor())
            {
                var temp = decryptor.TransformFinalBlock(arrBytes, 0, arrBytes.Length);
                return ByteArrayToObject(temp) as List<takenotes>;
            }
        }
        #endregion

        #region Сериализация
        public static byte[] ObjectToByteArray(object obj)
        {
            var xs = new XmlSerializer(typeof(object));
           // BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                JsonSerializer.Serialize(obj);
                xs.Serialize(ms, obj);
               // bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var xs = new XmlSerializer(typeof(object)); 
              //  var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = xs.Deserialize(memStream);
                return obj;
            }
        }
        #endregion

        #region сокеты
        public static byte[] RecieveMes(Socket socket)
        {
            // получаем сообщение
            List<byte> builder = new List<byte>();
            int bytes = 0; // количество полученных байтов
            byte[] data = new byte[256]; // буфер для получаемых данных
            do
            {
                bytes = socket.Receive(data);
                for (int i = 0; i < bytes; i++)
                    builder.Add(data[i]);
            } while (socket.Available > 0);

            return builder.ToArray();
        }
        #endregion

        #region Очереди
        public static void SendMes(IModel channel, string nameQueue, byte[] body)
        {
            channel.QueueDeclare(nameQueue, true, false);

            channel.ExchangeDeclare(nameQueue, ExchangeType.Fanout, true);

            channel.BasicPublish("",
                nameQueue,
                null,
                body);

            Console.WriteLine($"Сообщение доставлено в очередь {nameQueue}");
        }

        public static byte[] RecieveMes(IModel channel, string nameQueue)
        {
            channel.QueueDeclare(nameQueue, true, false);

            channel.ExchangeDeclare(nameQueue, ExchangeType.Fanout, true);

            var consumer = new EventingBasicConsumer(channel);

            byte[] rsaInBytes = null;

            consumer.Received += (model, ea) =>
            {
                rsaInBytes = ea.Body;
            };

            channel.BasicConsume(nameQueue,
                true,
                consumer);

            while (rsaInBytes == null)
            { }
            Console.WriteLine($"Сообщение принято из очереди {nameQueue}");
            return rsaInBytes;
        }

        #endregion
    }
}
