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
using CamadoWin8.Shared;
using Windows.UI.Xaml.Shapes;


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
        public struct SelectedBars
        {
            public Boolean IsFrequencySelected;
            public Boolean IsVibrationSelected;
            public Boolean IsTempratureSelected;
            public Boolean IsSoundSelected;
            public Boolean IsHumiditySelected;
        }
        SelectedBars selectedBar = new SelectedBars()
        {
            IsFrequencySelected = false,
            IsHumiditySelected = false,
            IsTempratureSelected = false,
            IsVibrationSelected = false,
            IsSoundSelected = false
        };
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
            var width = (float)sender.ActualWidth;
            var height = (float)(canvas.ActualHeight) - heightOffset;
            var startPointX = -62;
            var Humidity_startPointY = height;
            var Temprature_startPointY = height;
            var Vibration_startPointY = height;
            var Sound_startPointY = height;
            var Frequency_startPointY = height;

            float offset = height / numberOfIntervals;

            using (var cpb = new CanvasPathBuilder(args.DrawingSession))
            {
                cpb.BeginFigure(new Vector2() { X = 0, Y = height });
                cpb.AddLine(new Vector2() { X = width, Y = height });
                cpb.EndFigure(CanvasFigureLoop.Open);
                args.DrawingSession.DrawGeometry(CanvasGeometry.CreatePath(cpb), Colors.Black, 1);

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
                    DateTime DT = Convert.ToDateTime(key);
                    String timeString = DT.ToString("hh: mm");

                    if (i == 0)
                    {
                        args.DrawingSession.DrawText(timeString, new Vector2() { X = startPointX + 80, Y = height + 20 }, Colors.Black, format);
                        // args.DrawingSession.DrawLine(new Vector2() { X = startPointX, Y = height }, new Vector2() { X = startPointX, Y = height + 15 }, Colors.Black);
                    }
                    else
                    {
                        if (i == graphModel.graphData.Length - 1)
                        {
                            args.DrawingSession.DrawText(timeString, new Vector2() { X = startPointX + 57, Y = height + 20 }, Colors.Black, format);

                        }
                        else
                        {
                            args.DrawingSession.DrawText(timeString, new Vector2() { X = startPointX + 60, Y = height + 20 }, Colors.Black, format);

                        }
                        args.DrawingSession.DrawLine(new Vector2() { X = startPointX + 58, Y = height }, new Vector2() { X = startPointX + 58, Y = height + 15 }, Colors.Black);

                        if (selectedBar.IsHumiditySelected)
                        {
                            args.DrawingSession.DrawLine(new Vector2() { X = startPointX, Y = Humidity_startPointY }, new Vector2() { X = startPointX + 58, Y = height - humidity }, new PageNames().HumidityColor);
                            args.DrawingSession.DrawCircle(new Vector2() { X = startPointX + 60, Y = height - humidity }, 4, new PageNames().HumidityColor);
                        }
                        if (selectedBar.IsFrequencySelected)
                        {
                            args.DrawingSession.DrawLine(new Vector2() { X = startPointX, Y = Frequency_startPointY }, new Vector2() { X = startPointX + 58, Y = height - frequency }, new PageNames().FrequencyColor);
                            args.DrawingSession.DrawCircle(new Vector2() { X = startPointX + 60, Y = height - frequency }, 4, new PageNames().FrequencyColor);
                        }
                        if (selectedBar.IsSoundSelected)
                        {
                            args.DrawingSession.DrawLine(new Vector2() { X = startPointX, Y = Sound_startPointY }, new Vector2() { X = startPointX + 58, Y = height - spl }, new PageNames().SoundColor);
                            args.DrawingSession.DrawCircle(new Vector2() { X = startPointX + 60, Y = height - spl }, 4, new PageNames().SoundColor);
                        }
                        if (selectedBar.IsTempratureSelected)
                        {
                            args.DrawingSession.DrawLine(new Vector2() { X = startPointX, Y = Temprature_startPointY }, new Vector2() { X = startPointX + 58, Y = height - temprature }, new PageNames().TempratureColor);
                            args.DrawingSession.DrawCircle(new Vector2() { X = startPointX + 60, Y = height - temprature }, 4, new PageNames().TempratureColor);
                        }
                        if (selectedBar.IsVibrationSelected)
                        {
                            args.DrawingSession.DrawLine(new Vector2() { X = startPointX, Y = Vibration_startPointY }, new Vector2() { X = startPointX + 58, Y = height - vib }, new PageNames().VibrationColor);
                            args.DrawingSession.DrawCircle(new Vector2() { X = startPointX + 60, Y = height - vib }, 4, new PageNames().VibrationColor);
                        }
                    }

                    startPointX = startPointX + 62;
                    Humidity_startPointY = height - humidity;
                    Frequency_startPointY = height - frequency;
                    Sound_startPointY = height - spl;
                    Temprature_startPointY = height - temprature;
                    Vibration_startPointY = height - vib;

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
            switch (graphModel.selectedType)
            {
                case PageNames.BarType.Humidity:
                    {
                        this.HumidityCheckBox.Fill = new SolidColorBrush(new PageNames().HumidityColor);
                        selectedBar.IsHumiditySelected = true;
                    }
                    break;
                case PageNames.BarType.Spl:
                    this.SoundCheckBox.Fill = new SolidColorBrush(new PageNames().SoundColor);
                    selectedBar.IsSoundSelected = true;
                    break;
                case PageNames.BarType.Temprature:
                    this.TempratureCheckBox.Fill = new SolidColorBrush(new PageNames().TempratureColor);
                    selectedBar.IsTempratureSelected = true;
                    break;
                case PageNames.BarType.Vibration:
                    this.VibrationCheckBox.Fill = new SolidColorBrush(new PageNames().VibrationColor);
                    selectedBar.IsVibrationSelected = true;
                    break;
                case PageNames.BarType.Frequency:
                    this.FrequencyCheckBox.Fill = new SolidColorBrush(new PageNames().FrequencyColor);
                    selectedBar.IsFrequencySelected = true;
                    break;
            }

        }

        private void Rectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            switch ((String)rect.Tag)
            {
                case "100":
                    if (!selectedBar.IsHumiditySelected)
                    {
                        this.HumidityCheckBox.Fill = new SolidColorBrush(new PageNames().HumidityColor);
                    }
                    else
                    {
                        this.HumidityCheckBox.Fill = new SolidColorBrush(Colors.DarkGray);
                    }
                    selectedBar.IsHumiditySelected = !selectedBar.IsHumiditySelected;
                    break;
                case "101":
                    if (!selectedBar.IsSoundSelected)
                    {
                        this.SoundCheckBox.Fill = new SolidColorBrush(new PageNames().SoundColor);
                    }
                    else
                    {
                        this.SoundCheckBox.Fill = new SolidColorBrush(Colors.DarkGray);
                    }
                    selectedBar.IsSoundSelected = !selectedBar.IsSoundSelected;
                    break;
                case "102":
                    if (!selectedBar.IsTempratureSelected)
                    {
                        this.TempratureCheckBox.Fill = new SolidColorBrush(new PageNames().TempratureColor);
                    }
                    else
                    {
                        this.TempratureCheckBox.Fill = new SolidColorBrush(Colors.DarkGray);
                    }
                    selectedBar.IsTempratureSelected = !selectedBar.IsTempratureSelected;
                    break;
                case "103":
                    if (!selectedBar.IsVibrationSelected)
                    {
                        this.VibrationCheckBox.Fill = new SolidColorBrush(new PageNames().VibrationColor);
                    }
                    else
                    {
                        this.VibrationCheckBox.Fill = new SolidColorBrush(Colors.DarkGray);
                    }
                    selectedBar.IsVibrationSelected = !selectedBar.IsVibrationSelected;
                    break;
                case "104":
                    if (!selectedBar.IsFrequencySelected)
                    {
                        this.FrequencyCheckBox.Fill = new SolidColorBrush(new PageNames().FrequencyColor);
                    }
                    else
                    {
                        this.FrequencyCheckBox.Fill = new SolidColorBrush(Colors.DarkGray);
                    }
                    selectedBar.IsFrequencySelected = !selectedBar.IsFrequencySelected;
                    break;
            }
            this.barcanvas.Invalidate();
        }
    }
}
