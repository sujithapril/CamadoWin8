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
using GalaSoft.MvvmLight.Messaging;

using SM = System.Math;
using System.Globalization;
using CamadoWin8.Contracts.Services;
using CamadoWin8.Shared;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CamadoWin8.App.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class GraphView : Page, IGraphView
    {

        static int numberOfIntervals = 10;
        static int heightOffset = 60;
        GraphViewModel graphModel;
        struct AxisData
        {
            public string key;
            public string value;
        }

        AxisData[] xAxisData;
        float YAxisMaxValue_Left;
        float YAxisMaxValue_Right;

        public struct BarData
        {
            public Rect bar;
            public PageNames.BarType type;
        }

        public List<BarData> barList = new List<BarData>();

        CanvasTextFormat format = new CanvasTextFormat()
        {
            FontSize = 14,
            WordWrapping = CanvasWordWrapping.Wrap,
            HorizontalAlignment = CanvasHorizontalAlignment.Center,
        };
        public GraphView()
        {
            this.InitializeComponent();
            Messenger.Default.Register<LoadGroupedBarGraph>(
                this,(action) => LoadGraph(action)
                );

            graphModel = (GraphViewModel)this.ViewModel;
            this.HumidityCheckBox.Fill = new SolidColorBrush(new PageNames().HumidityColor);
            this.TempratureCheckBox.Fill = new SolidColorBrush(new PageNames().TempratureColor);
            this.SoundCheckBox.Fill = new SolidColorBrush(new PageNames().SoundColor);
            this.FrequencyCheckBox.Fill = new SolidColorBrush(new PageNames().FrequencyColor);
            this.VibrationCheckBox.Fill = new SolidColorBrush(new PageNames().VibrationColor);
         

            //            yAxisData_Right = this.plotPoints(graphModel.getMaxFrequency());

        }
        private async void LoadGraph(LoadGroupedBarGraph action)
        {
            System.Diagnostics.Debug.WriteLine("CAlled load graph");
            this.canvas.Invalidate();
            this.canvasright.Invalidate();
            this.barcanvas.Invalidate();
        }



        private void canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.CanvasControl sender,
 Microsoft.Graphics.Canvas.UI.Xaml.CanvasDrawEventArgs args)
        {
            if (graphModel.BarData.Count > 0)
            {
                GraphYAxisPlotter yAxisPlotter = new GraphYAxisPlotter();
                yAxisPlotter.AxisLabel = "(Humidity, Sound, Temperature, Vibration)";
                float[] maxDataValues = new float[4] { graphModel.getMaxHumidity(), graphModel.getMaxspl(), graphModel.getMaxTemprature(), graphModel.getMaxVib() };
                yAxisPlotter.MaximumOffset = maxDataValues.Max();
                YAxisMaxValue_Left = yAxisPlotter.renderLeftYAxis(sender, args);
            }

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
            if (graphModel.BarData.Count > 0)
            {

                var width = (float)sender.ActualWidth;
                var height = (float)(sender.ActualHeight) - heightOffset;
                var startPoint = 5;
                float offset = height / numberOfIntervals;

                using (var cpb = new CanvasPathBuilder(args.DrawingSession))
                {
                    // Verical line
                    cpb.BeginFigure(new Vector2() { X = 0, Y = height });
                    cpb.AddLine(new Vector2() { X = width, Y = height });
                    cpb.EndFigure(CanvasFigureLoop.Open);
                    args.DrawingSession.DrawGeometry(CanvasGeometry.CreatePath(cpb), Colors.Black, 1);

                    for (int i = 0; i < graphModel.BarData.Count; i++)
                    {
                        DateTime key = graphModel.BarData[i].Key;
                        float yReference_Left = height / YAxisMaxValue_Left;
                        float yReference_Right = height / YAxisMaxValue_Right;

                        float humidity = yReference_Left * graphModel.BarData[i].Humidity;
                        float spl = yReference_Left * graphModel.BarData[i].Spl;
                        float temprature = yReference_Left * graphModel.BarData[i].Temprature;
                        float vib = yReference_Left * graphModel.BarData[i].Vib;
                        float frequency = yReference_Right * graphModel.BarData[i].Frequency;
                        String timeString = key.ToString("hh: mm");

                        args.DrawingSession.DrawText(timeString, new Vector2() { X = startPoint + 60, Y = height + 20 }, Colors.Black, format);
                        args.DrawingSession.DrawLine(new Vector2() { X = startPoint + 60, Y = height }, new Vector2() { X = startPoint + 60, Y = height + 15 }, Colors.Black);
                        args.DrawingSession.FillRectangle(startPoint, height - humidity, 25, humidity, new PageNames().HumidityColor);
                        barList.Add(new BarData() { bar = new Rect(startPoint, height - humidity, 25, humidity), type = PageNames.BarType.Humidity });
                        startPoint = startPoint + 25;
                        args.DrawingSession.FillRectangle(startPoint, height - spl, 25, spl, new PageNames().SoundColor);
                        barList.Add(new BarData() { bar = new Rect(startPoint, height - spl, 25, spl), type = PageNames.BarType.Spl });
                        startPoint = startPoint + 25;
                        args.DrawingSession.FillRectangle(startPoint, height - temprature, 25, temprature, new PageNames().TempratureColor);
                        barList.Add(new BarData() { bar = new Rect(startPoint, height - temprature, 25, temprature), type = PageNames.BarType.Temprature });
                        startPoint = startPoint + 25;
                        args.DrawingSession.FillRectangle(startPoint, height - vib, 25, vib, new PageNames().VibrationColor);
                        barList.Add(new BarData() { bar = new Rect(startPoint, height - vib, 25, vib), type = PageNames.BarType.Vibration });
                        startPoint = startPoint + 25;
                        args.DrawingSession.FillRectangle(startPoint, height - frequency, 25, frequency, new PageNames().FrequencyColor);
                        barList.Add(new BarData() { bar = new Rect(startPoint, height - frequency, 25, frequency), type = PageNames.BarType.Frequency });
                        startPoint = startPoint + 40;
                    }
                }
            }
        }

        private void canvasright_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            // this.renderRightYAxis(sender, args);
            if (graphModel.BarData.Count > 0)
            {
                GraphYAxisPlotter yAxisPlotter = new GraphYAxisPlotter();
                yAxisPlotter.AxisLabel = "(Frequency)";
                yAxisPlotter.MaximumOffset = graphModel.getMaxFrequency();
                yAxisPlotter.IsLeftAxis = false;
                yAxisPlotter.AxisColor = Colors.Red;
                YAxisMaxValue_Right = yAxisPlotter.renderLeftYAxis(sender, args);
            }

        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public IViewModel ViewModel
        {
            get { return this.DataContext as IViewModel; }
        }

        private void barcanvas_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Point point = e.GetPosition((CanvasControl)sender);
            System.Diagnostics.Debug.WriteLine("Tapped at " + point.X + " " + point.Y);
            foreach (BarData data in barList)
            {
                Rect rectangle = data.bar;
                if (rectangle.Contains(point))
                {
                    System.Diagnostics.Debug.WriteLine("TYpe => " + data.type);
                    graphModel.LoadDetailView(data.type);
                    return;
                }
            }

        }

        private void barcanvas_DragEnter(object sender, DragEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DRAGENTER");
        }
    }
}
