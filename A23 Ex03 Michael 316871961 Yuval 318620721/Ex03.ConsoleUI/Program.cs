using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StartGarageManager();
        }

        private static void StartGarageManager()
        {
            GarageManager garageManager = new GarageManager();

            while (true)
            {
                try
                {
                    StartGarageAction(garageManager);
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

        private static void StartGarageAction(GarageManager garageManager)
        {
            string actionNumberInput = GetActionNumber();

            if (int.TryParse(actionNumberInput, out int actionNumber))
            {
                switch (actionNumber)
                {
                    case 1:
                        addVehicleToGarage(garageManager);
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

                Console.Clear();
                Console.WriteLine(">>> Command has been finished successfully\n");
            }
            else
            {
                throw new FormatException("Action string must be a valid integer - one from the given options");
            }
        }

        private static void addVehicleToGarage(GarageManager garageManager)
        {
            string carLicenseNumber = InputUtils.GetUserInput("Please insert your car license number");

            Vehicle currentVehicle = garageManager.GetVehicle(carLicenseNumber);

            if (currentVehicle == null)
            {
                Type vehicleType = GetVehicleType(garageManager);

                Dictionary<string, string> inputMessages = garageManager.getVehicleInputMessages(vehicleType);

                Dictionary<string, string> inputValues = new Dictionary<string, string>();

                foreach (string key in inputMessages.Keys)
                {
                    string input = InputUtils.GetUserInput(string.Format(">>> {0}", inputMessages[key]));

                    inputValues.Add(key, input);
                }

                inputValues["IdNumber"] = carLicenseNumber;

                garageManager.createVehicle(vehicleType, inputValues);
            }
            else
            {
                garageManager.updateVehicleStatus(carLicenseNumber, VehicleStatus.InService);
            }
        }

        private static Type GetVehicleType(GarageManager garageManager)
        {
            Dictionary<string, Type> allowedVehicles = garageManager.GetAllowedVehicles();

            List<string> numberedAllowedVehicleList = allowedVehicles.Select((type, index) => $"{(index + 1).ToString()}. {type.Value.Name}").ToList();

            string getVehicleTypeMessage = string.Format("Please choose one of the following vehicle types : \n{0}", string.Join("\n", numberedAllowedVehicleList));

            int vehicleType = InputUtils.GetNumericInput(getVehicleTypeMessage, 0, numberedAllowedVehicleList.Count + 1);

            return allowedVehicles[vehicleType.ToString()];
        }

        private static void fillGasTank(GarageManager garageManager)
        {
            List<Vehicle> currentVehiclesInGarage = garageManager.getCurrentVehiclesInGarage();

            if (currentVehiclesInGarage.Count > 0)
            {
                bool isInputValid = false;

                while (!isInputValid)
                {
                    string carLicenseNumber = getVehicleLicenseNumberForUpdate(garageManager);

                    string gasOptionInput = InputUtils.GetUserInput("Please choose Gas type :\n1. Octan95\n2. Octan96\n3. Octan98\n 4. Soler");

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

        private static void chargeElectricCar(GarageManager garageManager)
        {
            List<Vehicle> currentVehiclesInGarage = garageManager.getCurrentVehiclesInGarage();

            if (currentVehiclesInGarage.Count > 0)
            {
                bool isInputValid = false;

                while (!isInputValid)
                {
                    string carLicenseNumber = getVehicleLicenseNumberForUpdate(garageManager);

                    string chargeTimeInMinutesInput = InputUtils.GetUserInput("Please enter charging time in Minutes");

                    if (int.TryParse(chargeTimeInMinutesInput, out int chargeTimeInMinutes))
                    {
                        if (chargeTimeInMinutes >= 0)
                        {
                            garageManager.chargingElectricMotor(carLicenseNumber, chargeTimeInMinutes);
                            isInputValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Charging input must be a valid positive integer, please try again");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Charging input must be a valid integer, please try again");
                    }
                }
            }
            else
            {
                Console.WriteLine("No vehicles in garage, please add first a vehicle");
            }
        }

        private static void fillTiresToMaximun(GarageManager garageManager)
        {
            string carLicenseNumber = getVehicleLicenseNumberForUpdate(garageManager);

            garageManager.fillTires(carLicenseNumber);
        }

        private static void changeCarStatus(GarageManager garageManager)
        {
            bool isInputValid = false;

            List<Vehicle> currentVehiclesInGarage = garageManager.getCurrentVehiclesInGarage();

            if (currentVehiclesInGarage.Count > 0)
            {
                while (!isInputValid)
                {
                    string carLicenseNumber = getVehicleLicenseNumberForUpdate(garageManager);

                    string changeStatusOptionInput = InputUtils.GetUserInput("Please choose status option :\n1. InService\n2. Fixed\n3. Completed");

                    if (int.TryParse(changeStatusOptionInput, out int changeStatusOption))
                    {
                        switch (changeStatusOption - 1)
                        {
                            case (int)VehicleStatus.InService:
                            case (int)VehicleStatus.Fixed:
                            case (int)VehicleStatus.Completed:
                                garageManager.updateVehicleStatus(carLicenseNumber, (VehicleStatus)(changeStatusOption - 1));
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

        private static string GetActionNumber()
        {
            Console.WriteLine(@"Hello please choose on of the following options :
    1. Add new vehicle
    2. Display current vehicle in garage
    3. Change vehicle status
    4. Fill tire pressure to maximum
    5. Fill gas tank
    6. Recharge vehicle
    7. Display complete vehicle data");

            string actionNumber = Console.ReadLine();

            return actionNumber;
        }

        private static void displayGarageCars(GarageManager garageManager)
        {
            List<Vehicle> listOfVehiclesAtGarage = garageManager.getCurrentVehiclesInGarage();

            List<string> listOfVehicleIds = listOfVehiclesAtGarage.Select(vehicle => vehicle.IdNumber).ToList();

            List<string> formatedListOfVehicles = listOfVehiclesAtGarage.Select(vehicle =>
                string.Format("{0} : {1} : {2}", vehicle.GetType().Name, vehicle.IdNumber, vehicle.vehicleStatus.ToString())).ToList();

            Console.WriteLine(string.Format("All vehicles at garage are :\n {0}", string.Join("\n", formatedListOfVehicles).ToArray()));

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
                                .Where(vechile => vechile.vehicleStatus == (VehicleStatus)(filterOption - 1))
                                .Select(vehicle => string.Format("{0} : {1} : {2}", vehicle.GetType().Name, vehicle.IdNumber, vehicle.vehicleStatus.ToString())).ToList();
                            Console.WriteLine(string.Format("Filtered vehicles are :\n{0}", string.Join("\n", listOfVehicleIds)));
                            Console.ReadKey();
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

        private static string getVehicleLicenseNumberForUpdate(GarageManager garageManager, bool isVehicleMUstBeInGarage = true)
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

        private static int getGasAmountToFill()
        {
            bool isValid = false;

            int amountToFill = 0;

            while (!isValid)
            {
                string amountToFillInput = InputUtils.GetUserInput("Please insert amount of gas to fill");

                if (int.TryParse(amountToFillInput, out amountToFill))
                {
                    if (amountToFill >= 0)
                    {
                        isValid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid gas amount was inserted");
                }
            }

            return amountToFill;
        }

        private static void displayVehicleFullData(GarageManager garageManager)
        {
            List<Vehicle> currentVehiclesInGarage = garageManager.getCurrentVehiclesInGarage();

            if (currentVehiclesInGarage.Count > 0)
            {
                string carLicenseNumber = getVehicleLicenseNumberForUpdate(garageManager);
                Console.WriteLine(garageManager.displayVehicleData(carLicenseNumber));
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No vehicles in garage, please add first a vehicle");
            }
        }
    }
}
