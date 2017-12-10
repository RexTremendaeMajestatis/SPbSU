﻿namespace Task4.Model
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using Task4.View;

    public sealed class Line 
    {
        private Pen pen = new Pen(Color.Black);
        private Pen selectionPen = new Pen(Color.Red, 3);
        private Point firstPoint;
        private Point secondPoint;

        public Line(Point firstPoint, Point secondPoint, LineBuilder builder)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
            this.Builder = builder;
            this.Selected = false;
            this.Visible = true;
        }

        public bool Selected { get; set; }

        public bool Visible { get; set; }

        public LineBuilder Builder { get; set; }

        public Point InitPoint { get; set; }

        public Point SelectedPoint { get; set; }

        public void Draw(PaintEventArgs e)
        {
            if (this.Visible)
            {
                e.Graphics.DrawLine(this.pen, this.firstPoint, this.secondPoint);
                if (this.Selected)
                {
                    this.DrawSelection(e);
                }
            }
        }

        public bool Contain(Point point)
        {
            if (this.Distance(point) <= 15)
            {
                this.Selected = true;

                return true;
            }

            return false;
        }

        private double Distance(Point point)
        {
            var vectorA = new Vector(this.firstPoint, point);
            var vectorB = new Vector(this.firstPoint, this.secondPoint);

            if (Vector.ScalarMultiply(vectorA, vectorB) < 0.0)
            {
                this.SelectedPoint = this.firstPoint;
                this.InitPoint = this.secondPoint;

                return vectorA.Length;
            }
            else
            {
                var vectorC = new Vector(this.secondPoint, point);
                var vectorD = (-1) * vectorB;

                if (Vector.ScalarMultiply(vectorC, vectorD) < 0.0)
                {
                    this.SelectedPoint = this.secondPoint;
                    this.InitPoint = this.firstPoint;

                    return vectorC.Length;
                }
                else
                {
                    this.SelectedPoint = default(Point);
                    this.InitPoint = default(Point);

                    double cosAlpha = Vector.ScalarMultiply(vectorC, vectorD) / vectorC.Length * vectorD.Length;
                    double sinAlpha = Math.Sqrt(1 - (cosAlpha * cosAlpha));

                    return sinAlpha * vectorC.Length;
                }
            }
        }

        private void DrawSelection(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(this.selectionPen, new Rectangle(this.firstPoint.X - 2, this.firstPoint.Y - 2, 4, 4));
            e.Graphics.DrawEllipse(this.selectionPen, new Rectangle(this.secondPoint.X - 2, this.secondPoint.Y - 2, 4, 4));
            e.Graphics.DrawLine(this.selectionPen, this.firstPoint, this.secondPoint);
        }
    }
}
