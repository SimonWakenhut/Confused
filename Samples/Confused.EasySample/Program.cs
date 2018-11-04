using System;
using Confused;

namespace Confused.EasySample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var conf = Parse.File("Sample.conf");

            string helloMessage = conf["Sample"]["HelloMessage"];
            int aCoolNumber = Parse.Value<int>(conf["Sample"]["ACoolNumber"]);
            int[] anArray = Parse.Array<int>(conf["Sample"]["AnArray"]);

            Console.WriteLine($"{helloMessage}");
            Console.WriteLine($"{aCoolNumber} is a cool number!");

            Console.Write("Some more cool numbers:");
            foreach (var number in anArray)
            {
                Console.Write($" {number}");
            }
        }
    }
}
