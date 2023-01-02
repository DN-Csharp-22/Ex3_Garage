using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class InputParameterUtils
    {
        public static string GetEnumInputString(Type type)
        {
            List<string> indexedEnumOptions = Enum.GetNames(type).Select((enumOption, index) => $"{(index + 1).ToString()}. {enumOption}").ToList();

            return string.Join("\n", indexedEnumOptions);
        }

        public static string DecreaseIntegerString(string inputString, int amountToDecrease)
        {
            string result = inputString;

            if (int.TryParse(inputString, out int parsedInteger))
            {
                parsedInteger -= amountToDecrease;
                result = parsedInteger.ToString();
            }

            return result;
        }
    }
}
