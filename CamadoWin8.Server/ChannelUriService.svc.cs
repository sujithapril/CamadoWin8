using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace OnTheRoad.Server
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ChannelUriService
    {
        private OnTheRoadEntities context;

        public ChannelUriService()
        {
            context = new OnTheRoadEntities();
        }
        [OperationContract]
        bool SendChannelUri(string clientChannelUri)
        {
            try
            {
                OnTheRoad.Server.ChannelUri channelUri = new OnTheRoad.Server.ChannelUri();
                channelUri.ClientChannelUri = clientChannelUri;

                context.ChannelUri.Add(channelUri);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
