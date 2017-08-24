using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Day3
{
    public class Coin {
        private int face;
        public Coin (int i)
        {
            face = i;
        }  
        
        public Coin()
        {
            Flip();
        }
        
        public void Flip()
        {
            Random r = new Random();
            face = r.Next(2);
        }
        public int GetFace()
        {
            return face;
        }
    }
    public class MonetaryCoin : Coin
    {
        int value;
        string country;
        public MonetaryCoin(int v, string c) :base(0)
        {
            value = v;
            country = c;
        }
        public int GetValue()
        {
            return value;
        }
        public string GetCountry()
        {
            return country;
        }
    }
    public class OrnamentCoin : Coin
    {
        string design;
        string metal;
        bool hook;
        public OrnamentCoin(string d,string m, bool h) : base(0)
        {
            design = d;
            metal = m;
            hook = h;
        }
        public string GetDesign()
        {
            return design;
        }
        public string GetMetal()
        {
            return metal;
        }
        public bool GetHook()
        {
            return hook;
        }
        public void RemoveHook()
        {
            hook = false;
        }
    }

    public class Rectangle
    {
        private int length, width;
        public Rectangle(int length, int width)
        {
            this.length = length;
            this.width = width;
        }
        protected int Length // protected Length and
        { // Width properties with
            get { return length; } // only the get accessors
        } // so that the data cannot
        protected int Width // be set.
        {
            get { return width; }
        }
        // Calculate the shape perimeter
        public int GetPerimeter()
        {
            return 2 * (length + width);
        }
        // Calculate the shape area
        public int GetArea()
        {
            return (length * width);
        }
    }
    public class Parallelogram : Rectangle
    {
        private int angle;
        public Parallelogram(int length, int width, int angle): base(length, width)
        {
            this.angle = angle;
        }
        public new int GetArea()
        {
            return (int)(base.GetArea() * Math.Sin(angle * (Math.PI / 180)));
        }
        public int GetAngle()
        {
            return angle;
        }
    }

    public class Car
    {
        public Driver theowner;
        public void SetOwner(Driver d)
        {
            theowner = d;
        }
    }
    public class Driver
    {
        public Car mycar;
        public void Buy()
        {
            mycar = new Car();
            mycar.SetOwner(this);
        }
    }

        class Program
    {
        static void Main(string[] args)
        {
            /*
            MonetaryCoin C1 = new MonetaryCoin(50, "Singapore");
            MonetaryCoin C2 = new MonetaryCoin(10, "Singapore");
            MonetaryCoin C3 = new MonetaryCoin(10, "US");
            Console.WriteLine(C2.GetCountry());
            Console.WriteLine(C2.GetValue());
            Console.WriteLine(C3.GetCountry());
            Console.WriteLine(C1.GetFace());
            Console.WriteLine(C2.GetFace());
            C2.Flip();
            Console.WriteLine(C2.GetFace());
            */
            Driver d = new Driver();
            d.Buy();
            Car a=d.mycar;
            Console.Write(a.ToString());
        }
    }
}
