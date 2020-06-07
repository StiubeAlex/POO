using System;
namespace Form_2D
{
    public interface Form
    {
        string Forma { get; }
        float Arie();
        float Perimetru();
    }
    public class Cerc : Form
    {
        public string Forma => "Cerc";
        public float radius;
        public Cerc(float radius) { this.radius = radius; }
        public float Arie() { return (float)Math.PI * radius * radius; }
        public float Perimetru() { return 2f * (float)Math.PI * radius; }
    }
    public class Patrat : Form
    {
        public string Forma => "Patrat";
        public float length;
        public Patrat(float length) { this.length = length; }
        public float Arie() { return length * length; }
        public float Perimetru() { return 4f * length; }
    }
}