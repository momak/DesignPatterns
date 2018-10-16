using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonP1
{
    public sealed class SingletonClass
    {
        private static int counter = 0;
        private static readonly SingletonClass instance = null;
        private static readonly object obj = new object();


        /// <summary>
        /// Private constructor ensures that object is not instantiated other than with in the class itself
        /// </summary>
        private SingletonClass()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }

        /// <summary>
        /// public property is used to return only one instance of the class leveraging on the private property
        /// </summary>
        public static SingletonClass GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                            return new SingletonClass();
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Public method which can be invoked through the singleton instance
        /// </summary>
        /// <param name="message"></param>
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}
