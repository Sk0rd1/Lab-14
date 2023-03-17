using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_14
{

    internal interface ICylinder
    {
        double Radius { get; set; }
        double Height { get; set; }
        double Volume { get; }
        void PrintVolume();
    }

    class Cylinder : ICylinder
    {
        private double radius;
        public double Radius
        {
            get { return radius; }
            set { radius = value >= 0 ? value : 0; }
        }

        private double height;
        public double Height
        {
            get { return height; }
            set { height = value >= 0 ? value : 0; }
        }

        public Cylinder()
        {
            this.Radius = 0;
            this.Height = 0;
        }

        public Cylinder(double radius, double height)
        {
            this.Radius = radius;
            this.Height = height;
        }


        public double Volume
        {
            get { return Math.PI * Math.Pow(Radius, 2) * Height; }
        }

        public void PrintVolume()
        {
            Console.WriteLine($"Cylinder with radius {Radius} and height {Height} has volume {Volume:F2}");
        }
    }

    class CylinderArray
    {
        private ICylinder[] cylinders;

        public CylinderArray(int count)
        {
            cylinders = new ICylinder[count];
            for (int i = 0; i < count; i++)
            {
                cylinders[i] = new Cylinder(i + 6, 8 - i);
            }
        }

        public void Print()
        {
            for (int i = 0; i < cylinders.Length; i++)
            {
                Console.Write($"Cylinder {i + 1}: ");
                cylinders[i].PrintVolume();
            }
        }

        public void SortByVolume()
        {
            Array.Sort(cylinders, new CylinderComparerByVolume());
        }

        private class CylinderComparerByVolume : IComparer<ICylinder>
        {
            public int Compare(ICylinder c1, ICylinder c2)
            {
                return c1.Volume.CompareTo(c2.Volume);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 5;
            CylinderArray array = new CylinderArray(count);

            Console.WriteLine("Initial array:");
            array.Print();

            Console.WriteLine("Sorting by volume:");
            array.SortByVolume();
            array.Print();
            Console.Read();
        }
    }
}
