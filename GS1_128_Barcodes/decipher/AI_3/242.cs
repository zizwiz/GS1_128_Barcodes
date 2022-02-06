namespace GS1_128_Barcodes
{
    public partial class AI_3
    {
        public static string decipher_AI242(string data)
        {
            //Numeric 1 to 30 characters
            if ((CheckData.IsItNumber(data)) && ((data.Length > 0) && (data.Length <= 30)))
            {
                return "AI 242 = Made-to-Order variation number" +
                       " (MTO VARIANT).\r\r" +
                       "Variable length Numeric data up to 30 elements\r\r" +
                       "\tMTO VARIANT = " + data + "\r";
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}