using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using CamadoWin8.Contracts.Model;
using CamadoWin8.Contracts.Services;
using CamadoWin8.Contracts.ViewModels;
using CamadoWin8.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CamadoWin8.Contracts.View;
using CamadoWin8.Shared;
namespace CamadoWin8.ViewModel
{
    public class DetailGraphViewModel : ViewModelBase, IDetailGraphViewModel
    {
        public RelayCommand GoBack { get; set; }
        public RelayCommand GoHome { get; set; }
        public RelayCommand AddToFavorites { get; set; }



        private INavigationService navigationService;
        private IDialogService dialogService;
        private IShareContractService shareContractService;
        private ITileService tileService;
        private IToastService toastService;
        private IStateService stateService;
        private IDeviceService deviceService;
        private IGraphService graphService;

        public PageNames.BarType selectedType;

        public DetailGraphViewModel(INavigationService navigationService, IDialogService dialogService, IShareContractService shareContractService,
          ITileService tileService, IToastService toastService, IStateService stateService, IGraphService graphService)
        {

            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.shareContractService = shareContractService;
            this.tileService = tileService;
            this.toastService = toastService;
            this.stateService = stateService;
            this.graphService = graphService;           

        }
        public async void Initialize(object parameter)
        {
            if(parameter != null)
            {
                Tuple<IDeviceInfo,PageNames.BarType> TupleObj = parameter as Tuple<IDeviceInfo, PageNames.BarType>;

                IDeviceInfo deviceObj = TupleObj.Item1 as IDeviceInfo;
                selectedType = TupleObj.Item2;

                RootObjectLine lineGraphdata = null;
                string stDate;
                string endDate;
                if(deviceObj.StartDate != null && deviceObj.EndDate != null)
                {
                      stDate = deviceObj.StartDate.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
                     endDate = deviceObj.EndDate.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");

                   // stDate = (DateTime.UtcNow.AddHours(-8)).ToString("O");
                   // endDate = DateTime.UtcNow.ToString("O");
                    System.Diagnostics.Debug.WriteLine("real start date => " + deviceObj.StartDate.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                    System.Diagnostics.Debug.WriteLine("real end date => " + deviceObj.EndDate.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));

                    System.Diagnostics.Debug.WriteLine("STDate => " + stDate);
                    System.Diagnostics.Debug.WriteLine("ENd =. " + endDate);
                }
                else
                {
                    stDate = (DateTime.UtcNow.AddHours(-8)).ToString("O");
                    endDate = DateTime.UtcNow.ToString("O");
                }

                if (!await ApplicationVariables.IOnLine())
                {
                    lineGraphdata = (RootObjectLine)await graphService.GetLineGraph2(stDate, endDate, deviceObj.DeviceMacId, "MAX");
                }
                else
                {
                    lineGraphdata = (RootObjectLine)await graphService.GetLineGraph(stDate, endDate, deviceObj.DeviceMacId, "MAX");
                 //   System.Diagnostics.Debug.WriteLine("lineGraphdata => " + lineGraphdata);

                }

                try
                {
                    if(lineGraphdata != null)
                    {
                        FillData(lineGraphdata);
                        System.Diagnostics.Debug.WriteLine("lineGraphdata => " + lineGraphdata);

                    }
                    var LoadGraph = new LoadLineGraph { Message = "LoadLineGraph" };
                    MessengerInstance.Send<LoadLineGraph>(LoadGraph);
                }
                catch {
                }
                System.Diagnostics.Debug.WriteLine("DetailGraphView => " + parameter);
            }
           
            //if (parameter != null)
            //{
            //    selectedType = (PageNames.BarType)parameter;
            //}
        }
        private void FillData(RootObjectLine graphData){
            this.BarData.Clear(); 
            if (graphData.results != null)
            {
                foreach (LineResult result in graphData.results)
                {
                    if (result.series != null)
                    {
                        foreach (LineSeries series in result.series)
                        {
                            if (series.values != null)
                            {
                                foreach (List<object> list in series.values)
                                {
                                    DateTime date = (DateTime)list[0];
                                    float frequency = Convert.ToSingle(list[1]);
                                    float temp = Convert.ToSingle(list[2]);
                                    float hum = Convert.ToSingle(list[3]);
                                    float sound = Convert.ToSingle(list[4]);
                                    float vib = Convert.ToSingle(list[5]);

                                    barDataModel datamodel = new barDataModel()
                                    {
                                        frequency = frequency,
                                        temprature = temp,
                                        humidity = hum,
                                        spl = sound,
                                        vib = vib,
                                        key = date
                                    };
                                    BarData.Add(datamodel);
                                }
                            }
                        }
                    }
                }
            }
        }
        public struct barDataModel
        {
            public DateTime key;
            public float frequency;
            public float humidity;
            public float spl;
            public float temprature;
            public float vib;
        }

        public List<barDataModel> BarData = new List<barDataModel>();

        public float getMaxFrequency()
        {
            return this.BarData.OfType<barDataModel>().Max(barDataModel => barDataModel.frequency);
        }
        public float getMaxHumidity()
        {
            return this.BarData.Max(barDataModel => barDataModel.humidity);
        }
        public float getMaxspl()
        {
            return this.BarData.Max(barDataModel => barDataModel.spl);
        }
        public float getMaxTemprature()
        {
            return this.BarData.Max(barDataModel => barDataModel.temprature);
        }
        public float getMaxVib()
        {
            return this.BarData.Max(barDataModel => barDataModel.vib);
        }

    }
}
