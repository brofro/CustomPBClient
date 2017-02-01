using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PBClient.Models.Pushbullet
{
    [DataContract]
    public class GetPushesResponse
    {
        [DataMember(Name ="pushes")]
        public IEnumerable<Push> PushList { get; set; }
    }
}