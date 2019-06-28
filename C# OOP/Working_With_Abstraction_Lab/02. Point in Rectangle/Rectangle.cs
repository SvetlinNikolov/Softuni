using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Point_in_Rectangle
{
    public class Rectangle
    {
        public Point PointX { get; set; }
        public Point PointY { get; set; }
        public Rectangle(Point pointX, Point pointY)
        {
            this.PointX = pointX;
            this.PointY = pointY;
        }

        public bool Contains(Point pointToCompare)
        {
            if (pointToCompare.x >= this.PointX.x
                && pointToCompare.y >= this.PointX.y
                && pointToCompare.x <= this.PointY.x
                && pointToCompare.y <= this.PointY.y)
            {
                return true;
            }
            return false;
        }
    }
}
