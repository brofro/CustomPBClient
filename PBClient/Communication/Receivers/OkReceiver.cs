using System;
using Android.Content;
using Newtonsoft.Json;
using PBClient.Models.Selections;
using PBClient.Communication.HttpHelpers;
using PBClient.Communication.Routes;
using PBClient.Models.Pushbullet;

namespace PBClient.Communication.Receivers
{
    [BroadcastReceiver(
        Name = "PBClient.Communication.Receivers.OkReceiver",
        Label ="OkReceiver")]
    public class OkReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var data = intent.Extras;
            if (data.GetString("actionJson") != null)
            {
                var selection = data.GetString("actionJson");
                var postResponse = HttpHelper.PostHelper<string>(
                    PushbulletRoutes.GetRouteHttp(PushbulletRoutes.Pushes), 
                    JsonConvert.SerializeObject(new Push() { Title = "From Jette", Body = selection, Type = "note"}),
                    data.GetString("apiKey"));
            }
        }
    }
}