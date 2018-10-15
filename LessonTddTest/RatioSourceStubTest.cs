using System;
using System.Threading.Tasks;
using lessonTdd.Coonverter;
using NUnit.Framework;

namespace LessonTddTest
{
    [TestFixture]
    public class RatioSourceStubTest
    {
        IRatioSource _ratioSource;

        [SetUp]
        public void SetUp()
        {
            _ratioSource = new RatioSourceStub();
        }

        [TestCase(ECurrencyType.EUR, ECurrencyType.EUR)]
        [TestCase(ECurrencyType.EUR, ECurrencyType.USD)]
        [TestCase(ECurrencyType.USD, ECurrencyType.EUR)]
        [TestCase(ECurrencyType.USD, ECurrencyType.USD)]
        public async Task GetRatioTest(ECurrencyType from, ECurrencyType to)
        {
            //Given
            var expected = 2M;

            //When
            var actual = await _ratioSource.GetRatio(from, to);

            //Then
            Assert.AreEqual(expected, actual);
        }
    }
}