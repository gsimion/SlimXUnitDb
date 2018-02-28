using System;
using System.Collections.Generic;

namespace SlimXUnitDb.App.IDb
{
    /// <summary>
    /// Generic interface of implemented by a database connection.
    /// </summary>
    public interface IDb
    {
        IEnumerable<T> Select<T>(Func<T, bool> whereClause);
        IEnumerable<object> SelectAnonymous(string query);
        bool Transact(string query);
        bool Transact(Action action);
    }
}
