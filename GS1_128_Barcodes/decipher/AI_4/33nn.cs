namespace GS1_128_Barcodes
{
    public partial class AI_4
    {
        public static string decipher_AI33nn(string data)
        {
            string explanation = "";
            string units = "";
            int _decimalPoint = 1;

            //Numeric 6 characters
            if ((CheckData.IsItNumber(data)) && (data.Length == 10)) //data includes the ai hence 10 and not 6
            {
                string ai = data.Substring(0, 3);

                int _ctr = int.Parse(data.Substring(3, 1));

                //work out the divisor for the decimal point

                for (int i = 1; i <= _ctr; i++)
                {
                    _decimalPoint = _decimalPoint * 10;
                }

                data = (float.Parse(data.Substring(4, 6)) / _decimalPoint).ToString();

                switch (ai)
                {
                    case "330":
                        explanation = "Logistic weight in kilograms";
                        units = "kg";
                        break;
                    case "331":
                        explanation = "Length or first dimension in metres";
                        units = "m";
                        break;
                    case "332":
                        explanation = "Width, diameter, or second dimension in metres";
                        units = "m";
                        break;
                    case "333":
                        explanation = "Depth, thickness, height, or third dimension in metres";
                        units = "m";
                        break;
                    case "334":
                        explanation = "Area Square in metres";
                        units = "m²";
                        break;
                    case "335":
                        explanation = "Logistic volume in litres";
                        units = "l";
                        break;
                    case "336":
                        explanation = "Logistic volume in cubic metres";
                        units = "m³";
                        break;
                    default:
                        explanation = "Not known";
                        break;
                }



                return "AI " + ai + " = Logistic measures\r\r" +
                       "Fixed length Numeric data of 6 elements\r\r" +
                       "\t" + explanation + " = " + data + units + "\r";
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}