using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Example_1
            int x, y = 0;
            x = 10 / y;                                   // error !! System.DivideByZeroException
            Console.WriteLine(x);
            
            //Example_1_handling_1
            int x, y = 0;
            try
            {
                Console.WriteLine("Enter try block.");
                x = 10 / y; // error !!
                Console.WriteLine(x);                     //no excution
                Console.WriteLine("Exit try block.");     //no excution
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Enter catch block.");
                Console.WriteLine(e);
                Console.WriteLine("Exit catch block.");
            }
            Console.WriteLine("After try-catch block.");
            

            //Example_1_handling_2
            int x, y = 0;
            try
            {
                Console.WriteLine("Enter try block.");
                x = 10 / y; // error !!
                Console.WriteLine(x);
                Console.WriteLine("Exit try block.");
            }
            catch (IndexOutOfRangeException e)           //Specific one
            {
                Console.WriteLine("First exception:");
                Console.WriteLine(e.GetType());
            }
            catch (Exception e)                          //Most general one
            {
                Console.WriteLine("Second Exception:");
                Console.WriteLine(e.GetType());
            }
            Console.WriteLine("End of method.");
            
            //Using Finally
            int[] a = new int[3];
            try
            {
                Console.WriteLine("Enter try block.");
                for (int i = 0; i < 5; i++)             //Error!IndexOutOfRangeException
                {
                    a[i] = i;
                    Console.WriteLine(a[i]);
                }
                Console.WriteLine("Exit try block.");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Exception caught.");
            }
            finally
            {
                Console.WriteLine("CleanUp. ");
            }
            Console.WriteLine("End of method. ");
            
            int[] a = new int[3];
            try
            {
                Console.WriteLine("Enter try block.");
                for (int i = 0; i < 5; i++)             //Error!IndexOutOfRangeException
                {
                    a[i] = i;
                    Console.WriteLine(a[i]);
                }
                Console.WriteLine("Exit try block.");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Exception caught.");
            }
            finally
            {
                Console.WriteLine("CleanUp. ");
            }
            Console.WriteLine("End of method. ");
            
            Console.WriteLine("Enter Main.");
            MyClass mc = new MyClass();
            try
            {
                mc.M1();
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter catch block of Main.");
                Console.WriteLine("Exception from: {0}",
                e.TargetSite);
                Console.WriteLine("Exit catch block of Main.");
            }
            Console.WriteLine("Exit Main.");
            */
            Path p = new Path();
            p.Add(new Position(3, 4));
            p.Add(new Position(8, 5));
            p.Add(new Position(1, 7));
        }

        public class MyClass
        {
            public void M1()
            {
                try
                {
                    Console.WriteLine("Enter try block of M1.");
                    M2();
                    Console.WriteLine("Exit try block of M1.");
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine("Enter catch block of M1.");
                    Console.WriteLine("Exception from: {0}",
                    e.TargetSite);
                    Console.WriteLine("Exit catch block of M1.");
                }
                Console.WriteLine("Exit M1.");
            }
            public void M2()
            {
                Console.WriteLine("Enter M2.");
                int y = 0;
                int x = 10 / y;
                Console.WriteLine("Exit M2.");
            }
        }
    }
    public struct Position
    {
        public int x, y;
        public Position(int x, int y)
        {
            this.x = x; this.y = y;
        }
    }
    public class Path
    {
        int pt;
        Position[] posn;
        public Path()
        {
            pt = 0;
            posn = new Position[100];
        }
        public void Add(Position p)
        {
            posn[pt] = p;
            pt = pt + 1;
        }
    }
    
}
