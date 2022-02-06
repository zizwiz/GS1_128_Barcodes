namespace GS1_128_Barcodes
{
    public partial class AI_2
    {
        public static string decipher_AI12(string data)
        {
            //Numeric data 6 digits

            if ((CheckData.IsItNumber(data)) && (data.Length == 6))
            {
                string mydate = CheckDateTimes.CheckDate(data);

                data = "\r\t\tYY = " + data.Substring(0, 2) +
                       "\r\t\tMM = " + data.Substring(2, 2) +
                       "\r\t\tDD = " + data.Substring(4, 2);

                return "AI 12 = Due date for amount on payment slip (DUE DATE).\r\rFixed length Numeric data of 6 elements: YYMMDD\r\r\t" +
                       "DUE DATE = " + data + "\r\r" +
                       "Invoice should be paid before " + mydate + "\r";
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}