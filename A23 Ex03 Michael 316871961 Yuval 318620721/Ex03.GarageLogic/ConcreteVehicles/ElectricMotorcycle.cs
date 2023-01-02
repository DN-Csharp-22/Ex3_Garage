using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        public LicenseType licenseType { get; set; }

        protected new readonly Dictionary<string, string> inputMessages = new Dictionary<string, string>()
        {
           { "licenseType", string.Format("Please insert motorcycle license type out of : \n{0}", InputParameterUtils.GetEnumInputString(typeof(LicenseType))) },
        };

        public ElectricMotorcycle(Dictionary<string, string> inputValues = null) : base(inputValues)
        {
            if (inputValues != null)
            {
                if (int.TryParse(inputValues["licenseType"], out int licenseTypeInput) && Enum.IsDefined(typeof(LicenseType), licenseTypeInput))
                { 
                    this.licenseType = (LicenseType)licenseTypeInput;
                }
                else
                {
                    throw new ArgumentException("Invalid license type selected");
                }
            }
        }

        public new Dictionary<string, string> GetInputMessages()
        {
            Dictionary<string, string> result = base.GetInputMessages();

            foreach (string key in inputMessages.Keys)
            {
                result.Add(key, inputMessages[key]);
            }

            return result;
        }
    }
}