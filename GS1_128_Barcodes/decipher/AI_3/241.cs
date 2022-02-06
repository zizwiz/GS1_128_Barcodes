namespace GS1_128_Barcodes
{
    public partial class AI_3
    {
        public static string decipher_AI241(string data)
        {
            //Alphanumeric 1 to 30 characters
            if ((CheckData.CharacterSet82(data)) && ((data.Length > 0) && (data.Length <= 30)))
            {
                return "AI 241 = Customer part number" +
                       " (CUST. PART NO.).\r\r" +
                       "Variable length Alphanumeric data up to 30 elements\r\r" +
                       "\tCUST. PART NO. = " + data + "\r";
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}