using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Animal animal = new Animal("white");
            Cat kitty = new Cat("Kitty", "white");
            //Dog snoopy = new Dog();
            animal = kitty;
            //kitty = animal; not allow
            kitty = (Cat)animal;//InvalidCastException
            kitty.Print();
            */
            Parent p = new Parent();
            p.i = 5;
            Console.WriteLine(p.Calculate());
            Child c = new Child();
            c.i = 5;
            Console.WriteLine(c.Calculate());
            Child2 c2 = new Child2();
            c2.i = 5;
            Console.WriteLine(c2.Calculate());
            Parent p2;
            p2 = c; // widening conversion
            Console.WriteLine(p2.Calculate());
            Parent p3;
            p3 = c2; // widening conversion
            Console.WriteLine(p3.Calculate());



        }
    }
    class Animal
    {
        public string color = "";
        public Animal(string color)
        {
            this.color = color;
        }
        public void Print()
        {
            Console.WriteLine("This is a {0} animal", color);
        }
    }
    class Cat : Animal
    {
        public string name;
        public Cat(string name, string color) : base(color)
        {
            this.name = name;
        }
        public new void Print()
        {
            Console.WriteLine("This is a {0} cat: {1}", base.color, name);
        }
    }
    class Dog : Animal
    {
        public string name;
        public Dog(string name, string color) : base(color)
        {
            this.name = name;
        }
        public new void Print()
        {
            Console.WriteLine("This is a {0} dog: {1}", base.color, name);
        }
    }
    public class Parent
    {
        private int _i;
        protected int j = 3;
        public int i
        {
            get { return _i; }
            set { _i = value; }
        }
        public virtual int Calculate()
        {
            return 0;
        }
    }
    public class Child : Parent
    {
        
        public override int Calculate()
        {
            return i * i + j * j;

        }
        
    }
    public class Child2 : Parent
    {

        public new int Calculate()
        {
            return i * i + j * j;

        }

    }
}
