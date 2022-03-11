namespace GS1_128_Barcodes
{
    public partial class AI_2
    {
        public static string decipher_AI37(string data)
        {
            //Numeric 1 to 8 characters
            if ((CheckData.IsItNumber(data)) && ((data.Length > 0) && (data.Length <= 8)))
            {
                return "AI 37 = Count of trade items or trade item pieces contained in a logistic unit (COUNT)\r\r" +
                       "Up to 8 Numeric Characters\r\r" +
                       "The number of trade items or number of trade item pieces contained in the respective logistic unit = " + data + "\r";
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}