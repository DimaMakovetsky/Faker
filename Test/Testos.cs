using System;
using Xunit;
using Faker;
using Faker.GeneratorsOfAllTypes;


namespace Fact
{
    public class Factos
    {
        [Fact]
        public void ConstructorGenerarorFact()
        {
            var faker = new Faker.FakerClass();
            var user = faker.Create<User>();
            bool hasNull = false;
            foreach (Dog dog in user.dogs)
            {
                if (dog == null)
                {
                    hasNull = true;
                    break;
                }
            }
            Assert.False(hasNull);
        }
        [Fact]
        public void ConstructedObjectNotNull()
        {
            var faker = new Faker.FakerClass();
            var user = faker.Create<User>();
            Assert.NotNull(user);
        }
        private Faker.FakerClass faker = new Faker.FakerClass();

        [Fact]
        public void ByteTest()
        {
            IGenerator byteGen = new ByteGenerator();
            object o = byteGen.GetNewValue();
            Assert.Equal(typeof(byte),o.GetType());
        }

        [Fact]
        public void BoolTest()
        {
            IGenerator boolGen = new BoolGenerator();
            object o = boolGen.GetNewValue();
            Assert.Equal(typeof(bool),o.GetType());
        }

        [Fact]
        public void CharTest()
        {
            IGenerator charGen = new CharGenerator();
            object o = charGen.GetNewValue();
            Assert.Equal(typeof(char), o.GetType());
        }

        [Fact]
        public void DateTest()
        {
            IGenerator gen = new DateGenerator();
            object o = gen.GetNewValue();
            Assert.Equal(typeof(DateTime), o.GetType());
        }

        [Fact]
        public void DoubleTest()
        {
            IGenerator gen = new DoubleGenerator();
            object o = gen.GetNewValue();
            Assert.Equal(typeof(double), o.GetType());
        }

        [Fact]
        public void FloatTest()
        {
            IGenerator gen = new FloatGenerator();
            object o = gen.GetNewValue();
            Assert.Equal(typeof(float), o.GetType());
        }

        [Fact]
        public void IntTest()
        {
            IGenerator gen = new IntGenerator();
            object o = gen.GetNewValue();
            Assert.Equal(typeof(int), o.GetType());
        }

        [Fact]
        public void LongTest()
        {
            IGenerator gen = new LongGenerator();
            object o = gen.GetNewValue();
            Assert.Equal(typeof(long), o.GetType());
        }

        [Fact]
        public void ShortTest()
        {
            IGenerator gen = new ShortGenerator();
            object o = gen.GetNewValue();
            Assert.Equal(typeof(short), o.GetType());
        }

        [Fact]
        public void StringTest()
        {
            IGenerator gen = new StringGenerator();
            object o = gen.GetNewValue();
            Assert.Equal(typeof(string), o.GetType());
        }
    }
}
