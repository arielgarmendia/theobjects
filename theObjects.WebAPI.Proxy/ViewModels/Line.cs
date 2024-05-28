using System;
using System.Collections.Generic;
using System.Text;

namespace theObjects.WebAPI.Proxy.ViewModels
{
    public class Line : Shape
    {
        public Point StartPosition { get; set; }
        public Point EndPosition { get; set; }
        public Line() : base() { }
        public Line(Point StartPosition, Point EndPosition) : base()
        { 
            this.StartPosition = StartPosition;
            this.StartPosition = StartPosition;
        }
    }
}
