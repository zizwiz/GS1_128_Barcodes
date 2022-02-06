namespace GS1_128_Barcodes
{
    public partial class AI_2
    {
        public static string decipher_AI22(string data)
        {
            //Alphanumeric 1 to 20 characters
            if ((CheckData.CharacterSet82(data)) && ((data.Length > 0) && (data.Length <= 20)))
            {
                return "AI 22 = Consumer product variant (CPV).\r\r" +
                       "Variable length Alphanumeric data up to 20 elements\r\r" +
                       "\tCPV = " + data + "\r";
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}