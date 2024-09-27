using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    public class ParenthesisMethods
    {
        public static void CheckParanthesis()
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
                        text = ".";
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

                            switch (input)
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
                            parenthesisMatch = MatchParenthesis(c, parenthesisStack.Peek());
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

            if (textPosition + 1 != charInput.Count)            //occurs if parenthesis didn't match and we exited out of the foreach loop. textposition is in 0 count while count isnt so adding 1
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

    }
}
