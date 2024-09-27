using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    public class StackMethods
    {
        public static void ExamineStack()
        {
            bool examinationComplete = false;

            string text = "";
            Stack textStack;
            do
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Reverse string"

                    + "\n0. Return to main menu");
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
                    case '0':
                        examinationComplete = true;
                        break;
                    case '1':
                        try
                        {
                            textStack = new Stack();
                            Console.WriteLine("Enter input to reverse:");
                            text = Console.ReadLine();
                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Input is empty. Returning to selection menu.");
                            break;
                        }
                        char[] charArray = text.ToCharArray();
                        foreach (char c in text)        //Adding text char by char to stack.
                        {
                            textStack.Push(c);
                        }

                        int stackLength = textStack.Count;

                        Console.WriteLine($"Input: \n{text}\n\nOutput:\n");
                        for (int i = 0; i < stackLength; i++)
                        {
                            Console.Write(textStack.Pop());
                        }
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2)");
                        break;

                }
            }
            while (!examinationComplete);

            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }
    }
}
