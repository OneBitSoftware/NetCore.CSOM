using Microsoft.SharePoint.Client.NetCoreMime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public static class DataConvert
    {
        private delegate void WriteValueHandler(XmlWriter writer, object objValue);

        private static Dictionary<Type, DataConvert.WriteValueHandler> s_writeValueHandlers;

        private static Dictionary<Type, string> s_writeValueTypeNames;

        private static DataConvert.WriteValueHandler s_writeValueEnum;

        private static Dictionary<string, Type> s_strongTypedArrayElementTypeNames;

        internal static Dictionary<string, Type> StrongTypedArrayElementTypeNames
        {
            get
            {
                return DataConvert.s_strongTypedArrayElementTypeNames;
            }
        }

        static DataConvert()
        {
            DataConvert.s_writeValueHandlers = new Dictionary<Type, DataConvert.WriteValueHandler>();
            DataConvert.s_writeValueTypeNames = new Dictionary<Type, string>();
            DataConvert.s_writeValueHandlers[typeof(bool)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_Boolean);
            DataConvert.s_writeValueTypeNames[typeof(bool)] = "Boolean";
            DataConvert.s_writeValueHandlers[typeof(char)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_Char);
            DataConvert.s_writeValueTypeNames[typeof(char)] = "Char";
            DataConvert.s_writeValueHandlers[typeof(byte)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_Byte);
            DataConvert.s_writeValueTypeNames[typeof(byte)] = "Byte";
            DataConvert.s_writeValueHandlers[typeof(sbyte)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_SByte);
            DataConvert.s_writeValueTypeNames[typeof(sbyte)] = "SByte";
            DataConvert.s_writeValueHandlers[typeof(short)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_Int16);
            DataConvert.s_writeValueTypeNames[typeof(short)] = "Int16";
            DataConvert.s_writeValueHandlers[typeof(ushort)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_UInt16);
            DataConvert.s_writeValueTypeNames[typeof(ushort)] = "UInt16";
            DataConvert.s_writeValueHandlers[typeof(int)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_Int32);
            DataConvert.s_writeValueTypeNames[typeof(int)] = "Int32";
            DataConvert.s_writeValueHandlers[typeof(uint)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_UInt32);
            DataConvert.s_writeValueTypeNames[typeof(uint)] = "UInt32";
            DataConvert.s_writeValueHandlers[typeof(long)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_Int64);
            DataConvert.s_writeValueTypeNames[typeof(long)] = "Int64";
            DataConvert.s_writeValueHandlers[typeof(ulong)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_UInt64);
            DataConvert.s_writeValueTypeNames[typeof(ulong)] = "UInt64";
            DataConvert.s_writeValueHandlers[typeof(float)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_Single);
            DataConvert.s_writeValueTypeNames[typeof(float)] = "Single";
            DataConvert.s_writeValueHandlers[typeof(double)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_Double);
            DataConvert.s_writeValueTypeNames[typeof(double)] = "Double";
            DataConvert.s_writeValueHandlers[typeof(decimal)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_Decimal);
            DataConvert.s_writeValueTypeNames[typeof(decimal)] = "Decimal";
            DataConvert.s_writeValueHandlers[typeof(TimeSpan)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_TimeSpan);
            DataConvert.s_writeValueTypeNames[typeof(TimeSpan)] = "TimeSpan";
            DataConvert.s_writeValueHandlers[typeof(DateTime)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_DateTime);
            DataConvert.s_writeValueTypeNames[typeof(DateTime)] = "DateTime";
            DataConvert.s_writeValueHandlers[typeof(Guid)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_Guid);
            DataConvert.s_writeValueTypeNames[typeof(Guid)] = "Guid";
            DataConvert.s_writeValueHandlers[typeof(string)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_String);
            DataConvert.s_writeValueTypeNames[typeof(string)] = "String";
            DataConvert.s_writeValueHandlers[typeof(byte[])] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_ByteArray);
            DataConvert.s_writeValueTypeNames[typeof(byte[])] = "Base64Binary";
            DataConvert.s_writeValueHandlers[typeof(StringCollection)] = new DataConvert.WriteValueHandler(DataConvert.WriteValue_StringCollection);
            DataConvert.s_writeValueTypeNames[typeof(StringCollection)] = "Array";
            DataConvert.s_writeValueEnum = new DataConvert.WriteValueHandler(DataConvert.WriteValue_Enum);
            DataConvert.s_strongTypedArrayElementTypeNames = new Dictionary<string, Type>();
            DataConvert.s_strongTypedArrayElementTypeNames["Boolean"] = typeof(bool);
            DataConvert.s_strongTypedArrayElementTypeNames["Char"] = typeof(char);
            DataConvert.s_strongTypedArrayElementTypeNames["Byte"] = typeof(byte);
            DataConvert.s_strongTypedArrayElementTypeNames["SByte"] = typeof(sbyte);
            DataConvert.s_strongTypedArrayElementTypeNames["Int16"] = typeof(short);
            DataConvert.s_strongTypedArrayElementTypeNames["UInt16"] = typeof(ushort);
            DataConvert.s_strongTypedArrayElementTypeNames["Int32"] = typeof(int);
            DataConvert.s_strongTypedArrayElementTypeNames["UInt32"] = typeof(uint);
            DataConvert.s_strongTypedArrayElementTypeNames["Int64"] = typeof(long);
            DataConvert.s_strongTypedArrayElementTypeNames["UInt64"] = typeof(ulong);
            DataConvert.s_strongTypedArrayElementTypeNames["DateTime"] = typeof(DateTime);
            DataConvert.s_strongTypedArrayElementTypeNames["Single"] = typeof(float);
            DataConvert.s_strongTypedArrayElementTypeNames["Double"] = typeof(double);
            DataConvert.s_strongTypedArrayElementTypeNames["Decimal"] = typeof(decimal);
            DataConvert.s_strongTypedArrayElementTypeNames["Guid"] = typeof(Guid);
            DataConvert.s_strongTypedArrayElementTypeNames["String"] = typeof(string);
            DataConvert.s_strongTypedArrayElementTypeNames["TimeSpan"] = typeof(TimeSpan);
        }

        internal static string GetTypeName(Type type)
        {
            return DataConvert.s_writeValueTypeNames[type];
        }

        public static void WriteDictionaryToXml(XmlWriter writer, Dictionary<string, object> dict, string topLevelElementTagName, string[] keys, SerializationContext serializationContext)
        {
            if (!string.IsNullOrEmpty(topLevelElementTagName))
            {
                writer.WriteStartElement(topLevelElementTagName);
            }
            foreach (KeyValuePair<string, object> current in dict)
            {
                if (keys == null || Array.IndexOf<string>(keys, current.Key) >= 0)
                {
                    writer.WriteStartElement("Property");
                    writer.WriteAttributeString("Name", current.Key.ToString());
                    object value = current.Value;
                    DataConvert.WriteValueToXmlElement(writer, value, serializationContext);
                    writer.WriteEndElement();
                }
            }
            if (!string.IsNullOrEmpty(topLevelElementTagName))
            {
                writer.WriteEndElement();
            }
        }

        private static void WriteValue_Boolean(XmlWriter writer, object objValue)
        {
            writer.WriteValue((bool)objValue);
        }

        private static void WriteValue_Char(XmlWriter writer, object objValue)
        {
            writer.WriteValue(((char)objValue).ToString());
        }

        private static void WriteValue_Byte(XmlWriter writer, object objValue)
        {
            byte value = (byte)objValue;
            writer.WriteValue((int)value);
        }

        private static void WriteValue_ByteArray(XmlWriter writer, object objValue)
        {
            byte[] value = (byte[])objValue;
            writer.WriteValue(value);
        }

        private static void WriteValue_SByte(XmlWriter writer, object objValue)
        {
            sbyte value = (sbyte)objValue;
            writer.WriteValue((int)value);
        }

        private static void WriteValue_Int16(XmlWriter writer, object objValue)
        {
            short value = (short)objValue;
            writer.WriteValue((int)value);
        }

        private static void WriteValue_UInt16(XmlWriter writer, object objValue)
        {
            ushort value = (ushort)objValue;
            writer.WriteValue((int)value);
        }

        private static void WriteValue_Int32(XmlWriter writer, object objValue)
        {
            writer.WriteValue((int)objValue);
        }

        private static void WriteValue_UInt32(XmlWriter writer, object objValue)
        {
            uint num = (uint)objValue;
            writer.WriteValue((long)((ulong)num));
        }

        private static void WriteValue_Int64(XmlWriter writer, object objValue)
        {
            long value = (long)objValue;
            writer.WriteValue(value);
        }

        private static void WriteValue_UInt64(XmlWriter writer, object objValue)
        {
            writer.WriteString(((ulong)objValue).ToString(CultureInfo.InvariantCulture));
        }

        private static void WriteValue_Single(XmlWriter writer, object objValue)
        {
            float value = (float)objValue;
            writer.WriteValue(value);
        }

        private static void WriteValue_Double(XmlWriter writer, object objValue)
        {
            double value = (double)objValue;
            writer.WriteValue(value);
        }

        private static void WriteValue_Decimal(XmlWriter writer, object objValue)
        {
            decimal value = (decimal)objValue;
            writer.WriteValue(value);
        }

        private static void WriteValue_TimeSpan(XmlWriter writer, object objValue)
        {
            TimeSpan timeSpan = (TimeSpan)objValue;
            writer.WriteValue(timeSpan);
        }

        private static void WriteValue_DateTime(XmlWriter writer, object objValue)
        {
            string text = ((DateTime)objValue).ToString("o", CultureInfo.InvariantCulture);
            writer.WriteString(text);
        }

        private static void WriteValue_Guid(XmlWriter writer, object objValue)
        {
            writer.WriteString(((Guid)objValue).ToString("B"));
        }

        private static void WriteValue_String(XmlWriter writer, object objValue)
        {
            string text = (string)objValue;
            writer.WriteString(text);
        }

        private static void WriteValue_Enum(XmlWriter writer, object objValue)
        {
            Type underlyingType = Enum.GetUnderlyingType(objValue.GetType());
            object value = Convert.ChangeType(objValue, underlyingType, CultureInfo.InvariantCulture);
            writer.WriteValue(value);
        }

        private static void WriteValue_StringCollection(XmlWriter writer, object objValue)
        {
            StringCollection stringCollection = (StringCollection)objValue;
            foreach (string current in stringCollection)
            {
                if (current != null)
                {
                    writer.WriteStartElement("Object");
                    writer.WriteAttributeString("Type", typeof(string).FullName);
                    writer.WriteString(current);
                    writer.WriteEndElement();
                }
            }
        }

        public static void WriteValueToXmlElement(XmlWriter writer, object objValue, SerializationContext serializationContext)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (serializationContext == null)
            {
                throw new ArgumentNullException("serializationContext");
            }
            if (objValue == null)
            {
                writer.WriteAttributeString("Type", "Null");
                return;
            }
            if (!(objValue is ClientObject))
            {
                if (objValue is ClientValueObject)
                {
                    ClientValueObject clientValueObject = (ClientValueObject)objValue;
                    writer.WriteAttributeString("TypeId", clientValueObject.TypeId);
                    if (!clientValueObject.CustomWriteToXml(writer, serializationContext))
                    {
                        clientValueObject.WriteToXml(writer, serializationContext);
                        return;
                    }
                }
                else
                {
                    if (objValue is Stream)
                    {
                        Stream stream = (Stream)objValue;
                        writer.WriteAttributeString("Type", "Binary");
                        writer.WriteStartElement(MtomGlobals.XopIncludeLocalName);
                        string text = "http://sharepoint.microsoft.com/" + serializationContext.Context.NextSequenceId.ToString(CultureInfo.InvariantCulture);
                        serializationContext.AddStream(new StreamInfo(text, stream));
                        writer.WriteAttributeString(MtomGlobals.XopIncludeHrefLocalName, "cid:" + text);
                        writer.WriteEndElement();
                        return;
                    }
                    DataConvert.WriteValueHandler writeValueHandler = null;
                    if (DataConvert.s_writeValueHandlers.TryGetValue(objValue.GetType(), out writeValueHandler))
                    {
                        writer.WriteAttributeString("Type", DataConvert.s_writeValueTypeNames[objValue.GetType()]);
                        writeValueHandler(writer, objValue);
                        return;
                    }
                    if (objValue.GetType().IsArray)
                    {
                        writer.WriteAttributeString("Type", "Array");
                        //Edited for .NET Core
                        //using (IEnumerator enumerator = ((Array)objValue).GetEnumerator())
                        IEnumerator enumerator = ((Array)objValue).GetEnumerator();
                        {
                            while (enumerator.MoveNext())
                            {
                                object current = enumerator.Current;
                                writer.WriteStartElement("Object");
                                DataConvert.WriteValueToXmlElement(writer, current, serializationContext);
                                writer.WriteEndElement();
                            }
                            return;
                        }
                    }
                    if (objValue is IDictionary)
                    {
                        writer.WriteAttributeString("Type", "Dictionary");
                        IDictionary dictionary = objValue as IDictionary;
                        IDictionaryEnumerator enumerator2 = dictionary.GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            object value = enumerator2.Value;
                            if (DataConvert.CouldSerializeDictionaryEntry(value) && enumerator2.Key is string)
                            {
                                writer.WriteStartElement("Property");
                                writer.WriteAttributeString("Name", (string)enumerator2.Key);
                                DataConvert.WriteValueToXmlElement(writer, enumerator2.Value, serializationContext);
                                writer.WriteEndElement();
                            }
                        }
                        return;
                    }
                    //Edited for .NET Core
                    //if (typeof(IEnumerable).IsAssignableFrom(objValue.GetType()) && ExpressionUtility.GetElementType(objValue.GetType()) != null)

                    if (typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(objValue.GetType()) && ExpressionUtility.GetElementType(objValue.GetType()) != null)
                    {
                        writer.WriteAttributeString("Type", "Array");
                        //Edited for .NET Core
                        //using (IEnumerator enumerator3 = ((IEnumerable)objValue).GetEnumerator())
                        IEnumerator enumerator3 = ((IEnumerable)objValue).GetEnumerator();
                        {
                            while (enumerator3.MoveNext())
                            {
                                object current2 = enumerator3.Current;
                                writer.WriteStartElement("Object");
                                DataConvert.WriteValueToXmlElement(writer, current2, serializationContext);
                                writer.WriteEndElement();
                            }
                            return;
                        }
                    }
                    Type type = objValue.GetType();
                        //Edited for .NET Core
                    //if (type.IsEnum)
                    if (type.GetTypeInfo().IsEnum)
                    {
                        writer.WriteAttributeString("Type", "Enum");
                        DataConvert.s_writeValueEnum(writer, objValue);
                        return;
                    }
                    writer.WriteAttributeString("Type", "Unspecified");
                    writer.WriteString(objValue.ToString());
                }
                return;
            }
            ClientObject clientObject = (ClientObject)objValue;
            if (clientObject.Path == null)
            {
                throw new ClientRequestException(Resources.GetString("NoObjectPathAssociatedWithObject"));
            }
            ClientAction.CheckActionParameterInContext(serializationContext.Context, clientObject);
            writer.WriteAttributeString("ObjectPathId", clientObject.Path.Id.ToString(CultureInfo.InvariantCulture));
            serializationContext.AddClientObject(clientObject);
        }

        private static bool CouldSerializeDictionaryEntry(object objValue)
        {
            if (objValue == null)
            {
                return true;
            }
            if (objValue is ClientObject || objValue is ClientValueObject)
            {
                return true;
            }
            Type type = objValue.GetType();
            //Edited for .NET Core
            //if (type.IsPrimitive || type.IsEnum || type == typeof(Guid) || type == typeof(decimal) || type == typeof(TimeSpan) || type == typeof(DateTime) || type == typeof(string))
            if (type.GetTypeInfo().IsPrimitive || type.GetTypeInfo().IsEnum || type == typeof(Guid) || type == typeof(decimal) || type == typeof(TimeSpan) || type == typeof(DateTime) || type == typeof(string))
            {
                return true;
            }
            if (type.IsArray)
            {
                Type elementType = type.GetElementType();
            //Edited for .NET Core
                //if (elementType.IsPrimitive || elementType.IsEnum || elementType == typeof(Guid) || elementType == typeof(decimal) || elementType == typeof(DateTime) || elementType == typeof(TimeSpan) || elementType == typeof(string))
                if (elementType.GetTypeInfo().IsPrimitive || elementType.GetTypeInfo().IsEnum || elementType == typeof(Guid) || elementType == typeof(decimal) || elementType == typeof(DateTime) || elementType == typeof(TimeSpan) || elementType == typeof(string))
                {
                    return true;
                }
            }
            return false;
        }

        internal static void GetTypeNameOrTypeId(Type type, out string typeName, out string typeId)
        {
            typeName = null;
            typeId = null;
            //Edited for .NET Core
            //if (type.IsEnum)
            if (type.GetTypeInfo().IsEnum)
            {
                type = Enum.GetUnderlyingType(type);
            }
            if (type.GetTypeInfo().IsPrimitive || type == typeof(string) || type == typeof(decimal) || type == typeof(DateTime))
            {
                typeName = DataConvert.GetTypeName(type);
                return;
            }
            //Edited for .NET Core
            //ScriptTypeAttribute scriptTypeAttribute = (ScriptTypeAttribute)Attribute.GetCustomAttribute(type, typeof(ScriptTypeAttribute));
            ScriptTypeAttribute scriptTypeAttribute = type.GetTypeInfo().GetCustomAttribute<ScriptTypeAttribute>();
            if (scriptTypeAttribute != null)
            {
                typeId = scriptTypeAttribute.ServerTypeId;
            }
        }
    }
}
