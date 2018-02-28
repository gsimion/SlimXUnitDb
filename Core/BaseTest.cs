using Xunit;

namespace SlimXUnitDb.Test.Core
{
    /// <summary>
    /// Base test class for testing with database.
    /// </summary>
    public abstract class BaseTest : IClassFixture<FixtureBase>
    {
        private readonly FixtureBase _context;

        public FixtureBase Context { get { return _context; } }

        public BaseTest(FixtureBase context)
        {
            _context = context;
            Initialize();
        }

        protected abstract void Initialize();
    }
}
