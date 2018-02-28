using System;
using System.Collections.Generic;
using System.Linq;

namespace SlimXUnitDb.Test.Core
{
    /// <summary>
    /// Database selector.
    /// </summary>
    public sealed class Selector
    {
        private readonly FixtureBase _context;

        internal Selector(FixtureBase context)
        {
            _context = context;
        }

        public T GetRandom<T>()
        {
            return GetRandom<T>(x => true);
        }

        public T GetRandom<T>(Func<T, bool> whereClause)
        {
            List<T> fetchList = InternalGet<T>(whereClause);
            return fetchList.Any() ? fetchList[_context.Seed.Next(fetchList.Count)] : default(T);
        }

        public IEnumerable<T> Get<T>()
        {
            return Get<T>(x => true);
        }

        public IEnumerable<T> Get<T>(Func<T, bool> whereClause)
        {
            return InternalGet<T>(whereClause);
        }

        private List<T> InternalGet<T>(Func<T, bool> whereClause)
        {
            List<T> fetchList = new List<T>();
            fetchList.AddRange(_context.Conn.Select<T>(whereClause));
            
            return fetchList;
        }
    }
}
