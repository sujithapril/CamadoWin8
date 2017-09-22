using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Graphics.Canvas.Numerics;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace CamadoWin8.App.Common
{
    class GraphYAxisPlotter
    {
        public int NumberOfIntervals { get; set; } = 10;
        public float HeightOffset { get; set; } = 60;
        public float WidthOffset { get; set; } = 10;

        public float AxisLabelYOffset { get; set; } = 15;
        public float AxisPointOffset { get; set; } = 30;
        public float AxisLabelOffset { get; set; } = 80;

        public float MinimumOffset { get; set; } = 0;
        public float MaximumOffset { get; set; } = 50;
        public string AxisLabel { get; set; } = "";
        public Boolean IsLeftAxis { get; set; } = true;


        public CanvasTextFormat format { get; set; } = new CanvasTextFormat()
        {
            FontSize = 14,
            WordWrapping = CanvasWordWrapping.Wrap,
            HorizontalAlignment = CanvasHorizontalAlignment.Center,
        };
        public Color AxisColor { get; set; } = Colors.Black;
        public Color AxisPointsColor { get; set; } = Colors.Black;
        public Color AxisLabelColor { get; set; } = Colors.Black;

        public float renderLeftYAxis(CanvasControl canvas, CanvasDrawEventArgs args)
        {
            float[] plottingPoints = this.plotPoints();
            var width = (float)canvas.ActualWidth;
            var height = (float)(canvas.ActualHeight) - HeightOffset;
            float xPoint = 0;
            if (IsLeftAxis)
            {
                xPoint = width;
            }
            Vector2 startPoint = new Vector2() { X = xPoint, Y = height };
            Vector2 endPoint = new Vector2() { X = xPoint, Y = 0 };

            using (var cpb = new CanvasPathBuilder(args.DrawingSession))
            {
                // Verical Axis line
              //  cpb.BeginFigure(startPoint);
               
                //cpb.AddLine(endPoint);
            
                //cpb.EndFigure(CanvasFigureLoop.Open);
                args.DrawingSession.DrawLine(startPoint, endPoint, AxisColor);

                float offset = height / NumberOfIntervals;
                float yVal = height;
                for (int i = 0; i <= NumberOfIntervals; i++)
                {
                  //  cpb.BeginFigure(new Vector2() { X = xPoint, Y = yVal });
                    if (IsLeftAxis)
                    {
                        args.DrawingSession.DrawLine(new Vector2() { X = xPoint, Y = yVal }, new Vector2() { X = width - WidthOffset, Y = yVal }, AxisPointsColor);
                      //  cpb.AddLine(new Vector2() { X = width - WidthOffset, Y = yVal });
                    }
                    else
                    {
                        args.DrawingSession.DrawLine(new Vector2() { X = xPoint, Y = yVal }, new Vector2() { X = WidthOffset, Y = yVal }, AxisPointsColor);

                       // cpb.AddLine(new Vector2() { X = WidthOffset, Y = yVal });
                    }
                 //   cpb.EndFigure(CanvasFigureLoop.Open);

                    float yPosition = yVal - AxisLabelYOffset;
                    if (yPosition < 0)
                        yPosition = 2;
                    if (IsLeftAxis)
                    {
                        args.DrawingSession.DrawText(Convert.ToString(plottingPoints[i]), new Vector2() { X = width - AxisPointOffset, Y = yPosition }, AxisPointsColor, format);
                    }
                    else {
                        args.DrawingSession.DrawText(Convert.ToString(plottingPoints[i]), new Vector2() { X = AxisPointOffset, Y = yPosition }, AxisPointsColor, format);
                    }
                    yVal = yVal - offset;

                }
                //Draw 
                args.DrawingSession.DrawGeometry(CanvasGeometry.CreatePath(cpb), AxisPointsColor, 1);
                float xVal = width - AxisLabelOffset;
                if (!IsLeftAxis) { xVal = AxisLabelOffset; }
                args.DrawingSession.Transform *= System.Numerics.Matrix3x2.CreateRotation(-(float)Math.PI / 2, new Vector2() { X = xVal, Y = height - HeightOffset });
                args.DrawingSession.DrawText(AxisLabel, new Vector2() { X = xVal, Y = height - HeightOffset }, AxisLabelColor);

            }
            return plottingPoints.Max();

        }

        private float[] plotPoints()
        {
            //Find max value

            //Rounding maximum value to nearest number 
            Int32 numofDigits = Convert.ToInt32(Math.Ceiling(MaximumOffset) == 0 ? 1.0 : Math.Floor(Math.Log10(Math.Abs(Math.Ceiling(MaximumOffset))) + 1));

            int division = (int)Math.Pow(10.0, numofDigits);

            MaximumOffset = MaximumOffset / division;

            if (MaximumOffset < 0.1) { MaximumOffset = 0; }
            else if (MaximumOffset == 0.1f) { MaximumOffset = 0.1f; }
            else if (MaximumOffset <= 0.2f) { MaximumOffset = 0.2f; }
            else if (MaximumOffset <= 0.25f) { MaximumOffset = 0.25f; }
            else if (MaximumOffset <= 0.3f) { MaximumOffset = 0.3f; }
            else if (MaximumOffset <= 0.4f) { MaximumOffset = 0.4f; }
            else if (MaximumOffset <= 0.5f) { MaximumOffset = 0.5f; }
            else if (MaximumOffset <= 0.6f) { MaximumOffset = 0.6f; }
            else if (MaximumOffset <= 0.7f) { MaximumOffset = 0.7f; }
            else if (MaximumOffset <= 0.75f) { MaximumOffset = 0.75f; }
            else if (MaximumOffset <= 0.8f) { MaximumOffset = 0.8f; }
            else if (MaximumOffset <= 0.9f) { MaximumOffset = 0.9f; }
            else if (MaximumOffset <= 1.0f) { MaximumOffset = 1.0f; }
            MaximumOffset = MaximumOffset * division;

            float range = MaximumOffset / NumberOfIntervals;

            float[] plotingPoints = new float[NumberOfIntervals + 1];
            for (int i = 0; i <= 10; i++)
            {
                plotingPoints[i] = i * range;
            }
            return plotingPoints;

        }
    }
}