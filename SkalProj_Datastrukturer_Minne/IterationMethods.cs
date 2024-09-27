using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    public class IterationMethods
    {
        public static void ExamineIteration()
        {
            bool examinationComplete = false;
            do
            {
                char input = ' ';
                Console.WriteLine("Select what iteration method you would like to use:\n"
                    + "1. IterativeEven\n"
                    + "2. FibonacciIteration\n"
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
                        Console.WriteLine($"Input start number for IterativeEven:");
                        string text = Console.ReadLine();
                        try
                        {
                            numberInput = int.Parse(text);
                            int result = IterativeEven(numberInput);
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
                    case '2':

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
        private static int IterativeEven(int numberInput)
        {
            int result = 1;
            for (int i = 0; i < numberInput-1; i++)
            {
                result += 2;
            }
            return result;
        }
        private static int Fibonacci(int numberInput)
        {
            int fib1 = 0;
            int fib2 = 1;
            int result = 0;
            for (int i = 0; i < numberInput; i++)
            {
                result = (fib1 + fib2);
                fib2 = fib1; 
                fib1 = result;
                Console.WriteLine($"fib 1: {fib1}, fib 2: {fib2}");
            }
            
            return result;
        }


    }
}
