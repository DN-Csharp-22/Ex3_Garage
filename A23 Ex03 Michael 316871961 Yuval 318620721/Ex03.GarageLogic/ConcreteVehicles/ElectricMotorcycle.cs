using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        public LicenseType licenseType { get; set; }

        protected static new readonly Dictionary<string, string> inputMessages = new Dictionary<string, string>()
        {
           { "licenseType", string.Format("Please insert motorcycle license type out of : \n{0}", InputParameterUtils.GetEnumInputString(typeof(LicenseType))) },
        };

        public ElectricMotorcycle(Dictionary<string, string> inputValues = null) : base(inputValues)
        {
            if (inputValues != null)
            {
                if (int.TryParse(inputValues["licenseType"], out int licenseTypeInput) && Enum.IsDefined(typeof(LicenseType), licenseTypeInput - 1))
                { 
                    this.licenseType = (LicenseType)licenseTypeInput;
                }
                else
                {
                    throw new ArgumentException("Invalid license type selected");
                }
            }
        }

        public static new Dictionary<string, string> GetInputMessages()
        {
            Dictionary<string, string> result = ElectricVehicle.GetInputMessages();

            foreach (string key in inputMessages.Keys)
            {
                result.Add(key, inputMessages[key]);
            }

            return result;
        }

        public override string GetVehicleInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("Electric motorcycle");
            sb.AppendLine(base.GetVehicleInformation());

            sb.AppendLine(string.Format("License type : {0}", this.licenseType.ToString()));

            return sb.ToString();
        }
    }
}