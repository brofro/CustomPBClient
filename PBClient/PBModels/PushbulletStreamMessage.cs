using System.Runtime.Serialization;

namespace PBClient.PBModels
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