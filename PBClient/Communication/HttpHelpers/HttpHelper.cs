using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace PBClient.Communication.HttpHelpers
{
    public class HttpHelper
    {
        /// <summary>
        /// Sends a GET request to the url
        /// </summary>
        /// <typeparam name="T">The json deserializable response model</typeparam>
        /// <param name="url">The destination url</param>
        /// <param name="accessToken">The optional access token to append to headers as "Access-Token"</param>
        /// <returns>The deserialized response model defined by T</returns>
        public async static Task<T> GetHelper<T>(string url, string accessToken = "")
        {
            using (var client = new HttpClient())
            {
                //TODO: There is a better way to do this
                //Check for access token                
                if (accessToken != string.Empty)
                {
                    client.DefaultRequestHeaders.Add("Access-Token", accessToken);
                }

                var response = await client.GetAsync(url);
                var contentString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(contentString);
            }
        }
    }
}