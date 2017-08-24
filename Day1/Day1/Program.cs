using System;

namespace Day1
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Coin c = new Coin();
            c.Flip();
            Console.WriteLine(c.GetFace());
            Console.WriteLine(c.GetFace());
            Console.WriteLine(c.GetFace());
            Console.WriteLine(c.GetFace());
            Coin d = new Coin();
            d.Flip();
            Console.WriteLine(c.GetFace());
            Console.WriteLine(c.GetFace());
            Console.WriteLine(c.GetFace());
            Console.WriteLine(c.GetFace());

            Rectangle r1 = new Rectangle();
            Console.WriteLine(r1);
            Rectangle r2 = new Rectangle();

        }
        
    }
    class Coin
    {
        int face;
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
    //Class elements:1. attributes 2. constructors 3. properties 4. methods 
    class Rectangle
    {
        //Attributes
        int length, width;
        //Constructors (no return type)
        public Rectangle()
        {
            Console.WriteLine("Constructor is called.");
            length = 1;
            width = 1;
        }
        //Constructors can be overloaded
        public Rectangle(int l, int w)
        {
            Console.WriteLine("Overloaded constructor is called.");
            length = l;
            width = w;
        }
        //Methods:Assessor/Mutator(option 1)
        public int GetLength()
        {
            return length;
        }
        public void SetLength(int i)
        {
            if (i > 0)
            {
                length = 1;
            }
            else
            {
                Console.WriteLine("Length cannot be negative.");
            }
        }
        public int GetWidth()
        {
            return width;
        }
        public void SetWidth(int w)
        {
            if (w > 0)
            {
                width = 1;
            }
            else
            {
                Console.WriteLine("Width cannot be negative.");
            }
        }
        public int GetArea()
        {
            return width * length;
        }
        public int GetPerimeter()
        {
            return 2 * width + 2 * length;
        }
        //Properties(option 2)
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        public int Area
        {
            get
            {
                return width * length;
            }

        }
        public int Perimeter
        {
            get
            {
                return 2 * width + 2 * length;
            }
        }
    }
}