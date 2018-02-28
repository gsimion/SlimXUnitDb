namespace SlimXUnitDb.Test.Core.Generators
{
    /// <summary>
    /// Generator class for names.
    /// </summary>
    public class NameGenerator : BaseGenerator<string>
    {
        private readonly IntegerGenerator _numberGenerator;
        private readonly string _prefix;
        private readonly string _suffix;

        public NameGenerator(string prefix)
            : this(prefix, string.Empty)
        {
        }

        public NameGenerator(string prefix, string suffix)
        {
            _numberGenerator = new IntegerGenerator(1, 1);
            _prefix = prefix;
            _suffix = suffix;
        }

        /// <inheritdoc />
        protected override string GenerateNew()
        {
            decimal next = _numberGenerator.Generate();
            return _prefix + next + _suffix;
        }
    }

}
