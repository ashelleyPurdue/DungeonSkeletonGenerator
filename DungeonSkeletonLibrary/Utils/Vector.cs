using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonSkeletonLibrary.Utils
{
    public struct Vector
    {
        //Constants
        public static readonly Vector zero  = new Vector(0, 0, 0);
        public static readonly Vector left  = new Vector(-1, 0, 0);
        public static readonly Vector right = new Vector(1, 0, 0);
        public static readonly Vector up    = new Vector(0, 1, 0);
        public static readonly Vector down  = new Vector(0, -1, 0);
        

        //---

        public double x;
        public double y;
        public double z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return a + (b * -1);
        }

        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.x * b, a.y * b, a.z * b);
        }

        public static Vector operator /(Vector a, double b)
        {
            return a * (1.0 / b);
        }
    }
}
