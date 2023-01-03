using System;

namespace Ex03.ConsoleUI
{
    public class InputUtils
    {
        public static string GetUserInput(string i_message)
        {
            Console.WriteLine(i_message);

            string input = Console.ReadLine();

            return input;
        }

        public static int GetNumericInput(string i_message, int i_bottomLimit, int i_upperLimit)
        {
            int result = -1;

            bool inputIsValid = false;

            Console.WriteLine(i_message);

            string input = Console.ReadLine();

            while (!inputIsValid)
            {
                if (int.TryParse(input, out int o_vehicleTypeSelection))
                {
                    if (o_vehicleTypeSelection > i_bottomLimit && o_vehicleTypeSelection < i_upperLimit)
                    {
                        inputIsValid = true;
                        result = o_vehicleTypeSelection;
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
