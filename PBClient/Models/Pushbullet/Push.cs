using System.Runtime.Serialization;

namespace PBClient.Models.Pushbullet
{
    [DataContract]
    public class Push
    {
        [DataMember(Name ="type")]
        public string Type { get; set; }

        [DataMember(Name ="title")]
        public string Title { get; set; }

        [DataMember(Name ="body")]
        public string Body { get; set; }
    }
}