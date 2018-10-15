using lessonTdd.Coonverter;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace LessonTddTest
{
    [TestFixture]
    class PresenterTest
    {
        private Mock<IConverterInteractor> _interactor;
        private IPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _interactor = new Mock<IConverterInteractor>(MockBehavior.Strict);
            _presenter = new Presenter(_interactor.Object);
        }

        [TestCase("5", ECurrencyType.EUR, "Eur", "Usd", ECurrencyType.USD, "10 USD", 10)]
        [TestCase("10", ECurrencyType.USD, "Usd", "Eur", ECurrencyType.EUR, "20 EUR", 20)]
        [TestCase("5.2", ECurrencyType.EUR, "Eur", "Usd", ECurrencyType.USD, "10.4 USD", 10.4)]
        public async Task GetAmountTest_inParameters(string amount,
            ECurrencyType curTypeFrom, string from, string to, ECurrencyType curTypeTo, string expected, decimal expDexAmount)
        {
            //Given
            var dAmount = Convert.ToDecimal(amount);
            var inputAmount = new CurrencyAmount(dAmount, curTypeFrom);
            var expAmount = new CurrencyAmount(expDexAmount, curTypeTo);

            _interactor.Setup(f => f.Convert(inputAmount, curTypeTo))
                .Returns(Task.FromResult(expAmount));

            //When
            var actual = await _presenter.GetAmount(amount, from, to);

            //Then
            Assert.AreEqual(expected, actual);
            _interactor.Verify(f => f.Convert(inputAmount, curTypeTo), Times.Once);
        }

        [TestCase("_Eur", "10", "Isd")]
        [TestCase("5v", "Eudr", "Usd")]
        public void GetAmountTest_ArgumentException(string amount, string from, string to)
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await _presenter.GetAmount(amount, from, to));
        }

        [TestCase("10", "USD", "EUR")]
        public void GetAmountTest_ConvertException(string amount, string from, string to)
        {
            _interactor.Setup(f => f.Convert(new CurrencyAmount(10, ECurrencyType.USD), ECurrencyType.EUR))
             .Throws<ConvertException>();

            Assert.ThrowsAsync<ConvertException>(async () => await _presenter.GetAmount(amount, from, to));
        }
    }
}
