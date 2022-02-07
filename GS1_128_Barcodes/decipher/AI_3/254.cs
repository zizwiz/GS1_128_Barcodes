namespace GS1_128_Barcodes
{
    public partial class AI_3
    {
        public static string decipher_AI254(string data)
        {
            //Alphanumeric 1 to 20 characters
            if ((CheckData.CharacterSet82(data)) && ((data.Length > 0) && (data.Length <= 20)))
            {
                return "AI 254 = Global Location Number extension component" +
                       " (GLN EXTENSION COMPONENT).\r\r" +
                       "Variable length Alphanumeric data up to 20 elements\r\r" +
                       "\tGLN EXTENSION COMPONENT  = " + data + "\r";
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}