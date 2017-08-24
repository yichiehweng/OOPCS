using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rational;

namespace Workshop3
{
    class Program
    {
        static void Main(string[] args)
        {
            


            /*
            BankAccount accountA = new BankAccount("001","AAA");
            BankAccount accountB = new BankAccount("002", "BBB");
            accountA.Deposit(3000.00);
            accountA.Withdraw(100.00);      
            accountA.TransferTo(500.00, accountB);
            accountA.ShowBalance();
            accountB.ShowBalance();
            */

            Rational.Rational a = new Rational.Rational(3, 4);
            Rational.Rational b = new Rational.Rational(4, 5);
            Rational.Rational c = a.Add(b);
            Console.WriteLine(c.StrVal());
            c = b.Subtract(a);
            Console.WriteLine(c.StrVal());

        }
    }
    class BankAccount
    {
        //1.Attributes
        string accountNumber, accountHolderName;
        double balance = 0.0;
        //2.Constructors
        public BankAccount(string accountNumber, string accountHolderName)
        {
            this.accountNumber = accountNumber;
            this.accountHolderName = accountHolderName;
        }
        //3.Properties
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public string AccountHolderName
        {
            get
            {
                return accountHolderName;
            }
        }
        //4.Methods
        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("Cannot withdraw the value greater than balance");
            }
            else
            {
                balance = balance - amount;
                Console.WriteLine("Withdraw ${0} dollars",amount);
            }
        }
        public void Deposit(double amount)
        {
            balance = balance + amount;
            Console.WriteLine("Deposit ${0} dollars", amount);
        }
        public void ShowBalance()
        {
            Console.WriteLine("Your balance would be ${0} dollars", balance);
        }
        public void TransferTo(double amount, BankAccount another)
        {
            if (amount > balance)
            {
                Console.WriteLine("Cannot transfer the amount greater than balance");
            }
            else
            {
                balance = balance - amount;
                another.balance = another.balance + amount;
                Console.WriteLine("Transfer ${0} dollars to {1}'account:{2}", amount,another.AccountHolderName,another.AccountNumber);
            }
        }
    }
    class Customer
    {
        //1.Attributes
        string name, address, passportNumber;
        DateTime dateOfBirth;
        //2.Constructors
        public Customer(string name, string address,string passportNumber,DateTime dateOfBirth)
        {
            this.name = name;
            this.address = address;
            this.passportNumber = passportNumber;
            this.dateOfBirth = dateOfBirth;
        }
        //3.Properies
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Address
        {
            set
            {
                this.Address = address;
            }
            get
            {
                return address;
            }
        }
        public string PassportNumber
        {
            get
            {
                return passportNumber;
            }
        }
        public DateTime DateOdBirth
        {
            get
            {
                return dateOfBirth;
            }
        }
        //4.Methods
        public double GetAge()
        {
            DateTime currentDate = DateTime.Today;
            int AgeDays = (currentDate - dateOfBirth).Days;
            double age = AgeDays / 365;
            return age;
            
        }
    }
    class BankAccount2
    {
        //1.Attributes
        string accountNumber; 
        Customer accountHolderName;
        double balance = 0.0;
        //2.Constructors
        public BankAccount2(string accountNumber, Customer accountHolderName)
        {
            this.accountNumber = accountNumber;
            this.accountHolderName = accountHolderName;
        }
        //3.Properties
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public string AccountHolderName
        {
            get
            {
                return accountHolderName.Name;
            }
        }
        //4.Methods
        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("Cannot withdraw the value greater than balance");
            }
            else
            {
                balance = balance - amount;
                Console.WriteLine("Withdraw ${0} dollars", amount);
            }
        }
        public void Deposit(double amount)
        {
            balance = balance + amount;
            Console.WriteLine("Deposit ${0} dollars", amount);
        }
        public void ShowBalance()
        {
            Console.WriteLine("Your balance would be ${0} dollars", balance);
        }
        public void TransferTo(double amount, BankAccount another)
        {
            if (amount > balance)
            {
                Console.WriteLine("Cannot transfer the amount greater than balance");
            }
            else
            {
                balance = balance - amount;
                another.Deposit(amount);
                Console.WriteLine("Transfer ${0} dollars to {1}'account:{2}", amount, another.AccountHolderName, another.AccountNumber);
            }
        }
    }
}
