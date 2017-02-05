namespace PBClient.Communication.Routes
{
    public class PushbulletRoutes
    {
        public const string MainStream = "wss://stream.pushbullet.com/websocket";
        public const string MainRoute = "https://api.pushbullet.com/v2";

        public const string Pushes = "pushes";

        public static string GetRouteWss(string apiKey)
        {
            return $"{MainStream}/{apiKey}";
        }

        public static string GetRouteHttp(string endpoint)
        {
            return $"{MainRoute}/{endpoint}";
        }
    }
}