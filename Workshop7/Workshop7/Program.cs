using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop7
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            try
            {
                Triangle r = new Triangle(3, 4, 8);
                Console.WriteLine(r.GetParameter());
                Console.WriteLine(r.GetArea());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }                       
            finally
            {
                Console.WriteLine("End");
            }
            */
            Customer cus1 = new Customer("Tan Ah Kow", "2 Rich Street",
                                      "P345123", new DateTime(1990,01,01));
            Customer cus2 = new Customer("Lee Tee Kim", "88 Fatt Road",
                                      "P678678", new DateTime(1975, 03, 07));
            Customer cus3 = new Customer("Alex Gold", "91 Dream Cove",
                                      "P333221", new DateTime(1983, 07, 07));
            BankAccount3 b1 = new SavingsAccount("S1230123", cus1);
            BankAccount3 b2 = new OverDraftAccount("O1230124", cus1);
            BankAccount3 b3 = new CurrentAccount("C1230125", cus2);
            BankAccount3 b4 = new OverDraftAccount("O1230126", cus3);
            try
            {
                b1.Deposit(3000);
                b1.TransferTo(4000, b1);
                Console.WriteLine(b1.Balance);
            }catch(BalanceException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("End");
            }
            

        }
    }

    class Triangle
    {
        //1.attributes
        double s1, s2, s3;
        //2. constructors
        public Triangle(double s1, double s2, double s3)
        {
            if (s1 < 0.0 || s2 < 0.0 || s3 < 0.0)
            {
                throw new NegativeInputException("Input cannot be negative!");
            }
            else if (s1 + s2 <= s3 || s1 + s3 <= s2 || s2 + s3 <= s1)
            {
                throw new FormatException("Error!The triangle cannot be created.");
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
    
    class Customer
    {
        //1.Attributes
        string name, address, passportNumber;
        DateTime dateOfBirth;
        List<BankAccount3> accounts = new List<BankAccount3>();
        int numberOfAccounts = 0;

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
        public override string ToString()
        {
            string m = String.Format("[Customer:name={0},address={1},passport={2},age={3}]", Name, Address, PassportNumber, GetAge());
            return (m);
        }
        public void AddAccount(BankAccount3 a)
        {
            accounts.Add(a);
            numberOfAccounts++;
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
            accountHolderName.AddAccount(this);
        }
        //3.Properties
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public Customer AccountHolderName
        {
            get
            {
                return accountHolderName;
            }
        }
        public double Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }
        //4.Methods
        public  virtual void Withdraw(double amount)
        {            
                balance = balance - amount;
                Console.WriteLine("Withdraw ${0} dollars", amount);
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
            this.Withdraw(amount);
            another.Deposit(amount);
            /*
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
            */
        }
        public virtual double CalculateInterest()
        {
            return 0;
        }
        public void CreditInterest()
        {
            Deposit(CalculateInterest());
        }
        public override string ToString()
        {
            string output = String.Format("[BankAccount:accountNumber={0},accountHolder={1},balance={2}]", AccountNumber, AccountHolderName.ToString(), Balance);
            return (output);
        }

    }
    class SavingsAccount : BankAccount3
    {
        public SavingsAccount(string accountNumber, Customer accountHolderName) : base(accountNumber, accountHolderName)
        {
            if (balance < 0) throw new BalanceException("Balance can not be negative!");
        }
        public override void Withdraw(double amount)
        {
            if (amount>balance)
            {
                throw new BalanceException("You cannot withdraw amount greater than your balance."+Balance);
            }
            else
            {
                balance = balance - amount;
                Console.WriteLine("Withdraw ${0} dollars", amount);
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
            if (balance < 0) throw new BalanceException("Balance can not be negative!");
        }
        public override void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw new BalanceException("You cannot withdraw amount greater than your balance." + Balance);
            }
            else
            {
                balance = balance - amount;
                Console.WriteLine("Withdraw ${0} dollars", amount);
            }

        }
        public override double CalculateInterest()
        {
            return (balance * 0.25 / 100);
        }
    }
    class OverDraftAccount : BankAccount3
    {
        public OverDraftAccount(string accountNumber, Customer accountHolderName) : base(accountNumber, accountHolderName)
        {

        }
        public override double CalculateInterest()
        {
            if (balance >= 0)
            {
                return (balance * 0.25 / 100);
            }
            else
            {
                return (-(balance * 6 / 100));
            }
        }
        public new void TransferTo(double amount, BankAccount3 another)
        {
            balance = balance - amount;
            another.Deposit(amount);
            Console.WriteLine("Transfer ${0} dollars to {1}'account:{2}", amount, another.AccountHolderName, another.AccountNumber);
        }

    }
    class BankBranch
    {
        string BranchName;
        string BranchManager;
        List<BankAccount3> BankAccounts = new List<BankAccount3>();
        public BankBranch(string BranchName, string BranchManager)
        {
            this.BranchName = BranchName;
            this.BranchManager = BranchManager;
        }
        public void AddAccount(BankAccount3 b)
        {
            BankAccounts.Add(b);
        }
        public void PrintAccounts()
        {
            foreach (BankAccount3 account in BankAccounts)
            {
                Console.WriteLine(account);
            }

        }

        public void PrintCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            for (int i = 0; i < BankAccounts.Count; i++)
            {
                BankAccount3 a = BankAccounts[i];
                Customer c = a.AccountHolderName;
                //int c = cust.IndexOf(t);
                //if (c < 0)
                customerList.Add(c);
            }
            foreach (Customer c in customerList)
            {
                Console.WriteLine(c);
            }

        }
        public double TotalDeposits()
        {
            double total = 0;
            for (int i = 0; i < BankAccounts.Count; i++)
            {
                BankAccount3 a = (BankAccount3)BankAccounts[i];
                double bal = a.Balance;
                if (bal > 0)
                    total += bal;
            }
            return (total);
        }
        public double TotalInterestPaid()
        {
            double total = 0;
            for (int i = 0; i < BankAccounts.Count; i++)
            {
                BankAccount3 a = (BankAccount3)BankAccounts[i];
                double intr = a.CalculateInterest();
                if (intr > 0)
                    total += intr;
            }
            return (total);
        }
        public double TotalInterestEarned()
        {
            double total = 0;
            for (int i = 0; i < BankAccounts.Count; i++)
            {
                BankAccount3 a = (BankAccount3)BankAccounts[i];
                double intr = a.CalculateInterest();
                if (intr < 0)
                    total += (-intr);
            }
            return (total);
        }
    }

    public class FormException : ApplicationException
    {
        public FormException() : base()
        {
        }
        public FormException(string message) : base(message)
        {
        }
        public FormException(string message, Exception innerExc) : base(message, innerExc)
        {
        }
    }
    public class NegativeInputException : ApplicationException
    {
        public NegativeInputException() : base()
        {
        }
        public NegativeInputException(string message) : base(message)
        {
        }
        public NegativeInputException(string message, Exception innerExc) : base(message, innerExc)
        {
        }
    }
    public class BalanceException : ApplicationException
    {
        public BalanceException() : base()
        {
        }
        public BalanceException(string message) : base(message)
        {
        }
        public BalanceException(string message, Exception innerExc) : base(message, innerExc)
        {
        }
    }
}
