using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonP2
{
    public sealed class SingletonClass
    {
        private static int counter = 0;

        private SingletonClass()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }

        /// <summary>
        /// Eager Loading
        /// </summary>
        //private static readonly SingletonClass instance = new SingletonClass();

        /// <summary>
        /// Lazy Loading
        /// </summary>
        private static readonly Lazy<SingletonClass> instance = new Lazy<SingletonClass>(() => new SingletonClass());

        public static SingletonClass GetInstance
        {
            get
            {
                return instance.Value;
            }
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}
