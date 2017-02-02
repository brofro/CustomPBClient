using Newtonsoft.Json;
using PBClient.Communication.HttpHelpers;
using PBClient.Communication.Routes;
using PBClient.Models.Pushbullet;
using Pushbullet = PBClient.Models.Pushbullet.Enums;
using WebSocketSharp;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using PBClient.Models.Notification;
using System;
using Android.App;
using Android.Content;

namespace PBClient.Communication.WssHelpers
{
    //TODO: Check if this can be a common client, or derived from a common client
    public class PushbulletWebSocketClient
    {
        private static string ApiKey { get; set; }
        private WebSocket Connection { get; set; }
        private Context Context { get; set; }

        public PushbulletWebSocketClient(string apiKey, Context context)
        {
            ApiKey = apiKey;
            Context = context;
        }

        public void Connect()
        {
            //TODO: See if this needs to be disposable
            //TODO: Add error and onExit handling
            var ws = new WebSocket(PushbulletRoutes.GetRouteWss(ApiKey));
            ws.OnMessage += ReadMessage;
            ws.Connect();
        }

        private void ReadMessage(object sender, MessageEventArgs e)
        {
            var data = JsonConvert.DeserializeObject<PushbulletStreamMessage>(e.Data);
            HandleStreamMessage(data);
        }

        private void HandleStreamMessage(PushbulletStreamMessage streamMessage)
        {
            if (PushbulletConstants.ToType[streamMessage.Type] == Pushbullet.Type.Tickle)
                if (PushbulletConstants.ToSubtype[streamMessage.SubType] == Pushbullet.Subtype.Push)
                    OnNewPush();
        }

        private void OnNewPush()
        {
            var pushes = HttpHelper.GetHelper<GetPushesResponse>(PushbulletRoutes.GetRouteHttp(PushbulletRoutes.PushList), ApiKey).Result;
            var jsonBodyPushes = pushes.PushList.Where(x => x.Body.StartsWith("{") && x.Body.EndsWith("}"));

            //TODO: See why we can't call count here
            if (jsonBodyPushes != null)
                SetNotification(jsonBodyPushes);
        }

        private void SetNotification(IEnumerable<Push> pushes)
        {
            foreach(var jsonPush in pushes)
            {
                try
                {
                    var notification = JsonConvert.DeserializeObject<PushbulletNotification>(jsonPush.Body);
                    Notification.Builder builder = new Notification.Builder(Context)
                        .SetContentTitle(notification.Title)
                        .SetContentText(notification.Content)
                        .SetSmallIcon(Resource.Drawable.Icon);


                    //foreach (var action in notification.Selections)
                    //{
                    //    //TODO: Fix the pending intent here
                    //    builder.AddAction(new Notification.Action(Resource.Drawable.Icon, action,
                    //        PendingIntent.GetActivity(Application.Context, 0, null, PendingIntentFlags.NoCreate)));
                    //}

                    var not = builder.Build();
                    var notificationManager = Context.GetSystemService(Context.NotificationService) as NotificationManager;
                    notificationManager.Notify(0, not);
                }
                catch(Exception e)
                {
                    //Something here
                }
            }
        }
    }
}