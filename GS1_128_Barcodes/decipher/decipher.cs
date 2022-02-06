using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GS1_128_Barcodes
{
    public partial class Form1
    {
        private void DecipherData(string ai, string data)
        {

            switch (ai)
            {
                case "00": //SSCC
                    rchtxtbx_output.AppendText(AI_2.decipher_AI00(data) + "\r");
                    break;
                case "01": //GTIN
                    rchtxtbx_output.AppendText(AI_2.decipher_AI01(data) + "\r");
                    break;
                case "02": //CONTENT
                    rchtxtbx_output.AppendText(AI_2.decipher_AI02(data) + "\r");
                    break;
                case "10": //BATCH / LOT
                    rchtxtbx_output.AppendText(AI_2.decipher_AI10(data) + "\r");
                    break;
                case "11": //PROD DATE
                    rchtxtbx_output.AppendText(AI_2.decipher_AI11(data) + "\r");
                    break;
                case "12": //DUE DATE
                    rchtxtbx_output.AppendText(AI_2.decipher_AI12(data) + "\r");
                    break;
                case "13": //PACK DATE
                    rchtxtbx_output.AppendText(AI_2.decipher_AI13(data) + "\r");
                    break;
                case "15": //BEST BEFORE or BEST BY
                    rchtxtbx_output.AppendText(AI_2.decipher_AI15(data) + "\r");
                    break;
                case "16": //SELL BY
                    rchtxtbx_output.AppendText(AI_2.decipher_AI16(data) + "\r");
                    break;
                case "17": //USE BY or EXPIRY
                    rchtxtbx_output.AppendText(AI_2.decipher_AI17(data) + "\r");
                    break;
                case "20": //VARIANT
                    rchtxtbx_output.AppendText(AI_2.decipher_AI20(data) + "\r");
                    break;
                case "21": //SERIAL
                    rchtxtbx_output.AppendText(AI_2.decipher_AI21(data) + "\r");
                    break;
                case "22": //CPV
                    rchtxtbx_output.AppendText(AI_2.decipher_AI22(data) + "\r");
                    break;
                case "235": //TPX
                    rchtxtbx_output.AppendText(AI_3.decipher_AI235(data) + "\r");
                    break;
                case "240": //ADDITIONAL ID
                    rchtxtbx_output.AppendText(AI_3.decipher_AI240(data) + "\r");
                    break;
                case "241": //CUST. PART NO.
                    rchtxtbx_output.AppendText(AI_3.decipher_AI241(data) + "\r");
                    break;
                case "242": //MTO VARIANT
                    rchtxtbx_output.AppendText(AI_3.decipher_AI242(data) + "\r");
                    break;
                case "243": //PCN
                    rchtxtbx_output.AppendText(AI_3.decipher_AI243(data) + "\r");
                    break;
                case "250": //SECONDARY SERIAL
                    rchtxtbx_output.AppendText(AI_3.decipher_AI250(data) + "\r");
                    break;
                case "251": //REF. TO SOURCE
                    rchtxtbx_output.AppendText(AI_3.decipher_AI251(data) + "\r");
                    break;
                case "253": //GDTI
                    rchtxtbx_output.AppendText(AI_3.decipher_AI253(data) + "\r");
                    break;







                default:
                    rchtxtbx_output.AppendText(data + "\r");
                    break;
            }






        }
    }
}
