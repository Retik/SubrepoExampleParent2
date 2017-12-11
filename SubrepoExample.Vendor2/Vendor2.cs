using System;
using SubrepoExample.Common;

namespace SubrepoExample.Vendor2
{
    public class Vendor2 : IVendor
    {
        public string GetName()
        {
            return "Vendor2";
        }
    }
}
