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
using System.Runtime.Serialization;

namespace PBClient.PBModels
{
    [DataContract]
    public class GetPushesResponse
    {
        [DataMember(Name ="pushes")]
        public IEnumerable<Push> PushList { get; set; }
    }
}