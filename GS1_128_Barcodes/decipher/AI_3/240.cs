namespace GS1_128_Barcodes
{
    public partial class AI_3
    {
        public static string decipher_AI240(string data)
        {
            //Alphanumeric 1 to 30 characters
            if ((CheckData.CharacterSet82(data)) && ((data.Length > 0) && (data.Length <= 30)))
            {
                return "AI 240 = Additional product identification assigned by the manufacturer" +
                       " (ADDITIONAL ID).\r\r" +
                       "Variable length Alphanumeric data up to 30 elements\r\r" +
                       "\tADDITIONAL ID = " + data + "\r";
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}