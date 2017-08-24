using System;
using MyLibrary;

namespace Day2
{
    class Program
    {
        //Access Modifiers
        //private: Access is limited only to the containing class
        //protected internal: Access is limited to the current project or types derived from the containing class
        //internal: internal Access is limited to the current project or assembly
        //protected: Access is limited to the containing class or types derived from the containing class
        //public (default): Access is not restricted
        class Rectangle
        {
            // attributes
            int length, width;
            int positionX, positionY;// retangle created in paricular position
            // constructor
            public Rectangle()
            {
                Console.WriteLine("Constructor is called");
                length = 1;
                width = 1;
                positionX = 0;
                positionY = 0;
            }
            public Rectangle(int l, int w)
            {
                Console.WriteLine("Overloaded Constructor is called");
                length = l;
                width = w;
            }
            public Rectangle(int l, int w, int x,int y)
            {
                Console.WriteLine("Overloaded Constructor is called");
                length = l;
                width = w;
                positionX = x;
                positionY = y;
            }

            // methods
            public int GetLength()
            {
                return length;
            }
            public void SetLength(int l)
            {
                if (l > 0)
                    length = l;
                else
                    Console.WriteLine("Length cannot be negative");
            }
            public int GetWidth()
            {
                return width;
            }
            public void SetWidth(int l)
            {
                if (l > 0)
                    width = l;
                else
                    Console.WriteLine("Width cannot be negative");
            }
            public int Area
            {
                get
                {
                    return Length * Width;
                }
            }
            public int GetPerimeter()
            {
                return 2 * (Length + Width);
            }

            // properties
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
            public int PositionX // read only
            {
                get
                {
                    return positionX;
                }
            }
        }
        //Constructor Initialiser:inheritance
        class MyClass
        {
            private int x, y, z;
            public MyClass(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public MyClass(int x, int y, int z) : this(x, y)
            {
                this.z = z;
            }
        }

        static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            r.SetLength(5);
            r.SetWidth(7);

            Rectangle r2 = new Rectangle(3, 8);
            Console.WriteLine(r.Area);
            Console.WriteLine(r2.Area);

            Rectangle r3 = new Rectangle(3, 8,2,2);
            Console.WriteLine(r3.Area);

           Abc a0 = new Abc();
           a0.ToDo();

            

        }
    }
}