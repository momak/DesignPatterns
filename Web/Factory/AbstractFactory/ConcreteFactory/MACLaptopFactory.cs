using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Factory.AbstractFactory
{
    public class MACLaptopFactory : MACFactory
    {
        public override ISystemType SystemType()
        {
            return new Laptop();
        }
    }
}
 
