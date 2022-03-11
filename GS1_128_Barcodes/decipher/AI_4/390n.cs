namespace GS1_128_Barcodes
{
    public partial class AI_4
    {
        public static string decipher_AI390n(string data)
        {
             int _decimalPoint = 1;

            //Numeric 1 to 15 characters
            if ((CheckData.IsItNumber(data)) && (data.Length >= 1) && (data.Length <= 15)) //data includes the ai hence 10 and not 6
            {
                if ((int.Parse(data.Substring(3, 1)) >= 0) && (int.Parse(data.Substring(3, 1)) <= 2))
                {
                    string ai = data.Substring(0, 3);
                    string type = "";

                    int _ctr = int.Parse(data.Substring(3, 1));

                    //work out the divisor for the decimal point

                    for (int i = 1; i <= _ctr; i++)
                    {
                        _decimalPoint = _decimalPoint * 10;
                    }

                    data = (float.Parse(data.Substring(4, data.Length-4)) / _decimalPoint).ToString();


                     

                    return "AI " + ai + "n = Amount payable or coupon value - Single monetary area (AMOUNT)\r\r" +
                           "Variable length Numeric data up to 15 elements\r\r" +
                           "\tThe applicable amount payable or the coupon value = " + data + "\r";
                }
                else
                {
                    return "the decimal place is incorrect. It should be 0,1 or 2.";
                }
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}