using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArekRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            //<summary>
            //first try to calculate a factorial without using Recursion, 
            //and then implement recursion
            //</summary>

            Console.Write("Length: ");
            int userInput = int.Parse(Console.ReadLine());

            List<long> result = Fibbonacci(userInput);

            //print out list
            result.ForEach(x => Console.Write($"{x} "));

            Console.ReadKey();
        }
        static int factorial(int userInput)
        {
            if (userInput == 1)
            {
                return 1;
            }

            return userInput * factorial(userInput - 1);
        }

        static List<long> Fibbonacci(int userInput)
        {
            if (userInput <= 0)
            {
                return null;
            }
            if (userInput == 1)
            {
                return new List<long>() { 0 };
            }
            if (userInput == 2)
            {
                return new List<long>() { 0, 1 };
            }
            List<long> numbers = new List<long>(userInput) { 0, 1 };
            fibonacci(userInput, numbers);
            return numbers;
        }

        static void fibonacci(int count, List<long> numbers)
        {
            if (numbers.Count == count)
            {
                return;
            }
            numbers.Add(numbers[numbers.Count - 1] + numbers[numbers.Count - 2]);
            fibonacci(count, numbers);
        }
    }
}