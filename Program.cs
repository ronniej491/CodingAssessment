
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodingAssessment
{
    class Program
    {
        static void Main(string[] args)
        {


            //Reads the input of a paragraph from comsole.
            Console.WriteLine($"Please insert a paragraph");
            string input = Console.ReadLine();

            //Writes results of Count of Palindrome Words of the input paragraph to console.
            Console.WriteLine($"Count of Palindrome Words({CountPalindromeWords(input)})");
            Console.WriteLine($"-------------------------------------------------\n");

            //Writes results of Count of Palindrome Sentences of the input paragraph to console.
            Console.WriteLine($"Count of Palindrome Sentences({CountPalindromeSentences(input)})");
            Console.WriteLine($"-------------------------------------------------\n");

            //Writes results of List and Count Unqiue Words of the input paragraph to console.
            Console.WriteLine($"List and Count Unqiue Words");
            Console.WriteLine($"--------------------------------------------------");
            var listCountUnqiueWords = ListCountUnqiueWords(input);

            //loops through list of list Count Unqiue Words return from listCountUnqiueWords() method
            foreach (var item in listCountUnqiueWords)
            {
                //Writes each item from the listCountUnqiueWords array to the console by line
           
                Console.WriteLine(item);
            }
            Console.WriteLine($"=================================================\n");

            string exit = "";
            do
            {

                //Writes results of List of Words that contains the input of letter from the console and print to the console.
                Console.WriteLine($"Input A Letter");
                Console.WriteLine($"--------------------------------------------------");
                string inputLetter = Console.ReadLine();
                var inputALetter = InputALetter(input, inputLetter);
                if (inputALetter != null)
                {
                     //loops through list of  Words return from InputALetter() method
                Console.WriteLine($"Words found containing input search letter");
                foreach (var item in inputALetter)
                {
                    //Writes each item from the inputALetter array to the console by line
                   
                    Console.WriteLine(item);
                }
                Console.WriteLine($"=================================================\n");

                Console.WriteLine($"Would you like to seach another letter? Enter y for yes or any other key to exit");
                exit = Console.ReadLine();
                }
               
              

            } while (exit == "y");
           
            
        }

        public static Array InputALetter(string para, string searchString)
        {
            //Sets the array of char to split each sentence into an array
            char[] delimiterChars = { '.', '!', '?', ' ' };

            //Splits the paragragh into an array of words, removes empty entries, finds all words that of the input that is
            //contain in the new array and return a new array of matches.
            return para.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries).Where(q => searchString.ToCharArray().All(p => q.Contains(p))).ToArray();
        }

       

        public static Array ListCountUnqiueWords(string para)
        {
            //Sets the array of char to split each sentence into an array
            char[] delimiterChars = { '.', '!', '?', ' ' };


            //Splits the paragragh into an array of words, , removes empty entries, group words by Unqiue value
            //then count how many times word appears and send to a new array.
            IEnumerable<string> distinctWords = para.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            var summary = (from word in distinctWords
                           group word by word into g
                           select new { words = g.First(), count = g.Count() }).ToArray();
            
            return summary;
        }


        public static int CountPalindromeWords(string para)
        {
            var StringWithoutSpclCharac = Regex.Replace(para, @"[.|!|?]", "");
       
            // to check last word for palindrome
            StringWithoutSpclCharac = StringWithoutSpclCharac + " ";

            // to store each word
            string word = "";
            int count = 0;
            for (int i = 0; i < StringWithoutSpclCharac.Length; i++)
            {
                char ch = StringWithoutSpclCharac[i];

                // extracting each word
                if (ch != ' ')
                {
                    word = word + ch;
                }
                else
                {
                    //Method to check if word id Palindrome and returns boolean, if true add to the count of palindrome words
                    if (CheckPalindromeWord(word))
                    {
                        count++;
                    }
                    word = "";
                }
            }

            return count;
        }

     

        public static int CountPalindromeSentences(string para)
        {
            //sets count to 0
            int count = 0;
            //Sets the array of char to split each sentence into an array
            char[] delimiterChars = { '.', '!', '?'};

            //Splits the paragragh into an array of sentences, removes empty entries
            string[] sentence = para.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            //loops through each sentence
            foreach (var item in sentence)
            {
                //regex to remove speacial char and white spaces from sentence and convert to lower
                var pSentence = Regex.Replace(item, @"[^0-9a-zA-Z]+", "").ToLower();

                //convert to ToCharArray
                char[] charArray = pSentence.ToCharArray();

                //reverse the charArray to compare if sentence is Palindrome and add to the count
                Array.Reverse(charArray);
                string charArrayString = new string(charArray);
                if (pSentence == charArrayString)
                {
                    
                    count++;
                }
            }
         
            return count;
        }

        public static bool CheckPalindromeWord(string word)
        {
            int n = word.Length;
            word = word.ToLower();
            for (int i = 0; i < n; i++, n--)
            {
                if (word[i] != word[n - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}