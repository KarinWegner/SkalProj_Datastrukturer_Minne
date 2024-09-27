using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkalProj_Datastrukturer_Minne;

namespace SkalProj_Datastrukturer_Minne
{
    public class QueueMethods
    {
        public static void ExamineQueue()
        {
            bool examinationComplete = false;
            Queue queue = new Queue();
            do
            {
                Console.Clear();
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. View Queue"
                    + "\n2. Enqueue"
                    + "\n3. Dequeue"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        if (queue.Count == 0)
                        {
                            Console.WriteLine("Queue is empty!");
                        }
                        else
                        {
                            Console.WriteLine("Current queue:");
                            Console.WriteLine("----------------");
                            foreach (var item in queue)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine();
                            Console.WriteLine("End of queue.");
                        }

                        break;
                    case '2':
                        Console.WriteLine("Enter input to enqueue:");
                        try
                        {

                            string enqueuee = Console.ReadLine();
                            queue.Enqueue(enqueuee);
                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine(e.Message);

                        }
                        break;
                    case '3':
                        int numberInput;

                        Console.WriteLine($"There are {queue.Count} items in line");
                        Console.WriteLine("How many items do you want to dequeue?");
                        string text = Console.ReadLine();
                        try
                        {
                            numberInput = int.Parse(text);
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine(e.Message);
                            numberInput = 0;
                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine(e.Message);
                            numberInput = 0;
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                            numberInput = 0;
                        }

                        Console.WriteLine($"Dequeuing {numberInput} items");
                        Console.WriteLine("-----------------------");


                        for (int i = 0; i <= numberInput - 1; i++)
                        {
                            if (queue.Count == 0)
                            {
                                Console.WriteLine("Line is empty");
                                Console.WriteLine($"{i}/{numberInput} dequeues successful.");
                            }
                            else
                            {
                                string nextInLine = Convert.ToString(queue.Peek());
                                Console.WriteLine($"Dequeued {nextInLine}");
                                queue.Dequeue();
                            }
                        }



                        break;
                    case '0':
                        examinationComplete = true;
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3)");
                        break;
                }
            }
            while (!examinationComplete);

            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

        }
    }
}
