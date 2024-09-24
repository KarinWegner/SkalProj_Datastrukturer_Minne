using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {/*
            Frågor:
            1.

            2.
         Exempel: class är en reference type. När en class skapas läggs den på heapen och är ett eget objekt, separat från dess instans i programmet.
                  int är en value type. Den refererar inte till ett objekt på heapen utan är endast värdet tilldelat variabeln i programmet.
        */
            //OBS! För att köra koden måste klassen också tas ur kommentarläget
            //int a1 = 1;
            //int b1 = a1;                                //detta gör att värdet på int b1 matchar värdet på int a1. De har inga andra kopplingar.
            //ExampleClass a = new ExampleClass("abc");        
            //ExampleClass b = a;                         //Detta gör att string b pekar mot objektet för string a

            //Console.WriteLine($"A1 = {a1}");
            //Console.WriteLine($"B1 = {b1}");

            //Console.WriteLine($"A: {a.letters}");
            //Console.WriteLine($"B: {b.letters}");

            //a1 = 2;
            //a.letters = "cde";

            //Console.WriteLine($"A1 = {a1}");        //Eftersom variablerna inte har något med varandra att göra kommer de inte att följa varandras ändringar.
            //Console.WriteLine($"B1 = {b1}");

            //Console.WriteLine($"A: {a.letters}");   //Eftersom de pekar mot samma objekt ändras referensen för b också.
            //Console.WriteLine($"B: {b.letters}");

            /*
            Fråga 3: MyInt är en klass och inten är ett value på objektet. Referenser till den är alltså pointers. Etableras ett objekt som en pointer och ändrar sedan sitt värde utförs den ändringen på det refererade objektet i heapen.

            Inten y pekar bara till ett separat value och är inte sammankopplat med x. X är inte en pointer utan gav bara vidare sitt värde, inte kopplingen till det. När y ändras ändras därför inte x.



             */

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
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
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {   List<string> theList = new List<string>();
            bool examinationComplete = false;
            do {
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
                        else if(capacityCount > theList.Capacity) 
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
            while(!examinationComplete);
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
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
                        if (queue.Count==0)
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
                       
                        
                            for (int i = 0; i <= numberInput-1; i++)
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

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            Console.Clear();
            Stack stack = new Stack();
            bool examinationComplete = false;
            do
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. View Stack"
                    + "\n2. Push item"
                    + "\n3. Pull item"
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
                    case '0':
                        examinationComplete = true;
                        break;
                    case '1':
                        if (stack.Count == 0)
                        {
                            Console.WriteLine("Stack is empty!");
                        }
                        else
                        {
                            Console.WriteLine("Current stack:");
                            Console.WriteLine("--------------");
                            foreach (var item in stack)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine();
                            Console.WriteLine("Bottom of stack");
                        }
                        break;
                    case '2':
                        Console.WriteLine("Enter input to push to stack:");
                        try
                        {
                            string pushee = Console.ReadLine();
                            stack.Push(pushee);
                            Console.WriteLine($"Pushed {pushee} to stack");
                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine(e.Message);

                        }
                        
                        break;
                    case '3':
                        int numberInput;
                        Console.WriteLine($"There are {stack.Count} items stacked");
                        Console.WriteLine("How many items do you want to pull from stack?");
                        try
                        {
                             numberInput = int.Parse(Console.ReadLine());
                                                 
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Invalid input");
                            numberInput = 0;
                        }
                        catch (ArgumentNullException e)
                        {
                            
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Empty input");
                            numberInput = 0;
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Input error");
                            numberInput = 0;
                        }

                        
                            Console.WriteLine($"Pulling {numberInput} items from stack");
                        Console.WriteLine("--------------------------");
                        for (int i = 0; i < numberInput; i++)
                        {
                            if (stack.Count == 0)
                            {
                                Console.WriteLine("Reached bottom of stack");

                                Console.WriteLine($"{i}/{numberInput} pulls successful.");
                                i = numberInput;
                            }
                            else 
                            {
                               // Console.WriteLine($"i = {i}\nnumberInput = {numberInput}");
                            string pulledItem = Convert.ToString(stack.Peek());
                            Console.WriteLine($"Pulled {pulledItem} from top of stack");
                                stack.Pop();

                            }
                        }
                        

                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3)");
                        break;
                }

            } while (!examinationComplete);
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }
        //class ExampleClass
        //{
        //    public string letters;
        //    public ExampleClass(string input)
        //    {
        //        letters = input;
        //    }

        //}

    }
}

