namespace SlimXUnitDb.Test.Core.Generators
{
    /// <summary>
    /// Generator class for integers.
    /// </summary>
    public sealed class IntegerGenerator : BaseGenerator<int>
    {
        private readonly int _start;
        private readonly int _step;

        public IntegerGenerator(int start, int step)
            : base()
        {
            _start = start;
            _step = step;
        }

        /// <inheritdoc />
        protected override int GenerateNew()
        {
            if (Count == 0)
            {
                return _start;
            }
            else
            {
                return Current + _step;
            }
        }
    }

}
