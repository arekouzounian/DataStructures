using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekArrayAndRecursionWarmup
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an array of 3 words
            //recursively print out the characters in backwards order 
            string[] words = new string[4];
            words[0] = "The ";
            words[1] = "quick ";
            words[2] = "brown ";
            words[3] = "fox.";
            for(int i = 0; i < 4; i++)
            {
                Console.Write(words[i]);
            }
            for (int i = 0; i < words.Length; i++)
            {
                PrintOut(words[i], words[i].Length-1);
            }
            Console.WriteLine("\nEnter a starting number and an ending number.");
            int currentNum = int.Parse(Console.ReadLine());
            int endingNum = int.Parse(Console.ReadLine());
            CountDown(currentNum, endingNum);
            Console.ReadKey(); 
        }
        static void PrintOut(string word, int index)
        {
            if (index < 0)
            {
                return;
            }
            Console.Write(word[index]);
            PrintOut(word, --index);
        }

        static void CountDown(int currentNum, int endingNum)
        {
            if (currentNum < endingNum)
            {
                return;
            }
            Console.WriteLine(currentNum);
            CountDown(--currentNum, endingNum);
        }
    }
}
