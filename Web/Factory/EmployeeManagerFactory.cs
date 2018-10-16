using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Managers;
using Web.Models;

namespace Web.Factory
{
    public class EmployeeManagerFactory
    { 
        public IEmployeeManager GetEmployeeManager(int employeeTypeId)
        {
            IEmployeeManager returnValue = null;

            switch (employeeTypeId)
            {
                case 1:
                    returnValue = new PermanentEmployeeManager();
                    break;
                case 2:
                    returnValue = new ContractEmployeeManager();
                    break;
            }

            return returnValue;
        }
    }
}