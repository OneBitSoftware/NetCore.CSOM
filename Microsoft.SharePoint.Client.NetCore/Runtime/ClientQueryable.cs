using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal sealed class ClientQueryable<T> : IOrderedQueryable<T>, IOrderedQueryable, IQueryable<T>, IQueryable, IEnumerable<T>, IEnumerable
    {
        private Expression m_exp;

        private ClientQueryProvider m_provider;

        public Type ElementType
        {
            get
            {
                return typeof(T);
            }
        }

        public Expression Expression
        {
            get
            {
                return this.m_exp;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return this.m_provider;
            }
        }

        public ClientQueryable(ClientQueryProvider provider, Expression exp)
        {
            this.m_provider = provider;
            this.m_exp = exp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Provider.Execute<IEnumerable<T>>(this.Expression).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Provider.Execute<IEnumerable>(this.Expression).GetEnumerator();
        }
    }
}
