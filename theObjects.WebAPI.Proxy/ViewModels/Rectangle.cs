using System;
using System.Collections.Generic;
using System.Text;

namespace theObjects.WebAPI.Proxy.ViewModels
{
    public class Rectangle : Shape
    {
        public Point Position { get; set; }
        public double Width { get; set; } = 0;
        public double Length { get; set; } = 0;
        public Rectangle() : base() { }
        public Rectangle(int X, int Y, double Width, double Length) : base()
        {
            this.Length = Length;
            this.Width = Width;

            this.Position = new Point(X, Y);
            this.Position.X = X;
            this.Position.Y = Y;
        }
    }
}
