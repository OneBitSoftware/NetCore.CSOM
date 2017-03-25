using System;
using System.Reflection;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal class AssemblyLoadEventArgs : EventArgs
    {
        private Assembly _LoadedAssembly;

        /// <summary>Gets an <see cref="T:System.Reflection.Assembly" /> that represents the currently loaded assembly.</summary>
        /// <returns>An instance of <see cref="T:System.Reflection.Assembly" /> that represents the currently loaded assembly.</returns>
        /// <filterpriority>2</filterpriority>
        public Assembly LoadedAssembly
        {
            get
            {
                return this._LoadedAssembly;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.AssemblyLoadEventArgs" /> class using the specified <see cref="T:System.Reflection.Assembly" />.</summary>
        /// <param name="loadedAssembly">An instance that represents the currently loaded assembly. </param>
        public AssemblyLoadEventArgs(Assembly loadedAssembly)
        {
            this._LoadedAssembly = loadedAssembly;
        }
    }
}