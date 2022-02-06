namespace GS1_128_Barcodes
{
    public partial class AI_2
    {
        public static string decipher_AI20(string data)
        {
            //Numeric 2 characters
            if ((CheckData.IsItNumber(data)) && (data.Length ==2))
            {
                return "AI 20 = Internal product variant (VARIANT).\r\r" +
                       "Fixed length Numeric data of 2 elements\r\r" +
                       "\tVARIANT = " + data + "\r";
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}