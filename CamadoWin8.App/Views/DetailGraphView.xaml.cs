using CamadoWin8.App.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CamadoWin8.Contracts.View;
using CamadoWin8.Contracts.ViewModels;

using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Graphics.Canvas.Numerics;
using Microsoft.Graphics.Canvas.Text;
using CamadoWin8.ViewModel;
using Windows.UI;
using SM = System.Math;
using System.Globalization;
using CamadoWin8.Contracts.Services;


// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CamadoWin8.App.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DetailGraphView : Page, IDetailGraphView
    {
       /* public DetailGraphView()
        {
            this.InitializeComponent();
        }*/
        
        static int numberOfIntervals = 10;
        static int heightOffset = 60;
        DetailGraphViewModel graphModel;
        struct AxisData
        {
            public string key;
            public string value;
        }

        AxisData[] xAxisData;
        float YAxisMaxValue_Left;
        float YAxisMaxValue_Right;
        CanvasTextFormat format = new CanvasTextFormat()
        {
            FontSize = 14,
            FontFamily = "Times New Roman",
            WordWrapping = CanvasWordWrapping.Wrap,
            HorizontalAlignment = CanvasHorizontalAlignment.Center,
        };
        public DetailGraphView()
        {
            this.InitializeComponent();

            graphModel = (DetailGraphViewModel)this.ViewModel;

            xAxisData = new AxisData[] {
            new AxisData() {key = "2017-06-20T11:30:00Z", value = "11:30" },
            new AxisData() {key = "2017-06-20T12:30:00Z", value = "12.30" },
            new AxisData() {key = "2017-06-20T13:30:00Z", value = "13:30" },
            new AxisData() {key = "2017-06-20T14:30:00Z", value = "14:30" },
            new AxisData() {key = "2017-06-20T15:30:00Z", value = "15:30" },
            new AxisData() {key = "2017-06-20T16:30:00Z", value = "16:30" },
            new AxisData() {key = "2017-06-20T17:30:00Z", value = "17:30" },
            new AxisData() {key = "2017-06-20T18:30:00Z", value = "18:30" },
            new AxisData() {key = "2017-06-20T19:30:00Z", value = "19:30" },
            new AxisData() {key = "2017-06-20T20:30:00Z", value = "20:30" },
            new AxisData() {key = "2017-06-20T21:30:00Z", value = "21:30" },
            new AxisData() {key = "2017-06-20T22:30:00Z", value = "22:30" },
            new AxisData() {key = "2017-06-20T23:30:00Z", value = "23:30" },
            new AxisData() {key = "2017-06-20T00:30:00Z", value = "00:30" },
            new AxisData() {key = "2017-06-20T01:30:00Z", value = "01:30" },
            new AxisData() {key = "2017-06-20T02:30:00Z", value = "02:30" },
            new AxisData() {key = "2017-06-20T03:30:00Z", value = "03:30" },
            new AxisData() {key = "2017-06-20T04:30:00Z", value = "04:30" },
            new AxisData() {key = "2017-06-20T05:30:00Z", value = "05:30" },
            new AxisData() {key = "2017-06-20T06:30:00Z", value = "06:30" },
            new AxisData() {key = "2017-06-20T07:30:00Z", value = "07:30" },
            new AxisData() {key = "2017-06-20T08:30:00Z", value = "08:30" },
            new AxisData() {key = "2017-06-20T09:30:00Z", value = "09:30" },
            new AxisData() {key = "2017-06-20T10:30:00Z", value = "10:30" }
            };

            //            yAxisData_Right = this.plotPoints(graphModel.getMaxFrequency());

        }



        private void canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.CanvasControl sender,
 Microsoft.Graphics.Canvas.UI.Xaml.CanvasDrawEventArgs args)
        {
            GraphYAxisPlotter yAxisPlotter = new GraphYAxisPlotter();
            yAxisPlotter.AxisLabel = "(Humidity, Sound, Temperature, Vibration)";
            float[] maxDataValues = new float[4] { graphModel.getMaxHumidity(), graphModel.getMaxspl(), graphModel.getMaxTemprature(), graphModel.getMaxVib() };
            yAxisPlotter.MaximumOffset = maxDataValues.Max();
            YAxisMaxValue_Left = yAxisPlotter.renderLeftYAxis(sender, args);

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            this.canvas.RemoveFromVisualTree();
            this.canvas = null;

            this.barcanvas.RemoveFromVisualTree();
            this.barcanvas = null;

            this.canvasright.RemoveFromVisualTree();
            this.canvasright = null;
        }
        private void drawingcanvas_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            var width = (float)canvas.ActualWidth;
            var height = (float)(canvas.ActualHeight) - heightOffset;
            var startPointX = 5;
            var startPointY = height;
            float offset = height / numberOfIntervals;

            using (var cpb = new CanvasPathBuilder(args.DrawingSession))
            {
                System.Diagnostics.Debug.WriteLine("startingPoint => " + startPointX + " " + startPointY);
                for (int i = 0; i < xAxisData.Length; i++)
                {
                    string key = xAxisData[i].key;
                    float yReference_Left = height / YAxisMaxValue_Left;
                    float yReference_Right = height / YAxisMaxValue_Right;

                    float humidity = yReference_Left * graphModel.getHumidityForValue(key);
                    float spl = yReference_Left * graphModel.getSplForValue(key);
                    float temprature = yReference_Left * graphModel.getTemperatureForValue(key);
                    float vib = yReference_Left * graphModel.getVibForValue(key);
                    float frequency = yReference_Right * graphModel.getFrequncyForValue(key);
                    args.DrawingSession.DrawLine(new Vector2() { X = startPointX , Y = startPointY }, new Vector2() { X = startPointX, Y = height - humidity }, Colors.Black);
                    startPointX = startPointX+ 25;
                    startPointY = height - humidity;
                }
            }
        }

        private void canvasright_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            // this.renderRightYAxis(sender, args);
            GraphYAxisPlotter yAxisPlotter = new GraphYAxisPlotter();
            yAxisPlotter.AxisLabel = "(Frequency)";
            yAxisPlotter.MaximumOffset = graphModel.getMaxFrequency();
            yAxisPlotter.IsLeftAxis = false;
            yAxisPlotter.AxisColor = Colors.Red;
            YAxisMaxValue_Right = yAxisPlotter.renderLeftYAxis(sender, args);

        }
        
        public IViewModel ViewModel
        {
            get { return this.DataContext as IViewModel; }
        }



        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

    }
}
