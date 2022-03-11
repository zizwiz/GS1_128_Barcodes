namespace GS1_128_Barcodes
{
    public partial class AI_4
    {
        public static string decipher_AI32nn(string data)
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
                    case "320":
                        explanation = "Net weight in Pounds";
                        units = "lb";
                        break;
                    case "321":
                        explanation = "Length or first dimension in Inches";
                        units = "in";
                        break;
                    case "322":
                        explanation = "Length or first dimension in Feet";
                        units = "ft";
                        break;
                    case "323":
                        explanation = "Length or first dimension in Yards";
                        units = "yd";
                        break;
                    case "324":
                        explanation = "Width, diameter, or second dimension in Inches";
                        units = "in";
                        break;
                    case "325":
                        explanation = "Width, diameter, or second dimension in Feet";
                        units = "ft";
                        break;
                    case "326":
                        explanation = "Width, diameter, or second dimension in Yards";
                        units = "yd";
                        break;
                    case "327":
                        explanation = "Depth, thickness, height, or third dimension in Inches";
                        units = "in";
                        break;
                    case "328":
                        explanation = "Depth, thickness, height, or third dimension in Feet";
                        units = "ft";
                        break;
                    case "329":
                        explanation = "Depth, thickness, height, or third dimension in Yards";
                        units = "yd";
                        break;
                    default:
                        explanation = "Not known";
                        break;
                }



                return "AI " + ai + "n = Trade measures\r\r" +
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