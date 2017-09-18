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
        float[] yAxisData_Left;
        float[] yAxisData_Right;
        CanvasTextFormat format = new CanvasTextFormat()
        {
            FontSize = 14,
            FontFamily = "Times New Roman",
            WordWrapping = CanvasWordWrapping.Wrap,
            HorizontalAlignment = CanvasHorizontalAlignment.Center,
        };
        public GraphView()
        {
            this.InitializeComponent();
            graphModel = (GraphViewModel)this.ViewModel;

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

            float[] maxDataValues = new float[4] { graphModel.getMaxHumidity(), graphModel.getMaxspl(), graphModel.getMaxTemprature(), graphModel.getMaxVib() };

            yAxisData_Left = this.plotPoints(maxDataValues.Max());
            yAxisData_Right = this.plotPoints(graphModel.getMaxFrequency());

        }



        private void canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.CanvasControl sender,
 Microsoft.Graphics.Canvas.UI.Xaml.CanvasDrawEventArgs args)
        {
            this.renderLeftYAxis(sender, args);
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
            var startPoint = 5;
            float[] datapoints = (new float[] { 15.0f, 23.0f, 45.0f, 25.0f, 60.0f, 5.0f, 8.0f, 17.0f, 26.0f, 76.0f, 0.0f, 9.0f, 34.0f, 32.0f, 45.0f });

            float offset = height / numberOfIntervals;

            using (var cpb = new CanvasPathBuilder(args.DrawingSession))
            {
                // Verical line
                cpb.BeginFigure(new Vector2() { X = 0, Y = height });
                cpb.AddLine(new Vector2() { X = width, Y = height });
                cpb.EndFigure(CanvasFigureLoop.Open);
                args.DrawingSession.DrawGeometry(CanvasGeometry.CreatePath(cpb), Colors.Black, 1);

                for (int i = 0; i < xAxisData.Length; i++)
                {
                    string key = xAxisData[i].key;
                    float yReference_Left = height / yAxisData_Left.Max();
                    float yReference_Right = height / yAxisData_Right.Max();

                    float humidity = yReference_Left * graphModel.getHumidityForValue(key);
                    float spl = yReference_Left * graphModel.getSplForValue(key);
                    float temprature = yReference_Left * graphModel.getTemperatureForValue(key);
                    float vib = yReference_Left * graphModel.getVibForValue(key);
                    float frequency = yReference_Right * graphModel.getFrequncyForValue(key);

                    args.DrawingSession.DrawText(xAxisData[i].value, new Vector2() { X = startPoint + 60, Y = height + 20 }, Colors.Black, format);
                    args.DrawingSession.DrawLine(new Vector2() { X = startPoint + 60, Y = height }, new Vector2() { X = startPoint + 60, Y = height + 15 }, Colors.Black);
                    args.DrawingSession.FillRectangle(startPoint, height - humidity, 25, humidity, Colors.Blue);
                    startPoint = startPoint + 25;
                    args.DrawingSession.FillRectangle(startPoint, height - spl, 25, spl, Colors.Green);
                    startPoint = startPoint + 25;
                    args.DrawingSession.FillRectangle(startPoint, height - temprature, 25, temprature, Colors.Yellow);
                    startPoint = startPoint + 25;
                    args.DrawingSession.FillRectangle(startPoint, height - vib, 25, vib, Colors.Black);
                    startPoint = startPoint + 25;
                    args.DrawingSession.FillRectangle(startPoint, height - frequency, 25, frequency, Colors.Red);
                    startPoint = startPoint + 40;
                }
            }
        }

        private void canvasright_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            this.renderRightYAxis(sender, args);
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

        //Render Left y Axis
        public void renderLeftYAxis(CanvasControl canvas, CanvasDrawEventArgs args)
        {
            var width = (float)canvas.ActualWidth;
            var height = (float)(canvas.ActualHeight) - heightOffset;
            //  var xOffset = 10;
            Vector2 startPoint = new Vector2()
            {
                X = width,
                Y = height
            };
            using (var cpb = new CanvasPathBuilder(args.DrawingSession))
            {
                // Verical line
                cpb.BeginFigure(startPoint);
                cpb.AddLine(new Vector2() { X = width, Y = 0 });
                cpb.EndFigure(CanvasFigureLoop.Open);

                float offset = height / 10;
                float yVal = height;
                for (int i = 0; i <= 10; i++)
                {
                    cpb.BeginFigure(new Vector2() { X = width, Y = yVal });
                    cpb.AddLine(new Vector2() { X = width - 10, Y = yVal });
                    cpb.EndFigure(CanvasFigureLoop.Open);

                    float yPosition = yVal - 15;
                    if (yPosition < 0)
                        yPosition = 2;
                    args.DrawingSession.DrawText(Convert.ToString(yAxisData_Left[i]), new Vector2() { X = width - 30, Y = yPosition }, Colors.Black, format);
                    yVal = yVal - offset;

                }
                //Draw 
                args.DrawingSession.DrawGeometry(CanvasGeometry.CreatePath(cpb), Colors.Black, 1);
                Vector2 textPoint = new Vector2()
                {
                    X = width - 5,
                    Y = height - 5
                };

                args.DrawingSession.Transform *= System.Numerics.Matrix3x2.CreateRotation(-(float)Math.PI / 2, new Vector2() { X = width - 80, Y = height - heightOffset });
                args.DrawingSession.DrawText("(Humidity, Sound, Temperature, Vibration)", new Vector2() { X = width - 80, Y = height - heightOffset }, Colors.Black);

            }

        }


        //Render right Y Axis
        public void renderRightYAxis(CanvasControl canvas, CanvasDrawEventArgs args)
        {
            var width = (float)canvas.ActualWidth;
            var height = (float)(canvas.ActualHeight) - heightOffset;
            //  var xOffset = 10;
            Vector2 startPoint = new Vector2()
            {
                X = 0,
                Y = height
            };
            using (var cpb = new CanvasPathBuilder(args.DrawingSession))
            {
                // Verical line
                cpb.BeginFigure(startPoint);
                cpb.AddLine(new Vector2() { X = 0, Y = 0 });
                cpb.EndFigure(CanvasFigureLoop.Open);

                float offset = height / 10;
                float yVal = height;
                for (int i = 0; i <= 10; i++)
                {
                    System.Diagnostics.Debug.WriteLine("value => " + Convert.ToString(yAxisData_Right[i]) + " " + yVal);

                    cpb.BeginFigure(new Vector2() { X = 0, Y = yVal });
                    cpb.AddLine(new Vector2() { X = 10, Y = yVal });
                    cpb.EndFigure(CanvasFigureLoop.Open);

                    float yPosition = yVal - 14;
                    if (yPosition < 0)
                        yPosition = 2;
                    System.Diagnostics.Debug.WriteLine("value => " + Convert.ToString(yAxisData_Right[i]) + " " + yPosition);

                    args.DrawingSession.DrawText(Convert.ToString(yAxisData_Right[i]), new Vector2() { X = 0 + 35, Y = yPosition }, Colors.Black, format);
                    // args.DrawingSession.DrawText(Convert.ToString(points[i]), width - 50, yVal - 20, 20, 20, Colors.Black, format);
                    yVal = yVal - offset;

                }
                //Draw 
                args.DrawingSession.DrawGeometry(CanvasGeometry.CreatePath(cpb), Colors.Black, 1);
                args.DrawingSession.Transform *= System.Numerics.Matrix3x2.CreateRotation(-(float)Math.PI / 2, new Vector2() { X = 60, Y = height - heightOffset });
                args.DrawingSession.DrawText("(Frequency)", new Vector2() { X = 60, Y = height - heightOffset }, Colors.Black);

            }
        }
        //Find Y Axis Plot Points
        public float[] plotPoints(float maxValue)
        {
            //Find max value

            //Rounding maximum value to nearest number 
            Int32 numofDigits = Convert.ToInt32(Math.Ceiling(maxValue) == 0 ? 1.0 : Math.Floor(Math.Log10(Math.Abs(Math.Ceiling(maxValue))) + 1));
            System.Diagnostics.Debug.WriteLine("numofDigits => " + numofDigits);

            int division = (int)Math.Pow(10.0, numofDigits);
            System.Diagnostics.Debug.WriteLine("division => " + division);

            maxValue = maxValue / division;
            System.Diagnostics.Debug.WriteLine("maxValue => " + maxValue);

            if (maxValue < 0.1) { maxValue = 0; }
            else if (maxValue == 0.1f) { maxValue = 0.1f; }
            else if (maxValue <= 0.2f) { maxValue = 0.2f; }
            else if (maxValue <= 0.25f) { maxValue = 0.25f; }
            else if (maxValue <= 0.3f) { maxValue = 0.3f; }
            else if (maxValue <= 0.4f) { maxValue = 0.4f; }
            else if (maxValue <= 0.5f) { maxValue = 0.5f; }
            else if (maxValue <= 0.6f)
            {
                System.Diagnostics.Debug.WriteLine("enter 0.6 if loop");
                maxValue = 0.6f;
            }
            else if (maxValue <= 0.7f)
            {
                System.Diagnostics.Debug.WriteLine("enter 0.7 if loop");
                maxValue = 0.7f;
            }
            else if (maxValue <= 0.75f) { maxValue = 0.75f; }
            else if (maxValue <= 0.8f) { maxValue = 0.8f; }
            else if (maxValue <= 0.9f) { maxValue = 0.9f; }
            else if (maxValue <= 1.0f) { maxValue = 1.0f; }
            System.Diagnostics.Debug.WriteLine("maxValue => " + maxValue);
            maxValue = maxValue * division;
            System.Diagnostics.Debug.WriteLine("maxValue => " + maxValue);

            float range = maxValue / numberOfIntervals;
            System.Diagnostics.Debug.WriteLine("range => " + range);

            float[] plotingPoints = new float[numberOfIntervals + 1];
            for (int i = 0; i <= 10; i++)
            {
                plotingPoints[i] = i * range;
            }
            return plotingPoints;

        }

        private void barcanvas_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
