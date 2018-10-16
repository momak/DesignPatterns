using System;

namespace StaticDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            double celsius = 37; double farenheit = 98.6;

            Console.WriteLine($"Value of {farenheit} farenheit to celsius is {Converter.ToCelsius(farenheit)}");
            Console.WriteLine($"Value of {celsius} celsius to farenhait is {Converter.ToFarenheit(celsius)}");

            Console.ReadLine();
        }
    }
}
