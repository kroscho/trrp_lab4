using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using RabbitMQ.Client;
using Server;
using Newtonsoft.Json;
using System.Configuration;
using Grpc.Core;
using System.Drawing;
using Filter;
using System.IO;
using Google.Protobuf;


namespace Client
{
    public class Client
    {
        static int port = int.Parse(ConfigurationManager.AppSettings.Get("Port"));
        static string address = ConfigurationManager.AppSettings.Get("Adress");



        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
            
        }

        public FilterService.FilterServiceClient ConnectServ()
        {
            try
            {
                Channel channel = new Channel(address + ":" + port, ChannelCredentials.Insecure);
                var client = new DispatcherService.DispatcherServiceClient(channel);
                var reply = client.GetFilterServer(new FilterServerRequest());
                switch (Convert.ToInt64(reply.Error))
                {
                    case 0:
                        channel = new Channel(reply.Address, ChannelCredentials.Insecure);
                        var client1 = new FilterService.FilterServiceClient(channel);
                        MessageBox.Show("Соединение установлено с сервером по адресу: " + reply.Address);
                        return client1;
                    case 1:
                        MessageBox.Show("Серверы не найдены. Попробуйте подключиться позже.");
                        return null;
                    case 2:
                        MessageBox.Show("");
                        return null;
                    case 3:
                        MessageBox.Show("Сервер переполнен.");
                        return null;
                    case 4:
                        MessageBox.Show("Сервер не найден.");
                        return null;
                    case 5:
                        MessageBox.Show("Время ожидания вышло. Пока все серверы переполнены. Попробуйте подключиться позже.");
                        return null;
                    
                }
                MessageBox.Show("Неизвестная ошибка");
                return null;

            }
            catch
            {
                MessageBox.Show("Не удается подключиться к диспетчеру");
                return null;
            }
           
        }

        public System.Drawing.Bitmap SendgRPC(System.Drawing.Bitmap curImage, int fil, FilterService.FilterServiceClient client, int val)
        {
                var data = imageToByteArray(curImage);
                var reply = client.SendImage(new Filter.Image { Image_ = ByteString.CopyFrom(data), Type =fil, Kernel=val });
                Bitmap res=null;

                using (var ms = new MemoryStream(reply.FilterImage.ToByteArray()))
                {
                    res = new Bitmap(Bitmap.FromStream(ms));
                }

                if(reply.Success)
                     MessageBox.Show("Успешно");            
                return res;



        }
    }
}