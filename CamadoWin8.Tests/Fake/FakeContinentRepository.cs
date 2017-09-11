using CamadoWin8.Contracts.Model;
using CamadoWin8.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CamadoWin8.Tests.Fake
{
    public class FakeContinentRepository
    {
        public ObservableCollection<IContinentDetail> ContinentDetails;
        public ObservableCollection<ITravelTileInfo> TravelTileInfos;

        public FakeContinentRepository()
        {
            CreateContinentDetails();
        }

        private void CreateContinentDetails()
        {
            ContinentDetails = new ObservableCollection<IContinentDetail>();
             
            IContinentDetail c1 = new ContinentDetail()
            {
                ContinentId = 1,
                ContinentName = "Europe",
                Description = "Lorem Ipsum",
                ImageUrl = "",
                Travels = new List<ITravelTileInfo>() 
                {
                    new TravelTileInfo() 
                    {
                        ContinentId = 1, 
                        ImageUrl="",
                        TravelId=1,
                        TravelName="London city trip"
                    },
                    new TravelTileInfo()
                    {
                        ContinentId=1,
                        ImageUrl="",
                        TravelId=2,
                        TravelName="Paris city trip"
                    }
                }
            };

            ContinentDetails.Add(c1);
        }


    }
}
