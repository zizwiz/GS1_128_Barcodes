namespace GS1_128_Barcodes
{
    public partial class AI_3
    {
        public static string decipher_AI255(string data)
        {
            string _returnData = "";
            //13 Numeric + optional 12 Numeric characters
            if ((CheckData.IsItNumber(data.Substring(0, 13)) && ((data.Length > 0) && (data.Length <= 25))))
            {

                if (CheckSums.GCheckSum(data.Substring(0, 12), data.Substring(12, 1)))
                {
                    string checkdigit = data.Substring(12, 1);
                    string mydata = data.Substring(0, 13);


                    _returnData =
                        "AI 255 = Global Coupon Number (GCN).\r\rFixed length 13 Numeric GTIN plus optional 12 Numeric Serial Component\r" +
                        "Consists of variable length GS1 Company Prefix, Coupon component and Optional Serial Component" +
                        "\r\r\tCompany Prefix + Coupon Component = " + mydata + "\r\tCheck Digit = " + checkdigit + "\r\r";

                    if ((data.Length > 13) && (data.Length <= 25) && CheckData.IsItNumber(data.Substring(13, data.Length - 13)))
                    {
                        //has optional Serial Number
                        _returnData += "Optional Numeric Serial Component = " + data.Substring(13, data.Length - 13);
                    }
                    else
                    {
                        return "Optional serial Component appears incorrect";
                    }

                    return _returnData;

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