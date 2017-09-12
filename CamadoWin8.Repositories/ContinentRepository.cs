using CamadoWin8.Contracts.Model;
using CamadoWin8.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Storage;

namespace CamadoWin8.Repositories
{
    public class ContinentRepository
    {
        private string baseUri = "http://localhost:35756/OnTheRoadTravelService.svc/";
        private string PopularTravelsUriTemplate = "PopularTravels";
        private string TravelsPerContinentUriTemplate = "TravelsPerContinent/{0}";
        private string TravelDetailsUriTemplate = "Travels/{0}";

        private const string ContinentAndTravelInfosFileName = "ContinentAndTravelInfos.xml";
        private const string ContinentDetailAndTravelsFileName = "ContinentAndTravelTileInfos{0}.xml";
        private const string TravelDetailsFileName = "TravelDetails{0}.xml";

        //gets from the service all the tile infos
        public async Task<ObservableCollection<IContinentTileInfo>> GetContinentAndTravelTileInfos()
        {
            ObservableCollection<IContinentTileInfo> continents = new ObservableCollection<IContinentTileInfo>();
            string retrievedXml = string.Empty;

            try
            {
                //check cache first
                StorageFolder localFolder = 
                    ApplicationData.Current.LocalFolder;
                if (await StorageHelper.DoesFileExistAsync
                    (ContinentAndTravelInfosFileName, localFolder))
                {
                    //use cached version
                    StorageFile file = 
                        await localFolder.GetFileAsync(ContinentAndTravelInfosFileName);
                    retrievedXml = await Windows.Storage.FileIO.ReadTextAsync(file);
                }
                else //download and store now
                {
                    HttpClientHandler httpClientHandler = new HttpClientHandler();
                    //use this handler for example to pass credentials

                    HttpClient client = new HttpClient(httpClientHandler);
                    HttpResponseMessage response = await client.GetAsync(baseUri + PopularTravelsUriTemplate);
                    if (response != null)
                        retrievedXml = await response.Content.ReadAsStringAsync();

                    //store the response now
                    StorageFile storageFile = await localFolder.CreateFileAsync(ContinentAndTravelInfosFileName);
                    await Windows.Storage.FileIO.WriteTextAsync(storageFile, retrievedXml);
                }

                //read the response into XDocument
                var results = from t in XDocument.Parse(retrievedXml).Descendants("Continent")
                              select t;

                //Now we can parse the XML
                foreach (var continentElement in results)
                {
                    IContinentTileInfo continent = new ContinentTileInfo()
                    {

                        //Description = continentElement.Descendants("Description").FirstOrDefault().Value,
                        ContinentId = Int32.Parse(continentElement.Descendants("ContinentId").FirstOrDefault().Value),
                        ImageUrl = continentElement.Descendants("ImageUrl").FirstOrDefault().Value,
                        ContinentName = continentElement.Descendants("ContinentName").FirstOrDefault().Value
                    };
                    List<ITravelTileInfo> travels = new List<ITravelTileInfo>();

                    foreach (var travelElement in continentElement.Descendants("Travel"))
                    {
                        ITravelTileInfo travel = new TravelTileInfo()
                        {
                            ContinentId = Int32.Parse(travelElement.Descendants("ContinentId").FirstOrDefault().Value),
                            //Description = travelElement.Descendants("Description").FirstOrDefault().Value,
                            //Duration = Int32.Parse(travelElement.Descendants("Duration").FirstOrDefault().Value),
                            ImageUrl = travelElement.Descendants("ImageUrl").FirstOrDefault().Value,
                            //Outline = travelElement.Descendants("Outline").FirstOrDefault().Value,
                            //ShortTitle = travelElement.Descendants("ShortTitle").FirstOrDefault().Value,
                            TravelId = Int32.Parse(travelElement.Descendants("TravelId").FirstOrDefault().Value),
                            TravelName = travelElement.Descendants("TravelName").FirstOrDefault().Value
                        };
                        travels.Add(travel);
                    }

                    continent.Travels = travels;
                    continents.Add(continent);
                }

                return continents;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IContinentDetail> GetContinentDetailAndTravels(string continentId)
        {
            IContinentDetail continentDetail = null;
            string retrievedXml = string.Empty;

            try
            {
                //check cache first
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                if (await StorageHelper.DoesFileExistAsync(string.Format(ContinentDetailAndTravelsFileName, continentId), localFolder))
                {
                    //use cached version
                    StorageFile file = await localFolder.GetFileAsync(string.Format(ContinentDetailAndTravelsFileName, continentId));
                    retrievedXml = await Windows.Storage.FileIO.ReadTextAsync(file);
                }
                else //download and store now
                {
                    HttpClientHandler httpClientHandler = new HttpClientHandler();
                    //use this handler for example to pass credentials

                    HttpClient client = new HttpClient(httpClientHandler);
                    HttpResponseMessage response = await client.GetAsync(baseUri + string.Format(TravelsPerContinentUriTemplate, continentId));
                    if (response != null)
                        retrievedXml = await response.Content.ReadAsStringAsync();

                    //store the response now
                    StorageFile storageFile = await localFolder.CreateFileAsync(string.Format(ContinentDetailAndTravelsFileName, continentId));
                    await Windows.Storage.FileIO.WriteTextAsync(storageFile, retrievedXml);
                }

                //read the response into XDocument
                var results = from t in XDocument.Parse(retrievedXml).Descendants("Continent")
                              select t;

                //Now we can parse the XML
                XElement continentElement = results.FirstOrDefault();
                if (continentElement != null)
                {
                    continentDetail = new ContinentDetail()
                    {

                        Description = continentElement.Descendants("Description").FirstOrDefault().Value,
                        ContinentId = Int32.Parse(continentElement.Descendants("ContinentId").FirstOrDefault().Value),
                        ImageUrl = continentElement.Descendants("ImageUrl").FirstOrDefault().Value,
                        ContinentName = continentElement.Descendants("ContinentName").FirstOrDefault().Value
                    };
                    List<ITravelTileInfo> travels = new List<ITravelTileInfo>();

                    foreach (var travelElement in continentElement.Descendants("Travel"))
                    {
                        ITravelTileInfo travel = new TravelTileInfo()
                        {
                            ContinentId = Int32.Parse(travelElement.Descendants("ContinentId").FirstOrDefault().Value),
                            //Description = travelElement.Descendants("Description").FirstOrDefault().Value,
                            //Duration = Int32.Parse(travelElement.Descendants("Duration").FirstOrDefault().Value),
                            ImageUrl = travelElement.Descendants("ImageUrl").FirstOrDefault().Value,
                            //Outline = travelElement.Descendants("Outline").FirstOrDefault().Value,
                            //ShortTitle = travelElement.Descendants("ShortTitle").FirstOrDefault().Value,
                            TravelId = Int32.Parse(travelElement.Descendants("TravelId").FirstOrDefault().Value),
                            TravelName = travelElement.Descendants("TravelName").FirstOrDefault().Value
                        };
                        travels.Add(travel);
                    }

                    continentDetail.Travels = travels;

                }

                return continentDetail;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<ITravelDetail> GetTravelDetails(string travelId)
        {
            ITravelDetail travelDetail = null;
            string retrievedXml = string.Empty;

            try
            {

                //check cache first
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                if (await StorageHelper.DoesFileExistAsync(string.Format(TravelDetailsFileName, travelId), localFolder))
                {
                    //use cached version
                    StorageFile file = await localFolder.GetFileAsync(string.Format(TravelDetailsFileName, travelId));
                    retrievedXml = await Windows.Storage.FileIO.ReadTextAsync(file);
                }
                else //download and store now
                {
                    HttpClientHandler httpClientHandler = new HttpClientHandler();
                    //use this handler for example to pass credentials

                    HttpClient client = new HttpClient(httpClientHandler);
                    HttpResponseMessage response = await client.GetAsync(baseUri+ string.Format(TravelDetailsUriTemplate, travelId));
                    if (response != null)
                        retrievedXml = await response.Content.ReadAsStringAsync();

                    //store the response now
                    StorageFile storageFile = await localFolder.CreateFileAsync(string.Format(TravelDetailsFileName, travelId));
                    await Windows.Storage.FileIO.WriteTextAsync(storageFile, retrievedXml);
                }

                var results = from t in XDocument.Parse(retrievedXml).Descendants("Travel")
                              select t;

                //Now we can parse the XML
                XElement travelElement = results.FirstOrDefault();
                if (travelElement != null)
                {
                    travelDetail = new TravelDetail()
                    {

                        ContinentId = Int32.Parse(travelElement.Descendants("ContinentId").FirstOrDefault().Value),
                        Description = travelElement.Descendants("Description").FirstOrDefault().Value,
                        Duration = Int32.Parse(travelElement.Descendants("Duration").FirstOrDefault().Value),
                        ImageUrl = travelElement.Descendants("ImageUrl").FirstOrDefault().Value,
                        Outline = travelElement.Descendants("Outline").FirstOrDefault().Value,
                        ShortTitle = travelElement.Descendants("ShortTitle").FirstOrDefault().Value,
                        TravelId = Int32.Parse(travelElement.Descendants("TravelId").FirstOrDefault().Value),
                        TravelName = travelElement.Descendants("TravelName").FirstOrDefault().Value
                    };
                }

                return travelDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ITravelTileInfo>> GetInfiniteTravelData()
        {
            throw new NotImplementedException();
        }


    }
}
