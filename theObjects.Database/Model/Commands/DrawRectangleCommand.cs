using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace theObjects.Database.Model.Commands
{
    public class DrawRectangleCommand
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
    }
}
