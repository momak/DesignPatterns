using System;
using System.Threading.Tasks;

namespace SingletonP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(
                () => PrintStudentDetails(),
                () => PrintEmployeeDetails()
            );
            Console.ReadLine();
        }

        /// <summary>
        /// Assuming Singleton is created from employee class
        /// we refer to the GetInstance property from the Singleton class
        /// </summary>
        private static void PrintEmployeeDetails()
        {
            SingletonClass fromEmployee = SingletonClass.GetInstance;
            fromEmployee.PrintDetails("From Employee");
        }

        /// <summary>
        /// Assuming Singleton is created from student class
        /// we refer to the GetInstance property from the Singleton class
        /// </summary>
        private static void PrintStudentDetails()
        {
            SingletonClass fromStudent = SingletonClass.GetInstance;
            fromStudent.PrintDetails("From Student");
        }
    }
}
