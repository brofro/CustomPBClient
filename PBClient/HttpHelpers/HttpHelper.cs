using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace PBClient.HttpHelpers
{
    public class HttpHelper
    { 

        public static T GetHelper<T>(string uri, string accessToken = "")
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Access-Token", accessToken);

                var response = client.GetAsync(uri).Result;
                var resultString = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(resultString);
            }
        }
    }
}