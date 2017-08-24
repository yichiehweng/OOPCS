using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Workshop6
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ArrayList investmentsList = new ArrayList();
            Coin coinA = new Coin("This is a Coin.",10, 100, new DateTime(2017, 08, 15));
            investmentsList.Add(coinA);
            Gold goldA = new Gold("This is a Gold.",10000, 10000000, new DateTime(2015, 01, 01));
            investmentsList.Add(goldA);
            Antique antiqueA = new Antique("Something I don't know",1, 1000000000, new DateTime(1999, 09, 09));
            investmentsList.Add(antiqueA);
            for(int i=0;i<investmentsList.Count;i++)
            {
                Console.WriteLine(investmentsList[i]);
            }

            List<IInvestment> list = new List<IInvestment>();
            list.Add(coinA);
            list.Add(goldA);
            list.Add(antiqueA);

            double totalValue = 0;
            for (int i= 0;i < list.Count;i++)
            {                
                totalValue = totalValue + list[i].EstimatedValue;
            }
            Console.WriteLine(totalValue);

            double totalProfit = 0;
            for (int i = 0; i < list.Count; i++)
            {
                totalProfit = totalProfit + list[i].GetProfits();
            }
            Console.WriteLine(totalProfit);
            */
            Customer c = new Customer("Tan Ah Kow", "4 Short Street", 2000);
            Customer d = new Customer("Chong Ah Lian", "81 Berry Road", 1500);
            Customer e = new Customer("Goh Ah Lian", "81 Berry Road", 15000);
            
            List<Customer> list = new List<Customer>();
            list.Add(c);
            list.Add(d);
            list.Add(e);
            //list.Sort();
            foreach(Customer i in list)
            {
                Console.WriteLine(i);
            }
            int n = 65;
            int m = 231;
            Console.WriteLine(n < m);
            Console.WriteLine(c < d);
        }
    }
    public abstract class Shape
    {
        public abstract double GetArea();
        public abstract double GetParameter();
    }
    class Triangle:Shape
    {
        //1.attributes
        double s1, s2, s3;
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
        public override double GetParameter()
        {
            return s1 + s2 + s3;
        }
        public override double GetArea()
        {
            double s = (s1 + s2 + s3) / 2;
            double r = Math.Sqrt(s * (s - s1) * (s - s2) * (s - s3));
            return (r);
        }

    }
    class Rectangle:Shape
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
        public double Length
        {
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
        public override double GetArea()
        {
            return length * breadth;
        }
        public override double GetParameter()
        {
            return 2 * (length + breadth);
        }
    }
    class Circle:Shape
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
        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }
        public override double GetParameter()
        {
            return 2 * Math.PI * radius;
        }
    }

    public interface IInvestment
    {
        double Cost
        {
            set;
            get;
        }
        double EstimatedValue
        {
            set;
            get;
        }
        DateTime AcquiredDate
        {
            set;
            get;
        }
        double GetProfits();
    }
    class Coin:IInvestment
    {
        double cost;
        double estimatedValue;
        DateTime acquiredDate;
        string description;
        
        public Coin(string description, double cost, double estimatedValue, DateTime acquiredDate)
        {
            this.description = description;
            this.cost = cost;
            this.estimatedValue = estimatedValue;
            this.acquiredDate = acquiredDate;
        }

        public double Cost
        {
            set
            {
                this.cost = value;
            }
            get
            {
                return cost;
            }
        }
        public double EstimatedValue
        {
            set
            {
                this.estimatedValue = value;
            }
            get
            {
                return estimatedValue;
            }
        }
        public DateTime AcquiredDate
        {
            set
            {
                this.acquiredDate = value;
            }
            get
            {
                return acquiredDate;
            }
        }
        public override string ToString()
        {
            string output = description + "Acquired Date:" + acquiredDate.ToString();
            return output;
        }
        public double GetProfits()
        {
            return estimatedValue - cost;
        }

    }
    class Gold : IInvestment
    {
        string description;
        double cost;
        double estimatedValue;
        DateTime acquiredDate;

        public Gold(string description, double cost, double estimatedValue, DateTime acquiredDate)
        {
            this.description = description;
            this.cost = cost;
            this.estimatedValue = estimatedValue;
            this.acquiredDate = acquiredDate;
        }

        public double Cost
        {
            set
            {
                this.cost = value;
            }
            get
            {
                return cost;
            }
        }
        public double EstimatedValue
        {
            set
            {
                this.estimatedValue = value;
            }
            get
            {
                return estimatedValue;
            }
        }
        public DateTime AcquiredDate
        {
            set
            {
                this.acquiredDate = value;
            }
            get
            {
                return acquiredDate;
            }
        }
        public double GetProfits()
        {
            return estimatedValue - cost;
        }

        public override string ToString()
        {
            string output = description + "Acquired Date:" + acquiredDate.ToString();
            return output;
        }
    }
    class Antique : IInvestment
    {
        string description;
        double cost;
        double estimatedValue;
        DateTime acquiredDate;

        public Antique(string description,double cost, double estimatedValue, DateTime acquiredDate)
        {
            this.description = description;
            this.cost = cost;
            this.estimatedValue = estimatedValue;
            this.acquiredDate = acquiredDate;
        }

        public double Cost
        {
            set
            {
                this.cost = value;
            }
            get
            {
                return cost;
            }
        }
        public double EstimatedValue
        {
            set
            {
                this.estimatedValue = value;
            }
            get
            {
                return estimatedValue;
            }
        }
        public DateTime AcquiredDate
        {
            set
            {
                this.acquiredDate = value;
            }
            get
            {
                return acquiredDate;
            }
        }
        public double GetProfits()
        {
            return estimatedValue - cost;
        }
        public override string ToString()
        {
            string output = description + "Acquired Date:" + acquiredDate.ToString();
            return output;
        }

    }

    class Customer:IComparable
    {
        private string name;
        private string address;
        private double balance;

        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
        }
        public double Balance
        {
            get
            {
                return balance;
            }
        }
        public Customer(string n, string a, double b)
        {
            name = n;
            address = a;
            balance = b;
        }
        public int CompareTo(object another)
        {
            if (another is Customer)
            {
                Customer a = (Customer)another;
                return this.Name.CompareTo(a.Name);
            }
            else
            {
                return -1;
            }
            
        }
        public override string ToString()
        {
            string output = "Name: "+Name + " Address:" + address;
            return output;
        }
        public static bool operator <(Customer a, Customer b)
        {
            return (a.CompareTo(b) < 0);
        }
        public static bool operator >(Customer a, Customer b)
        {
            return (a.CompareTo(b) > 0);
        }
    }






}

