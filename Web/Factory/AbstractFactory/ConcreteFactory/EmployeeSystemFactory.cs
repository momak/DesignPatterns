using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Factory.AbstractFactory
{
    public class EmployeeSystemFactory
    {
        public IComputerFactory Create(Employee emp)
        {
            IComputerFactory returnValue = null;

            switch (emp.EmployeeTypeID)
            {
                case 1:
                    returnValue = emp.JobDescription == "Manager" ? new MACLaptopFactory() : new MACFactory();
                    break;
                case 2:
                    returnValue = emp.JobDescription == "Manager" ? new DellLaptopFactory() : new DellFactory();
                    break;
            }

            return returnValue;
        }
    }
}