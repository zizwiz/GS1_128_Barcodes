using System;
using System.Text.RegularExpressions;

namespace GS1_128_Barcodes
{
    public class CheckData
    {

        public static bool IsCharLegal(string ICL)
        {
            String str = "1234567890abcdefghijklmnopqrstuvwxyz$%+-./ ()";

            foreach (char c in ICL)
            {

                if (!str.Contains(c.ToString().ToLower())) return false;

            }

            return true;
        }

        public static bool CharacterSet82(string data)
        {
            String str = "!\" % &'()*+,-./0123456789:;<=>?ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz";

            foreach (char c in data)
            {

                if (!str.Contains(c.ToString())) return false;

            }

            return true;
        }


        public static bool CharacterSet39(string data)
        {
            String str = "#-/0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            foreach (char c in data)
            {

                if (!str.Contains(c.ToString())) return false;

            }

            return true;
        }

        public static bool IsItNumber(string data)
        {
            return Regex.IsMatch(data, @"^\d+$");
        }


    }
}
