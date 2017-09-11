using CamadoWin8.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Services.Infrastructure
{
    public class PushNotificationService : IPushNotificationService
    {
        public string ChannelUri { get; set; }

        public async void RegisterChannelUriWithService()
        {
            var channelOperation =
                  await Windows.Networking.PushNotifications.PushNotificationChannelManager.
                  CreatePushNotificationChannelForApplicationAsync();
            ChannelUri = channelOperation.Uri;

            ServiceClient.ChannelUriService.ChannelUriServiceClient client = new ServiceClient.ChannelUriService.ChannelUriServiceClient();
            await client.SendChannelUriAsync(ChannelUri.ToString());
        }
    }
}
