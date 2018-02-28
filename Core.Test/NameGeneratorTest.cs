using SlimXUnitDb.Test.Core.Generators;
using Xunit;

namespace Core.Test
{
    public class NameGeneratorTest
    {
        [Fact(DisplayName = "NameGenerator :: generate output.")]
        public void NameGenerator_Generate_Output()
        {
            string expectedPrefix = "name";
            string expectedSuffix = " surname";
            var generator = new NameGenerator(expectedPrefix, expectedSuffix);
            string actual = generator.Generate();

            Assert.StartsWith(expectedPrefix, actual);
            Assert.EndsWith(expectedSuffix, actual);
        }

        [Fact(DisplayName = "NameGenerator :: generate properties.")]
        public void NameGenerator_Generate_Properties()
        {
            string expectedPrefix = "name";
            string expectedSuffix = " surname";
            var generator = new NameGenerator(expectedPrefix, expectedSuffix);
            generator.Generate();

            Assert.StartsWith(expectedPrefix, generator.Current);
            Assert.EndsWith(expectedSuffix, generator.Current);
            Assert.Equal(1, generator.Count);
        }
    }
}
