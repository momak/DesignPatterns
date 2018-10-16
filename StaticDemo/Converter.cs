using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDemo
{
    public static class Converter
    {
        public static double ToFarenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        public static double ToCelsius(double farenheit)
        {
            return (farenheit - 32) * 5 / 9;
        }
    }
}
