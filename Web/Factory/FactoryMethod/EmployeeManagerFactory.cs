using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Factory.FactoryMethod
{
    public class EmployeeManagerFactory
    {
        public BaseEmployeeFactory CreateFactory(Employee emp)
        {
            BaseEmployeeFactory returnValue = null;
            switch (emp.EmployeeTypeID)
            {
                case 1:
                    returnValue = new PermanentEmployeeFactory(emp);
                    break;
                case 2:
                    returnValue = new ContractEmployeeFactory(emp);
                    break;
            }

            return returnValue;
        }
    }
}