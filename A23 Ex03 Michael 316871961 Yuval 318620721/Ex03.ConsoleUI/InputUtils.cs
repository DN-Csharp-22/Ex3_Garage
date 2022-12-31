using System;

namespace Ex03.ConsoleUI
{
    public class InputUtils
    {
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);

            string input = Console.ReadLine();

            return input;
        }
    }
}
