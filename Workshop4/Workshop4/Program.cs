using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop4
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date1 = new DateTime(2008, 8, 29, 19, 27, 15);
            Customer cus1 = new Customer("Tan Ah Kow", "2 Rich Street",
                                      "P123123", date1);
            Customer cus2 = new Customer("Kim May Mee", "89 Gold Road",
                                      "P334412", date1);

            SavingsAccount a1 = new SavingsAccount("S0000223", cus1);
            a1.Deposit(1000);
            a1.Withdraw(100);
            Console.WriteLine(a1.CalculateInterest());
        }
    }
    class Customer
    {
        //1.Attributes
        string name, address, passportNumber;
        DateTime dateOfBirth;
        //2.Constructors
        public Customer(string name, string address, string passportNumber, DateTime dateOfBirth)
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
    class BankAccount3
    {
        //1.Attributes
        string accountNumber;
        Customer accountHolderName;
        protected double balance = 0.0;
        //2.Constructors
        public BankAccount3(string accountNumber, Customer accountHolderName)
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
        public void TransferTo(double amount, BankAccount3 another)
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
        public virtual double CalculateInterest()
        {
            return 0;
        }

        public void CreditInterest()
        {
            Deposit(CalculateInterest());
        }

    }
    class SavingsAccount :BankAccount3
    {
        public SavingsAccount(string accountNumber, Customer accountHolderName) : base(accountNumber, accountHolderName)
        {
            if (balance < 0)
            {
                Console.WriteLine("Balance can not be negative!");return;
            }
        }
        public override double CalculateInterest()
        {
            return (balance * 1 / 100);
        }
    }
    class CurrentAccount : BankAccount3
    {
        public CurrentAccount(string accountNumber, Customer accountHolderName) : base(accountNumber, accountHolderName)
        {
            if (balance < 0)
            {
                Console.WriteLine("Balance can not be negative!"); return;
            }
        }
        public override double CalculateInterest()
        {
            return (balance * 0.25 / 100);
        }
    }
    class OverDraftAccount: BankAccount3
    {
        public OverDraftAccount(string accountNumber, Customer accountHolderName) : base(accountNumber, accountHolderName)
        {
            
        }
        public override double CalculateInterest()
        {
            if(balance >= 0)
            {
                return (balance * 0.25 / 100);
            }
            else
            {
                return (-(balance * 6 / 100));
            }
        }
        public new void Withdraw(double amount)
        {          
                balance = balance - amount;
                Console.WriteLine("Withdraw ${0} dollars", amount);
        }
        public new void TransferTo(double amount, BankAccount3 another)
        {           
                balance = balance - amount;
                another.Deposit(amount);
                Console.WriteLine("Transfer ${0} dollars to {1}'account:{2}", amount, another.AccountHolderName, another.AccountNumber);
        }

    }

}
