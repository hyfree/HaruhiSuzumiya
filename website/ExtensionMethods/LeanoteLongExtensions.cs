﻿using System;
using System.Globalization;

namespace HaruhiSuzumiya.Common.ExtensionMethods
{
    public static class LeanoteLongExtensions
    {
        public static string ToHex(this long number)
        {
            return number.ToString("x");
        }

        public static string ToHex24(this long number)
        {
            return "00000000"+number.ToString("x");
        }
        public static long ToLongByHex(this string hex)
        {   
            //if (hex.Length == 24)
            //{
            //    hex = hex.Substring(0, 16);
            //}
            //119993f42d821000
            long result;
            long.TryParse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result);
            return result;
        }
          public static long ToLongByNumber(this string number)
        {   
            //if (hex.Length == 24)
            //{
            //    hex = hex.Substring(0, 16);
            //}
            //119993f42d821000
            long result;
            long.TryParse(number, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
            return result;
        }
    }
}