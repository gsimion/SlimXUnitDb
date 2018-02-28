using SlimXUnitDb.App.IDb;
using System;
using System.Collections.Generic;

namespace SampleApp
{
    public class Db : IDb
    {
        public IEnumerable<T> Select<T>(Func<T, bool> whereClause)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> SelectAnonymous(string query)
        {
            throw new NotImplementedException();
        }

        public bool Transact(string query)
        {
            return true;
        }

        public bool Transact(Action action)
        {
            return true;
        }
    }
}
