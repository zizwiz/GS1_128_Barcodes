namespace GS1_128_Barcodes
{
    public partial class AI_3
    {
        public static string decipher_AI243(string data)
        {
            //Alphanumeric 1 to 30 characters
            if ((CheckData.CharacterSet82(data)) && ((data.Length > 0) && (data.Length <= 20)))
            {
                return "AI 243 = Packaging component number" +
                       " (PCN).\r\r" +
                       "Variable length Alphanumeric data up to 20 elements\r\r" +
                       "\tPCN = " + data + "\r";
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}