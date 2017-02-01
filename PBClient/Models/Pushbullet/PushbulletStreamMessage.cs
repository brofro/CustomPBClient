using System.Runtime.Serialization;

namespace PBClient.Models.Pushbullet
{
    [DataContract]
    public class PushbulletStreamMessage
    {
        [DataMember(Name ="type")]
        public string Type { get; set; }

        [DataMember(Name ="subtype")]
        public string SubType { get; set; }
    }
}