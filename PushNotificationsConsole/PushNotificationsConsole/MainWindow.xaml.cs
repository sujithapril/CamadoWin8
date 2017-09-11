using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PushNotificationsConsole
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendToastButton_Click_1(object sender, RoutedEventArgs e)
        {
            
            PushNotificationsConsole.WnsAuthentication.OAuthToken token = 
                WnsAuthentication.GetAccessToken(ClientSecretTextBox.Text, SIDTextBox.Text);
            MessageTextBlock.Text = SendToastNotification(token);
        }

        private void SendTileButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void SendBadgeButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private string SendToastNotification(PushNotificationsConsole.WnsAuthentication.OAuthToken token)
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
    }
}
