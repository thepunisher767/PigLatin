﻿using System;
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
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            string[] wordArray = ToArray(userInput);    //Create an array to store individual words
            for (int i = 0; i < wordArray.Length; i++)
            {
                if (wordArray[i].IndexOfAny(vowels) == 0)   //Checks if first index is vowel
                {
                    wordArray[i] = wordArray[i] + "way";
                    Console.Write($"{wordArray[i]}");
                }
                else if (wordArray[i].Length == 1)          //checks for single char consonant, as my Substring below was throwing exceptions for these odd cases due to length.
                {
                    Console.Write($"{wordArray[i]}");
                }
                else
                {
                    int firstVowelIndex = wordArray[i].IndexOfAny(vowels); //Get index of first vowel
                    //Console.WriteLine(firstVowelIndex);
                    string trimFront = wordArray[i].Substring(0, firstVowelIndex);
                    string trimEnd = wordArray[i].Substring(firstVowelIndex);
                    Console.Write($"{trimEnd}{trimFront}ay");
                }
                Console.Write(" ");
            }
            Console.Write(".");
            return;
        }

        public static string StringValidation(string input)   //Check for valid input
        {
            while (string.IsNullOrEmpty(input))
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
