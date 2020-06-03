using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractPoint
{
    public class Point : AbstractPoint
    {
        private float aa;
        private float bb;
        private float rr;
        private float AA;
        public override float a
        {
            get { return aa; }
            set { aa = value; rr = rGet(); AA = AGet(); }
        }
        public override float b
        {
            get { return bb; }
            set { bb = value; rr = rGet(); AA = AGet(); }
        }
        public override float r
        {
            get { return rr; }
            set { rr = value; aa = aGet(); bb = bGet(); }
        }
        public override float A
        {
            get { return AA; }
            set { AA = value; aa = aGet(); bb = bGet(); }
        }
        public Point(PointRepresentation pr, float ar, float bA)
        {
            if (pr == PointRepresentation.Polar)
            {
                rr = ar;
                AA = bA;
                aa = aGet();
                bb = bGet();
            }
            if (pr == PointRepresentation.Rectangular)
            {
                aa = ar;
                bb = bA;
                rr = rGet();
                AA = AGet();
            }
        }
        public override void Move(float x, float y)
        {
            aa += x;
            bb += y;
            rr = rGet();
            AA = AGet();
        }
        public override void Rotate(float angle)
        {
            AA += angle;
            aa = aGet();
            bb = bGet();
        }
    }
}