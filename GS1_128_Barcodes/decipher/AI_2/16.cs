namespace GS1_128_Barcodes
{
    public partial class AI_2
    {
        public static string decipher_AI16(string data)
        {
            //Numeric data 6 digits

            if ((CheckData.IsItNumber(data)) && (data.Length == 6))
            {
                string mydate = CheckDateTimes.CheckDate(data);

                data = "\r\t\tYY = " + data.Substring(0, 2) +
                       "\r\t\tMM = " + data.Substring(2, 2) +
                       "\r\t\tDD = " + data.Substring(4, 2);

                return "AI 16 = Sell by date (SELL BY).\r\rFixed length Numeric data of 6 elements: YYMMDD\r\r\t" +
                       "SELL BY = " + data + "\r\r" +
                       "The product should not be merchandised after " + mydate + "\r";
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}