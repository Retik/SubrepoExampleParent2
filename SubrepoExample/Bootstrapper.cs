using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Lifestyles;
using SubrepoExample.Common;

namespace SubrepoExample
{
    public static class Bootstrapper
    {
        public static Container Bootstrap()
        {
            var container = new Container();
            container.Options.PropertySelectionBehavior = new ImportPropertySelectionBehavior();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            var assemblies = new List<Assembly>();
            foreach (var file in new DirectoryInfo(AssemblyDirectory.Get()).GetFiles().Where(file => file.Extension.ToLower() == ".dll"))
            {
                try
                {
                    assemblies.Add(Assembly.LoadFrom(file.FullName));
                }
                catch (BadImageFormatException) { }
                catch (FileNotFoundException) { }
            }
            container.RegisterPackages(assemblies);
            container.Verify();

            return container;
        }
    }

    public class ImportPropertySelectionBehavior : IPropertySelectionBehavior
    {
        public bool SelectProperty(Type implementationType, PropertyInfo prop) => prop.GetCustomAttributes(typeof(ImportAttribute)).Any();
    }

    public static class AssemblyDirectory
    {
        public static string Get()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            var directory = Path.GetDirectoryName(location);
            return directory;
        }
    }
}
