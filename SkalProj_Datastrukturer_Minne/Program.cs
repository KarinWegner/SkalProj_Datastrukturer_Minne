using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;
using SkalProj_Datastrukturer_Minne;
using System.Net.Http.Headers;

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

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            bool examinationComplete = false;

            string text = "";
            Stack textStack = new Stack();
            do
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Enter string to reverse"
                    + "\n2. Reverse string"
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
                    case '1':
                        try
                        {
                            text = Console.ReadLine();
                            ArgumentNullException.ThrowIfNullOrWhiteSpace(text);
                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Input is empty. Returning to selection menu.");
                            break;
                        }

                        foreach (char c in text)        //Adding text char by char to stack.
                        {
                            textStack.Push(c);
                        }

                        break;
                    case '2':
                        Console.WriteLine($"Input: \n{text}\n\nOutput:\n");
                        foreach (char c in textStack)
                        {
                            Console.Write(textStack.Peek());
                            Console.WriteLine(textStack.Pop());
                        }
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


        static void CheckParanthesis()
        {
            string testInput1 = "List<int> lista = new List<int>(){2, 3, 4}";
            string testInput2 = "(([{uysfe().uhsfu}, abc.()]))";
            string testInput3 = "((([]){[]([])}))";
            string testInput4 = "[(){[]}})";
            string testInput5 = "no parenthesis";
            Console.Clear();
            Queue charInput = new Queue();
            Stack<char> parenthesisStack = new Stack<char>();

            bool examinationComplete = false;
            do
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Write custom input"
                    + "\n2. Use loaded test strings to check"
                    + "\n0. Return to main menu");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line

                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {

                    Console.WriteLine("Please enter some input!");
                }
                finally { Console.Clear(); }

                switch (input)
                {
                    case '0':
                        examinationComplete = true;
                        break;
                    case '1':
                        Console.WriteLine("Input string to check validity on:");
                        string? text;
                        try
                        {

                            text = Console.ReadLine();
                            ArgumentNullException.ThrowIfNullOrWhiteSpace(text);

                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine(e.Message);  //ändrar text till . så den inte är tom
                            text = ".";

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);   //ändrar text till . så den inte är tom
                            text = ".";
                        }

                        ParenthesisChecker(text);

                        break;
                    case '2':
                        text=".";
                        bool correctInput = true;
                        do
                        {
                            correctInput = true;


                            Console.WriteLine("Please select a prewritten string by inputting the number \n(1, 2, 3 ,4, 0) of your choice+ "
                                + $"\n1.{testInput1}"
                                + $"\n2.{testInput2}"
                                + $"\n3.{testInput3}"
                                + $"\n4.{testInput4}"
                                + $"\n5.{testInput5}");

                        try
                        {
                            input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line

                        }
                        catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                        {

                            Console.WriteLine("Please enter some input!");
                        }

                        switch(input)
                        {
                            case '1': 
                                text = testInput1;
                                break;
                            case '2':
                                text = testInput2;
                                break;
                            case '3':
                                text = testInput3;
                                break;
                            case '4':
                                text = testInput4;
                                break;
                            case '5':
                                text = testInput5;
                                break;
                            default:
                                Console.WriteLine("Please enter some valid input (1, 2, 3, 4, 5)");
                                    correctInput = false;
                                 break;

                        }
                        } while (!correctInput);
                        ParenthesisChecker(text);

                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3)");
                        break;
                }





            } while (!examinationComplete);
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

        private static void ParenthesisChecker(string text)
        {
            Stack<char> parenthesisStack = new Stack<char>();
            Queue charInput = new Queue();
            foreach (char c in text)
            {
                charInput.Enqueue(c);
            }

            Console.WriteLine();
            Console.WriteLine("Parenthesis found:");
            int textPosition = -1;              //Kollar var i kön vi är
            bool foundParenthesis = false;                  //Kollar om det finns några parenteser alls i texten
            foreach (char c in charInput)
            {
                textPosition++;

                int parenthesisType = ParenthesisFinder(c);
                if (parenthesisType > 0)                    //Type 0 is NotParenthesis
                {
                    if (parenthesisType == 1)               //0 is Opener. Adds it to the stack 
                    {
                        foundParenthesis = true;
                        parenthesisStack.Push(c);
                        Console.Write(c);
                    }
                    else if (parenthesisType == 2)
                    {
                        bool parenthesisMatch;
                        try
                        {
                             parenthesisMatch= MatchParenthesis(c, parenthesisStack.Peek());
                        }
                        catch (InvalidOperationException e)
                        {

                            Console.WriteLine(e.Message);
                            parenthesisMatch = false;
                        }
                        
                        if (!parenthesisMatch)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Non-matching end parenthesis found.");
                            break;
                        }
                        else
                        {
                            parenthesisStack.Pop();
                            Console.Write(c);
                        }
                    }
                }

            }

            Console.WriteLine();

            if (textPosition+1 != charInput.Count)            //occurs if parenthesis didn't match and we exited out of the foreach loop. textposition is in 0 count while count isnt so adding 1
            {
                Console.WriteLine("An incorrect input was found in the text. Input was not valid.");
                Console.WriteLine("Error found at:");
                for (int i = 0; i < textPosition; i++)
                {
                    Console.Write(charInput.Dequeue());
                }

            }
            else if (parenthesisStack.Count != 0)           //occurs if we finished the foreach loop but all startParenthesis were not matched with an endParenthesis
            {
                Console.WriteLine("There are still parenthesis left open in the text. Input is not valid");
            }
            else if (foundParenthesis == false)
            {
                Console.WriteLine("Text contained no parenthesis.");
            }
            else
            {
                Console.WriteLine("No errors found. Input is valid!");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to selection menu");
            Console.ReadKey();
        }

        private static bool MatchParenthesis(char endParenthesis, char topOfStack)
        {
            bool isMatch;
            int p1ID = Identifier(endParenthesis);                                                       //Parenthesis 1 ID
            int p2ID = Identifier(topOfStack);                                                           //Parenthesis 2 ID

            if (p1ID == p2ID)                                                                //If assigned the same ID, it's a match
                return true;

            else
                return false;

        }

        private static int Identifier(char parenthesis)
        {
            int ID;
            if (parenthesis == '(' || parenthesis == ')')
            {
                return 0;
            }
            else if (parenthesis == '[' || parenthesis == ']')
            {
                return 1;
            }
            else  //(parenthesis == '{' || parenthesis == '}')
            {
                return 2;
            }
        }



        private static int ParenthesisFinder(char c)        //returns 0 if it's not a parenthesis, 1 for opener and 2 for closing parenthesis.
        {
            int parenthesisType;
            if (c == '(' || c == '[' || c == '{')
            {
                parenthesisType = (int)Type.StartParenthesis;
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                parenthesisType = (int)Type.EndParenthesis;
            }
            else
            {
                parenthesisType = (int)Type.NotParenthesis;
            }
            return parenthesisType;
        }

        //private static bool IsStartParenthesis(char c)        //Made obsolete by ParenthesisFinder which returns more valuable info at once
        //{
        //    bool isStartParenthesis;
        //    switch (c)
        //    {
        //        case '(':
        //            isStartParenthesis = true;
        //            break;
        //        case '{':
        //            isStartParenthesis = true;
        //            break;
        //        case '[':
        //            isStartParenthesis = true;
        //            break;
        //        default:
        //            isStartParenthesis = false;
        //            break;
        //    }
        //    return isStartParenthesis;
        //}
        class ExampleClass
        {
            public string letters;
            public ExampleClass(string input)
            {
                letters = input;
            }

        }
        static void ExamineItemStack()  //ville inte slänga den missuppfattade koden jag skrev till uppgift 3
        {

        }
    }

}

