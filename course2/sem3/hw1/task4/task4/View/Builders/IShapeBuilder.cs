﻿namespace Task4
{
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Interface for builder
    /// </summary>
    public interface IShapeBuilder
    {
        /// <summary>
        /// Sets start point
        /// </summary>
        void Init(Point point);

        /// <summary>
        /// Sets second point for drawing
        /// </summary>
        void Drag(Point point);

        /// <summary>
        /// Draws shape by two points
        /// </summary>
        void Draw(PaintEventArgs e);

        /// <summary>
        /// Returns created shape
        /// </summary>
        Line GetProduct();
    }
}
