using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnTheRoad.Server
{
    public partial class BroadcastTileUpdate : System.Web.UI.Page
    {
        private string sID = "ms-app://s-1-15-2-3321693172-3523444587-1979803812-1796983107-2703763341-1637156320-3250013125";
        private string clientSecret = "ZY2Ve+diEE+91dZE5iS6totZKgyJyPsY";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSendTile_Click(object sender, EventArgs e)
        {
            WnsAuthentication.OAuthToken token =
                WnsAuthentication.GetAccessToken(clientSecret, sID);

            ResponseTextBox.Text = SendToastNotification(token);
        }

        private string SendToastNotification(WnsAuthentication.OAuthToken token)
        {
            string type = string.Empty;
            string toastMessage = string.Empty;
            bool result = false;

            try
            {
                type = "wns/toast";

                toastMessage =
                    String.Format("<?xml version='1.0' encoding='utf-8'?><toast><visual><binding template=\"ToastText01\"><text id=\"1\">{0}</text></binding></visual></toast>", MessageTextBox.Text);

                byte[] contentInBytes = Encoding.UTF8.GetBytes(toastMessage);

                var request = (HttpWebRequest)WebRequest.Create(new Uri(UriTextBox.Text));
                request.Method = "POST";
                request.ContentType = "text/xml";
                request.Headers = new WebHeaderCollection();
                request.Headers.Add("X-WNS-Type", type);
                request.Headers.Add("Authorization", "Bearer " + token.AccessToken);

                request.ContentLength = toastMessage.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(contentInBytes, 0, toastMessage.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                return response.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        protected void SendTileUpdateButton_Click(object sender, EventArgs e)
        {
            WnsAuthentication.OAuthToken token =
               WnsAuthentication.GetAccessToken(clientSecret, sID);

            ResponseTextBox.Text = SendTileNotification(token);
        }

        private string SendTileNotification(WnsAuthentication.OAuthToken token)
        {
            string type = string.Empty;
            string tileMessage = string.Empty;

            try
            {
                type = "wns/tile";

                tileMessage = string.Format("<tile><visual><binding template=\"TileWideText03\"><text id=\"1\">{0}</text></binding></visual></tile>", MessageTextBox.Text);
                    //String.Format("<?xml version='1.0' encoding='utf-8'?><tile><visual><binding template=\"TileSquareBlock\"><text id=\"1\">{0}</text><text id=\"2\">{1}</text></binding></visual></tile>", "New travels", MessageTextBox.Text);
               


                byte[] contentInBytes = Encoding.UTF8.GetBytes(tileMessage);

                var request = (HttpWebRequest)WebRequest.Create(new Uri(UriTextBox.Text));
                request.Method = "POST";
                request.ContentType = "text/xml";
                request.Headers = new WebHeaderCollection();
                request.Headers.Add("X-WNS-Type", type);
                request.Headers.Add("Authorization", "Bearer " + token.AccessToken);

                request.ContentLength = tileMessage.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(contentInBytes, 0, tileMessage.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                return response.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}