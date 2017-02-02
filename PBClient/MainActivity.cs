using Android.App;
using Android.Widget;
using Android.OS;
using System;
using PBClient.Communication.WssHelpers;
using System.Threading;
using Android.Content;

namespace PBClient
{
    [Activity(Label = "PBClient", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        PushbulletWebSocketClient client = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button start = FindViewById<Button>(Resource.Id.Start);



            button.Click += delegate
            {
                button.Text = string.Format("{0} clicks!", count++);
            };

            start.Click += (object sender, EventArgs e) =>
            {
                if (client == null)
                {
                    client = new PushbulletWebSocketClient("", this);
                    client.Connect();
                }
            };            
        }
    }
}

