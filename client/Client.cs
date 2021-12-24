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
            Channel channel = new Channel(address + ":" + port, ChannelCredentials.Insecure);
            
            var client = new DispatcherService.DispatcherServiceClient(channel);
            var reply = client.GetFilterServer(new FilterServerRequest());
            
            channel = new Channel(reply.Address, ChannelCredentials.Insecure);
            var client1 = new FilterService.FilterServiceClient(channel);
            MessageBox.Show("Соединение установлено с сервером по адресу: "+reply.Address);
            return client1;
        }

        public System.Drawing.Bitmap SendgRPC(System.Drawing.Bitmap curImage, int fil, FilterService.FilterServiceClient client)
        {
                var data = imageToByteArray(curImage);
                var reply = client.SendImage(new Filter.Image { Image_ = ByteString.CopyFrom(data), Type =fil });
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