namespace GS1_128_Barcodes
{
    public partial class AI_3
    {
        public static string decipher_AI250(string data)
        {
            //Alphanumeric 1 to 30 characters
            if ((CheckData.CharacterSet82(data)) && ((data.Length > 0) && (data.Length <= 30)))
            {
                return "AI 250 = Secondary serial number" +
                       " (SECONDARY SERIAL).\r\r" +
                       "Variable length Alphanumeric data up to 30 elements\r\r" +
                       "\tSECONDARY SERIAL = " + data + "\r";
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}