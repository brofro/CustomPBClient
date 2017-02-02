using System.Collections.Generic;
using PBClient.Models.Pushbullet.Enums;

namespace PBClient.Models.Pushbullet
{
    public class PushbulletConstants
    {
        public static string TickleLabel = "tickle";
        public static string NopLabel = "nop";
        public static string PushLabel = "push";
        public static string DeviceLabel = "device";

        public static Dictionary<string, Type> ToType = new Dictionary<string, Type>()
        {
            {TickleLabel, Type.Tickle },
            {NopLabel, Type.Nop },
            {PushLabel, Type.EphemeralPush }
        };

        public static Dictionary<string, Subtype> ToSubtype = new Dictionary<string, Subtype>()
        {
            {PushLabel, Subtype.Push },
            {DeviceLabel, Subtype.Device }
        };  
    }
}