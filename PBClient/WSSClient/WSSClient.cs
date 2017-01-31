using System;
using System.Threading;
using Newtonsoft.Json;
using WebSocketSharp;
using PBClient.PBModels;

namespace PBClient.WSSClient
{
    public class SocketClient
    {
        private const string ApiKey = "";
        private const string PBStreamUri = "wss://stream.pushbullet.com/websocket/" + ApiKey;
        private const string PBGetListUri = "https://api.pushbullet.com/v2/pushes";

        public static void Connect(string uri = PBStreamUri)
        {
            using (var ws = new WebSocket(PBStreamUri))
            {
                ws.OnMessage += ReadMessage;

                ws.Connect();

                while (true)
                {
                    Thread.Sleep(3000);
                }
            }
        }

        private static void ReadMessage(object sender, EventArgs e)
        {
            var data = JsonConvert.DeserializeObject<PushbulletStreamMessage>(((MessageEventArgs)e).Data);
            if (data.Type == "tickle")
            {
                if (data.SubType == "push")
                {
                    var pushes = HttpHelpers.HttpHelper.GetHelper<GetPushesResponse>(PBGetListUri, ApiKey);
                }
            }
        }
    }
}