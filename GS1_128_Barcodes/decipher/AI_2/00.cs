namespace GS1_128_Barcodes
{
    public partial class AI_2
    {
        public static string decipher_AI00(string data)
        {
            //Numeric data 18 digits.
            if (CheckData.IsItNumber(data) && (data.Length == 18))
            {
                if (CheckSums.GCheckSum(data.Substring(0, data.Length - 1), data.Substring(data.Length - 1, 1)))
                {
                    string mydata = "\r\tExtension Digit = " + data.Substring(0, 1) +
                           "\r\tGS1 Company Prefix and Serial Reference = " + data.Substring(1, 16) +
                           "\r\tChecksum = " + data.Substring(17, 1) + " (Checksum is correct)";

                    return
                        "AI 00 = Serial Shipping Container Code (SSCC).\r\rFixed length Numeric data of 18 elements:\r\rSSCC:" +
                        mydata + "\r\r" +
                        "SSCC(Serial Shipping Container Code) = " + data;
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