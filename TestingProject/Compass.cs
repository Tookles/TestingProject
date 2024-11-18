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

        public Point Rotate(Point InputPoint, Direction NewDirection)
        {
            int turn = NewDirection == Direction.Rightturn ? 1 : -1;
            int position = (int)InputPoint + turn; 
            if (position == 4) position = 0;
            if (position == -1) position = 3; 
            return (Point)position;
         
        }
    }
}
