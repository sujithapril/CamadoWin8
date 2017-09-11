using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PushNotificationsConsole
{
    public class WnsAuthentication
    {
        [DataContract]
        public class OAuthToken
        {
            [DataMember(Name = "access_token")]
            public string AccessToken { get; set; }
            [DataMember(Name = "token_type")]
            public string TokenType { get; set; }
        }

        public static OAuthToken GetAccessToken(string clientSecret, string sid)
        {
            var urlEncodedClientSecret = HttpUtility.UrlEncode(clientSecret);
            var urlEncodedSid = HttpUtility.UrlEncode(sid);

            var body = String.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=notify.windows.com", urlEncodedSid, urlEncodedClientSecret);
            OAuthToken oAuthToken;

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                string response = client.UploadString("https://login.live.com/accesstoken.srf", body);


                using (MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(response)))
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(OAuthToken));
                    oAuthToken = (OAuthToken)jsonSerializer.ReadObject(memoryStream);
                }
            }
            return oAuthToken;
        }
    }
}
