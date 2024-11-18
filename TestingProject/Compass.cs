using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject
{
    internal class Compass
    {
        public Point Point { get; set; }

        public Point Rotate(Point NewPoint, Direction NewDirection)
        {
            return Point.South; 
        }
    }
}
