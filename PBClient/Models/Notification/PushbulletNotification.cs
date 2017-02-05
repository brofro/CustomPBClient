using PBClient.Models.Selections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PBClient.Models.Notification
{
    [DataContract]
    public class PushbulletNotification
    {
        /**
         * { "title": "From Dodd", "content": "Boba?", "selections": [{"receiver" : 1, "label" : "Daccord"}, {"receiver" : 1, "label" : "Cannot Be"} ] }
         * 
         **/
        [DataMember(Name ="title")]
        public string Title { get; set; }

        [DataMember(Name ="content")]
        public string Content { get; set; }

        [DataMember(Name ="selections")]
        public IEnumerable<SelectionBase> Selections { get; set; }
    }
}