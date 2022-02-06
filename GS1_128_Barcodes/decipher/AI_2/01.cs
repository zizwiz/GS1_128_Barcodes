namespace GS1_128_Barcodes
{
    public partial class AI_2
    {
        public static string decipher_AI01(string data)
        {
            //Numeric data 8, 12, 13 or 14 digits

            if ((CheckData.IsItNumber(data)) && ((data.Length == 8) || (data.Length == 12) || (data.Length == 13) || (data.Length == 14)))
            {
                if (CheckSums.GCheckSum(data.Substring(0, data.Length - 1), data.Substring(data.Length - 1, 1)))
                {
                    string checkdigit = data.Substring(data.Length - 1, 1);
                    string mydata = data.Substring(0, data.Length - 1);


                    return "AI 01 = Identification of a trade item (GTIN).\r\rFixed length Numeric data of 8, 12, 13 or 14 elements.\r" +
                           "GTIN consists of variable length GS1 Company Prefix and Item reference" +
                           "\r\r\tGTIN = " + mydata + "\r\tCheck Digit = " + checkdigit + "\r\r" +
                           "Global Trade Item Number (GTIN) = " + data;
;
                }
                else
                {
                    return "Check your checksum appears incorrect.";
                }
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}
