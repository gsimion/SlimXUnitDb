using Bogus;
using SlimXUnitDb.Test.Core;
using SlimXUnitDb.Test.Core.Generators;
using System;
using System.Collections.Generic;
using Xunit;

namespace Core.Test
{
    public class BaseFactoryTest
    {
        public static int Counter;

        public class SimpleObj
        {
            public int Hash { get; set; }
            public SimpleObj()
            {
            }

            public SimpleObj(int hash)
                : this()
            {
                Hash = hash;
            }
        }

        private class SimpleObjFaker : BaseFactory<SimpleObj>
        {
            public SimpleObjFaker(BaseTest testContest) : base(testContest)
            {
            }

            protected override SimpleObj GenerateNew(Action<Faker<SimpleObj>> action)
            {
                var faker = new Faker<SimpleObj>();
                faker.RuleFor(u => u.Hash, 1);
                action(faker);

                return faker;
            }

            protected override SimpleObj GenerateNew()
            {
                var faker = new Faker<SimpleObj>();
                faker.RuleFor(u => u.Hash, 1);

                return faker;
            }

            protected override void SyncDb(IReadOnlyList<SimpleObj> list)
            {
                Counter += list.Count;
            }
        }

        public static IEnumerable<object[]> GetSimpleObjects()
        {
            yield return new object[] { new Faker<SimpleObj>().RuleFor(u => u.Hash, 1) };
        }

        [Theory(DisplayName = "Bogus :: assumption on override rule.")]
        [MemberData(nameof(GetSimpleObjects))]
        public void Bogus_Faker_Override_Hash(dynamic faker)
        {
            Assert.IsType<Faker<SimpleObj>>(faker);
            (faker as Faker<SimpleObj>).RuleFor(x => x.Hash, 100);
            SimpleObj o = faker;
            Assert.Equal(100, o.Hash);
        }

        [Fact(DisplayName = "BaseFactory :: create new assert on inheritedn properties.")]
        public void BaseFactory_Constructor_Properties()
        {
            var generator = new SimpleObjFaker(null);   

            Assert.NotNull(generator);
            Assert.Equal(0, generator.Count);
        }

        [Fact(DisplayName = "BaseFactory :: generate default output.")]
        public void BaseFactory_Generate_Defult_Output()
        {
            var generator = new SimpleObjFaker(null);
            var generated = generator.Generate();
            int expectedHash = 1;

            Assert.NotNull(generated);
            Assert.IsType<SimpleObj>(generated);
            Assert.Equal(expectedHash, generated.Hash);
        }

        [Fact(DisplayName = "BaseFactory :: generate override output.")]
        public void BaseFactory_Generate_Override_Output()
        {
            int expectedHash = 1234;
            var generator = new SimpleObjFaker(null);
            var generated = generator.Generate(u => u.RuleFor(x => x.Hash, expectedHash));
            
            Assert.NotNull(generated);
            Assert.IsType<SimpleObj>(generated);
            Assert.Equal(expectedHash, generated.Hash);
        }

        [Fact(DisplayName = "BaseFactory :: sync db count.")]
        public void BaseFactory_Sync_CorrectCall_Count()
        {
            int initialCount = Counter;

            var generator = new SimpleObjFaker(null);
            generator.Generate();
            generator.Generate();

            generator.Sync();

            Assert.Equal(2, Counter - initialCount);
        }

        [Fact(DisplayName = "BaseFactory :: sync db after accepting changes count.")]
        public void BaseFactory_AcceptChanges_Sync_CorrectCall_NothingToSync_Count()
        {
            int initialCount = Counter;

            var generator = new SimpleObjFaker(null);
            generator.Generate();
            generator.Generate();
            generator.AcceptChanges();

            generator.Sync();

            Assert.Equal(0, Counter - initialCount);
        }

        [Fact(DisplayName = "BaseFactory :: sync db after accepting changes count.")]
        public void BaseFactory_AcceptChanges_Sync_CorrectCall_Count()
        {
            int initialCount = Counter;

            var generator = new SimpleObjFaker(null);
            generator.Generate();
            generator.AcceptChanges();
            generator.Generate();
            generator.Generate();

            generator.Sync();

            Assert.Equal(2, Counter - initialCount);
            Assert.Equal(3, generator.Count);
        }      
    }
}
