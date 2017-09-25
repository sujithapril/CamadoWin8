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
       

        static int numberOfIntervals = 10;
        static int heightOffset = 60;
        DetailGraphViewModel graphModel;
        public enum BarType { Frequency, Humidity, Spl, Vibration, Temprature };

        float YAxisMaxValue_Left;
        float YAxisMaxValue_Right;
        CanvasTextFormat format = new CanvasTextFormat()
        {
            FontSize = 14,
            WordWrapping = CanvasWordWrapping.Wrap,
            HorizontalAlignment = CanvasHorizontalAlignment.Center,
        };
        public DetailGraphView()
        {
            this.InitializeComponent();
            graphModel = (DetailGraphViewModel)this.ViewModel;
           
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
            var startPointX = -62;
            var startPointY = height;
            float offset = height / numberOfIntervals;

            using (var cpb = new CanvasPathBuilder(args.DrawingSession))
            {
                System.Diagnostics.Debug.WriteLine("startingPoint => " + startPointX + " " + startPointY);
                for (int i = 0; i < graphModel.graphData.Length; i++)
                {
                    string key = graphModel.graphData[i].key;
                    float yReference_Left = height / YAxisMaxValue_Left;
                    float yReference_Right = height / YAxisMaxValue_Right;

                    float humidity = yReference_Left * graphModel.getHumidityForValue(key);
                    float spl = yReference_Left * graphModel.getSplForValue(key);
                    float temprature = yReference_Left * graphModel.getTemperatureForValue(key);
                    float vib = yReference_Left * graphModel.getVibForValue(key);
                    float frequency = yReference_Right * graphModel.getFrequncyForValue(key);
                    if (i == 0)
                    {
                        // args.DrawingSession.DrawLine(new Vector2() { X = startPointX, Y = startPointY }, new Vector2() { X = startPointX, Y = height - humidity }, Colors.GreenYellow);
                    }
                    else
                    {
                        args.DrawingSession.DrawLine(new Vector2() { X = startPointX, Y = startPointY }, new Vector2() { X = startPointX + 58, Y = height - humidity }, Colors.GreenYellow);
                        args.DrawingSession.DrawCircle(new Vector2() { X = startPointX + 60, Y = height - humidity }, 4, Colors.Red);
                    }
                    startPointX = startPointX + 62;
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

        private void Rectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
