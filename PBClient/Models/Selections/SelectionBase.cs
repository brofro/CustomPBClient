using Newtonsoft.Json;
using PBClient.Models.Selections.Enums;
using System.Runtime.Serialization;

namespace PBClient.Models.Selections
{
    [DataContract]
    public class SelectionBase
    {
        [DataMember(Name = "receiver")]
        public ReceiverType Receiver { get; set; }

        [DataMember(Name = "label")]
        public string Label { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}