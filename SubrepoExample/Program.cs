using System;
using SubrepoExample.Common;

namespace SubrepoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var container = Bootstrapper.Bootstrap();
                var vendor = container.GetInstance<IVendor>();
                Console.WriteLine($"This vendor is: {vendor.GetName()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
