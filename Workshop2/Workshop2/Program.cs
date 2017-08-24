using System;

namespace Workshop2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("*****Coin*****");
            Coin coinA=new Coin();
            string strFace = coinA.StrFace;
            Console.WriteLine(strFace);           
            coinA.Flip();
            strFace = coinA.StrFace;
            Console.WriteLine(strFace);
            
            Console.WriteLine("*****Triangle*****");
            Triangle triangleA = new Triangle(3, 4, 5);
            Console.WriteLine(triangleA.Side1);
            Console.WriteLine(triangleA.Side2);
            Console.WriteLine(triangleA.Side3);
            Console.WriteLine(triangleA.GetParameter());
            Console.WriteLine(triangleA.GetArea());
            
            Console.WriteLine("*****Rectangle*****");
            Rectangle rectangleA = new Rectangle(5,10);
            Console.WriteLine(rectangleA.Length);
            Console.WriteLine(rectangleA.Breadth);
            Console.WriteLine(rectangleA.GetParameter());
            Console.WriteLine(rectangleA.GetArea());
            
            Console.WriteLine("*****Circle*****");
            Circle circleA = new Circle(3.0);
            Console.WriteLine(circleA.Radius);
            Console.WriteLine(circleA.GetArea());
            Console.WriteLine(circleA.GetParameter());
            
            Console.WriteLine("*****Dice*****");
            Dice diceA = new Dice();
            diceA.Throw(); Console.WriteLine(diceA.StrFaceUp);
            diceA.Throw(); Console.WriteLine(diceA.StrFaceUp);
            diceA.Throw(); Console.WriteLine(diceA.StrFaceUp);
            */
        }
    }
    //Class elements:1. attributes 2. constructors 3. properties 4. methods
    public class Coin
    {
        // Attributes
        private int face;
        Random r = new Random();
        // Constructors
        public Coin()
        {
            face=Flip();
        }
        // Properties
        public string StrFace
        {
            get
            {
                if (GetFace() == 0) return "HEAD";
                else return "TAIL";
            }
        }
        // Methods
        public int GetFace()
        {
            return face;
        }

        public int Flip()
        {          
            return r.Next(2);
        }       
    }
    class Triangle
    {
        //1.attributes
        double s1,s2,s3;
        //2. constructors
        public Triangle(double s1, double s2, double s3)
        {
            if (s1 < 0.0 || s2 < 0.0 || s3 < 0.0)
            {
                Console.WriteLine("Error input!"); return;

            }
            else if (s1 + s2 <= s3 || s1 + s3 <= s2 || s2 + s3 <= s1)
            {
                Console.WriteLine("Error!The triangle cannot be created."); return;
            }
            else
            {
                this.s1 = s1;
                this.s2 = s2;
                this.s3 = s3;
            }

        }
        //3. properties
        public double Side1
        {
            get
            {
                return s1;
            }
        }
        public double Side2
        {
            get
            {
                return s2;
            }
        }
        public double Side3
        {
            get
            {
                return s3;
            }
        }
        //4. methods
        public double GetParameter()
        {
            return s1 + s2 + s3;
        }
        public double GetArea()
        {
            double s = (s1 + s2 + s3) / 2;
            double r = Math.Sqrt(s * (s - s1) * (s - s2) * (s - s3));
            return (r);
        }

    }
    class Rectangle
    {
        //1. attributes
        double length, breadth;
        //2. constructors
        public Rectangle(double length, double breadth)
        {
            if (length <= 0 || breadth <= 0)
            {
                Console.WriteLine("Error input!!!");
            }
            else
            {
                this.length = length;
                this.breadth = breadth;
            }

        }
        //3. properties
        public double Length{
            get
            {
                return length;
            }
        }
        public double Breadth
        {
            get
            {
                return breadth;
            }
        }
        //4. methods
        public double GetArea()
        {
            return length * breadth;
        }
        public double GetParameter()
        {
            return 2 * (length + breadth);
        }
    }
    class Circle
    {
        //1. attributes
        double radius;
        //2. constructors
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                Console.WriteLine("Error input!!!");
            }
            else
            {
                this.radius = radius;
            }
        }
        //3. properties
        public double Radius
        {
            get
            {
                return radius;
            }
        }
        //4.methods
        public double GetArea()
        {
            return Math.PI * radius * radius;
        }
        public double GetParameter()
        {
            return 2 * Math.PI * radius;
        }
    }
    class Dice
    {
        //1. attributes
        int face;
        Random r = new Random();
        //2. constructors
        public Dice()
        {
            Throw();
        }
        //3. properties
        public string StrFaceUp
        {
            get
            {
                if (GetFace() == 1) return "1";
                else if (GetFace() == 2) return "2";
                else if (GetFace() == 3) return "3";
                else if (GetFace() == 4) return "4";
                else if (GetFace() == 5) return "5";
                else if (GetFace() == 6) return "6";
                else return "??";
            }
        }       
        //4. methods
        public void Throw()
        {          
            face = r.Next(6) + 1;
        }
        public int GetFace()
        {
            return face;
        }
    }
}