using Newtonsoft.Json;
using PBClient.Communication.HttpHelpers;
using PBClient.Communication.Routes;
using PBClient.Models.Pushbullet;
using System.Collections.Generic;
using System.Threading;
using WebSocketSharp;

namespace PBClient.Communication.WssHelpers
{
    //TODO: Check if this can be a common client, or derived from a common client
    public class PushbulletWebSocketClient
    {
        private static string ApiKey { get; set; }

        public PushbulletWebSocketClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        public static void Connect ()
        {
            //TODO: See if this needs to be disposable
            //TODO: Add error and onExit handling
            using (var ws = new WebSocket(PushbulletRoutes.GetRouteWss(ApiKey)))
            {
                ws.OnMessage += ReadMessage;

                ws.Connect();

                while (true)
                {
                    Thread.Sleep(5000);
                }
            }

            
        }

        private static void ReadMessage(object sender, MessageEventArgs e)
        {
            //TODO: Add control flow for different messages
            var data = JsonConvert.DeserializeObject<PushbulletStreamMessage>(e.Data);
        }

        private static void OnNewPush()
        {
            //TODO: Do something with this
            var pushes = HttpHelper.GetHelper<PushbulletStreamMessage>(PushbulletRoutes.GetRouteHttp(PushbulletRoutes.PushList));
        }
    }
}