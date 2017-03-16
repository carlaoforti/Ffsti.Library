using System;
using System.Reflection;

namespace Ffsti.Library.Base.Helpers
{
    /// <summary>
    /// Class for handle Assemblies Values
    /// </summary>
    public static class AssemblyHelper
    {
        /// <summary>
        /// Retrieve the version for a given assembly
        /// </summary>
        /// <param name="assembly">Assembly to get version number</param>
        /// <returns>Version</returns>
        public static Version RetrieveVersionFromAssembly(Assembly assembly)
        {
            return assembly.GetName().Version;
        }

        /// <summary>
        /// Retrieve the version for the executing assembly
        /// </summary>
        /// <returns>Version</returns>
        public static Version RetrieveVersionFromExecutingAssembly()
        {
            return Assembly.GetExecutingAssembly().GetName().Version;
        }
    }
}
