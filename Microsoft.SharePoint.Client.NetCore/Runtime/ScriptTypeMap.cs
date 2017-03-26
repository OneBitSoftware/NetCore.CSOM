using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Reflection;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyModel;
using Microsoft.DotNet.PlatformAbstractions;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal static class ScriptTypeMap
    {
        private class ScriptTypeInfo
        {
            public Type Type;

            public bool ValueObject;

            public ScriptTypeInfo(Type type, bool valueObject)
            {
                this.Type = type;
                this.ValueObject = valueObject;
            }
        }

        private const string ElementNameAssemblyName = "AssemblyName";

        private static object s_lock = new object();

        private static volatile bool s_inited;

        private static Dictionary<string, ScriptTypeMap.ScriptTypeInfo> s_clientProxies = new Dictionary<string, ScriptTypeMap.ScriptTypeInfo>();

        private static Dictionary<Type, ScriptTypeMap.ScriptTypeInfo> s_typeToScriptTypeMap = new Dictionary<Type, ScriptTypeMap.ScriptTypeInfo>();

        private static Dictionary<string, object> s_loadedAssemblies = new Dictionary<string, object>();

        private static List<IScriptTypeFactory> s_scriptTypeFactories = new List<IScriptTypeFactory>();

        internal static bool IsInited
        {
            get
            {
                return ScriptTypeMap.s_inited;
            }
        }

        internal static void EnsureInited()
        {
            if (ScriptTypeMap.s_inited)
            {
                return;
            }
            lock (ScriptTypeMap.s_lock)
            {
                if (!ScriptTypeMap.s_inited)
                {
                    ScriptTypeMap.Init();
                    ScriptTypeMap.s_inited = true;
                }
            }
        }

        private static void Init()
        {
            ScriptTypeMap.LoadClientTypeAssemblies();
            //Edited for .NET Core
            //Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            //AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(ScriptTypeMap.AppDomain_AssemblyLoad);
            //Assembly[] array = assemblies;
            //for (int i = 0; i < array.Length; i++)
            //{
            //    Assembly assembly = array[i];
            //    try
            //    {
            //        object[] customAttributes = assembly.GetCustomAttributes(typeof(ClientTypeAssemblyAttribute), false);
            //        if (customAttributes != null && customAttributes.Length != 0)
            //        {
            //            ScriptTypeMap.AddClientProxyAssembly(assembly);
            //        }
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}

            // The above code seems to loop all loaded assemblies to check for the ClientTypeAssemblyAttribute
            // The below is how I have rewritten it for .NET Core
            // NOTE: I can't find a way to hook to something similiar to AppDomain.CurrentDomain.AssemblyLoad

            var currentAssembly = Assembly.GetEntryAssembly();
            var currentAssemblyClientTypeAttributes = currentAssembly.GetCustomAttribute<ClientTypeAssemblyAttribute>();
            var currentAssemblyReferencedAssemblies = currentAssembly.GetReferencedAssemblies();

            foreach (var assemblyName in currentAssemblyReferencedAssemblies)
            {
                try
                {
                    var assembly = Assembly.Load(assemblyName);

                    var customAttributes = assembly.GetCustomAttributes<ClientTypeAssemblyAttribute>();
                    if (customAttributes != null && customAttributes.Count() != 0)
                    {
                        ScriptTypeMap.AddClientProxyAssembly(assembly);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private static bool IsFatalException(Exception ex)
        {
            //Edited for .NET Core
            // will be added in .NET Standard 2.0
            //return ex is AccessViolationException || ex is AppDomainUnloadedException || ex is OutOfMemoryException || ex is StackOverflowException || ex is ThreadAbortException;
            return ex is OutOfMemoryException;
        }

        private static void LoadClientTypeAssemblies()
        {
            try
            {
                ScriptTypeMap.LoadAssembliesDefinedInConfigFile();
            }
            catch (Exception ex)
            {
                if (ScriptTypeMap.IsFatalException(ex))
                {
                    throw;
                }
            }
            try
            {
                ScriptTypeMap.LoadAssembliesDefinedInProgramFiles();
            }
            catch (Exception ex2)
            {
                if (ScriptTypeMap.IsFatalException(ex2))
                {
                    throw;
                }
            }
        }

        private static void LoadAssembliesDefinedInConfigFile()
        {
            //ClientRuntimeConfigurationSection clientRuntimeConfigurationSection = ConfigurationManager.GetSection("microsoft.sharepoint.client/clientRuntime") as ClientRuntimeConfigurationSection;
            //if (clientRuntimeConfigurationSection != null && clientRuntimeConfigurationSection.TypeAssemblies != null)
            //{
            //    foreach (AssemblyInfo assemblyInfo in clientRuntimeConfigurationSection.TypeAssemblies)
            //    {
            //        try
            //        {
            //            Assembly.Load(assemblyInfo.Assembly);
            //        }
            //        catch (Exception ex)
            //        {
            //            if (ScriptTypeMap.IsFatalException(ex))
            //            {
            //                throw;
            //            }
            //        }
            //    }
            //}
        }

        private static void LoadAssembliesDefinedInProgramFiles()
        {
            string text = ClientUtility.GetSetupDirectory();
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            text = Path.Combine(text, "TypeAssemblies");
            if (Directory.Exists(text))
            {
                string[] files = Directory.GetFiles(text, "ClientTypeAssembly.*.xml");
                for (int i = 0; i < files.Length; i++)
                {
                    string path = files[i];
                    try
                    {
                        using (TextReader textReader = System.IO.File.OpenText(path))
                        {
                            //XmlDocument xmlDocument = new XmlDocument();
                            //xmlDocument.Load(XmlReader.Create(textReader));
                            //foreach (XmlNode xmlNode in xmlDocument.DocumentElement.ChildNodes)
                            //{
                            //    if (xmlNode.NodeType == XmlNodeType.Element && xmlNode.Name == "AssemblyName")
                            //    {
                            //        Assembly.Load(xmlNode.InnerText);
                            //    }
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ScriptTypeMap.IsFatalException(ex))
                        {
                            throw;
                        }
                    }
                }
            }
        }

        private static void AppDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Assembly loadedAssembly = args.LoadedAssembly;
            //Edited for .NET Core
            //object[] customAttributes = loadedAssembly.GetCustomAttributes(typeof(ClientTypeAssemblyAttribute), false);
            var customAttributes = loadedAssembly.GetCustomAttributes<ClientTypeAssemblyAttribute>();
            if (customAttributes != null && customAttributes.Count() > 0)
            {
                ScriptTypeMap.AddClientProxyAssembly(loadedAssembly);
            }
        }

        internal static void AddClientProxyAssembly(Assembly assembly)
        {
            lock (ScriptTypeMap.s_lock)
            {
                if (!ScriptTypeMap.s_loadedAssemblies.ContainsKey(assembly.FullName))
                {
                    Type[] types = assembly.GetTypes();
                    for (int i = 0; i < types.Length; i++)
                    {
                        Type type = types[i];
                        //Edited for .NET Core
                        //if (type.IsClass)
                        if (type.GetTypeInfo().IsClass)
                        {
                        //Edited for .NET Core
                            //object[] customAttributes = type.GetCustomAttributes(typeof(ScriptTypeAttribute), false);
                            object[] customAttributes = type.GetTypeInfo().GetCustomAttributes<ScriptTypeAttribute>().ToArray();
                            if (customAttributes.Length > 0)
                            {
                                ScriptTypeAttribute scriptTypeAttribute = (ScriptTypeAttribute)customAttributes[0];
                        //Edited for .NET Core
                                //if (!string.IsNullOrEmpty(scriptTypeAttribute.ScriptType) && typeof(IFromJson).IsAssignableFrom(type))
                                if (!string.IsNullOrEmpty(scriptTypeAttribute.ScriptType) && typeof(IFromJson).GetTypeInfo().IsAssignableFrom(type))
                                {
                                    ScriptTypeMap.ScriptTypeInfo value = new ScriptTypeMap.ScriptTypeInfo(type, scriptTypeAttribute.ValueObject);
                                    ScriptTypeMap.s_clientProxies[scriptTypeAttribute.ScriptType] = value;
                                    if (!string.IsNullOrEmpty(scriptTypeAttribute.TypeAlias))
                                    {
                                        ScriptTypeMap.s_clientProxies[scriptTypeAttribute.TypeAlias] = value;
                                    }
                                    ScriptTypeMap.s_typeToScriptTypeMap[type] = value;
                                }
                            }
                        }
                    }
                    //Edited for .NET Core
                    //object[] customAttributes2 = assembly.GetCustomAttributes(typeof(ClientTypeAssemblyAttribute), false);
                    object[] customAttributes2 = assembly.GetCustomAttributes<ClientTypeAssemblyAttribute>().ToArray();
                    if (customAttributes2 != null || customAttributes2.Length != 0)
                    {
                        ClientTypeAssemblyAttribute clientTypeAssemblyAttribute = (ClientTypeAssemblyAttribute)customAttributes2[0];
                        if (clientTypeAssemblyAttribute.ScriptTypeFactory != null)
                        {
                            IScriptTypeFactory scriptTypeFactory = Activator.CreateInstance(clientTypeAssemblyAttribute.ScriptTypeFactory) as IScriptTypeFactory;
                            if (scriptTypeFactory != null)
                            {
                                ScriptTypeMap.s_scriptTypeFactories.Add(scriptTypeFactory);
                            }
                        }
                    }
                    ScriptTypeMap.s_loadedAssemblies[assembly.FullName] = null;
                }
            }
        }

        public static Type GetTypeFromScriptType(string scriptType)
        {
            ScriptTypeMap.EnsureInited();
            ScriptTypeMap.ScriptTypeInfo scriptTypeInfo = null;
            if (ScriptTypeMap.s_clientProxies.TryGetValue(scriptType, out scriptTypeInfo))
            {
                return scriptTypeInfo.Type;
            }
            return null;
        }

        public static IFromJson CreateObjectFromScriptType(string scriptType, ClientRuntimeContext context)
        {
            ScriptTypeMap.EnsureInited();
            foreach (IScriptTypeFactory current in ScriptTypeMap.s_scriptTypeFactories)
            {
                IFromJson fromJson = current.CreateObjectFromScriptType(scriptType, context);
                if (fromJson != null)
                {
                    IFromJson result = fromJson;
                    return result;
                }
            }
            ScriptTypeMap.ScriptTypeInfo scriptTypeInfo = null;
            if (ScriptTypeMap.s_clientProxies.TryGetValue(scriptType, out scriptTypeInfo))
            {
                IFromJson result2;
                if (scriptTypeInfo.ValueObject)
                {
                    result2 = (Activator.CreateInstance(scriptTypeInfo.Type) as IFromJson);
                }
                else
                {
                    Type arg_86_0 = scriptTypeInfo.Type;
                    object[] array = new object[2];
                    array[0] = context;
                    result2 = (Activator.CreateInstance(arg_86_0, array) as IFromJson);
                }
                return result2;
            }
            return null;
        }

        public static IFromJson CreateObjectFromFallbackScriptType(Type fallbackType, ClientRuntimeContext context)
        {
            ScriptTypeMap.EnsureInited();
            ScriptTypeMap.ScriptTypeInfo scriptTypeInfo = null;
            if (ScriptTypeMap.s_typeToScriptTypeMap.TryGetValue(fallbackType, out scriptTypeInfo))
            {
                IFromJson result;
                if (scriptTypeInfo.ValueObject)
                {
                    result = (Activator.CreateInstance(fallbackType) as IFromJson);
                }
                else
                {
                    object[] array = new object[2];
                    array[0] = context;
                    result = (Activator.CreateInstance(fallbackType, array) as IFromJson);
                }
                return result;
            }
            return null;
        }
    }
}
