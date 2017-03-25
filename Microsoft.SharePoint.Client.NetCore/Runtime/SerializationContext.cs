using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public sealed class SerializationContext
    {
        private ClientRuntimeContext m_context;

        private Dictionary<long, ObjectPath> m_paths = new Dictionary<long, ObjectPath>();

        private List<StreamInfo> m_streams;

        internal ClientRuntimeContext Context
        {
            get
            {
                return this.m_context;
            }
        }

        internal List<StreamInfo> Streams
        {
            get
            {
                return this.m_streams;
            }
        }

        internal Dictionary<long, ObjectPath> Paths
        {
            get
            {
                return this.m_paths;
            }
        }

        internal SerializationContext(ClientRuntimeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.m_context = context;
        }

        public void AddClientObject(ClientObject obj)
        {
            if (obj.Path != null)
            {
                this.AddObjectPath(obj.Path);
            }
        }

        public void AddObjectPath(ObjectPath path)
        {
            this.m_paths[path.Id] = path;
        }

        internal void AddStream(StreamInfo stream)
        {
            if (stream != null)
            {
                if (this.m_streams == null)
                {
                    this.m_streams = new List<StreamInfo>();
                }
                this.m_streams.Add(stream);
            }
        }

        internal void MergeFrom(SerializationContext context)
        {
            foreach (KeyValuePair<long, ObjectPath> current in context.Paths)
            {
                this.AddObjectPath(current.Value);
            }
            if (context.Streams != null)
            {
                foreach (StreamInfo current2 in context.Streams)
                {
                    this.AddStream(current2);
                }
            }
        }
    }
}
