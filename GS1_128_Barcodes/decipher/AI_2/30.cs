namespace GS1_128_Barcodes
{
    public partial class AI_2
    {
        public static string decipher_AI30(string data)
        {
            //Numeric 1 to 8 characters
            if ((CheckData.IsItNumber(data)) && ((data.Length > 0) && (data.Length <= 8)))
            {
                return "AI 30 = Variable count of items (VAR. COUNT)\r\r" +
                       "Up to 8 Numeric Characters\r\r" +
                       "The number of items contained in a variable measure trade item = " + data + "\r";
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}