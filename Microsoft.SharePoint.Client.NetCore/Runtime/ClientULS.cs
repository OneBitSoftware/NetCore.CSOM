using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal static class ClientULS
    {
        private static object s_lock = new object();

        private static TraceSource s_authTraceSource;

        private static TraceSource s_requestTraceSource;

        private static TraceSource s_generalTraceSource;

        private static TraceSource AuthTraceSource
        {
            get
            {
                if (ClientULS.s_authTraceSource == null)
                {
                    lock (ClientULS.s_lock)
                    {
                        if (ClientULS.s_authTraceSource == null)
                        {
                            ClientULS.s_authTraceSource = new TraceSource("CSOMAuth");
                        }
                    }
                }
                return ClientULS.s_authTraceSource;
            }
        }

        private static TraceSource RequestTraceSource
        {
            get
            {
                if (ClientULS.s_requestTraceSource == null)
                {
                    lock (ClientULS.s_lock)
                    {
                        if (ClientULS.s_requestTraceSource == null)
                        {
                            ClientULS.s_requestTraceSource = new TraceSource("CSOMRequest");
                        }
                    }
                }
                return ClientULS.s_requestTraceSource;
            }
        }

        private static TraceSource GeneralTraceSource
        {
            get
            {
                if (ClientULS.s_generalTraceSource == null)
                {
                    lock (ClientULS.s_lock)
                    {
                        if (ClientULS.s_generalTraceSource == null)
                        {
                            ClientULS.s_generalTraceSource = new TraceSource("CSOMGeneral");
                        }
                    }
                }
                return ClientULS.s_generalTraceSource;
            }
        }

        internal static void SendTraceTag(uint tagId, ClientTraceCategory category, ClientTraceLevel traceLevel, string format, params object[] args)
        {
            TraceSource traceSource;
            switch (category)
            {
                case ClientTraceCategory.Request:
                    traceSource = ClientULS.RequestTraceSource;
                    break;
                case ClientTraceCategory.Authentication:
                    traceSource = ClientULS.AuthTraceSource;
                    break;
                default:
                    traceSource = ClientULS.GeneralTraceSource;
                    break;
            }
            TraceEventType eventType;
            switch (traceLevel)
            {
                case ClientTraceLevel.Medium:
                    eventType = TraceEventType.Information;
                    break;
                case ClientTraceLevel.High:
                    eventType = TraceEventType.Error;
                    break;
                default:
                    eventType = TraceEventType.Verbose;
                    break;
            }
            traceSource.TraceEvent(eventType, (int)tagId, format, args);
        }
    }
}
