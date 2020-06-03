using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractPoint
{
    public enum PointRepresentation
    {
        Polar,
        Rectangular
    }

    public abstract class AbstractPoint
    {
        public abstract float a { get; set; }
        public abstract float b { get; set; }
        public abstract float r { get; set; }
        public abstract float A { get; set; }
        public abstract void Move(float x, float y);
        public abstract void Rotate(float angle);
        protected float aGet()
        {
            return r * (float)Math.Cos(A);
        }
        protected float bGet()
        {
            return r * (float)Math.Sin(A);
        }
        protected float rGet()
        {
            return (float)Math.Sqrt(a * a + b * b);
        }
        protected float AGet()
        {
            return (float)Math.Atan(b / a);
        }
        public override string ToString()
        {
            return $"({a}, {b}):[{r}, {A}]";
        }
    }
}
