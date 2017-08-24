using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Workshop5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Customer2 c = new Customer2("Tan Ah Kow", "4 Short Street");
            int n = 65;
            Console.WriteLine(n);
            Console.WriteLine(c);
            Console.WriteLine(n.ToString());
            Console.WriteLine(c.ToString());
            
            Rational a = new Rational(0, 2);
            Rational b = new Rational(4, 5);
            Rational c = a + b;    // c=operator+(a,b);
            Console.WriteLine(c);
            c = b - a;
            Console.WriteLine(c);
            
            BankBranch branch = new BankBranch("KOKO Bank Branch","Tan Mon Nee");
            Customer cus1 = new Customer("Tan Ah Kow", "2 Rich Street","P345123",new DateTime(1990,01,01));
            Customer cus2 = new Customer("Lee Tee Kim", "88 Fatt Road","P678678",new DateTime(1987,03,07));
            Customer cus3 = new Customer("Alex Gold", "91 Dream Cove", "P333221",new DateTime(2000,09,06));
            branch.AddAccount(new SavingsAccount("S1230123", cus1));
            branch.AddAccount(new OverDraftAccount("O1230124", cus1));
            branch.AddAccount(new CurrentAccount("C1230125", cus2));
            branch.AddAccount(new OverDraftAccount("O1230126", cus3));
            branch.PrintCustomers();
            branch.PrintAccounts();
            Console.WriteLine(branch.TotalInterestEarned());
            Console.WriteLine(branch.TotalInterestPaid());
            */
            Customer y = new Customer("Tan Ah Kow", "20, Seaside Road", "XXX20", new DateTime(1989, 10, 11));
            Customer z = new Customer("Kim Lee Keng", "2, Rich View", "XXX9F", new DateTime(1993, 4, 25));
            BankAccount3 a = new BankAccount3("001-001-001", y);
            BankAccount3 b = new BankAccount3("001-001-002", z);
        }
    }
    class Customer
    {
        //1.Attributes
        string name, address, passportNumber;
        DateTime dateOfBirth;
        List<BankAccount3> accounts = new List<BankAccount3>();
        int numberOfAccounts=0;

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
        public override string ToString()
        {
            string output = String.Format("[BankAccount:accountNumber={0},accountHolder={1},balance={2}]",AccountNumber, AccountHolderName.ToString(), Balance);
            return (output);
        }

    }
    class SavingsAccount : BankAccount3
    {
        public SavingsAccount(string accountNumber, Customer accountHolderName) : base(accountNumber, accountHolderName)
        {
            if (balance < 0)
            {
                Console.WriteLine("Balance can not be negative!"); return;
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
            foreach (Customer c in customerList )
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
    class Customer2
    {
        private string name;
        private string address;
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
        public Customer2(string n, string a)
        {
            name = n;
            address = a;
        }
        public override string ToString()
        {
            string output="Name:"+name+" "+"Address:"+address;
            return output;
        }
    }
    public class Rational
    {
        private int numerator, denominator;

        public int GetNumerator()
        {
            return numerator;
        }

        public int GetDenominator()
        {
            return denominator;
        }

        public static Rational operator +(Rational num1, Rational num2)
        {
            int commonDenom = num1.denominator * num2.GetDenominator();
            int numer1 = num1.numerator * num2.GetDenominator();
            int numer2 = num2.GetNumerator() * num1.denominator;
            int sum = numer1 + numer2;
            Rational result = new Rational(sum, commonDenom);
            return result;
        }

        public static Rational operator -(Rational num1, Rational num2)
        {
            int commonDenom = num1.denominator * num2.GetDenominator();
            int numer1 = num1.numerator * num2.GetDenominator();
            int numer2 = num2.GetNumerator() * num1.denominator;
            int difference = numer1 - numer2;
            Rational result = new Rational(difference, commonDenom);
            return result;
        }

        public static Rational operator *(Rational num1, Rational num2)
        {
            int numer = num1.numerator * num2.GetNumerator();
            int denom = num1.denominator * num2.GetDenominator();
            Rational result = new Rational(numer, denom);
            return result;
        }

        public static Rational operator /(Rational num1, Rational num2)
        {
            int numer = num2.GetDenominator();
            int denom = num2.GetNumerator();

            Rational r = new Rational(numer, denom);
            Rational result = num1 * r;
            return result;
        }

        public override string ToString()
        {
            string result;

            if (numerator == 0)
                result = "0";
            else
            {
                if (denominator == 1)
                    result = numerator.ToString();
                else
                    result = numerator + "/" + denominator;
            }
            return result;
        }

        public Rational(int numer, int denom)
        {
            if (denom == 0)    // set denominator to 1 if
                denom = 1;      // argument is zero
            if (denom < 0)
            {   // make numerator "store" the sign
                numer = numer * -1;
                denom = denom * -1;
            }
            numerator = numer;
            denominator = denom;
            Reduce();          // calling a private method
        }

        private void Reduce()
        {
            if (numerator != 0)
            {
                int common = HCF(Math.Abs(numerator), denominator);
                numerator = numerator / common;
                denominator = denominator / common;
            }
        }

        private int HCF(int num1, int num2)
        {
            while (num1 != num2)
            {
                if (num1 > num2)
                    num1 -= num2;
                else
                    num2 -= num1;
            }
            return num1;
        }
    }
}
