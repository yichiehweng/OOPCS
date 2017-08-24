using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer a = new Customer("Tan Lian Hwee", "Clementi Road", "C10010");
            Customer b = new Customer("Lim Teck Gee", "Kent Ridge Road", "C10020");

            TourGuide c = new TourGuide("Koh Ghim Moh", "Dover Road", 3400);
            TourGuide d = new TourGuide("Liat Kim Ho", "West Coast Road", 2700);

            Tour t1 = new Tour("Paris", 3400, 3);
            Tour t2 = new Tour("London", 3200, 3);
            Tour t3 = new Tour("Munich", 3100, 2);
            Tour t4 = new Tour("Milan", 3500, 3);

            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Console.WriteLine(t3);
            Console.WriteLine(t4);

            TourPackage p = new TourPackage("Europe");
            p.ConsistOf(t1);
            p.ConsistOf(t2);

            Trip holiday1 = new Trip(t1, new DateTime(2015, 5, 2), 20);
            Trip holiday2 = new Trip(t1, new DateTime(2015, 6, 17), 20);
        }
    }
    class Customer
    {
        string name;
        string address;
        string id;

        public Customer(string name, string address, string id)
        {
            this.name = name;
            this.address = address;
            this.id = id;
        }

        public string Name
        {
            set
            {
                this.name = value;
            }
            get
            {
                return name;
            }
        }
        public string Address
        {
            set
            {
                this.address = value;
            }
            get
            {
                return address;
            }
        }
        public string Id
        {
            get
            {
                return id;
            }
        }
    }
    class TourGuide
    {
        string name;
        string address;
        int salary;

        public TourGuide(string name, string address, int salary)
        {
            this.name = name;
            this.address = address;
            this.salary = salary;
        }
        public string Name
        {
            set
            {
                this.name = value;
            }
            get
            {
                return name;
            }
        }
        public string Address
        {
            set
            {
                this.address = value;
            }
            get
            {
                return address;
            }
        }
        public int Salary
        {
            set
            {
                this.salary = value;
            }
            get
            {
                return salary;
            }
        }
    }
    class Tour
    {
        // A Tour object has attributes name(string), cost(int), duration(int) and places of interest to be visited(list).
        protected string name;
        protected int cost;
        protected int duration;
        List<Tour> places;
        protected double disCount;
        protected double totalCost;

        public Tour(string name, int cost, int duration)
        {
            this.name = name;
            this.cost = cost;
            this.duration = duration;
        }
        public Tour()
        {
            this.name = "";
            this.cost = 0;
            this.duration = 0;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
        public virtual double Cost
        {
            get
            {
                return cost;
            }
        }
        public virtual int Duration
        {
            get
            {
                return duration;
            }
        }

        public override string ToString()
        {
            string output = string.Format("Name of Tour:{0} Cost:{1} Duration:{2}", Name, Cost, Duration);
            return output;
        }


    }
    class TourPackage : Tour
    {
        List<Tour> tourList;        
        int totalDuration;
        public TourPackage(string name) : base()
        {
            this.name = name;
            tourList = new List<Tour>();
        }
        public override double Cost
        {
            get
            {
                disCount = 0.9;
                foreach (Tour i in tourList)
                {
                    totalCost = totalCost + i.Cost;
                }
                return totalCost * disCount;
            }

        }
        public override int Duration
        {
            get
            {
                foreach (Tour i in tourList)
                {
                    totalDuration = totalDuration + i.Duration;
                }
                return totalDuration;
            }
        }
        public void ConsistOf(Tour t)
        {
            tourList.Add(t);
        }
    }
    class Trip
    {
        Tour tour;
        DateTime date;
        int maxSize;
        List<Customer> bookingsList;
        public Trip(Tour tour, DateTime date, int maxSize)
        {
            this.tour = tour;
            this.date = date;
            this.maxSize = maxSize;
        }
        public void Book(Customer customer, int number)
        {
            if (maxSize < number)
            {
                throw new InsuffientSeatException("Booking fail! There are not enough seats.");
            }
            else{
                for (int i = 0; i < number; i++)
                {
                    bookingsList.Add(customer);
                    maxSize--;
                }
            }
           
        }
    }    
    class Booking
    {
        Customer customer;
        Trip trip;
        int number;
        public Booking(Customer customer, Trip trip, int number)
        {
            this.customer = customer;
            this.trip = trip;
            this.number = number;
        }
        public double Cost
        {
            get
            {
                double totalCost = 0;
                if (number > 5)
                {
                    double disCount = 0.95;
                   
                    totalCost = totalCost * disCount;
                }
                return totalCost;
            }
        }

    }

    public class InsuffientSeatException : ApplicationException
    {
        public InsuffientSeatException() : base()
        {
        }
        public InsuffientSeatException(string message) : base(message)
        {
        }
        public InsuffientSeatException(string message, Exception innerExc) : base(message, innerExc)
        {
        }
    }
}
