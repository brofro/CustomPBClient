using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PBClient.Models.Notification
{
    [DataContract]
    public class PushbulletNotification
    {
        [DataMember(Name ="title")]
        public string Title { get; set; }

        [DataMember(Name ="content")]
        public string Content { get; set; }

        [DataMember(Name ="selections")]
        public IEnumerable<string> Selections { get; set; }
    }
}