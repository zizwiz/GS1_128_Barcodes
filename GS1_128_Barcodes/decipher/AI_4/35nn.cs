namespace GS1_128_Barcodes
{
    public partial class AI_4
    {
        public static string decipher_AI35nn(string data)
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
                    case "350":
                        explanation = "Area Square in inches";
                        units = "in²";
                        type = "Trade measures";
                        break;
                    case "351":
                        explanation = "Area Square in feet";
                        units = "ft²";
                        type = "Trade measures";
                        break;
                    case "352":
                        explanation = "Area Square in yards";
                        units = "yd²";
                        type = "Trade measures";
                        break;
                    case "353":
                        explanation = "Area Square in inches";
                        units = "in²";
                        type = "Logistic measures";
                        break;
                    case "354":
                        explanation = "Area Square in feet";
                        units = "in²";
                        type = "Logistic measures";
                        break;
                    case "355":
                        explanation = "Area Square in yards";
                        units = "in²";
                        type = "Logistic measures";
                        break;
                    case "356":
                        explanation = "Net weight in Troy ounces";
                        units = "oz t";
                        type = "Trade measures";
                        break;
                    case "357":
                        explanation = "Net weight (or volume) in Ounces";
                        units = "oz";
                        type = "Trade measures";
                        break;
                    default:
                        explanation = "Not known";
                        break;
                }



                return "AI " + ai + " = "+ type +"\r\r" +
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