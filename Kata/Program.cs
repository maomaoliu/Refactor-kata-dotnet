using System;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var fizzBuzz = new FizzBuzz.FizzBuzz();
            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine(fizzBuzz.Of(i));
            }
        }
    }
}