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

        public static int GetNumericInput(string message, int bottomLimit, int upperLimit)
        {
            int result = -1;

            bool inputIsValid = false;

            Console.WriteLine(message);

            string input = Console.ReadLine();

            while (!inputIsValid)
            {
                if (int.TryParse(input, out int vehicleTypeSelection))
                {
                    if (vehicleTypeSelection > bottomLimit && vehicleTypeSelection < upperLimit)
                    {
                        inputIsValid = true;
                        result = vehicleTypeSelection;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input : Please choose one of the given options");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input : Please insert a valid integer");
                }
            }

            return result;
        }
    }
}
