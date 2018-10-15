using System.Threading.Tasks;
using lessonTdd.Coonverter;
using Moq;
using NUnit.Framework;
using System.Reflection;
using System;

namespace LessonTddTest
{
    [TestFixture]
    public class CoverterInteractorTest
    {
        private IConverterInteractor _interactor;
        private Mock<IRatioSource> _ratioSourceMock;

        [SetUp]
        public void SetUp()
        {
            _ratioSourceMock = new Mock<IRatioSource>(MockBehavior.Strict);
            _interactor = new ConverterInteractor(_ratioSourceMock.Object);
        }

        [Test]
        public void CtorTest()
        {
            //When
            var fieldInfo = typeof(ConverterInteractor)
                .GetField("_ratioSource", BindingFlags.NonPublic | BindingFlags.Instance);
            var actual = fieldInfo.GetValue(_interactor);

            //Then
            Assert.AreEqual(_ratioSourceMock.Object, actual);
        }

        [Test]
        public void CtorNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => new ConverterInteractor(null));
        }

        [Test]
        public async Task ConvertTest()
        {
            //Given
            var expected = new CurrencyAmount(8, ECurrencyType.USD);
            var input = new CurrencyAmount(4, ECurrencyType.EUR);
            var currency = ECurrencyType.USD;

            _ratioSourceMock.Setup(f => f.GetRatio(input.Currency, currency))
                            .Returns(Task.FromResult(2M));

            //When
            var actual = await _interactor.Convert(input, currency);

            //Then
            Assert.AreEqual(expected, actual);
            _ratioSourceMock.Verify(f => f.GetRatio(input.Currency, currency), Times.Once);
        }

        [Test]
        public void ConvertTest_RatioException()
        {
            // Given
            var expected = new CurrencyAmount(4, ECurrencyType.EUR);
            var input = new CurrencyAmount(8, ECurrencyType.USD);
            var currency = ECurrencyType.USD;

            _ratioSourceMock.Setup(f => f.GetRatio(input.Currency, currency))
                            .Throws<Exception>();

            //Then
            Assert.ThrowsAsync<ConvertException>(async () => await _interactor.Convert(input, currency));
        }
    }
}
