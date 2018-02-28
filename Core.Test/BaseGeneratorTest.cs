using SlimXUnitDb.Test.Core.Generators;
using System;
using Xunit;

namespace Core.Test
{
    public class BaseGeneratorTest
    {
        private class NumberGeneratorStart0Increment1 : BaseGenerator<int>
        {
            protected override int GenerateNew()
            {
                return Count == 0 ? 0 : Current + 1;
            }
        }

        private class ObjectGenerator : BaseGenerator<object>
        {
            protected override object GenerateNew()
            {
                return new object();
            }
        }

        [Fact(DisplayName = "BaseGenerator :: create new assert on properties.")]
        public void BaseGenerator_Constructor_Properties()
        {
            var generator = new NumberGeneratorStart0Increment1();

            Assert.NotNull(generator);
            Assert.Equal(0, generator.Count);
        }

        [Fact(DisplayName = "BaseGenerator :: create new exception current.")]
        public void BaseGenerator_Constructor_Current()
        {
            var generator = new NumberGeneratorStart0Increment1();

            Assert.Throws<ArgumentOutOfRangeException>(() => generator.Current);
        }

        [Fact(DisplayName = "BaseGenerator :: create new exception previous.")]
        public void BaseGenerator_Constructor_Previous()
        {
            var generator = new NumberGeneratorStart0Increment1();

            Assert.Throws<ArgumentOutOfRangeException>(() => generator.Previous);
        }

        [Fact(DisplayName = "BaseGenerator :: generate output.")]
        public void BaseGenerator_Generate_Output()
        {
            int expected = 0;
            var generator = new NumberGeneratorStart0Increment1();
            int actual = generator.Generate();

            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "BaseGenerator :: generate properties.")]
        public void BaseGenerator_Generate_Properties()
        {
            int expected = 0;
            var generator = new NumberGeneratorStart0Increment1();
            generator.Generate();

            Assert.Equal(expected, generator.Current);
            Assert.Equal(1, generator.Count);
        }

        [Fact(DisplayName = "BaseGenerator :: generate multiple properties.")]
        public void BaseGenerator_GenerateMultiple_Properties()
        {
            int iterations = 5;
            var generator = new NumberGeneratorStart0Increment1();
            for (int i = 0; i < iterations; i++)
            {
                generator.Generate();
            }        

            Assert.Equal(iterations - 1, generator.Current);
            Assert.Equal(iterations - 2, generator.Previous);
            Assert.Equal(iterations, generator.Count);
        }

        [Fact(DisplayName = "BaseGenerator :: generate multiple on reference type properties.")]
        public void BaseGenerator_Generate_ReferenceType_Properties()
        {
            var generator = new ObjectGenerator();
            var first = generator.Generate();
            var last = generator.Generate();

            Assert.Equal(last, generator.Current);
            Assert.Equal(first, generator.Previous);
            Assert.Equal(2, generator.Count);
        }
    }
}
