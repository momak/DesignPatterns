using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Factory.AbstractFactory
{
    public class I5 : IProcessor
    {
        public string GetProcessor()
        {
            return Enumerations.Processors.i5.ToString();
        }
    }
}
