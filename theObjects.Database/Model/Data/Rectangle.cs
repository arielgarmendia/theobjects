using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace theObjects.Database.Model.Data
{
    public class Rectangle
    {
        [Key]
        public Guid ID { get; set; }
        public virtual Point Position { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }
    }
}
