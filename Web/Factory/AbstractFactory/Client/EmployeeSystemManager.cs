using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Factory.AbstractFactory
{
    public class EmployeeSystemManager
    {
        private IComputerFactory _iComputerFactory;

        public EmployeeSystemManager(IComputerFactory iComputerFactory)
        {
            _iComputerFactory = iComputerFactory;
        }

        public string GetSystemDetails()
        {
            IBrand brand = _iComputerFactory.Brand();
            IProcessor processor = _iComputerFactory.Processor();
            ISystemType systemType = _iComputerFactory.SystemType();

            string returnValue = $"{brand.GetBrand()} {systemType.GetSystemType()} {processor.GetProcessor()}";
            return returnValue;
        }
    }
}