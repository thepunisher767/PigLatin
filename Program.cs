using System;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueFlag = true;
            Console.WriteLine("Welcome to the Pig Latin Translator!\n");
            while (continueFlag)
            {
                Console.Write("Enter a line to be translated: ");
                Translator(StringValidation(Console.ReadLine()));
                Console.Write("\n\nTranslate another line? (y/n): ");
                string userContinue = YesOrNo(Console.ReadLine());
                if (userContinue == "n")
                {
                    continueFlag = false;
                }
            }
            Console.WriteLine("OK BYEEEEEE!");
        }

        public static string[] ToArray(string userInput)
        {
            string[] words = userInput.Split(' ');
            return words;
        }

        public static void Translator(string userInput)
        {
            Regex firstCap = new Regex(@"^[A-Z][a-z]*$");
            Regex allCaps = new Regex(@"^[A-Z]*$");
            Regex checkSpecialAndNumbers = new Regex(@"^[a-zA-Z]*$");

            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            string[] wordArray = ToArray(userInput);    //Create an array to store individual words from userInput
            for (int i = 0; i < wordArray.Length; i++)
            {
                bool noSpecialOrNumbers = checkSpecialAndNumbers.IsMatch(wordArray[i]); //Check if this passes the regex
                bool firstCapCheck = firstCap.IsMatch(wordArray[i]);
                bool allCapsCheck = allCaps.IsMatch(wordArray[i]);

                if (noSpecialOrNumbers == true) //if there are no special characters or number, do the IF
                {
                    if (wordArray[i].IndexOfAny(vowels) == 0)   //Checks if first index is vowel
                    {
                        wordArray[i] = wordArray[i] + "way";
                        //Console.Write($"{wordArray[i]}");
                    }
                    else if (wordArray[i].IndexOfAny(vowels) == -1) //will return -1 if no vowels are found. This prevents exceptions from the Substrings below
                    {
                        //Console.Write($"{wordArray[i]}");
                    }
                    else
                    {
                        int firstVowelIndex = wordArray[i].IndexOfAny(vowels); //Get index of first vowel
                        //Console.WriteLine(firstVowelIndex);
                        string trimFront = wordArray[i].Substring(0, firstVowelIndex);
                        string trimEnd = wordArray[i].Substring(firstVowelIndex);
                        wordArray[i] = trimEnd + trimFront + "ay";
                        //Console.Write($"{trimEnd}{trimFront}ay");
                    }                   
                }
                if (firstCapCheck)
                {

                    char letter = Char.ToUpper(wordArray[i][0]);
                    wordArray[i] = letter + wordArray[i].Substring(1).ToLower();
                }
                else if (allCapsCheck)
                {
                    wordArray[i] = wordArray[i].ToUpper();
                }
                else
                {
                    wordArray[i] = wordArray[i].ToLower();
                }

                Console.Write($"{wordArray[i]}");   //just write the word if there are special/numbers

                if (i < wordArray.Length - 1)   //Add space after each word, unless it is the last one
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("."); //Add period after the last word
                }
            }
            //Console.Write(".");
            return;
        }

        public static string StringValidation(string input)   //Check for valid input
        {
            Regex spacesOnly = new Regex(@"^[ ]*$");
            while (string.IsNullOrEmpty(input) || spacesOnly.IsMatch(input))
            {
                Console.Write($"Please enter an string...: ");
                input = Console.ReadLine();
            }
            return input;
        }
        public static string YesOrNo(string answer) //method to check (y/n)
        {
            answer = answer.ToLower();
            while (answer != "y" && answer != "n")
            {
                Console.Write("Please enter valid input (y/n): ");
                answer = Console.ReadLine();
                answer = answer.ToLower();
                Console.WriteLine();
            }
            return answer;
        }
    }
}
