﻿using GalaSoft.MvvmLight;
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


        public PageNames.BarType selectedType;
        public async void Initialize(object parameter)
        {
            System.Diagnostics.Debug.WriteLine("DetailGraphView => " + parameter);
            if (parameter != null)
            {
                selectedType = (PageNames.BarType)parameter;
            }
        }
        public struct barDataModel
        {
            public string key;
            public float frequency;
            public float humidity;
            public float spl;
            public float temprature;
            public float vib;
        }


        public barDataModel[] graphData { get; set; } = new barDataModel[]
        {
            new barDataModel() {key = "2017-09-14T15:00:52Z",humidity=25.0f, frequency = 1000.0f, spl= 24.59f,temprature=100.0f,vib=65.0f},
            new barDataModel() {key = "2017-09-14T15:01:52Z",humidity=30.0f, frequency = 800.0f, spl= 24.59f,temprature=105.0f,vib=65.0f},
            new barDataModel() {key = "2017-09-14T15:02:52Z",humidity=25.0f, frequency = 800.0f, spl= 35.0f,temprature=100.0f,vib=65.0f},
            new barDataModel() {key = "2017-09-14T15:03:52Z",humidity=25.0f, frequency = 800.0f, spl= 35.0f,temprature=100.0f,vib=65.0f},
            new barDataModel() {key = "2017-09-14T15:04:52Z",humidity=25.0f, frequency = 800.0f, spl= 35.0f,temprature=100.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:05:52Z",humidity=25.0f, frequency = 700.0f, spl= 24.59f,temprature=100.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:06:52Z",humidity=35.0f, frequency = 600.0f, spl= 24.59f,temprature=70.0f,vib=45.0f},
            new barDataModel() {key = "2017-09-14T15:07:52Z",humidity=50.0f, frequency = 800.0f, spl= 30.0f,temprature=70.0f,vib=45.0f},
            new barDataModel() {key = "2017-09-14T15:08:52Z",humidity=30.0f, frequency = 800.0f, spl= 30.0f,temprature=70.0f,vib=45.0f},
            new barDataModel() {key = "2017-09-14T15:09:52Z",humidity=25.0f, frequency = 800.0f, spl= 30.0f,temprature=70.0f,vib=45.0f},
            new barDataModel() {key = "2017-09-14T15:10:52Z",humidity=25.0f, frequency = 200.0f, spl= 30.0f,temprature=70.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:11:52Z",humidity=25.0f, frequency = 800.0f, spl= 24.59f,temprature=70.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:12:52Z",humidity=25.0f, frequency = 225.0f, spl= 24.59f,temprature=70.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:13:52Z",humidity=30.0f, frequency = 225.0f, spl= 24.59f,temprature=70.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:14:52Z",humidity=40.0f, frequency = 225.0f, spl= 24.59f,temprature=70.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:15:52Z",humidity=35.0f, frequency = 225.0f, spl= 24.59f,temprature=70.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:16:52Z",humidity=20.0f, frequency = 225.0f, spl= 24.59f,temprature=100.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:17:52Z",humidity=25.0f, frequency = 225.0f, spl= 24.59f,temprature=75.0f,vib=60.0f},
            new barDataModel() {key = "2017-09-14T15:18:52Z",humidity=25.0f, frequency = 800.0f, spl= 24.59f,temprature=75.0f,vib=60.0f},
            new barDataModel() {key = "2017-09-14T15:19:52Z",humidity=25.0f, frequency = 800.0f, spl= 28.0f,temprature=75.0f,vib=60.0f},
            new barDataModel() {key = "2017-09-14T15:20:52Z",humidity=25.0f, frequency = 800.0f, spl= 24.59f,temprature=75.0f,vib=60.0f},
            new barDataModel() {key = "2017-09-14T15:21:52Z",humidity=25.0f, frequency = 800.0f, spl= 24.59f,temprature=100.0f,vib=60.0f},
            new barDataModel() {key = "2017-09-14T15:22:52Z",humidity=25.0f, frequency = 800.0f, spl= 24.59f,temprature=100.0f,vib=70.0f},
            new barDataModel() {key = "2017-09-14T15:23:52Z",humidity=25.0f, frequency = 800.0f, spl= 34.0f,temprature=85.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:24:52Z",humidity=25.0f, frequency = 800.0f, spl= 34.0f,temprature=85.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:25:52Z",humidity=25.0f, frequency = 300.0f, spl= 34.0f,temprature=85.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:26:52Z",humidity=25.0f, frequency = 300.0f, spl= 24.59f,temprature=85.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:27:52Z",humidity=25.0f, frequency = 300.0f, spl= 24.59f,temprature=85.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:28:52Z",humidity=25.0f, frequency = 300.0f, spl= 24.59f,temprature=85.0f,vib=75.0f},
            new barDataModel() {key = "2017-09-14T15:29:52Z",humidity=25.0f, frequency = 300.0f, spl= 24.59f,temprature=85.0f,vib=75.0f},
            new barDataModel() {key = "2017-09-14T15:30:52Z",humidity=25.0f, frequency = 800.0f, spl= 24.59f,temprature=85.0f,vib=75.0f},
            new barDataModel() {key = "2017-09-14T15:31:52Z",humidity=25.0f, frequency = 335.0f, spl= 27.0f,temprature=85.0f,vib=75.0f},
            new barDataModel() {key = "2017-09-14T15:32:52Z",humidity=25.0f, frequency = 335.0f, spl= 27.0f,temprature=85.0f,vib=75.0f},
            new barDataModel() {key = "2017-09-14T15:33:52Z",humidity=21.0f, frequency = 335.0f, spl= 27.0f,temprature=85.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:34:52Z",humidity=21.0f, frequency = 335.0f, spl= 27.0f,temprature=85.0f,vib=75.0f},
            new barDataModel() {key = "2017-09-14T15:35:52Z",humidity=21.0f, frequency = 800.0f, spl= 24.59f,temprature=85.0f,vib=75.0f},
            new barDataModel() {key = "2017-09-14T15:36:52Z",humidity=25.0f, frequency = 800.0f, spl= 24.59f,temprature=85.0f,vib=75.0f},
            new barDataModel() {key = "2017-09-14T15:37:52Z",humidity=25.0f, frequency = 800.0f, spl= 24.59f,temprature=100.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:38:52Z",humidity=25.0f, frequency = 800.0f, spl= 32.0f,temprature=100.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:39:52Z",humidity=25.0f, frequency = 800.0f, spl= 32.0f,temprature=100.0f,vib=85.0f},
            new barDataModel() {key = "2017-09-14T15:40:52Z",humidity=27.0f, frequency = 800.0f, spl= 24.59f,temprature=100.0f,vib=85.0f},
            new barDataModel() {key = "2017-09-14T15:41:52Z",humidity=25.0f, frequency = 400.0f, spl= 43.0f,temprature=100.0f,vib=85.0f},
            new barDataModel() {key = "2017-09-14T15:42:52Z",humidity=25.0f, frequency = 800.0f, spl= 24.59f,temprature=100.0f,vib=85.0f},
            new barDataModel() {key = "2017-09-14T15:43:52Z",humidity=22.0f, frequency = 800.0f, spl= 24.59f,temprature=100.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:44:52Z",humidity=25.0f, frequency = 400.0f, spl= 24.59f,temprature=100.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:45:52Z",humidity=25.0f, frequency = 400.0f, spl= 24.59f,temprature=100.0f,vib=90.0f},
            new barDataModel() {key = "2017-09-14T15:46:52Z",humidity=35.0f, frequency = 400.0f, spl= 24.59f,temprature=90.0f,vib=90.0f},
            new barDataModel() {key = "2017-09-14T15:47:52Z",humidity=25.0f, frequency = 800.0f, spl= 24.59f,temprature=90.0f,vib=90.0f},
            new barDataModel() {key = "2017-09-14T15:48:52Z",humidity=25.0f, frequency = 500.0f, spl= 24.59f,temprature=90.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:49:52Z",humidity=30.0f, frequency = 800.0f, spl= 24.59f,temprature=90.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:50:52Z",humidity=25.0f, frequency = 800.0f, spl= 24.59f,temprature=90.0f,vib=35.0f},
            new barDataModel() {key = "2017-09-14T15:51:52Z",humidity=25.0f, frequency = 800.0f, spl= 24.59f,temprature=90.0f,vib=26.0f},
            new barDataModel() {key = "2017-09-14T15:52:52Z",humidity=25.0f, frequency = 800.0f, spl= 24.59f,temprature=90.0f,vib=26.0f},
            new barDataModel() {key = "2017-09-14T15:53:52Z",humidity=25.0f, frequency = 800.0f, spl= 24.59f,temprature=90.0f,vib=26.0f},
            new barDataModel() {key = "2017-09-14T15:54:52Z",humidity=43.0f, frequency = 800.0f, spl= 24.59f,temprature=90.0f,vib=26.0f},
            new barDataModel() {key = "2017-09-14T15:55:52Z",humidity=10.0f, frequency = 800.0f, spl= 24.59f,temprature=90.0f,vib=26.0f},
            new barDataModel() {key = "2017-09-14T15:56:52Z",humidity=28.0f, frequency = 800.0f, spl= 24.59f,temprature=90.0f,vib=26.0f},
            new barDataModel() {key = "2017-09-14T15:57:52Z",humidity=28.0f, frequency = 800.0f, spl= 24.59f,temprature=100.0f,vib=26.0f},
            new barDataModel() {key = "2017-09-14T15:58:52Z",humidity=25.0f, frequency = 800.0f, spl= 24.59f,temprature=100.0f,vib=26.0f},
            new barDataModel() {key = "2017-09-14T15:59:52Z",humidity=25.0f, frequency = 800.0f, spl= 24.59f,temprature=100.0f,vib=26.0f},

        };



        public float getMaxFrequency()
        {
            return this.graphData.OfType<barDataModel>().Max(barDataModel => barDataModel.frequency);
        }
        public float getFrequncyForValue(string value)
        {
            barDataModel obj = Array.Find(graphData, barDataModel => barDataModel.key == value);
            return obj.frequency;
        }
        public float getHumidityForValue(string value)
        {
            barDataModel obj = Array.Find(graphData, barDataModel => barDataModel.key == value);
            return obj.humidity;
        }
        public float getSplForValue(string value)
        {
            barDataModel obj = Array.Find(graphData, barDataModel => barDataModel.key == value);
            return obj.spl;
        }
        public float getTemperatureForValue(string value)
        {
            barDataModel obj = Array.Find(graphData, barDataModel => barDataModel.key == value);
            return obj.temprature;
        }
        public float getVibForValue(string value)
        {
            barDataModel obj = Array.Find(graphData, barDataModel => barDataModel.key == value);
            return obj.vib;
        }
        public float getMaxHumidity()
        {
            return this.graphData.OfType<barDataModel>().Max(barDataModel => barDataModel.humidity);
        }
        public float getMaxspl()
        {
            return this.graphData.OfType<barDataModel>().Max(barDataModel => barDataModel.spl);
        }
        public float getMaxTemprature()
        {
            return this.graphData.OfType<barDataModel>().Max(barDataModel => barDataModel.temprature);
        }
        public float getMaxVib()
        {
            return this.graphData.OfType<barDataModel>().Max(barDataModel => barDataModel.vib);
        }
    }
}
