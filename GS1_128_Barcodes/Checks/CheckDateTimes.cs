using System;
using System.Globalization;

namespace GS1_128_Barcodes
{
    class CheckDateTimes
    {

        public static string CheckDate(string data)
        {
            string result = "";
            DateTime convertedDate = DateTime.MinValue;
            string dFormat = "yyMMdd";
            

            if (DateTime.TryParseExact(data, dFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out convertedDate))
            {
                result = convertedDate.ToLongDateString();
            }

            return result;
        }




    }
}
