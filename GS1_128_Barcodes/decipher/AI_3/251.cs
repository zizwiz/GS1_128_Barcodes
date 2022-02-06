namespace GS1_128_Barcodes
{
    public partial class AI_3
    {
        public static string decipher_AI251(string data)
        {
            //Alphanumeric 1 to 30 characters
            if ((CheckData.CharacterSet82(data)) && ((data.Length > 0) && (data.Length <= 30)))
            {
                return "AI 251 = Reference to source entity" +
                       " (REF. TO SOURCE).\r\r" +
                       "Variable length Alphanumeric data up to 30 elements\r\r" +
                       "\tREF. TO SOURCE = " + data + "\r";
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}