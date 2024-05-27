using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace theObjects.Database.Model.Commands
{
    public class DrawCircleCommand
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Diameter { get; set; }
    }
}
