using System;
using System.Collections.Generic;
using Bogus;
using SampleApp.Objects;
using SlimXUnitDb.Test.Core;
using SlimXUnitDb.Test.Core.Generators;
using Xunit;

namespace SampleApp.Test
{
    public class AppPersonTest : BaseTest
    {
        private FakePersonFactory _personFactory;

        public AppPersonTest(FixtureBase context) : base(context)
        {
        }

        protected override void Initialize()
        {
            _personFactory = new FakePersonFactory(this);
        }

        [Fact]
        public void TestPerson_SavePerson()
        {
            var fakePerson = _personFactory.Generate();
            var actualResult = PersonModule.SavePerson(Context.Conn, fakePerson);

            Assert.True(actualResult, "Person saved!");
        }

        #region factories

        private class FakePersonFactory : BaseFactory<AppPerson>
        {
            private readonly NameGenerator _nameGenerator = new NameGenerator("___TEST_NAME_", "__");
            private readonly IntegerGenerator _idGenerator = new IntegerGenerator(1001, 1);

            public FakePersonFactory(BaseTest context) : base(context)
            {
            }

            protected override AppPerson GenerateNew(Action<Faker<AppPerson>> action)
            {
                var faker = new Faker<AppPerson>();
                SetupDefaultFakerBahavior(faker);
                action(faker);

                return faker;
            }

            protected override AppPerson GenerateNew()
            {
                var faker = new Faker<AppPerson>();
                SetupDefaultFakerBahavior(faker);

                return faker;
            }

            protected override void SyncDb(IReadOnlyList<AppPerson> list)
            {
                foreach (AppPerson p in list)
                {
                    _testContest.Context.Conn.Transact("Insert person transaction.");
                }                
            }

            private void SetupDefaultFakerBahavior(Faker<AppPerson> faker)
            {
                faker.RuleFor(u => u.Name, f => _nameGenerator.Generate())
                    .RuleFor(u => u.Id, f => _idGenerator.Generate());
            }
        }

        #endregion

    }
}
