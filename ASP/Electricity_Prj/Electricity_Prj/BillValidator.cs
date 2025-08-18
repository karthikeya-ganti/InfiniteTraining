using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electricity_Prj
{
    public class BillValidator
    {
        public string ValidateUnitsConsumed(int UnitsConsumed)
        {
            return UnitsConsumed < 0 ? "Given units is invalid" : "Valid";
        }
    }
}