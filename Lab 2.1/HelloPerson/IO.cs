using System;

namespace HelloPerson
{
    internal static class IO
    {
        //"ReadName" sounds like a general use method, but in reality it has specific logic for 2.1
        internal static string ReadName()
        {
            var name = string.Empty;
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("What’s your name?");
                name = Console.ReadLine();
            }

            //C# 6 feature - cool
            Console.WriteLine($"Hello {name}.");
            Console.WriteLine();
            return name;
        }

        internal static int ReadNumber()
        {
            var number = 0;
            while (number < 1 || number > 10)
            {
                var input = string.Empty;

                //nice
                while (string.IsNullOrEmpty(input))
                {
                    Console.Write("Enter a number in the range 1-10: ");
                    input = Console.ReadLine();
                }
                int.TryParse(input, out number);
            }
            return number;
        }

        internal static void WriteOutput(string name, int number)
        {
            for (var i = 0; i < number; ++i)
            {
                for (var j = 0; j < i; ++j)
                {
                    Console.Write(' ');
                }
                Console.WriteLine(name);
            }
        }
    }
}
