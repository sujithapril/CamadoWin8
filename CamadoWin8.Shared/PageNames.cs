using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;

namespace CamadoWin8.Shared
{
    public class PageNames
    {

        public const string LogInView = "CamadoWin8.App.Views.LogInView";
        public const string LayOutView = "CamadoWin8.App.Views.LayOutView";
        public const string HomeView = "CamadoWin8.App.Views.HomeView";
        public const string LocationView = "CamadoWin8.App.Views.LocationView";
        public const string GraphView = "CamadoWin8.App.Views.GraphView";
        public const string DetailGraphView = "CamadoWin8.App.Views.DetailGraphView";
        public enum BarType { Frequency, Humidity, Spl, Vibration, Temprature };

        public Color FrequencyColor = Color.FromArgb(255, 240, 78, 35);
        public Color VibrationColor = Color.FromArgb(255, 104, 102, 229);
        public Color SoundColor = Color.FromArgb(255, 122, 193, 66);
        public Color TempratureColor = Color.FromArgb(255, 104, 102, 94);
        public Color HumidityColor = Color.FromArgb(255, 42, 96, 169);


    }
    public class ApplicationVariables
    {
        public  static bool IsOffLine = false;

        public static Frame RootFrame { get; set; }
    }
}
