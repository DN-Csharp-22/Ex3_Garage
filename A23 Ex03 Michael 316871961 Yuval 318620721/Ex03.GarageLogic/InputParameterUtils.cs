using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class InputParameterUtils
    {
        public static string GetEnumInputString(Type i_type)
        {
            List<string> indexedEnumOptions = Enum.GetNames(i_type).Select((enumOption, index) => $"{(index + 1).ToString()}. {enumOption}").ToList();

            return string.Join("\n", indexedEnumOptions);
        }

        public static string DecreaseIntegerString(string i_inputString, int i_amountToDecrease)
        {
            string result = i_inputString;

            if (int.TryParse(i_inputString, out int o_parsedInteger))
            {
                o_parsedInteger -= i_amountToDecrease;
                result = o_parsedInteger.ToString();
            }

            return result;
        }
    }
}
