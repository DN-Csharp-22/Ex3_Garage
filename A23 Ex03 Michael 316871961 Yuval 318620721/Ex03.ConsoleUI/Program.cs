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
                    case 1: //add

                        break;
                    case 2:
                        displayGarageCars(garageManager);
                        break;
                    case 3:
                        changeCarStatus(garageManager);
                        break;
                    case 4:
                        fillTiresToMaximun(garageManager);
                        break;
                    case 5:
                        fillGasTank(garageManager);
                        break;
                    case 6:
                        chargeElectricCar(garageManager);
                        break;
                    case 7:
                        displayVehicleFullData(garageManager);
                        break;
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

        public static void fillGasTank(GarageManager garageManager)
        {
            List<Vehicle> currentVehiclesInGarage = garageManager.getCurrentVehiclesInGarage();

            if (currentVehiclesInGarage.Count > 0)
            {
                bool isInputValid = false;

                while (!isInputValid)
                {
                    string carLicenseNumber = getVehicleLicenseNumber(garageManager);

                    string gasOptionInput = InputUtils.GetUserInput("Please choose Gas type :\n1. Octan95\n2. Octan96\n3. Octan98\n 4. Soler");

                    //TODO validate that the amount is a valid positive integer===> Yuval : ***i did it look at line 252**
                    int gasAmountToFill = getGasAmountToFill();

                    if (int.TryParse(gasOptionInput, out int gasToFill))
                    {
                        switch (gasToFill - 1)
                        {
                            case (int)GasType.Octan95:
                            case (int)GasType.Octan96:
                            case (int)GasType.Octan98:
                            case (int)GasType.Soler:
                                garageManager.FillGasTank(carLicenseNumber, (GasType)(gasToFill - 1), gasAmountToFill);
                                isInputValid = true;
                                break;
                            default:
                                Console.WriteLine("Invalid option was chosen : Please choose an integer from the given options above");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid integer was inserted");
                    }
                }
            }
            else
            {
                Console.WriteLine("No vehicles in garage, please add first a vehicle");
            }
        }

        public static void chargeElectricCar(GarageManager garageManager)
        {
            List<Vehicle> currentVehiclesInGarage = garageManager.getCurrentVehiclesInGarage();

            if (currentVehiclesInGarage.Count > 0)
            {
                bool isInputValid = false;

                while (!isInputValid)
                {
                    string carLicenseNumber = getVehicleLicenseNumber(garageManager);

                    string chargeTimeInMinutesInput = InputUtils.GetUserInput("Please enter charging time in Minutes");

                    if (int.TryParse(chargeTimeInMinutesInput, out int chargeTimeInMinutes))
                    {
                        if (chargeTimeInMinutes >= 0)  // check if input is valid positive intager
                        {
                            garageManager.chargingElectricMotor(carLicenseNumber, chargeTimeInMinutes);
                            isInputValid = true;

                        }
                        else
                        {
                            Console.WriteLine("chreging input must be a valid integer, please try again");

                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No vehicles in garage, please add first a vehicle");
            }
        }

        public static void fillTiresToMaximun(GarageManager garageManager)
        {
            string carLicenseNumber = getVehicleLicenseNumber(garageManager);

            garageManager.fillTires(carLicenseNumber);
        }

        public static void changeCarStatus(GarageManager garageManager)
        {
            bool isInputValid = false;

            List<Vehicle> currentVehiclesInGarage = garageManager.getCurrentVehiclesInGarage();

            if (currentVehiclesInGarage.Count > 0)
            {
                while (!isInputValid)
                {
                    string carLicenseNumber = getVehicleLicenseNumber(garageManager);

                    string changeStatusOptionInput = InputUtils.GetUserInput("Please choose status option :\n1. InService\n2. Fixed\n3. Completed");

                    if (int.TryParse(changeStatusOptionInput, out int changeStatusOption))
                    {
                        switch (changeStatusOption - 1)
                        {
                            case (int)VehicleStatus.InService:
                            case (int)VehicleStatus.Fixed:
                            case (int)VehicleStatus.Completed:
                                garageManager.updateVehicleStatus(carLicenseNumber, (VehicleStatus)changeStatusOption);
                                isInputValid = true;
                                break;
                            default:
                                Console.WriteLine("Invalid option was chosen : Please choose an integer from the given options above");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid integer was inserted");
                    }
                }
            }
            else
            {
                Console.WriteLine("No vehicles in garage, please add first a vehicle");
            }
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

        public static void displayGarageCars(GarageManager garageManager)
        {
            List<Vehicle> listOfVehiclesAtGarage = garageManager.getCurrentVehiclesInGarage();

            List<string> listOfVehicleIds = listOfVehiclesAtGarage.Select(vehicle => vehicle.IdNumber).ToList();

            Console.WriteLine(string.Format("All vehicles at garage are :\n {0}",
                             string.Join("\n", listOfVehiclesAtGarage.Select(v => v.IdNumber).ToArray())));

            bool isInputValid = false;

            while (!isInputValid)
            {
                string filterOptionInput = InputUtils.GetUserInput("Filter list of vehicles :\n1. InService\n2. Fixed\n3. Completed\n4. No filltering");

                if (int.TryParse(filterOptionInput, out int filterOption))
                {
                    switch (filterOption - 1)
                    {
                        case (int)VehicleStatus.InService:
                        case (int)VehicleStatus.Fixed:
                        case (int)VehicleStatus.Completed:
                            listOfVehicleIds = listOfVehiclesAtGarage
                                .Where(vechile => vechile.vehicleStatus == (VehicleStatus)filterOption - 1)
                                .Select(vehicle => vehicle.IdNumber).ToList();

                            Console.WriteLine(string.Format("Filtered vehicles are :\n {0}",
                              string.Join("\n", listOfVehiclesAtGarage.Select(v => v.IdNumber).ToArray())));
                            isInputValid = true;
                            break;
                        case 4:
                            isInputValid = true;
                            break;
                        default:
                            Console.WriteLine("Please choose an integer from the given options above");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid integer was inserted");
                }
            }
        }

        public static string getVehicleLicenseNumber(GarageManager garageManager, bool isVehicleMUstBeInGarage = true)
        {
            string carLicenseNumber = InputUtils.GetUserInput("Please insert your car license number");

            if (isVehicleMUstBeInGarage)
            {
                List<Vehicle> currentVehiclesInGarage = garageManager.getCurrentVehiclesInGarage();

                while (!currentVehiclesInGarage.Any(vehicle => vehicle.IdNumber == carLicenseNumber))
                {
                    Console.WriteLine(string.Format("Cannot find a vehicle with license number : {0}", carLicenseNumber));
                    carLicenseNumber = InputUtils.GetUserInput("Please insert your car license number");
                }
            }

            return carLicenseNumber;
        }

        public static int getGasAmountToFill() //validate that the amount is a valid positive integer
        {
            bool isValid = false;

            int amountToFill = 0; //defult

            while (!isValid) // run until input is valid
            {
                string amountToFillInput = InputUtils.GetUserInput("Please insert amount of gas to fill");

                if (int.TryParse(amountToFillInput, out amountToFill))
                {

                    if (amountToFill >= 0)
                    {
                        isValid = false;

                    }
                }
                else
                {
                    Console.WriteLine("Invalid gas amount was inserted");

                }
            }
            return amountToFill;
        }

        public static void displayVehicleFullData(GarageManager garageManager)
        {
            string carLicenseNumber = null;

            List<Vehicle> currentVehiclesInGarage = garageManager.getCurrentVehiclesInGarage();

            if (currentVehiclesInGarage.Count > 0)
            {
                carLicenseNumber = getVehicleLicenseNumber(garageManager);
                garageManager.displayVehicleData(carLicenseNumber);
            }
            else
            {
                Console.WriteLine("No vehicles in garage, please add first a vehicle");
            }
        }
    }
}
