using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    public class ListMethods
    {
        public static void ExamineList()
        {
            List<string> theList = new List<string>();
            bool examinationComplete = false;
            do
            {
                /*
                 * Loop this method untill the user inputs something to exit to main menue.
                 * Create a switch statement with cases '+' and '-'
                 * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
                 * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
                 * In both cases, look at the count and capacity of the list
                 * As a default case, tell them to use only + or -
                 * Below you can see some inspirational code to begin working.
                */
                Console.WriteLine("Add an input to list by writing '+' followed by the string you want to add.");
                Console.WriteLine("remove an input from the list by writing '-' followed by the string you want to remove.");

                string input = Console.ReadLine();
                char nav = input[0];                                //Hämtar ut första char:en i input
                string value = input.Substring(1);                  //Hämtar ut hela stringen utom första char:en
                int capacityCount = 0;
                switch (nav)
                {
                    case '+':
                        capacityCount = theList.Capacity;
                        theList.Add(value);

                        Console.WriteLine("Value added");

                        if (capacityCount == theList.Capacity)
                        {
                            Console.WriteLine("List capacity was not changed.");
                        }
                        else if (capacityCount > theList.Capacity)
                        {
                            Console.WriteLine("List capacity was decreased!");
                        }
                        else if (capacityCount < theList.Capacity)
                        {
                            Console.WriteLine("List capacity was increased!");
                        }
                        break;
                    case '-':
                        try
                        {

                            capacityCount = theList.Capacity;
                            theList.Remove(value);
                            Console.WriteLine("value removed.");
                        }
                        catch (Exception)
                        {


                        }
                        break;

                }
                Console.WriteLine($"List capacity:\t{theList.Capacity}");
                Console.WriteLine($"List count:\t{theList.Count}");
                if (capacityCount == theList.Capacity)
                {
                    Console.WriteLine("List capacity was not changed.");
                }
                else if (capacityCount > theList.Capacity)
                {
                    Console.WriteLine("List capacity was decreased!");
                }
                else if (capacityCount < theList.Capacity)
                {
                    Console.WriteLine("List capacity was increased!");
                }
            }
            while (!examinationComplete);
        }
    }
}
