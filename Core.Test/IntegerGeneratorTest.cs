using SlimXUnitDb.Test.Core.Generators;
using Xunit;

namespace Core.Test
{
    public class IntegerGeneratorTest
    {
        [Fact(DisplayName = "IntegerGenerator :: generate output.")]
        public void IntegerGenerator_Generate_Output()
        {
            int expected = 100;
            var generator = new IntegerGenerator(expected, 1);
            int actual = generator.Generate();

            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "IntegerGenerator :: generate properties.")]
        public void IntegerGenerator_Generate_Properties()
        {
            int expected = 101;
            var generator = new IntegerGenerator(expected, 1);
            generator.Generate();

            Assert.Equal(expected, generator.Current);
            Assert.Equal(1, generator.Count);
        }

        [Fact(DisplayName = "IntegerGenerator :: generate multiple properties.")]
        public void IntegerGenerator_GenerateStep_Properties()
        {
            int iterations = 5;
            int step = 4;
            var generator = new IntegerGenerator(0, step);
            for (int i = 0; i < iterations; i++)
            {
                generator.Generate();
            }        

            Assert.Equal(iterations * step - 1 * step, generator.Current);
            Assert.Equal(iterations * step - 2 * step, generator.Previous);
            Assert.Equal(iterations, generator.Count);
        }
    }
}
