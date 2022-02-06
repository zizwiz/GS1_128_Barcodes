using System;

namespace GS1_128_Barcodes
{
    public class CheckSums
    {


        public static Boolean GCheckSum(string data, string checksum)
        {
            Boolean result = false;
            Int32 datalength = 0;
            Int32 total = 0;
            Int32 cSum = 0;
            Int32[] mutiply = { 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3 };

            datalength = 17 - data.Length;
            
            for (int i = 0; i < data.Length; i++)
            {
                total = total + (Int32.Parse(data[i].ToString()) * mutiply[i + datalength]);
            }
            
            cSum = 10 - (total % 10);
            
            if (cSum == Int32.Parse(checksum))
            {
                result = true;
            }
            
            return result;

        }







    }
}
