using System.Diagnostics.Eventing.Reader;

namespace GS1_128_Barcodes
{
    public partial class AI_3
    {
        public static string decipher_AI253(string data)
        {
            //13 Numeric + optional 17 Alphanumeric characters
            if ((CheckData.IsItNumber(data.Substring(0,13)) && ((data.Length > 0) && (data.Length <= 13))))
            {

                if (CheckSums.GCheckSum(data.Substring(0,13), data.Substring(12,1)))
                {
                    string checkdigit = data.Substring(data.Length - 1, 1);
                    string mydata = data.Substring(0, data.Length - 1);
                    string serialData;

                    if (data.Length > 13) //has optional Serial Number
                    {
                        if (CheckData.CharacterSet82(data.Substring(13, data.Length - 13)))
                        {
                            serialData = data.Substring(13, data.Length - 13);
                        }
                    }

                    return "AI 253 = Global Document Type Identifier (GDTI).\r\rFixed length 13 Numeric GTIN plus optional 17 Alphanumeric Serial Component\r" +
                           "GTIN consists of variable length GS1 Company Prefix and Item reference" +
                           "\r\r\tGTIN = " + mydata + "\r\tCheck Digit = " + checkdigit + "\r\r" +


                           "Global Document Type Identifier (GDTI) = " + data;
                    


                    
                }
                else
                {
                    return "The Checkdigit appears incorrect.";
                }
            }
            else
            {
                return "Check your data it appears incorrect.";
            }
        }
    }
}