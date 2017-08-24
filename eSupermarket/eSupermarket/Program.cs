using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSupermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Product productA = new Product("00001", "Apple", 0.5);            
            Product productB = new Product("00002", "Bag", 2.0);
            Product productC = new Product("00003", "Carpet", 20.0);
            Product productD = new Product("00004", "Donunt", 3.0);
            Product productE = new Product("00005", "Eggs", 1.0);
            Product productF = new Product("00005", "Fish", 4.0);
            Product.ShowProductList();

            Customer customerA = new Customer("Kevin", "1234567", true);
            OrderList orderA = new OrderList(customerA);
            orderA.Add(productA,5);
            orderA.Add(productC,1);
            orderA.ShowOrderList();
            Console.WriteLine(orderA.GetTotalPrice());

            Customer customerB = new Customer("Ben", "1234567", false);
            OrderList orderB = new OrderList(customerA);
            orderB.Add(productB, 1);
            orderB.Add(productD, 10);
            orderB.Add(productE, 2);
            orderB.Add(productE, 1);
            orderB.ShowOrderList();
            Console.WriteLine(orderB.GetTotalPrice());
        }
    }
    class Product
    {
        //Attributes
        string code;
        string item;
        double price;
        static List<Product> productList = new List<Product>();
        //Constructors
        public Product()
        {
            this.code = "";
            this.item = "";
            this.price = 0;
            productList.Add(this);
        }
        public Product(string code, string item, double price)
        {
            this.code = code;
            this.item = item;
            this.price = price;
            productList.Add(this);
        }
        //Properties
        public string Code
        {
            get
            {
                return code;
            }
        }
        public string Item
        {
            get
            {
                return item;
            }
        }
        public double Price
        {
            set
            {
                this.price = value;
            }
            get
            {
                return price;
            }
        }
        //Methods
        public override string ToString()
        {
            string m = string.Format("Code:{0},Item:{1},Price:{2}", Code, Item, Price);
            return m;
        }
        static public void ShowProductList()
        {
            Console.WriteLine("Product List:");
            foreach (Product i in productList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-------------");
        }
    }   
    class Customer
    {
        //Atributes
        string name;
        string telNumber;
        bool isMember;
        //Constructor
        public Customer(string name, string telNumber,bool isMember)
        {
            this.name = name;
            this.telNumber = telNumber;
            this.isMember = isMember;
        }
        //Properties
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string TelNumber
        {
            get
            {
                return telNumber;
            }
        }
        public bool IsMember
        {
            set
            {
                isMember = value;
            }
            get
            {
                return isMember;
            }
        }
        //Methods
        public override string ToString()
        {
            string m = string.Format("Name:{0},Telnember:{1},Member{2}",name,telNumber,isMember);
            return base.ToString();
        }
    }
    class OrderList
    {
        //Attributes
        private List<Product> orderList;
        private Customer customer;
        private double totalPrice;
        private static  double discount=1;
        //Constructor
        public OrderList(Customer customer)
        {
            this.customer = customer;
            orderList = new List<Product>();
        }
        //Properties
        public Customer Customer
        {
            get
            {
                return customer;
            }
        }
        public List<Product> ProductList
        {
            get
            {
                return orderList;
            }
        }
        //Methods
        public void Add(Product product, int number)
        {
            for (int i = 0; i < number; i++)
            {
                orderList.Add(product);
            }

        }
        public void ShowOrderList()
        {
            Console.WriteLine("Order List:");
            foreach (Product i in orderList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-----------");
        }
        public double GetTotalPrice()
        {

            if (customer.IsMember)
            {
                discount = 0.95;
            }
            foreach (Product i in orderList)
            {
                totalPrice = totalPrice + i.Price;
            }
            
            return totalPrice*discount;
        }

    }
}
