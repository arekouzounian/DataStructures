using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekRecursionFactors
{
    class Program
    {
        static void Main(string[] args)
        {
            //make a recursive program that takes in a number and lists all of its factors
            //take a number
            //divide that number by 2
            //increment a 2-count var
            //check if the number type isn't int32
            //if it isn't, then return 
            int count = 0; 
            Console.Write("Enter a number: ");
            int userInput = int.Parse(Console.ReadLine());
            factor(userInput);
            Console.ReadKey(); 
        }

        static void factor(int num)
        {
            factor(num, num);
        }


        static void factor(int number, int count)
        {
            
            if (count == 0)
            {
                return;
            }

            if (number % count == 0)
            {
                Console.WriteLine(count);
            }
            factor(number, count - 1);


        }
    }
}
