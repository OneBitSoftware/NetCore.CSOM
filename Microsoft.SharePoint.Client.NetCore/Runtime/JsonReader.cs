using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Net;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public sealed class JsonReader : IDisposable
    {
        private delegate object ReadObjectHandler(JsonReader reader);

        private static class ReadObjectHandlers
        {
            private static Dictionary<Type, JsonReader.ReadObjectHandler> s_handlers;

            static ReadObjectHandlers()
            {
                JsonReader.ReadObjectHandlers.s_handlers = new Dictionary<Type, JsonReader.ReadObjectHandler>();
                JsonReader.ReadObjectHandlers.s_handlers[typeof(bool)] = new JsonReader.ReadObjectHandler(JsonReader.Read_Boolean);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(byte)] = new JsonReader.ReadObjectHandler(JsonReader.Read_Byte);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(char)] = new JsonReader.ReadObjectHandler(JsonReader.Read_Char);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(short)] = new JsonReader.ReadObjectHandler(JsonReader.Read_Int16);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(ushort)] = new JsonReader.ReadObjectHandler(JsonReader.Read_UInt16);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(int)] = new JsonReader.ReadObjectHandler(JsonReader.Read_Int32);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(uint)] = new JsonReader.ReadObjectHandler(JsonReader.Read_UInt32);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(long)] = new JsonReader.ReadObjectHandler(JsonReader.Read_Int64);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(ulong)] = new JsonReader.ReadObjectHandler(JsonReader.Read_UInt64);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(float)] = new JsonReader.ReadObjectHandler(JsonReader.Read_Single);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(double)] = new JsonReader.ReadObjectHandler(JsonReader.Read_Double);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(decimal)] = new JsonReader.ReadObjectHandler(JsonReader.Read_Decimal);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(TimeSpan)] = new JsonReader.ReadObjectHandler(JsonReader.Read_TimeSpan);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(DateTime)] = new JsonReader.ReadObjectHandler(JsonReader.Read_DateTime);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(Guid)] = new JsonReader.ReadObjectHandler(JsonReader.Read_Guid);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(string)] = new JsonReader.ReadObjectHandler(JsonReader.Read_String);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(bool[])] = new JsonReader.ReadObjectHandler(JsonReader.Read_BooleanArray);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(byte[])] = new JsonReader.ReadObjectHandler(JsonReader.Read_ByteArray);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(short[])] = new JsonReader.ReadObjectHandler(JsonReader.Read_Int16Array);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(ushort[])] = new JsonReader.ReadObjectHandler(JsonReader.Read_UInt16Array);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(int[])] = new JsonReader.ReadObjectHandler(JsonReader.Read_Int32Array);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(uint[])] = new JsonReader.ReadObjectHandler(JsonReader.Read_UInt32Array);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(long[])] = new JsonReader.ReadObjectHandler(JsonReader.Read_Int64Array);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(ulong[])] = new JsonReader.ReadObjectHandler(JsonReader.Read_UInt64Array);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(float[])] = new JsonReader.ReadObjectHandler(JsonReader.Read_SingleArray);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(double[])] = new JsonReader.ReadObjectHandler(JsonReader.Read_DoubleArray);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(decimal[])] = new JsonReader.ReadObjectHandler(JsonReader.Read_DecimalArray);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(TimeSpan[])] = new JsonReader.ReadObjectHandler(JsonReader.Read_TimeSpanArray);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(DateTime[])] = new JsonReader.ReadObjectHandler(JsonReader.Read_DateTimeArray);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(Guid[])] = new JsonReader.ReadObjectHandler(JsonReader.Read_GuidArray);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(string[])] = new JsonReader.ReadObjectHandler(JsonReader.Read_StringArray);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(StringCollection)] = new JsonReader.ReadObjectHandler(JsonReader.Read_StringCollection);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(Stream)] = new JsonReader.ReadObjectHandler(JsonReader.Read_StreamLink);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(Dictionary<string, object>)] = new JsonReader.ReadObjectHandler(JsonReader.Read_Dictionary);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(XElement)] = new JsonReader.ReadObjectHandler(JsonReader.Read_XElement);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(XDocument)] = new JsonReader.ReadObjectHandler(JsonReader.Read_XDocument);
                JsonReader.ReadObjectHandlers.s_handlers[typeof(SimpleDataTable)] = new JsonReader.ReadObjectHandler(JsonReader.Read_SimpleDataTable);
            }

            public static JsonReader.ReadObjectHandler GetReadObjectHandler(Type type)
            {
                JsonReader.ReadObjectHandler result = null;
                if (JsonReader.ReadObjectHandlers.s_handlers.TryGetValue(type, out result))
                {
                    return result;
                }
                return null;
            }
        }

        private class Token
        {
            private JsonTokenType m_tokenType;

            private int m_position;

            private string m_stringValue;

            private long m_longValue;

            private ulong m_ulongValue;

            private double m_doubleValue;

            private bool m_boolValue;

            private DateTime m_dateTimeValue;

            private Guid m_guidValue;

            private byte[] m_byteArrayValue;

            public JsonTokenType Type
            {
                get
                {
                    return this.m_tokenType;
                }
            }

            public int Position
            {
                get
                {
                    return this.m_position;
                }
            }

            public string StringValue
            {
                get
                {
                    if ((this.m_tokenType == JsonTokenType.Name || this.m_tokenType == JsonTokenType.String || this.m_tokenType == JsonTokenType.StreamLink) && this.m_stringValue != null)
                    {
                        return this.m_stringValue;
                    }
                    throw new InvalidOperationException();
                }
                set
                {
                    if ((this.m_tokenType == JsonTokenType.Name || this.m_tokenType == JsonTokenType.String || this.m_tokenType == JsonTokenType.StreamLink) && value != null)
                    {
                        this.m_stringValue = value;
                    }
                }
            }

            public long LongValue
            {
                get
                {
                    if (this.m_tokenType == JsonTokenType.Long)
                    {
                        return this.m_longValue;
                    }
                    throw new InvalidOperationException();
                }
                set
                {
                    if (this.m_tokenType == JsonTokenType.Long)
                    {
                        this.m_longValue = value;
                        return;
                    }
                    throw new InvalidOperationException();
                }
            }

            public ulong ULongValue
            {
                get
                {
                    if (this.m_tokenType == JsonTokenType.ULong)
                    {
                        return this.m_ulongValue;
                    }
                    throw new InvalidOperationException();
                }
                set
                {
                    if (this.m_tokenType == JsonTokenType.ULong)
                    {
                        this.m_ulongValue = value;
                        return;
                    }
                    throw new InvalidOperationException();
                }
            }

            public double DoubleValue
            {
                get
                {
                    if (this.m_tokenType == JsonTokenType.Double)
                    {
                        return this.m_doubleValue;
                    }
                    throw new InvalidOperationException();
                }
                set
                {
                    if (this.m_tokenType == JsonTokenType.Double)
                    {
                        this.m_doubleValue = value;
                        return;
                    }
                    throw new InvalidOperationException();
                }
            }

            public bool BoolValue
            {
                get
                {
                    if (this.m_tokenType == JsonTokenType.Boolean)
                    {
                        return this.m_boolValue;
                    }
                    throw new InvalidOperationException();
                }
                set
                {
                    if (this.m_tokenType == JsonTokenType.Boolean)
                    {
                        this.m_boolValue = value;
                        return;
                    }
                    throw new InvalidOperationException();
                }
            }

            public DateTime DateTimeValue
            {
                get
                {
                    if (this.m_tokenType == JsonTokenType.DateTime)
                    {
                        return this.m_dateTimeValue;
                    }
                    throw new InvalidOperationException();
                }
                set
                {
                    if (this.m_tokenType == JsonTokenType.DateTime)
                    {
                        this.m_dateTimeValue = value;
                        return;
                    }
                    throw new InvalidOperationException();
                }
            }

            public Guid GuidValue
            {
                get
                {
                    if (this.m_tokenType == JsonTokenType.Guid)
                    {
                        return this.m_guidValue;
                    }
                    throw new InvalidOperationException();
                }
                set
                {
                    if (this.m_tokenType == JsonTokenType.Guid)
                    {
                        this.m_guidValue = value;
                        return;
                    }
                    throw new InvalidOperationException();
                }
            }

            public byte[] ByteArrayValue
            {
                get
                {
                    if (this.m_tokenType == JsonTokenType.ByteArray)
                    {
                        return this.m_byteArrayValue;
                    }
                    throw new InvalidOperationException();
                }
                set
                {
                    if (this.m_tokenType == JsonTokenType.ByteArray)
                    {
                        this.m_byteArrayValue = value;
                        return;
                    }
                    throw new InvalidOperationException();
                }
            }

            public Token(JsonTokenType tokenType, int position)
            {
                this.m_tokenType = tokenType;
                this.m_position = position;
            }
        }

        private enum ScopeType
        {
            Array,
            Object
        }

        private sealed class Scope
        {
            private int _objectCount;

            private JsonReader.ScopeType _type;

            public int ObjectCount
            {
                get
                {
                    return this._objectCount;
                }
                set
                {
                    this._objectCount = value;
                }
            }

            public JsonReader.ScopeType Type
            {
                get
                {
                    return this._type;
                }
            }

            public Scope(JsonReader.ScopeType type)
            {
                this._type = type;
            }
        }

        private const string DateTimePrefix = "\"\\/Date(";

        private const string GuidPrefix = "\"\\/Guid(";

        private const string ByteArrayPrefix = "\"\\/Base64Binary(";

        private const string StreamLinkPrefix = "\"\\/Binary(";

        internal static readonly long MinDateTimeTicks = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;

        //Edited for .NET Core
        private static string MinDoubleValueAsString = "-1.7976931348623157E+308";//.ToString(CultureInfo.InvariantCulture);

        private static string MaxDoubleValueAsString = 1.7976931348623157E+308.ToString(CultureInfo.InvariantCulture);

        private TextPeekReader m_reader;

        private char[] m_tokenBuffer;

        private Stack<JsonReader.Scope> m_scopes = new Stack<JsonReader.Scope>();

        private JsonReaderOptions m_options;

        private ClientRuntimeContext m_runtimeContext;

        private static MethodInfo s_readDictionaryMethod;

        private List<JsonReader.Token> m_peekedTokens = new List<JsonReader.Token>();

        private static char[] s_DateTimeComponentSeparator = new char[]
        {
            ','
        };

        private long[] m_dateTimeComponents = new long[7];

        private char[] m_dateTimeSigns = new char[7];

        private char[] m_dateTimeHhmm = new char[4];

        private byte[] m_tryReadGuidByteBuf = new byte[8];

        private long[] m_tryReadGuidIntBuf = new long[3];

        private static int DateTimePrefixLength = "\"\\/Date(".Length;

        private static int GuidPrefixLength = "\"\\/Guid(".Length;

        private static int ByteArrayPrefixLength = "\"\\/Base64Binary(".Length;

        private static int StreamLinkPrefixLength = "\"\\/Binary(".Length;

        private StringBuilder m_decodeStringBuf = new StringBuilder();

        private char[] m_decodeStringHexChars = new char[4];

        public ClientRuntimeContext Context
        {
            get
            {
                return this.m_runtimeContext;
            }
        }

        private static MethodInfo ReadDictionaryMethod
        {
            get
            {
                MethodInfo methodInfo = JsonReader.s_readDictionaryMethod;
                if (methodInfo == null)
                {
                    //Edited for .NET Core
                    //MethodInfo[] methods = typeof(JsonReader).GetMethods(BindingFlags.Instance | BindingFlags.Public);
                    MethodInfo[] methods = typeof(JsonReader).GetTypeInfo().GetMethods(BindingFlags.Instance | BindingFlags.Public);
                    for (int i = 0; i < methods.Length; i++)
                    {
                        MethodInfo methodInfo2 = methods[i];
                        if (methodInfo2.Name == "ReadDictionary" && methodInfo2.IsGenericMethod)
                        {
                            methodInfo = methodInfo2;
                            break;
                        }
                    }
                    JsonReader.s_readDictionaryMethod = methodInfo;
                }
                return methodInfo;
            }
        }

        public JsonReader(TextReader reader, ClientRuntimeContext runtimeContext)
        {
            this.m_reader = new TextPeekReader(reader);
            this.m_tokenBuffer = new char[64];
            this.m_runtimeContext = runtimeContext;
            this.SkipWhiteSpace();
            this.m_options = JsonReaderOptions.None;
        }

        public bool ReadBoolean()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.Boolean)
            {
                return token.BoolValue;
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_Boolean(JsonReader reader)
        {
            return reader.ReadBoolean();
        }

        public byte ReadByte()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.Long)
            {
                return (byte)token.LongValue;
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_Byte(JsonReader reader)
        {
            return reader.ReadByte();
        }

        public char ReadChar()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.String)
            {
                return token.StringValue[0];
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_Char(JsonReader reader)
        {
            return reader.ReadChar();
        }

        public short ReadInt16()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.Long)
            {
                return (short)token.LongValue;
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_Int16(JsonReader reader)
        {
            return reader.ReadInt16();
        }

        public ushort ReadUInt16()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.Long)
            {
                return (ushort)token.LongValue;
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_UInt16(JsonReader reader)
        {
            return reader.ReadUInt16();
        }

        public int ReadInt32()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.Long)
            {
                return (int)token.LongValue;
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_Int32(JsonReader reader)
        {
            return reader.ReadInt32();
        }

        public uint ReadUInt32()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.Long)
            {
                return (uint)token.LongValue;
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_UInt32(JsonReader reader)
        {
            return reader.ReadUInt32();
        }

        public long ReadInt64()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.Long)
            {
                return token.LongValue;
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_Int64(JsonReader reader)
        {
            return reader.ReadInt64();
        }

        public ulong ReadUInt64()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.Long)
            {
                return (ulong)token.LongValue;
            }
            if (token.Type == JsonTokenType.ULong)
            {
                return token.ULongValue;
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_UInt64(JsonReader reader)
        {
            return reader.ReadUInt64();
        }

        public float ReadSingle()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.Long)
            {
                return (float)token.LongValue;
            }
            if (token.Type == JsonTokenType.ULong)
            {
                return token.ULongValue;
            }
            if (token.Type == JsonTokenType.Double)
            {
                return (float)token.DoubleValue;
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_Single(JsonReader reader)
        {
            return reader.ReadSingle();
        }

        public double ReadDouble()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.Long)
            {
                return (double)token.LongValue;
            }
            if (token.Type == JsonTokenType.ULong)
            {
                return token.ULongValue;
            }
            if (token.Type == JsonTokenType.Double)
            {
                return token.DoubleValue;
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_Double(JsonReader reader)
        {
            return reader.ReadDouble();
        }

        public decimal ReadDecimal()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.String)
            {
                return decimal.Parse(token.StringValue, CultureInfo.InvariantCulture);
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_Decimal(JsonReader reader)
        {
            return reader.ReadDecimal();
        }

        public TimeSpan ReadTimeSpan()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.String)
            {
                return XmlConvert.ToTimeSpan(token.StringValue);
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_TimeSpan(JsonReader reader)
        {
            return reader.ReadTimeSpan();
        }

        public DateTime ReadDateTime()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.DateTime)
            {
                return token.DateTimeValue;
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_DateTime(JsonReader reader)
        {
            return reader.ReadDateTime();
        }

        public Guid ReadGuid()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.Guid)
            {
                return token.GuidValue;
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_Guid(JsonReader reader)
        {
            return reader.ReadGuid();
        }

        public byte[] ReadByteArray()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type == JsonTokenType.ByteArray)
            {
                return token.ByteArrayValue;
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_ByteArray(JsonReader reader)
        {
            return reader.ReadByteArray();
        }

        public Stream ReadStream()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.StreamLink)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            if (this.Context == null || string.IsNullOrEmpty(token.StringValue))
            {
                return null;
            }
            return new AttachmentStreamFromServer(this.Context, token.StringValue);
        }

        private static object Read_StreamLink(JsonReader reader)
        {
            return reader.ReadStream();
        }

        public string ReadString()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.String)
            {
                return token.StringValue;
            }
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        private static object Read_String(JsonReader reader)
        {
            return reader.ReadString();
        }

        public T ReadEnum<T>()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.Long)
            {
                Type underlyingType = Enum.GetUnderlyingType(typeof(T));
                object obj = Convert.ChangeType(token.LongValue, underlyingType, CultureInfo.InvariantCulture);
                return (T)((object)obj);
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        public JsonTokenType PeekTokenType()
        {
            JsonReader.Token token = this.PeekToken();
            return token.Type;
        }

        internal bool PeekObjectType(out string objectType)
        {
            objectType = null;
            JsonReader.Token token = this.PeekToken(0);
            if (token.Type != JsonTokenType.ObjectStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            JsonReader.Token token2 = this.PeekToken(1);
            if (token2.Type != JsonTokenType.Name)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token2.Position
                }));
            }
            if (!(token2.StringValue == "_ObjectType_"))
            {
                return false;
            }
            JsonReader.Token token3 = this.PeekToken(2);
            if (token3.Type != JsonTokenType.String)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token3.Position
                }));
            }
            objectType = token3.StringValue;
            return true;
        }

        private int PeekTokenPosition()
        {
            JsonReader.Token token = this.PeekToken();
            return token.Position;
        }

        public void ReadArrayStart()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
        }

        public void ReadArrayEnd()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type != JsonTokenType.ArrayEnd)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
        }

        public void ReadObjectStart()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type != JsonTokenType.ObjectStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
        }

        public string ReadName()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.Name)
            {
                return token.StringValue;
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        public string PeekName()
        {
            JsonReader.Token token = this.PeekToken();
            if (token.Type == JsonTokenType.Name)
            {
                return token.StringValue;
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        public void ReadObjectEnd()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type != JsonTokenType.ObjectEnd)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
        }

        public bool[] ReadBooleanArray()
        {
            JsonReader.Token token = this.ReadToken();
            List<bool> list = new List<bool>();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.ReadBoolean());
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        private static object Read_BooleanArray(JsonReader reader)
        {
            return reader.ReadBooleanArray();
        }

        public short[] ReadInt16Array()
        {
            JsonReader.Token token = this.ReadToken();
            List<short> list = new List<short>();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.ReadInt16());
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        private static object Read_Int16Array(JsonReader reader)
        {
            return reader.ReadInt16Array();
        }

        public ushort[] ReadUInt16Array()
        {
            JsonReader.Token token = this.ReadToken();
            List<ushort> list = new List<ushort>();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.ReadUInt16());
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        private static object Read_UInt16Array(JsonReader reader)
        {
            return reader.ReadUInt16Array();
        }

        public int[] ReadInt32Array()
        {
            JsonReader.Token token = this.ReadToken();
            List<int> list = new List<int>();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.ReadInt32());
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        private static object Read_Int32Array(JsonReader reader)
        {
            return reader.ReadInt32Array();
        }

        public uint[] ReadUInt32Array()
        {
            JsonReader.Token token = this.ReadToken();
            List<uint> list = new List<uint>();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.ReadUInt32());
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        private static object Read_UInt32Array(JsonReader reader)
        {
            return reader.ReadUInt32Array();
        }

        public long[] ReadInt64Array()
        {
            JsonReader.Token token = this.ReadToken();
            List<long> list = new List<long>();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.ReadInt64());
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        private static object Read_Int64Array(JsonReader reader)
        {
            return reader.ReadInt64Array();
        }

        public ulong[] ReadUInt64Array()
        {
            JsonReader.Token token = this.ReadToken();
            List<ulong> list = new List<ulong>();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.ReadUInt64());
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        private static object Read_UInt64Array(JsonReader reader)
        {
            return reader.ReadUInt64Array();
        }

        public float[] ReadSingleArray()
        {
            JsonReader.Token token = this.ReadToken();
            List<float> list = new List<float>();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.ReadSingle());
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        private static object Read_SingleArray(JsonReader reader)
        {
            return reader.ReadSingleArray();
        }

        public double[] ReadDoubleArray()
        {
            JsonReader.Token token = this.ReadToken();
            List<double> list = new List<double>();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.ReadDouble());
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        private static object Read_DoubleArray(JsonReader reader)
        {
            return reader.ReadDoubleArray();
        }

        public decimal[] ReadDecimalArray()
        {
            JsonReader.Token token = this.ReadToken();
            List<decimal> list = new List<decimal>();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.ReadDecimal());
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        private static object Read_DecimalArray(JsonReader reader)
        {
            return reader.ReadDecimalArray();
        }

        public TimeSpan[] ReadTimeSpanArray()
        {
            JsonReader.Token token = this.ReadToken();
            List<TimeSpan> list = new List<TimeSpan>();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.ReadTimeSpan());
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        private static object Read_TimeSpanArray(JsonReader reader)
        {
            return reader.ReadTimeSpanArray();
        }

        public DateTime[] ReadDateTimeArray()
        {
            JsonReader.Token token = this.ReadToken();
            List<DateTime> list = new List<DateTime>();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.ReadDateTime());
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        private static object Read_DateTimeArray(JsonReader reader)
        {
            return reader.ReadDateTimeArray();
        }

        public Guid[] ReadGuidArray()
        {
            JsonReader.Token token = this.ReadToken();
            List<Guid> list = new List<Guid>();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.ReadGuid());
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        private static object Read_GuidArray(JsonReader reader)
        {
            return reader.ReadGuidArray();
        }

        public string[] ReadStringArray()
        {
            JsonReader.Token token = this.ReadToken();
            List<string> list = new List<string>();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.ReadString());
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        private static object Read_StringArray(JsonReader reader)
        {
            return reader.ReadStringArray();
        }

        public T[] ReadEnumArray<T>()
        {
            JsonReader.Token token = this.ReadToken();
            List<T> list = new List<T>();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.ReadEnum<T>());
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        public StringCollection ReadStringCollection()
        {
            string[] array = this.ReadStringArray();
            if (array == null)
            {
                return null;
            }
            StringCollection stringCollection = new StringCollection();
            stringCollection.AddRange(array);
            return stringCollection;
        }

        private static object Read_StringCollection(JsonReader reader)
        {
            return reader.ReadStringCollection();
        }

        public Dictionary<string, T> ReadDictionary<T>()
        {
            Dictionary<string, object> dictionary = this.ReadDictionary();
            if (dictionary == null)
            {
                return null;
            }
            Dictionary<string, T> dictionary2 = new Dictionary<string, T>();
            foreach (KeyValuePair<string, object> current in dictionary)
            {
                //Edited for .NET Core
                //if (current.Value == null && !typeof(T).IsValueType)
                if (current.Value == null && !typeof(T).GetTypeInfo().IsValueType)
                {
                    dictionary2[current.Key] = default(T);
                }
                else if (current.Value is T)
                {
                    dictionary2[current.Key] = (T)((object)current.Value);
                }
            }
            return dictionary2;
        }

        private static object Read_Dictionary(JsonReader reader)
        {
            return reader.ReadDictionary();
        }

        public Dictionary<string, object> ReadDictionary()
        {
            JsonReader.Token token = this.PeekToken();
            if (token.Type == JsonTokenType.Null)
            {
                this.ReadToken();
                return null;
            }
            this.ReadObjectStart();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            while (this.PeekToken().Type != JsonTokenType.ObjectEnd)
            {
                KeyValuePair<string, object> keyValuePair = this.ReadKeyValue();
                if (!(keyValuePair.Key == "_ObjectType_") || !(keyValuePair.Value is string))
                {
                    dictionary[keyValuePair.Key] = keyValuePair.Value;
                }
            }
            this.ReadObjectEnd();
            return dictionary;
        }

        private XElement ReadXElement()
        {
            JsonReader.Token token = this.PeekToken();
            if (token.Type == JsonTokenType.Null)
            {
                this.ReadToken();
                return null;
            }
            XDocument parent = new XDocument();
            return this.ReadXmlElement(parent);
        }

        private XDocument ReadXDocument()
        {
            JsonReader.Token token = this.PeekToken();
            if (token.Type == JsonTokenType.Null)
            {
                this.ReadToken();
                return null;
            }
            XDocument xDocument = new XDocument();
            this.ReadXmlElement(xDocument);
            return xDocument;
        }

        private static object Read_XElement(JsonReader reader)
        {
            return reader.ReadXElement();
        }

        private static object Read_XDocument(JsonReader reader)
        {
            return reader.ReadXDocument();
        }

        private XElement ReadXmlElement(XContainer parent)
        {
            this.ReadObjectStart();
            while (this.ReadName() != "Name")
            {
                this.ReadString();
            }
            XElement xElement = new XElement(this.ReadString());
            parent.Add(xElement);
            JsonReader.Token token;
            while ((token = this.PeekToken()).Type != JsonTokenType.ObjectEnd)
            {
                string a = this.ReadName();
                if (a == "Attributes")
                {
                    this.ReadXmlAttributes(xElement);
                }
                else
                {
                    if (!(a == "Children"))
                    {
                        throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                        {
                            token.Position
                        }));
                    }
                    this.ReadXmlChildren(xElement);
                }
            }
            this.ReadObjectEnd();
            return xElement;
        }

        private void ReadXmlAttributes(XElement elem)
        {
            JsonReader.Token token = this.PeekToken();
            if (token.Type == JsonTokenType.Null)
            {
                this.ReadToken();
                return;
            }
            this.ReadObjectStart();
            while (this.PeekToken().Type != JsonTokenType.ObjectEnd)
            {
                string expandedName = this.ReadName();
                string value = this.ReadString();
                elem.Add(new XAttribute(expandedName, value));
            }
            this.ReadObjectEnd();
        }

        private void ReadXmlChildren(XElement parent)
        {
            JsonReader.Token token = this.PeekToken();
            if (token.Type == JsonTokenType.Null)
            {
                this.ReadToken();
                return;
            }
            this.ReadArrayStart();
            while ((token = this.PeekToken()).Type != JsonTokenType.ArrayEnd)
            {
                if (token.Type == JsonTokenType.String)
                {
                    this.ReadToken();
                    parent.Add(token.StringValue);
                }
                else
                {
                    this.ReadXmlElement(parent);
                }
            }
            this.ReadArrayEnd();
        }

        private SimpleDataTable ReadSimpleDataTable()
        {
            JsonReader.Token token = this.PeekToken();
            if (token.Type == JsonTokenType.Null)
            {
                this.ReadToken();
                return null;
            }
            SimpleDataTable simpleDataTable = new SimpleDataTable();
            this.ReadObjectStart();
            while (this.PeekToken().Type != JsonTokenType.ObjectEnd)
            {
                string a = this.ReadName();
                if (a == "Rows")
                {
                    List<Dictionary<string, object>> list = this.ReadList<Dictionary<string, object>>();
                    if (list == null)
                    {
                        continue;
                    }
                    using (List<Dictionary<string, object>>.Enumerator enumerator = list.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            Dictionary<string, object> current = enumerator.Current;
                            simpleDataTable.Rows.Add(current);
                        }
                        continue;
                    }
                }
                this.ReadObject();
            }
            this.ReadObjectEnd();
            return simpleDataTable;
        }

        private static object Read_SimpleDataTable(JsonReader reader)
        {
            return reader.ReadSimpleDataTable();
        }

        private object ReadJsonObject(Type fallbackType)
        {
            JsonReader.Token token = this.PeekToken();
            JsonReader.Token token2 = this.PeekToken(1);
            JsonReader.Token token3 = this.PeekToken(2);
            if (token.Type == JsonTokenType.ObjectStart && token2.Type == JsonTokenType.Name && token2.StringValue == "_ObjectType_" && token3.Type == JsonTokenType.String && this.Context != null)
            {
                string stringValue;
                if ((stringValue = token3.StringValue) != null)
                {
                    if (stringValue == "SP.ClientXDocument")
                    {
                        return this.ReadXDocument();
                    }
                    if (stringValue == "SP.ClientXElement")
                    {
                        return this.ReadXElement();
                    }
                    if (stringValue == "SP.SimpleDataTable")
                    {
                        return this.ReadSimpleDataTable();
                    }
                }
                IFromJson fromJson = ScriptTypeMap.CreateObjectFromScriptType(token3.StringValue, this.Context);
                if (fromJson == null && fallbackType != null && fallbackType != typeof(object))
                {
                    fromJson = ScriptTypeMap.CreateObjectFromFallbackScriptType(fallbackType, this.Context);
                }
                if (fromJson != null)
                {
                    if (!fromJson.CustomFromJson(this))
                    {
                        fromJson.FromJson(this);
                    }
                    return fromJson;
                }
            }
            this.ReadObjectStart();
            Dictionary<string, object> dictionary = null;
            while (this.PeekToken().Type != JsonTokenType.ObjectEnd)
            {
                KeyValuePair<string, object> keyValuePair = this.ReadKeyValue();
                if (dictionary == null)
                {
                    dictionary = new Dictionary<string, object>();
                }
                dictionary[keyValuePair.Key] = keyValuePair.Value;
            }
            this.ReadObjectEnd();
            if (dictionary == null)
            {
                dictionary = new Dictionary<string, object>();
            }
            return dictionary;
        }

        public KeyValuePair<string, object> ReadKeyValue()
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type != JsonTokenType.Name)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            string text = token.StringValue;
            object value = null;
            bool flag = false;
            if (text.Length > 8 && text[text.Length - 8] == '$')
            {
                string text2 = text.Substring(text.Length - 8);
                string key;
                switch (key = text2)
                {
                    case "$   Byte":
                        text = text.Substring(0, text.Length - 8);
                        value = this.ReadByte();
                        flag = true;
                        break;
                    case "$   Char":
                        text = text.Substring(0, text.Length - 8);
                        value = this.ReadChar();
                        flag = true;
                        break;
                    case "$  Int16":
                        text = text.Substring(0, text.Length - 8);
                        value = this.ReadInt16();
                        flag = true;
                        break;
                    case "$ UInt16":
                        text = text.Substring(0, text.Length - 8);
                        value = this.ReadUInt16();
                        flag = true;
                        break;
                    case "$  Int32":
                        text = text.Substring(0, text.Length - 8);
                        value = this.ReadInt32();
                        flag = true;
                        break;
                    case "$ UInt32":
                        text = text.Substring(0, text.Length - 8);
                        value = this.ReadUInt32();
                        flag = true;
                        break;
                    case "$  Int64":
                        text = text.Substring(0, text.Length - 8);
                        value = this.ReadInt64();
                        flag = true;
                        break;
                    case "$ UInt64":
                        text = text.Substring(0, text.Length - 8);
                        value = this.ReadUInt64();
                        flag = true;
                        break;
                    case "$ Single":
                        text = text.Substring(0, text.Length - 8);
                        value = this.ReadSingle();
                        flag = true;
                        break;
                    case "$ Double":
                        text = text.Substring(0, text.Length - 8);
                        value = this.ReadDouble();
                        flag = true;
                        break;
                    case "$Decimal":
                        text = text.Substring(0, text.Length - 8);
                        value = this.ReadDecimal();
                        flag = true;
                        break;
                    case "$     TS":
                        text = text.Substring(0, text.Length - 8);
                        value = this.ReadTimeSpan();
                        flag = true;
                        break;
                    case "$  Array":
                        {
                            string text3;
                            Type type;
                            if (this.IsArray(text, out text3, out type))
                            {
                                text = text3;
                                //Edited for .NET Core
                                //MethodInfo methodInfo = typeof(JsonReader).GetMethod("ReadArray");
                                MethodInfo methodInfo = typeof(JsonReader).GetTypeInfo().GetMethod("ReadArray");
                                methodInfo = methodInfo.MakeGenericMethod(new Type[]
                                {
                            type
                                });
                                value = methodInfo.Invoke(this, null);
                                flag = true;
                            }
                            break;
                        }
                }
            }
            if (!flag)
            {
                value = this.ReadObject();
            }
            return new KeyValuePair<string, object>(text, value);
        }

        private bool IsArray(string key, out string fieldName, out Type elementType)
        {
            fieldName = null;
            elementType = null;
            int num = key.IndexOf("$", StringComparison.Ordinal);
            if (num > 0 && num + "$  Array".Length + 1 < key.Length)
            {
                fieldName = key.Substring(0, num);
                string text = key.Substring(num + 1, key.Length - "$  Array".Length - 1 - num);
                if (DataConvert.StrongTypedArrayElementTypeNames.TryGetValue(text, out elementType))
                {
                    return true;
                }
                elementType = ScriptTypeMap.GetTypeFromScriptType(text);
                if (elementType != null)
                {
                    return true;
                }
            }
            return false;
        }

        public T Read<T>()
        {
            Type typeFromHandle = typeof(T);
            JsonReader.ReadObjectHandler readObjectHandler = JsonReader.ReadObjectHandlers.GetReadObjectHandler(typeFromHandle);
            if (readObjectHandler != null)
            {
                return (T)((object)readObjectHandler(this));
            }
            //Edited for .NET Core
            //if (typeFromHandle.IsEnum)
            if (typeFromHandle.GetTypeInfo().IsEnum)
            {
                return this.ReadEnum<T>();
            }
            if (typeFromHandle.IsArray)
            {
                Type elementType = typeFromHandle.GetElementType();
                //Edited for .NET Core
                //MethodInfo methodInfo = typeof(JsonReader).GetMethod("ReadArray");
                MethodInfo methodInfo = typeof(JsonReader).GetTypeInfo().GetMethod("ReadArray");
                methodInfo = methodInfo.MakeGenericMethod(new Type[]
                {
                    elementType
                });
                return (T)((object)methodInfo.Invoke(this, null));
            }
             //Edited for .NET Core
            //if (typeFromHandle.IsGenericType && (typeFromHandle.GetGenericTypeDefinition() == typeof(Dictionary<string, object>).GetGenericTypeDefinition() || typeFromHandle.GetGenericTypeDefinition() == typeof(IDictionary<string, object>).GetGenericTypeDefinition()) && typeFromHandle.GetGenericArguments()[0] == typeof(string))
            if (typeFromHandle.GetTypeInfo().IsGenericType && (typeFromHandle.GetGenericTypeDefinition() == typeof(Dictionary<string, object>).GetGenericTypeDefinition() || typeFromHandle.GetGenericTypeDefinition() == typeof(IDictionary<string, object>).GetGenericTypeDefinition()) && typeFromHandle.GetTypeInfo().GetGenericArguments()[0] == typeof(string))
            {
                //Edited for .NET Core
                //Type type = typeFromHandle.GetGenericArguments()[1];
                Type type = typeFromHandle.GetTypeInfo().GetGenericArguments()[1];
                MethodInfo methodInfo2 = JsonReader.ReadDictionaryMethod.MakeGenericMethod(new Type[]
                {
                    type
                });
                return (T)((object)methodInfo2.Invoke(this, null));
            }
            return (T)((object)this.ReadObject(typeof(T)));
        }

        public T[] ReadArray<T>()
        {
            if (typeof(T) == typeof(byte))
            {
                return this.ReadByteArray() as T[];
            }
            JsonReader.Token token = this.PeekToken();
            if (token.Type == JsonTokenType.Null)
            {
                this.ReadToken();
                return null;
            }
            List<T> list = new List<T>();
            this.ReadArrayStart();
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.Read<T>());
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        public List<T> ReadList<T>()
        {
            JsonReader.Token token = this.PeekToken();
            if (token.Type == JsonTokenType.Null)
            {
                this.ReadToken();
                return null;
            }
            List<T> list = new List<T>();
            this.ReadArrayStart();
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                list.Add(this.Read<T>());
            }
            this.ReadArrayEnd();
            return list;
        }

        public object ReadObject()
        {
            return this.ReadObject(null);
        }

        private object ReadObject(Type fallbackType)
        {
            JsonReader.Token token = this.PeekToken();
            switch (token.Type)
            {
                case JsonTokenType.ObjectStart:
                    return this.ReadJsonObject(fallbackType);
                case JsonTokenType.ArrayStart:
                    {
                        Type fallbackElementType = null;
                        //Edited for .NET Core
                        //if (fallbackType != null && fallbackType != typeof(object) && typeof(IEnumerable).IsAssignableFrom(fallbackType))
                        if (fallbackType != null && fallbackType != typeof(object) && typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(fallbackType))
                        {
                            fallbackElementType = ExpressionUtility.GetElementType(fallbackType);
                        }
                        return this.ReadObjectArray(fallbackElementType);
                    }
                case JsonTokenType.String:
                    this.ReadToken();
                    return token.StringValue;
                case JsonTokenType.Long:
                    this.ReadToken();
                    if (token.LongValue >= -2147483648L && token.LongValue <= 2147483647L)
                    {
                        return (int)token.LongValue;
                    }
                    return token.LongValue;
                case JsonTokenType.ULong:
                    this.ReadToken();
                    return token.ULongValue;
                case JsonTokenType.Double:
                    this.ReadToken();
                    return token.DoubleValue;
                case JsonTokenType.Boolean:
                    this.ReadToken();
                    return token.BoolValue;
                case JsonTokenType.DateTime:
                    this.ReadToken();
                    return token.DateTimeValue;
                case JsonTokenType.Guid:
                    this.ReadToken();
                    return token.GuidValue;
                case JsonTokenType.Null:
                    this.ReadToken();
                    return null;
                case JsonTokenType.ByteArray:
                    return this.ReadByteArray();
                case JsonTokenType.StreamLink:
                    return this.ReadStream();
            }
            throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
            {
                token.Position
            }));
        }

        public object[] ReadObjectArray()
        {
            return this.ReadObjectArray(null);
        }

        internal object[] ReadObjectArray(Type fallbackElementType)
        {
            JsonReader.Token token = this.ReadToken();
            if (token.Type == JsonTokenType.Null)
            {
                return null;
            }
            if (token.Type != JsonTokenType.ArrayStart)
            {
                throw new InvalidOperationException(Resources.GetString("JsonDataTypeNotMatch", new object[]
                {
                    token.Position
                }));
            }
            List<object> list = new List<object>();
            while (this.PeekToken().Type != JsonTokenType.ArrayEnd)
            {
                object item = this.ReadObject(fallbackElementType);
                list.Add(item);
            }
            this.ReadArrayEnd();
            return list.ToArray();
        }

        private JsonReader.Token PeekToken()
        {
            return this.PeekToken(0);
        }

        private JsonReader.Token PeekToken(int tokenPosition)
        {
            while (this.m_peekedTokens.Count < tokenPosition + 1)
            {
                this.m_peekedTokens.Add(this.GetTokenPrivate());
            }
            return this.m_peekedTokens[tokenPosition];
        }

        private JsonReader.Token ReadToken()
        {
            JsonReader.Token result;
            if (this.m_peekedTokens.Count > 0)
            {
                result = this.m_peekedTokens[0];
                this.m_peekedTokens.RemoveAt(0);
            }
            else
            {
                result = this.GetTokenPrivate();
            }
            return result;
        }

        private void SkipWhiteSpace()
        {
            int num;
            while ((num = this.m_reader.Peek()) != -1 && char.IsWhiteSpace((char)num))
            {
                this.m_reader.Skip();
            }
        }

        private void SkipWhiteSpaceAndSeparator(char separator)
        {
            bool flag = false;
            int num;
            while ((num = this.m_reader.Peek()) != -1)
            {
                if (char.IsWhiteSpace((char)num))
                {
                    this.m_reader.Skip();
                }
                else
                {
                    if (flag || num != (int)separator)
                    {
                        break;
                    }
                    flag = true;
                    this.m_reader.Skip();
                }
            }
            if (!flag)
            {
                throw new FormatException(Resources.GetString("JsonNotWellFormated"));
            }
        }

        private void SkipWhiteSpaceAndSeparatorUntilBlockEnd(char separator, char blockend)
        {
            bool flag = false;
            bool flag2 = false;
            int num;
            while ((num = this.m_reader.Peek()) != -1)
            {
                if (char.IsWhiteSpace((char)num))
                {
                    this.m_reader.Skip();
                }
                else if (!flag && num == (int)separator)
                {
                    flag = true;
                    this.m_reader.Skip();
                }
                else
                {
                    if (num == (int)blockend)
                    {
                        flag2 = true;
                        break;
                    }
                    break;
                }
            }
            if (!flag && !flag2)
            {
                throw new FormatException(Resources.GetString("JsonNotWellFormated"));
            }
        }

        private void SkipToNextToken()
        {
            if (this.m_scopes.Count > 0 && this.m_scopes.Peek().Type == JsonReader.ScopeType.Array)
            {
                this.SkipWhiteSpaceAndSeparatorUntilBlockEnd(',', ']');
                return;
            }
            if (this.m_scopes.Count > 0 && this.m_scopes.Peek().Type == JsonReader.ScopeType.Object)
            {
                this.SkipWhiteSpaceAndSeparatorUntilBlockEnd(',', '}');
                return;
            }
            this.SkipWhiteSpace();
        }

        private JsonReader.Token GetTokenPrivate()
        {
            int num = this.m_reader.Peek();
            if (num == -1)
            {
                throw new FormatException(Resources.GetString("JsonReachTheEndOfStream"));
            }
            int offset = this.m_reader.Offset;
            int num2 = num;
            if (num2 <= 102)
            {
                switch (num2)
                {
                    case 34:
                    case 39:
                        {
                            JsonReader.Token token;
                            if (this.m_scopes.Count > 0 && this.m_scopes.Peek().Type == JsonReader.ScopeType.Object && this.m_scopes.Peek().ObjectCount % 2 == 0)
                            {
                                token = new JsonReader.Token(JsonTokenType.Name, offset);
                                token.StringValue = this.DecodeString(offset, true);
                                this.SkipWhiteSpaceAndSeparator(':');
                            }
                            else if (this.m_reader.Peek(1) == 92 && this.m_reader.Peek(2) == 47 && (this.m_options & JsonReaderOptions.DoNotUseEscapedToken) == JsonReaderOptions.None)
                            {
                                token = this.TryReadDateTime(offset);
                                if (token != null)
                                {
                                    return token;
                                }
                                token = this.TryReadGuid(offset);
                                if (token != null)
                                {
                                    return token;
                                }
                                token = this.TryReadByteArray(offset);
                                if (token != null)
                                {
                                    return token;
                                }
                                token = this.TryReadStreamLink(offset);
                                if (token != null)
                                {
                                    return token;
                                }
                            }
                            else
                            {
                                token = new JsonReader.Token(JsonTokenType.String, offset);
                                token.StringValue = this.DecodeString(offset, false);
                                this.SkipToNextToken();
                            }
                            this.IncreaseObjectCount();
                            return token;
                        }
                    case 35:
                    case 36:
                    case 37:
                    case 38:
                    case 40:
                    case 41:
                    case 42:
                    case 43:
                    case 44:
                    case 46:
                    case 47:
                        break;
                    case 45:
                    case 48:
                    case 49:
                    case 50:
                    case 51:
                    case 52:
                    case 53:
                    case 54:
                    case 55:
                    case 56:
                    case 57:
                        {
                            JsonReader.Token token = this.ReadTokenNumber(offset);
                            this.IncreaseObjectCount();
                            return token;
                        }
                    default:
                        switch (num2)
                        {
                            case 91:
                                {
                                    JsonReader.Token token = new JsonReader.Token(JsonTokenType.ArrayStart, offset);
                                    this.m_scopes.Push(new JsonReader.Scope(JsonReader.ScopeType.Array));
                                    this.m_reader.Skip();
                                    this.SkipWhiteSpace();
                                    return token;
                                }
                            case 92:
                                break;
                            case 93:
                                {
                                    if (this.m_scopes.Count == 0 || this.m_scopes.Peek().Type != JsonReader.ScopeType.Array)
                                    {
                                        throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
                                        {
                                offset
                                        }));
                                    }
                                    JsonReader.Token token = new JsonReader.Token(JsonTokenType.ArrayEnd, offset);
                                    this.m_scopes.Pop();
                                    this.m_reader.Skip();
                                    this.SkipToNextToken();
                                    this.IncreaseObjectCount();
                                    return token;
                                }
                            default:
                                if (num2 == 102)
                                {
                                    JsonReader.Token token = this.ReadTokenFalse(offset);
                                    this.IncreaseObjectCount();
                                    return token;
                                }
                                break;
                        }
                        break;
                }
            }
            else
            {
                if (num2 == 110)
                {
                    JsonReader.Token token = this.ReadTokenNull(offset);
                    this.IncreaseObjectCount();
                    return token;
                }
                if (num2 == 116)
                {
                    JsonReader.Token token = this.ReadTokenTrue(offset);
                    this.IncreaseObjectCount();
                    return token;
                }
                switch (num2)
                {
                    case 123:
                        {
                            JsonReader.Token token = new JsonReader.Token(JsonTokenType.ObjectStart, offset);
                            this.m_scopes.Push(new JsonReader.Scope(JsonReader.ScopeType.Object));
                            this.m_reader.Skip();
                            this.SkipWhiteSpace();
                            return token;
                        }
                    case 125:
                        {
                            if (this.m_scopes.Count == 0 || this.m_scopes.Peek().Type != JsonReader.ScopeType.Object)
                            {
                                throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
                                {
                            offset
                                }));
                            }
                            JsonReader.Token token = new JsonReader.Token(JsonTokenType.ObjectEnd, offset);
                            this.m_scopes.Pop();
                            this.m_reader.Skip();
                            this.SkipToNextToken();
                            this.IncreaseObjectCount();
                            return token;
                        }
                }
            }
            throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
            {
                offset
            }));
        }

        private bool IsTokenEnd(int ch)
        {
            return char.IsWhiteSpace((char)ch) || ch == 44 || ch == 58 || ch == 93 || ch == 59 || ch == 125;
        }

        private JsonReader.Token ReadTokenTrue(int tokenPosition)
        {
            if (this.m_reader.Read() == 116 && this.m_reader.Read() == 114 && this.m_reader.Read() == 117 && this.m_reader.Read() == 101)
            {
                int ch = this.m_reader.Peek();
                if (this.IsTokenEnd(ch))
                {
                    JsonReader.Token token = new JsonReader.Token(JsonTokenType.Boolean, tokenPosition);
                    token.BoolValue = true;
                    this.SkipToNextToken();
                    return token;
                }
            }
            throw new FormatException(Resources.GetString("JsonUnknownData", new object[]
            {
                tokenPosition
            }));
        }

        private JsonReader.Token ReadTokenFalse(int tokenPosition)
        {
            if (this.m_reader.Read() == 102 && this.m_reader.Read() == 97 && this.m_reader.Read() == 108 && this.m_reader.Read() == 115 && this.m_reader.Read() == 101)
            {
                int ch = this.m_reader.Peek();
                if (this.IsTokenEnd(ch))
                {
                    JsonReader.Token token = new JsonReader.Token(JsonTokenType.Boolean, tokenPosition);
                    token.BoolValue = false;
                    this.SkipToNextToken();
                    return token;
                }
            }
            throw new FormatException(Resources.GetString("JsonUnknownData", new object[]
            {
                tokenPosition
            }));
        }

        private JsonReader.Token ReadTokenNull(int tokenPosition)
        {
            if (this.m_reader.Read() == 110 && this.m_reader.Read() == 117 && this.m_reader.Read() == 108 && this.m_reader.Read() == 108)
            {
                int ch = this.m_reader.Peek();
                if (this.IsTokenEnd(ch))
                {
                    JsonReader.Token result = new JsonReader.Token(JsonTokenType.Null, tokenPosition);
                    this.SkipToNextToken();
                    return result;
                }
            }
            throw new FormatException(Resources.GetString("JsonUnknownData", new object[]
            {
                tokenPosition
            }));
        }

        private JsonReader.Token ReadTokenNumber(int tokenPosition)
        {
            int num = this.m_reader.Peek(this.m_tokenBuffer, this.m_tokenBuffer.Length);
            int i;
            for (i = 0; i < num; i++)
            {
                char ch = this.m_tokenBuffer[i];
                if (this.IsTokenEnd((int)ch))
                {
                    break;
                }
            }
            if (i == 0 || i == num)
            {
                throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
                {
                    tokenPosition
                }));
            }
            string text = new string(this.m_tokenBuffer, 0, i);
            long longValue;
            if (long.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out longValue))
            {
                JsonReader.Token token = new JsonReader.Token(JsonTokenType.Long, tokenPosition);
                token.LongValue = longValue;
                this.m_reader.Skip(i);
                this.SkipToNextToken();
                return token;
            }
            ulong uLongValue;
            if (ulong.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out uLongValue))
            {
                JsonReader.Token token = new JsonReader.Token(JsonTokenType.ULong, tokenPosition);
                token.ULongValue = uLongValue;
                this.m_reader.Skip(i);
                this.SkipToNextToken();
                return token;
            }
            double doubleValue = 0.0;
            bool flag = false;
            if (text == JsonReader.MinDoubleValueAsString)
            {
                doubleValue = -1.7976931348623157E+308;
                flag = true;
            }
            else if (text == JsonReader.MaxDoubleValueAsString)
            {
                doubleValue = 1.7976931348623157E+308;
                flag = true;
            }
            else if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out doubleValue))
            {
                flag = true;
            }
            if (flag)
            {
                JsonReader.Token token = new JsonReader.Token(JsonTokenType.Double, tokenPosition);
                token.DoubleValue = doubleValue;
                this.m_reader.Skip(i);
                this.SkipToNextToken();
                return token;
            }
            throw new FormatException(Resources.GetString("JsonUnknownData", new object[]
            {
                tokenPosition
            }));
        }

        private JsonReader.Token TryReadDateTime(int tokenPosition)
        {
            JsonReader.Token token = null;
            int num = 0;
            while (num < JsonReader.DateTimePrefixLength && this.m_reader.Peek(num) == (int)"\"\\/Date("[num])
            {
                num++;
            }
            if (num != JsonReader.DateTimePrefixLength)
            {
                return token;
            }
            token = new JsonReader.Token(JsonTokenType.DateTime, tokenPosition);
            this.m_reader.Skip(JsonReader.DateTimePrefixLength);
            char c = '\0';
            bool flag = false;
            bool flag2 = false;
            int i;
            for (i = 0; i < this.m_dateTimeComponents.Length; i++)
            {
                this.m_dateTimeComponents[i] = 0L;
                this.m_dateTimeSigns[i] = '\0';
            }
            int j;
            for (j = 0; j < this.m_dateTimeHhmm.Length; j++)
            {
                this.m_dateTimeHhmm[j] = '\0';
            }
            i = 0;
            j = 0;
            bool flag3 = false;
            int num2;
            while (!flag3 && (num2 = this.m_reader.Read()) != -1)
            {
                switch (num2)
                {
                    case 32:
                        flag2 = false;
                        flag = false;
                        continue;
                    case 41:
                        flag3 = true;
                        continue;
                    case 43:
                    case 45:
                        if (flag2)
                        {
                            if (i == 0)
                            {
                                c = (char)num2;
                                flag = true;
                                flag2 = false;
                                continue;
                            }
                            throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
                            {
                            tokenPosition
                            }));
                        }
                        else
                        {
                            if (this.m_dateTimeSigns[i] == '\0')
                            {
                                this.m_dateTimeSigns[i] = (char)num2;
                                continue;
                            }
                            throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
                            {
                            tokenPosition
                            }));
                        }
                        //break;
                    case 44:
                        flag2 = false;
                        flag = false;
                        i++;
                        if (i >= this.m_dateTimeComponents.Length)
                        {
                            throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
                            {
                            tokenPosition
                            }));
                        }
                        continue;
                    case 48:
                    case 49:
                    case 50:
                    case 51:
                    case 52:
                    case 53:
                    case 54:
                    case 55:
                    case 56:
                    case 57:
                        if (flag)
                        {
                            if (j >= this.m_dateTimeHhmm.Length)
                            {
                                throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
                                {
                                tokenPosition
                                }));
                            }
                            this.m_dateTimeHhmm[j] = (char)num2;
                            j++;
                        }
                        else if (!flag2)
                        {
                            flag2 = true;
                        }
                        if (flag2)
                        {
                            this.m_dateTimeComponents[i] = this.m_dateTimeComponents[i] * 10L + (long)(num2 - 48);
                            continue;
                        }
                        continue;
                }
                throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
                {
                    tokenPosition
                }));
            }
            if (flag3 && this.m_reader.Read() == 92 && this.m_reader.Read() == 47 && this.m_reader.Read() == 34)
            {
                for (int k = 0; k < this.m_dateTimeComponents.Length; k++)
                {
                    if (this.m_dateTimeSigns[k] == '-')
                    {
                        this.m_dateTimeComponents[k] = -this.m_dateTimeComponents[k];
                    }
                }
                if (i == 0)
                {
                    long num3 = this.m_dateTimeComponents[0];
                    token.DateTimeValue = new DateTime(num3 * 10000L + JsonReader.MinDateTimeTicks, DateTimeKind.Utc);
                    if (c != '\0')
                    {
                        token.DateTimeValue = token.DateTimeValue.ToLocalTime();
                    }
                }
                else
                {
                    token.DateTimeValue = new DateTime((int)this.m_dateTimeComponents[0], (int)this.m_dateTimeComponents[1] + 1, (int)this.m_dateTimeComponents[2], (int)this.m_dateTimeComponents[3], (int)this.m_dateTimeComponents[4], (int)this.m_dateTimeComponents[5], (int)this.m_dateTimeComponents[6], DateTimeKind.Unspecified);
                }
                this.SkipToNextToken();
                this.IncreaseObjectCount();
                return token;
            }
            throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
            {
                tokenPosition
            }));
        }

        private JsonReader.Token TryReadGuid(int tokenPosition)
        {
            JsonReader.Token token = null;
            int num = 0;
            while (num < JsonReader.GuidPrefixLength && this.m_reader.Peek(num) == (int)"\"\\/Guid("[num])
            {
                num++;
            }
            if (num != JsonReader.GuidPrefixLength)
            {
                return token;
            }
            token = new JsonReader.Token(JsonTokenType.Guid, tokenPosition);
            this.m_reader.Skip("\"\\/Guid(".Length);
            int i;
            for (i = 0; i < this.m_tryReadGuidByteBuf.Length; i++)
            {
                this.m_tryReadGuidByteBuf[i] = 0;
            }
            int j;
            for (j = 0; j < this.m_tryReadGuidIntBuf.Length; j++)
            {
                this.m_tryReadGuidIntBuf[j] = 0L;
            }
            i = 0;
            j = 0;
            int num2 = 0;
            int num3;
            while ((num3 = this.m_reader.Read()) != -1 && num3 != 41)
            {
                if (num3 >= 48 && num3 <= 57)
                {
                    if (j < 3)
                    {
                        this.m_tryReadGuidIntBuf[j] = this.m_tryReadGuidIntBuf[j] * 16L + (long)num3 - 48L;
                    }
                    else
                    {
                        this.m_tryReadGuidByteBuf[i / 2] = (byte)((int)(this.m_tryReadGuidByteBuf[i / 2] * 16) + num3 - 48);
                        i++;
                    }
                }
                else if (num3 >= 65 && num3 <= 70)
                {
                    if (j < 3)
                    {
                        this.m_tryReadGuidIntBuf[j] = this.m_tryReadGuidIntBuf[j] * 16L + (long)num3 - 65L + 10L;
                    }
                    else
                    {
                        this.m_tryReadGuidByteBuf[i / 2] = (byte)((int)(this.m_tryReadGuidByteBuf[i / 2] * 16) + num3 - 65 + 10);
                        i++;
                    }
                }
                else if (num3 >= 97 && num3 <= 102)
                {
                    if (j < 3)
                    {
                        this.m_tryReadGuidIntBuf[j] = this.m_tryReadGuidIntBuf[j] * 16L + (long)num3 - 97L + 10L;
                    }
                    else
                    {
                        this.m_tryReadGuidByteBuf[i / 2] = (byte)((int)(this.m_tryReadGuidByteBuf[i / 2] * 16) + num3 - 97 + 10);
                        i++;
                    }
                }
                else
                {
                    if (num3 != 45)
                    {
                        throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
                        {
                            tokenPosition
                        }));
                    }
                    j++;
                }
                num2++;
            }
            if (num2 == 36 && j == 4 && i == 16 && num3 == 41 && this.m_reader.Read() == 92 && this.m_reader.Read() == 47 && this.m_reader.Read() == 34)
            {
                Guid guidValue = new Guid((int)this.m_tryReadGuidIntBuf[0], (short)this.m_tryReadGuidIntBuf[1], (short)this.m_tryReadGuidIntBuf[2], this.m_tryReadGuidByteBuf);
                token.GuidValue = guidValue;
                this.SkipToNextToken();
                this.IncreaseObjectCount();
                return token;
            }
            throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
            {
                tokenPosition
            }));
        }

        private JsonReader.Token TryReadByteArray(int tokenPosition)
        {
            JsonReader.Token token = null;
            int num = 0;
            while (num < JsonReader.ByteArrayPrefixLength && this.m_reader.Peek(num) == (int)"\"\\/Base64Binary("[num])
            {
                num++;
            }
            if (num != JsonReader.ByteArrayPrefixLength)
            {
                return token;
            }
            token = new JsonReader.Token(JsonTokenType.ByteArray, tokenPosition);
            this.m_reader.Skip(JsonReader.ByteArrayPrefixLength);
            StringBuilder stringBuilder = new StringBuilder();
            int num2;
            while ((num2 = this.m_reader.Read()) != -1 && num2 != 41)
            {
                stringBuilder.Append((char)num2);
            }
            if (num2 == 41 && this.m_reader.Read() == 92 && this.m_reader.Read() == 47 && this.m_reader.Read() == 34)
            {
                string text = stringBuilder.ToString();
                text = text.Replace("\\u002f", "/");
                text = text.Replace("\\u002F", "/");
                byte[] byteArrayValue = Convert.FromBase64String(text);
                token.ByteArrayValue = byteArrayValue;
                this.SkipToNextToken();
                this.IncreaseObjectCount();
                return token;
            }
            throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
            {
                tokenPosition
            }));
        }

        private JsonReader.Token TryReadStreamLink(int tokenPosition)
        {
            JsonReader.Token token = null;
            int num = 0;
            while (num < JsonReader.StreamLinkPrefixLength && this.m_reader.Peek(num) == (int)"\"\\/Binary("[num])
            {
                num++;
            }
            if (num != JsonReader.StreamLinkPrefixLength)
            {
                return token;
            }
            token = new JsonReader.Token(JsonTokenType.StreamLink, tokenPosition);
            this.m_reader.Skip(JsonReader.StreamLinkPrefixLength);
            StringBuilder stringBuilder = new StringBuilder();
            int num2;
            while ((num2 = this.m_reader.Read()) != -1 && num2 != 41)
            {
                stringBuilder.Append((char)num2);
            }
            if (num2 == 41 && this.m_reader.Read() == 92 && this.m_reader.Read() == 47 && this.m_reader.Read() == 34)
            {
                string text = stringBuilder.ToString();
                text = WebUtility.UrlDecode(text);
                token.StringValue = text;
                this.SkipToNextToken();
                this.IncreaseObjectCount();
                return token;
            }
            throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
            {
                tokenPosition
            }));
        }

        private void IncreaseObjectCount()
        {
            if (this.m_scopes.Count > 0)
            {
                JsonReader.Scope scope = this.m_scopes.Peek();
                scope.ObjectCount++;
            }
        }

        private bool Hex4ToInt(char[] hexChars, out int n)
        {
            n = 0;
            for (int i = 0; i < hexChars.Length; i++)
            {
                n <<= 4;
                char c = hexChars[i];
                if (c >= '0' && c <= '9')
                {
                    n += (int)(c - '0');
                }
                else if (c >= 'a' && c <= 'f')
                {
                    n += (int)(c - 'a' + '\n');
                }
                else
                {
                    if (c < 'A' || c > 'F')
                    {
                        return false;
                    }
                    n += (int)(c - 'A' + '\n');
                }
            }
            return true;
        }

        private string DecodeString(int tokenPosition, bool isName)
        {
            int num = this.m_reader.Read();
            if (num != 34 && num != 39)
            {
                throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
                {
                    tokenPosition
                }));
            }
            int num2 = num;
            StringBuilder decodeStringBuf = this.m_decodeStringBuf;
            decodeStringBuf.Length = 0;
            bool flag = false;
            char[] decodeStringHexChars = this.m_decodeStringHexChars;
            bool flag2 = false;
            bool flag3 = isName || (this.m_options & JsonReaderOptions.IgnoreStringValue) == JsonReaderOptions.None;
            while (!flag && (num = this.m_reader.Read()) != -1)
            {
                if (flag2)
                {
                    int num3 = num;
                    char value;
                    if (num3 <= 92)
                    {
                        if (num3 <= 39)
                        {
                            if (num3 != 34)
                            {
                                if (num3 != 39)
                                {
                                    goto IL_1A3;
                                }
                                value = '\'';
                            }
                            else
                            {
                                value = '"';
                            }
                        }
                        else if (num3 != 47)
                        {
                            if (num3 != 92)
                            {
                                goto IL_1A3;
                            }
                            value = '\\';
                        }
                        else
                        {
                            value = '/';
                        }
                    }
                    else if (num3 <= 102)
                    {
                        if (num3 != 98)
                        {
                            if (num3 != 102)
                            {
                                goto IL_1A3;
                            }
                            value = '\f';
                        }
                        else
                        {
                            value = '\b';
                        }
                    }
                    else if (num3 != 110)
                    {
                        switch (num3)
                        {
                            case 114:
                                value = '\r';
                                break;
                            case 115:
                                goto IL_1A3;
                            case 116:
                                value = '\t';
                                break;
                            case 117:
                                {
                                    int num4 = this.m_reader.Read(decodeStringHexChars, 4);
                                    if (num4 != 4)
                                    {
                                        throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
                                        {
                                    tokenPosition
                                        }));
                                    }
                                    int num5 = 0;
                                    if (!this.Hex4ToInt(decodeStringHexChars, out num5))
                                    {
                                        throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
                                        {
                                    tokenPosition
                                        }));
                                    }
                                    value = (char)num5;
                                    break;
                                }
                            default:
                                goto IL_1A3;
                        }
                    }
                    else
                    {
                        value = '\n';
                    }
                    if (flag3)
                    {
                        decodeStringBuf.Append(value);
                    }
                    flag2 = false;
                    continue;
                    IL_1A3:
                    throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
                    {
                        tokenPosition
                    }));
                }
                if (num == 92)
                {
                    flag2 = true;
                }
                else if (num == num2)
                {
                    flag = true;
                }
                else if (flag3)
                {
                    decodeStringBuf.Append((char)num);
                }
            }
            if (!flag)
            {
                throw new FormatException(Resources.GetString("JsonNotWellFormated", new object[]
                {
                    tokenPosition
                }));
            }
            return decodeStringBuf.ToString();
        }

        public void Dispose()
        {
            if (this.m_reader != null)
            {
                this.m_reader.Dispose();
            }
        }
    }

}
