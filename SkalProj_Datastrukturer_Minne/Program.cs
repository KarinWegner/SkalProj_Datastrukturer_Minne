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
                    + "\n5. Examine Recursion"
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
                        ListMethods.ExamineList();
                        break;
                    case '2':
                        QueueMethods.ExamineQueue();
                        break;
                    case '3':
                        StackMethods.ExamineStack();
                        break;
                    case '4':
                        ParenthesisMethods.CheckParanthesis();
                        break;
                    case '5':
                        RecursionMethods.ExamineRecursion();
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

  
        
        class ExampleClass
        {
            public string letters;
            public ExampleClass(string input)
            {
                letters = input;
            }

        }
        
    }

}

