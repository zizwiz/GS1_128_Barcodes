namespace GS1_128_Barcodes
{
    public partial class AI_4
    {
        public static string decipher_AI36nn(string data)
        {
            string explanation = "";
            string units = "";
            int _decimalPoint = 1;

            //Numeric 6 characters
            if ((CheckData.IsItNumber(data)) && (data.Length == 10)) //data includes the ai hence 10 and not 6
            {
                string ai = data.Substring(0, 3);
                string type = "";

                int _ctr = int.Parse(data.Substring(3, 1));

                //work out the divisor for the decimal point

                for (int i = 1; i <= _ctr; i++)
                {
                    _decimalPoint = _decimalPoint * 10;
                }

                data = (float.Parse(data.Substring(4, 6)) / _decimalPoint).ToString();

                switch (ai)
                {
                    case "360":
                        explanation = "Net volume in Quarts";
                        units = "qt";
                        type = "Trade measures";
                        break;
                    case "361":
                        explanation = "Net volume in Gallons (U.S.)";
                        units = "us gal";
                        type = "Trade measures";
                        break;
                    case "362":
                        explanation = "Logistic volume in Quarts";
                        units = "in²";
                        type = "Logistic measures";
                        break;
                    case "363":
                        explanation = "Logistic volume in Gallons (U.S.)";
                        units = "in²";
                        type = "Logistic measures";
                        break;
                    case "364":
                        explanation = "Net volume in Cubic inches";
                        units = "in³";
                        type = "Trade measures";
                        break;
                    case "365":
                        explanation = "Net volume in Cubic feet";
                        units = "ft³";
                        type = "Trade measures";
                        break;
                    case "366":
                        explanation = "Net volume in Cubic yards";
                        units = "yd³";
                        type = "Trade measures";
                        break;
                    case "367":
                        explanation = "Logistic volume in Cubic inches";
                        units = "in²";
                        type = "Logistic measures";
                        break;
                    case "368":
                        explanation = "Logistic volume in Cubic feet";
                        units = "in²";
                        type = "Logistic measures";
                        break;
                    case "369":
                        explanation = "Logistic volume in Cubic yards";
                        units = "in²";
                        type = "Logistic measures";
                        break;
                    default:
                        explanation = "Not known";
                        break;
                }



                return "AI " + ai + "n = " + type +"\r\r" +
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