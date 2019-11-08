using System.Linq;
using System.Text;

namespace CadastralNumberInformation.Core.Rosreestr.net
{
    public class RosreestrSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://rosreestr.net/";
        public string Page { get; set; } = "kadastr";
        public string CadastralNumber { get; set; }

        public RosreestrSettings(string cadastralNumber)
        {
            if (string.IsNullOrWhiteSpace(cadastralNumber))
            {
                var stringBuilder = new StringBuilder();

                var value = string.Join("", cadastralNumber.Where(w => char.IsDigit(w)));

                for (int i = 0; i < value.Length; i++)
                {
                    stringBuilder.Append(value[i]);

                    if(i == 1 || i == 3 || i == 9)
                    {
                        stringBuilder.Append("-");
                    }                    
                }

                cadastralNumber = stringBuilder.ToString();
            }

            CadastralNumber = cadastralNumber;
        }
    }
}
