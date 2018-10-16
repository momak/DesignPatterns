using System;
using System.Threading.Tasks;

namespace SingletonP2
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

        private static void PrintEmployeeDetails()
        {
            SingletonClass fromEmployee = SingletonClass.GetInstance;
            fromEmployee.PrintDetails("From Employee");
        }

        private static void PrintStudentDetails()
        {
            SingletonClass fromStudent = SingletonClass.GetInstance;
            fromStudent.PrintDetails("From Student");
        }
    }
}
