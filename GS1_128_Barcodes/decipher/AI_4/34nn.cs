namespace GS1_128_Barcodes
{
    public partial class AI_4
    {
        public static string decipher_AI34nn(string data)
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
                    case "340":
                        explanation = "Logistic weight in pounds";
                        units = "lb";
                        break;
                    case "341":
                        explanation = "Length or first dimension in inches";
                        units = "in";
                        break;
                    case "342":
                        explanation = "Length or first dimension in feet";
                        units = "ft";
                        break;
                    case "343":
                        explanation = "Length or first dimension in yards";
                        units = "yd";
                        break;
                    case "344":
                        explanation = "Width, diameter, or second dimension in inches";
                        units = "in";
                        break;
                    case "345":
                        explanation = "Width, diameter, or second dimension in feet";
                        units = "ft";
                        break;
                    case "346":
                        explanation = "Width, diameter, or second dimension in yards";
                        units = "yd";
                        break;
                    case "347":
                        explanation = "Depth, thickness, height, or third dimension in inches";
                        units = "in";
                        break;
                    case "348":
                        explanation = "Depth, thickness, height, or third dimension in feet";
                        units = "ft";
                        break;
                    case "349":
                        explanation = "Depth, thickness, height, or third dimension in yards";
                        units = "yd";
                        break;
                    default:
                        explanation = "Not known";
                        break;
                }



                return "AI " + ai + "n = Logistic measures\r\r" +
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