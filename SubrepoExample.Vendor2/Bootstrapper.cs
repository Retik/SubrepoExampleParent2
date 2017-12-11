using SimpleInjector;
using SimpleInjector.Packaging;
using SubrepoExample.Common;

namespace SubrepoExample.Vendor2
{
    public class Bootstrapper : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IVendor, Vendor2>();
        }
    }
}
