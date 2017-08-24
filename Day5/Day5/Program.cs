using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Day5
{
    class Program
    {
        static void Print(int[] a)
        {
            for(int i=0; i < a.Length; i++)
            {
                Console.Write("{0},",a[i]);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //1. Tostring(): Virtual methods in Object class. Allow to overwride.
            //2. Abstract methods: methods not yet have implementation
            //3. Abstract class: class contain at least one abstract method
            //4. Abstract properties: for computed properties 
            //5. Interface: class only has abstract methods
            //              allow multiple parents 
            //              name: start from I...
            //              connot contain any attribute. Contain abstract methods and abstract propertes
            //6. Sort
            int[] group1 = new int[] { 45, 4, 1, 20, 15 };
            Array.Sort(group1);
            Print(group1);
            string[] group2= new string[] { "aaa", "bbb", "ccc" };
            Array.Sort(group2);
            //Print(group2);
            Person[] group3 = new Person[] { new Person("Angle"), new Person("Ben"), new Person("Carl") };
            Array.Sort(group3);
            //7.List<T>: From System.Collections.Generic
            //           can limit the type of list(more convience)
            List<Person> a = new List<Person>();
            for(int i = 0; i < group3.Length; i++)
            {
                a.Add(group3[i]);
            }
            for (int i = 0; i < a.Count; i++)
            {
                Person cus = a[i];
            }

        }
    }
    class Person:Object,IComparable
    {
        string name;
        public Person(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return name;
        }
        
        public int CompareTo(object obj)// implement interface IComparable
        {
            if(obj is Person)
            {
                Person a = (Person)obj;
                return this.name.CompareTo(a.name);
            }
            else
            {
                return 0;
            }
            
        }
    }

    public abstract class Account
    {
        // Attributes
        private string accountNumber;
        private Customer accountHolder;
        private double balance;
       
        // Constructor
        public Account(string number, Customer holder, double bal)
        {
            accountNumber = number;
            accountHolder = holder;
            balance = bal;
        }

        public Account()
            : this("000-000-000", new Customer(), 0)
        {
        }

        // Properties
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public Customer AccountHolder
        {
            get
            {
                return accountHolder;
            }
            set
            {
                accountHolder = value;
            }
        }
        public double Balance
        {
            get
            {
                return balance;
            }
            protected set
            {
                balance = value;
            }
        }

        // Methods

        public void Deposit(double amount)
        {
            balance = balance + amount;
        }

        public virtual bool Withdraw(double amount)
        {
            balance = balance - amount;
            return (true);
        }

        public bool TransferTo(double amount, Account another)
        {
            if (Withdraw(amount))
            {
                another.Deposit(amount);
                return (true);
            }
            else
            {
                Console.WriteLine("Cannot transfer");
                return (false);
            }

        }

        public abstract double CalculateInterest();
        

        public void CreditInterest()
        {
            Deposit(CalculateInterest());
        }

        public override string ToString()
        {
            string m = String.Format("[BankAccount:accountNumber={0},accountHolder={1},balance={2}]",
                AccountNumber, AccountHolder.ToString(), Balance);
            return (m);
        }
    }

    public class SavingsAccount : Account
    {
        private static double interestRate = 1;
        public SavingsAccount(string number, Customer holder, double bal)
            : base(number, holder, bal)
        {
        }

        public override double CalculateInterest()
        {
            return (Balance * interestRate / 100);
        }

        public override bool Withdraw(double amount)
        {
            if (amount < Balance)
                return (base.Withdraw(amount));
            else
            {
                Console.WriteLine("Cannot withdraw");
                return (false);
            }
        }

        public override string ToString()
        {
            string m = String.Format("[SavingsAccount:accountNumber={0},accountHolder={1},balance={2}]",
                AccountNumber, AccountHolder, Balance);
            return (m);
        }
    }

    public class CurrentAccount : Account
    {
        private static double interestRate = 0.25;

        public CurrentAccount(string number, Customer holder, double bal)
            : base(number, holder, bal)
        {
        }

        public override double CalculateInterest()
        {
            return (Balance * interestRate / 100);
        }

        public override bool Withdraw(double amount)
        {
            if (amount < Balance)
                return (base.Withdraw(amount));
            else
            {
                Console.WriteLine("Cannot withdraw");
                return (false);
            }
        }

        public override string ToString()
        {
            string m = String.Format("[CurrentAccount:accountNumber={0},accountHolder={1},balance={2}]",
                AccountNumber, AccountHolder.ToString(), Balance);
            return (m);
        }
    }

    public class OverdraftAccount : Account
    {
        private static double interestRate = 0.25;
        private static double overdraftInterest = 6;

        public OverdraftAccount(string number, Customer holder, double bal)
            : base(number, holder, bal)
        {
        }

        public override double CalculateInterest()
        {
            return ((Balance > 0) ?
                    (Balance * interestRate / 100) :
                    (Balance * overdraftInterest / 100));
        }

        public override string ToString()
        {
            string m = String.Format("[OverdraftAccount:accountNumber={0},accountHolder={1},balance={2}]",
                AccountNumber, AccountHolder.ToString(), Balance);
            return (m);
        }
    }

    public class Customer
    {
        // Attributes
        private string name;
        private string address;
        private string passport;
        private int age;

        // Constructor
        public Customer(string name, string address, string passport, int age)
        {
            this.name = name;
            this.address = address;
            this.passport = passport;
            this.age = age;
        }

        public Customer(string name)
            : this(name, "ThisAddress", "ThisPassport", 0)
        {
        }

        public Customer()
            : this("ThisName", "ThisAddress", "ThisPassport", 0)
        {
        }

        // Properties
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
            set
            {
                address = value;
            }
        }
        public string Passport
        {
            get
            {
                return passport;
            }
            set
            {
                passport = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        // Methods

        public void GrowOld()
        {
            age = age + 1;
        }

        public override string ToString()
        {
            string m = String.Format("[Customer:name={0},address={1},passport={2},age={3}]",
                Name, Address, Passport, Age);
            return (m);
        }
    }

    class BankBranch
    {
        private string name;
        private string manager;
        private ArrayList accounts;

        public string Name
        {
            get { return name; }
        }

        public string Manager
        {
            get { return manager; }
        }

        public BankBranch(string n, string m)
        {
            name = n;
            manager = m;
            accounts = new ArrayList();
        }

        public void AddAccount(Account a)
        {
            accounts.Add(a);
        }

        public void PrintAccounts()
        {
            for (int i = 0; i < accounts.Count; i++)
                Console.WriteLine(accounts[i]);
        }

        public void PrintCustomers()
        {
            ArrayList cust = new ArrayList();
            for (int i = 0; i < accounts.Count; i++)
            {
                Account a = (Account)accounts[i];
                Customer t = a.AccountHolder;
                int c = cust.IndexOf(t);
                if (c < 0)
                    cust.Add(t);
            }
            for (int i = 0; i < cust.Count; i++)
                Console.WriteLine(cust[i]);
        }

        public void CreditInterest()
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                Account a = (Account)accounts[i];
                a.CreditInterest();
            }
        }

        public double TotalDeposits()
        {
            double total = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                Account a = (Account)accounts[i];
                double bal = a.Balance;
                if (bal > 0)
                    total += bal;
            }
            return (total);
        }

        public double TotalInterestPaid()
        {
            double total = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                Account a = (Account)accounts[i];
                double intr = a.CalculateInterest();
                if (intr > 0)
                    total += intr;
            }
            return (total);
        }

        public double TotalInterestEarned()
        {
            double total = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                Account a = (Account)accounts[i];
                double intr = a.CalculateInterest();
                if (intr < 0)
                    total += (-intr);
            }
            return (total);
        }
    }

    
}
