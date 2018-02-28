using System;
using System.Collections.Generic;
using SlimXUnitDb.App.IDb;

namespace SlimXUnitDb.Test.Core
{
    /// <summary>
    /// Class representing the implementation for idb from the test perspective.
    /// </summary>
    internal sealed class TestDb : IDb
    {
        public IEnumerable<T> Select<T>(Func<T, bool> whereClause)
        {
            //TODO: implement
            throw new NotImplementedException();
        }

        public IEnumerable<object> SelectAnonymous(string query)
        {
            //TODO: implement
            throw new NotImplementedException();
        }

        public bool Transact(string query)
        {
            //TODO: implement
            return true;
        }

        public bool Transact(Action action)
        {
            //TODO: implement
            return true;
        }
    }
}
