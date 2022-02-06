namespace GS1_128_Barcodes
{
    public partial class AI_3
    {
        public static string decipher_AI235(string data)
        {
            //Alphanumeric 1 to 28 characters
            if ((CheckData.CharacterSet82(data)) && ((data.Length > 0) && (data.Length <= 28)))
            {
                return "AI 235 = Third Party Controlled, Serialised Extension of Global Trade Item Number" +
                       " (TPX).\r\r" +
                       "Variable length Alphanumeric data up to 28 elements\r\r" +
                       "\tTPX = " + data + "\r";
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}