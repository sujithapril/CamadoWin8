using CamadoWin8.Contracts.Model;
using CamadoWin8.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.Streams;

namespace CamadoWin8.Services.Infrastructure
{
    public class ShareContractService : IShareContractService
    {
        public ShareContractService()
        {

        }

        public void Initialize()
        {
            DataTransferManager dataTransferManager;
            dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested -= this.DataRequested;
            dataTransferManager.DataRequested += this.DataRequested;
        }

        private void DataRequested(DataTransferManager sender, DataRequestedEventArgs e)
        {
            if (SharedTravelDetail != null)
            {
                e.Request.Data.Properties.Title = SharedTravelDetail.TravelName;

                e.Request.Data.Properties.Description = "Overview of the travel";

                e.Request.Data.SetText(SharedTravelDetail.Description);

                var uri = new Uri(SharedTravelDetail.ImageUrl);
                var reference = RandomAccessStreamReference.CreateFromUri(uri);
                e.Request.Data.Properties.Thumbnail = reference;
                e.Request.Data.SetBitmap(reference);
            }
        }


        public ITravelDetail SharedTravelDetail
        {
            get;
            set;
        }
    }
}
