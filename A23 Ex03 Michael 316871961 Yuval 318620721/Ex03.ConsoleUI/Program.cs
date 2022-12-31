using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    partial class Program
    {
        static void Main(string[] args)
        {
            StartGarageManager();
        }
        public static void StartGarageManager()
        {
            while (true)
            {
                try
                {
                    StartGarageAction();
                }
                catch (FormatException fex)
                {
                    Console.WriteLine(string.Format("Invalid format error : {0}", fex.Message));
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine(string.Format("Invalid argument error : {0}", aex.Message));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("General Error : {0}", ex.Message));
                }
            }
        }

        public static void StartGarageAction()
        {
            string actionNumberInput = GetActionNumber();

            GarageManager garageManager = new GarageManager();

            if (int.TryParse(actionNumberInput, out int actionNumber))
            {
                switch (actionNumber)
                {
                    case 1:

                        break;
                    case 2://display current vehicles list with filter options
                        VehicleStatus status = (VehicleStatus)actionNumber;


                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                    default:
                        throw new ArgumentException("Invalid action number was chosen");
                }
            }
            else
            {
                throw new FormatException("Action string must be a valid integer - one from the given options");
            }

            string carLicenseNumber = InputUtils.GetUserInput("Please insert your car license number");
        }
        public static string GetActionNumber()
        {
            Console.WriteLine(@"Hello please choose on of the following options :
                    1. Add new vehicle
                    2. Display current vehicle in garage
                    3. Change vehicle status
                    4. Fill tire pressure to maximum
                    5. Fill gas tank
                    6. Recharge cehicle
                    7. Display complete vehicle data");

            string actionNumber = Console.ReadLine();

            return actionNumber;
        }
    }
}
