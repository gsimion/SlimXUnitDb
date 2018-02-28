using SlimXUnitDb.App.IDb;
using System;

namespace SlimXUnitDb.Test.Core
{
    /// <summary>
    /// Class handling common set up and tear down fixture operations for database related tests.
    /// </summary>
    public sealed class FixtureBase : IDisposable
    {
        private readonly TestDb _conn;

        /// <summary>
        /// The fixture shared random seed.
        /// </summary>
        public readonly Random Seed;

        /// <summary>
        /// The database selector.
        /// </summary>
        public readonly Selector Selector;

        /// <summary>
        /// The database connection.
        /// </summary>
        public IDb Conn { get { return _conn; } }

        public FixtureBase()
        {
            _conn = new TestDb();
            Seed = new Random();
            Selector = new Selector(this);

            SetUpDb(_conn);
        }

        public void Dispose()
        {
            CleanUpDb(_conn);
        }

        private static void SetUpDb(IDb conn)
        {
            //TODO: set up db to default for each test fixture
        }

        private static void CleanUpDb(IDb conn)
        {
            //TODO: clean up db after test fixture's tests have run
        }
    }
}
