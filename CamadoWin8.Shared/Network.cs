using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

using Windows.Networking.Connectivity;
using System.Net.Http;

namespace CamadoWin8.Shared
{
    public class Network
    {
        public static async Task<bool> IsConnected()
        {

            bool isConnected = true;  //first api server availability          

            //try
            //{

            //    var c = new HttpClient();
            //    var resp = await c.GetAsync(new Uri("http://iot.cabotprojects.com"));
            //    if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            //    {
            //        isConnected = false;
            //    }
            //    else
            //    {
            //        isConnected = true;
            //    }
            //}

            //catch { isConnected = false; }


            //if (isConnected)  //internet availability check
            //{
            //    isConnected = NetworkInterface.GetIsNetworkAvailable();
            //    if (isConnected)
            //    {
            //        ConnectionProfile InternetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
            //        NetworkConnectivityLevel connection = InternetConnectionProfile.GetNetworkConnectivityLevel();
            //        if (connection == NetworkConnectivityLevel.None || connection == NetworkConnectivityLevel.LocalAccess)
            //        {
            //            isConnected = false;
            //        }
            //    }
            //}
           

            return isConnected;

        }
    }
}
