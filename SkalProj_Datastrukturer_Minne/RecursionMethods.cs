using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    public class RecursionMethods
    {
        public static void ExamineRecursion()
        {
            bool examinationComplete = false;
            do
            {
                char input = ' ';
                Console.WriteLine("Select what recursion method you would like to use:\n"
                    + "1. RecursionOdd\n"
                    + "2. RecursionEven\n"
                    + "3. FibonacciRecursion\n"
                    + "0. Return to start menu");
                try
                {
                    input = Console.ReadLine()[0];
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);

                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);

                }
                int numberInput;
                switch (input)
                {
                    case '0':
                        examinationComplete = true; break;
                    case '1':
                        Console.WriteLine($"Input start number for RecursiveOdd");
                        string text = Console.ReadLine();
                        try
                        {
                            numberInput = int.Parse(text);
                            int result = RecursiveOdd(numberInput);
                            Console.WriteLine(result);
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case '2':
                        Console.WriteLine($"Input start number for RecursiveEven");
                        text = Console.ReadLine();
                        try
                        {
                            numberInput = int.Parse(text);
                            int result = RecursiveEven(numberInput);
                            Console.WriteLine(result);
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case '3':
                        Console.WriteLine($"Input the number in the fibonnacisequence you want to find:");
                        text = Console.ReadLine();
                        try
                        {
                            numberInput = int.Parse(text);
                            int result = Fibonacci(numberInput);
                            Console.WriteLine(result);
                        }
                        catch (System.FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    default:
                        break;
                }



                Console.WriteLine("try again?\n"
                    + "1. Yes\n"
                    + "2. No");

                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line

                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {

                    Console.WriteLine("Please enter some input!");
                }

                switch (input)
                {
                    case '1':
                        Console.WriteLine("Restarting..");
                        Console.Clear();
                        break;
                    case '2':
                        examinationComplete = true;
                        break;
                    default:
                        Console.WriteLine("Please select an available number, 1 or 2");
                        break;

                }
            } while (!examinationComplete);
        }

        static int RecursiveOdd(int n)
        {

            if (n == 1)
            {
                // Console.WriteLine($"n = {n}");
                return 1;
            }
            //Console.WriteLine($"({n} - 1) + 2 = {(n - 1) + 2}");
            return (RecursiveOdd(n - 1) + 2);
        }
        static int RecursiveEven(int n)
        {

            if (n == 0)
            {
                //Console.WriteLine($"n = {n}");
                return 0;
            }
            //Console.WriteLine($"({n} - 1) + 2 = {(n - 1) + 2}");
            return (RecursiveEven(n - 1) + 2);
        }
        static int Fibonacci(int n)
        {
           // Console.WriteLine($"n = {n}");

            if (n < 2)
            {
                return n;
            }
          //  Console.WriteLine($"(n-1) + (n-2) = {(n - 1) + (n - 2)}");

            int fib1 = Fibonacci(n - 1);
            int fib2 = Fibonacci(n - 2);
            int fibonacci = fib1 + fib2;
            //  return (Fibonacci(n-1)+(n-2));            //detta gav fel resultat
            return fibonacci;
        }
    }
}
